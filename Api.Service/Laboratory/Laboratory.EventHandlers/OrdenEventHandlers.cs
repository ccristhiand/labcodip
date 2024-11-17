using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Silac.Domain;

namespace Laboratory.Service.EventHandlers
{
    public interface IOrdenEventHandlers
    {
        Task<ResponseCreateCommand> Post(OrdenCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, OrdenUpdateCommand command);
        Task<ResponseCreateCommand> AddExamen(string id, OrdenAddCommand command);
        Task<ResponseCreateCommand> PostResult(string id, OrdenValidateCommand command);
        Task<ResponseCreateCommand> ValidateTecnico(OrdenValidateCommand command);
        Task<ResponseCreateCommand> ValidateMedico(OrdenValidateCommand command);
        Task<ResponseCreateCommand> QuitarValidacion(string id, string idArea, string user);
    }

    public class OrdenEventHandlers : IOrdenEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public OrdenEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Post(OrdenCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                //Orden
                var orden = DtoMapperExtension.MapTo<Orden>(command);

                orden.IdOrden = Ulid.NewUlid().ToString();
                orden.Creado_por = command.user;
                orden.HoraOrden = DateTime.Now.ToString("hh:mm:ss");
                orden.Fecha_creacion = DateTime.Now;
                orden.Estado = States.Activo;
                orden.Accion = Actions.Creado;

                await _dbContext.Orden.AddAsync(orden);
                string idsTipoMuestra = "";
                string validateidTipoMuestra = "";
                //Orden Examen
                command.ListaOrdenExamenQuery.ForEach(async x =>
                {
                    OrdenExamen ordenExamen = new OrdenExamen();

                    var examen = _dbContext.Examen.AsNoTracking().Where(y => y.IdExamen == x.IdExamen).Include(y => y.Area!).FirstOrDefault();

                    if (validateidTipoMuestra != examen.IdTipoMuestra)
                    {
                        idsTipoMuestra += $",{examen.IdTipoMuestra}";
                        validateidTipoMuestra = examen.IdTipoMuestra;
                    }

                    ordenExamen.IdOrden = orden.IdOrden;
                    ordenExamen.IdOrdenExamen = Ulid.NewUlid().ToString();
                    ordenExamen.IdExamen = x.IdExamen;
                    ordenExamen.IdLaboratorio = examen!.Area!.IdLaboratorio;
                    ordenExamen.IdArea = examen.IdArea;
                    ordenExamen.Creado_por = command.user;
                    ordenExamen.Fecha_creacion = DateTime.Now;
                    ordenExamen.Estado = States.Pendiente;
                    ordenExamen.Accion = Actions.Creado;
                    ordenExamen.Idperfil = x.Idperfil;
                    ordenExamen.NombrePerfil = x.NombrePerfil;

                    await _dbContext.OrdenExamen.AddAsync(ordenExamen);
                });

                //Persona
                Configurations configurations = new Configurations(_dbContext);

                string idPersona = configurations.AddPersona(command.IdTipoDocu, command.NroDocumento, command.ApePaterno, command.ApeMaterno, command.Nombre, command.FechaNacimiento, command.IdSexo, command.user);

                // Paciente
                var queryPaciente = _dbContext.Paciente.AsNoTracking().FirstOrDefault(y => y.IdPersona == idPersona);
                var idPaciente = "";

                if (queryPaciente == null)
                {
                    Paciente paciente = new Paciente();

                    paciente.IdPaciente = Ulid.NewUlid().ToString();
                    paciente.IdPersona = idPersona;
                    paciente.Estado = States.Activo;
                    paciente.Accion = Actions.Creado;
                    paciente.Creado_por = command.user;
                    paciente.Fecha_creacion = DateTime.Now;
                    paciente.IdLaboratorio = command.IdLaboratorio;
                    paciente.IdArea = command.IdArea;

                    await _dbContext.Paciente.AddAsync(paciente);

                    idPaciente = paciente.IdPaciente;
                }
                else
                {
                    idPaciente = queryPaciente!.IdPaciente;
                }

                // Orden Paciente
                var ordenPaciente = DtoMapperExtension.MapTo<OrdenPaciente>(command);

                ordenPaciente.IdOrdenPaciente = Ulid.NewUlid().ToString();
                ordenPaciente.IdPaciente = idPaciente;
                ordenPaciente.IdOrden = orden.IdOrden;
                ordenPaciente.Creado_por = command.user;
                ordenPaciente.Fecha_creacion = DateTime.Now;
                ordenPaciente.Estado = States.Activo;
                ordenPaciente.Accion = Actions.Creado;

                await _dbContext.OrdenPaciente.AddAsync(ordenPaciente);

                await _dbContext.SaveChangesAsync();

                var nroOrden = Configurations.generarCorrelativo(orden.Codigo.ToString()!);

                orden.NroOrden = nroOrden;

                await _dbContext.SaveChangesAsync();
                //Agregar registros al tracking
                new Configurations(_dbContext).CreateTracking(orden.IdOrden, idsTipoMuestra, command.user);


                response = Configurations.Response(new Messages().Guardar(Forms.Orden), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Orden), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, OrdenUpdateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                //Orden
                var orden = _dbContext.Orden.FirstOrDefault(x => x.IdOrden == id);

                if (orden != null)
                {
                    orden.Cama = command.Cama;
                    orden.FechaOrden = command.FechaOrden;
                    orden.NroAtencion = command.NroAtencion;
                    orden.Modificado_por = command.user;
                    orden.Fecha_modificacion = DateTime.Now;
                    orden.Accion = Actions.Modificado;

                    //----Eliminando orden examen sin resultados-----
                    var selectIdOrdenExamen = _dbContext.OrdenExamen.AsNoTracking().Where(x => x.IdOrden == orden.IdOrden && (x.Resultado == null || x.Resultado == "")).ToList();
                    var listaIdOrdenExamen = _dbContext.OrdenExamen.AsNoTracking().Where(x => x.IdOrden == orden.IdOrden && (x.Resultado != null && x.Resultado != "")).Select(y => y.IdExamen).ToList();

                    selectIdOrdenExamen.ForEach(y =>
                    {
                        var ordenExamen = _dbContext.OrdenExamen.Single(x => x.IdOrdenExamen == y.IdOrdenExamen);

                        _dbContext.OrdenExamen.Remove(ordenExamen);
                    });

                    //----Agregando los nuevo orden examen-----
                    command.ListaIdOrdenExamenQuery = command.ListaIdOrdenExamenQuery.ToList().Where(y => !listaIdOrdenExamen.Contains(y)).ToList();
                    string idsTipoMuestra = "";
                    string validateidTipoMuestra = "";
                    command.ListaIdOrdenExamenQuery.ForEach(async x =>
                    {
                        OrdenExamen ordenExamen = new OrdenExamen();

                        var examen = _dbContext.Examen.AsNoTracking().Where(y => y.IdExamen == x).Include(y => y.Area!).FirstOrDefault();
                        if (validateidTipoMuestra != examen.IdTipoMuestra)
                        {
                            idsTipoMuestra += $",{examen.IdTipoMuestra}";
                            validateidTipoMuestra = examen.IdTipoMuestra;
                        }


                        ordenExamen.IdOrden = orden.IdOrden;
                        ordenExamen.IdOrdenExamen = Ulid.NewUlid().ToString();
                        ordenExamen.IdExamen = x;
                        ordenExamen.IdLaboratorio = examen!.Area!.IdLaboratorio;
                        ordenExamen.IdArea = examen.IdArea;
                        ordenExamen.Creado_por = command.user;
                        ordenExamen.Fecha_creacion = DateTime.Now;
                        ordenExamen.Estado = States.Pendiente;
                        ordenExamen.Accion = Actions.Creado;

                        await _dbContext.OrdenExamen.AddAsync(ordenExamen);
                    });

                    // Orden Paciente
                    var ordenPaciente = _dbContext.OrdenPaciente.FirstOrDefault(x => x.IdOrden == orden.IdOrden)!;

                    ordenPaciente.HistoriaClinica = command.HistoriaClinica;
                    ordenPaciente.IdProcedencia = command.IdProcedencia;
                    ordenPaciente.IdServicio = command.IdServicio;
                    ordenPaciente.IdMedico = command.IdMedico;
                    ordenPaciente.IdOrigen = command.IdOrigen;
                    ordenPaciente.Modificado_por = command.user;
                    ordenPaciente.Fecha_modificacion = DateTime.Now;
                    ordenPaciente.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();
                    new Configurations(_dbContext).CreateTracking(orden.IdOrden, idsTipoMuestra, command.user);

                    response = Configurations.Response(new Messages().Guardar(Forms.Orden), TypeResponse.Success);

                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Orden), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Orden), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> AddExamen(string id, OrdenAddCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                //Orden Examen
                command.ListaIdOrdenExamenQuery.ForEach(async x =>
                {
                    OrdenExamen ordenExamen = new OrdenExamen();

                    ordenExamen.IdOrden = id;
                    ordenExamen.IdOrdenExamen = Ulid.NewUlid().ToString();
                    ordenExamen.IdExamen = x;
                    ordenExamen.IdLaboratorio = command.IdLaboratorio;
                    ordenExamen.IdArea = command.IdArea;
                    ordenExamen.Creado_por = command.user;
                    ordenExamen.Fecha_creacion = DateTime.Now;
                    ordenExamen.Estado = States.Pendiente;
                    ordenExamen.Accion = Actions.Creado;

                    await _dbContext.OrdenExamen.AddAsync(ordenExamen);
                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Examen(Forms.Orden), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorExamen(Forms.Orden), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> PostResult(string id, OrdenValidateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                //Orden Examen
                command.ListaOrdenExamenQuery.ForEach(y =>
                {
                    var ordenExamen = _dbContext.OrdenExamen.FirstOrDefault(x => x.IdOrdenExamen == y.IdOrdenExamen)!;
                    //tracking
                    if (ordenExamen.Resultado != y.Resultado)
                    {
                        string idOrdenExa = new Configurations(_dbContext).Updatetracking(movimientoTracking.TrcEnvioDeResultado, y.IdOrdenExamen, command.user);
                    }

                    ordenExamen.Modificado_por = (ordenExamen.Resultado != y.Resultado) ? command.user : ordenExamen.Modificado_por;
                    ordenExamen.Fecha_modificacion = (ordenExamen.Resultado != y.Resultado) ? DateTime.Now : ordenExamen.Fecha_modificacion;
                    ordenExamen.Accion = (ordenExamen.Resultado != y.Resultado) ? Actions.Modificado : ordenExamen.Accion;

                    ordenExamen.FechaResultado = (ordenExamen.Estado == States.Validado) ? ordenExamen.FechaResultado : ((ordenExamen.Resultado != y.Resultado) ? ((y.Resultado == null) ? null : DateTime.Now) : ordenExamen.FechaResultado);
                    ordenExamen.Resultado = (ordenExamen.Estado == States.Validado) ? ordenExamen.Resultado : y.Resultado;
                    ordenExamen.Observacion = (ordenExamen.Estado == States.Validado) ? ordenExamen.Observacion : command.Observacion;
                    ordenExamen.Estado = (ordenExamen.Estado == States.Validado) ? ordenExamen.Estado : ((y.Resultado == null) ? States.Pendiente : States.PorValidar);


                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().PreValidar(Forms.Orden), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                response = Configurations.Response(new Messages().ErrorPreValidar(Forms.Orden), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> ValidateTecnico(OrdenValidateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                //Orden Examen
                command.ListaOrdenExamenQuery.ForEach(y =>
                {
                    var ordenExamen = _dbContext.OrdenExamen.FirstOrDefault(x => x.IdOrdenExamen == y.IdOrdenExamen)!;
                    //tracking
                    if (ordenExamen.Resultado != null && ordenExamen.Resultado != "")
                    {
                        string idOrdenExa = new Configurations(_dbContext).Updatetracking(movimientoTracking.TrcPrevalidacionMedica, y.IdOrdenExamen, command.user);
                    }

                    ordenExamen.Modificado_por = (ordenExamen.Resultado != y.Resultado) ? command.user : ordenExamen.Modificado_por;
                    ordenExamen.Fecha_modificacion = (ordenExamen.Resultado != y.Resultado) ? DateTime.Now : ordenExamen.Fecha_modificacion;
                    ordenExamen.Accion = (ordenExamen.Resultado != y.Resultado) ? Actions.Modificado : ordenExamen.Accion;

                    ordenExamen.Resultado = (ordenExamen.Estado == States.Validado) ? ordenExamen.Resultado : y.Resultado;
                    ordenExamen.Observacion = (ordenExamen.Estado == States.Validado) ? ordenExamen.Observacion : command.Observacion;
                    ordenExamen.FechaResultado = (ordenExamen.Estado == States.Validado) ? ordenExamen.FechaResultado : ((y.Resultado == null) ? null : ((ordenExamen.FechaResultado == null) ? DateTime.Now : ordenExamen.FechaResultado));

                    ordenExamen.UsuarioValTec = (ordenExamen.Estado == States.Validado) ? ordenExamen.UsuarioValTec : ((y.Resultado == null) ? null : command.user);
                    ordenExamen.FechaUsuarioValTec = (ordenExamen.Estado == States.Validado) ? ordenExamen.FechaUsuarioValTec : ((y.Resultado == null) ? null : ((ordenExamen.FechaUsuarioValTec == null) ? DateTime.Now : ordenExamen.FechaUsuarioValTec));
                    ordenExamen.EstadoUsuarioTec = (ordenExamen.Estado == States.Validado) ? ordenExamen.EstadoUsuarioTec : ((y.Resultado == null) ? null : States.Prevalidado);

                    ordenExamen.Estado = (ordenExamen.Estado == States.Validado) ? ordenExamen.Estado : ((y.Resultado == null) ? States.Pendiente : States.PorValidar);
                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().PreValidar(Forms.Orden), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                response = Configurations.Response(new Messages().ErrorPreValidar(Forms.Orden), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> ValidateMedico(OrdenValidateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                //Orden Examen
                command.ListaOrdenExamenQuery.ForEach(y =>
                {
                    var ordenExamen = _dbContext.OrdenExamen.FirstOrDefault(x => x.IdOrdenExamen == y.IdOrdenExamen)!;
                    //tracking
                    if (ordenExamen.Resultado != null && ordenExamen.Resultado != "")
                    {
                        string idOrdenExa = new Configurations(_dbContext).Updatetracking(movimientoTracking.TrcValidacionMedica, y.IdOrdenExamen, command.user);
                    }

                    ordenExamen.Modificado_por = (ordenExamen.Resultado != y.Resultado) ? command.user : ordenExamen.Modificado_por;
                    ordenExamen.Fecha_modificacion = (ordenExamen.Resultado != y.Resultado) ? DateTime.Now : ordenExamen.Fecha_modificacion;
                    ordenExamen.Accion = (ordenExamen.Resultado != y.Resultado) ? Actions.Modificado : ordenExamen.Accion;

                    ordenExamen.Resultado = (ordenExamen.Estado == States.Validado) ? ordenExamen.Resultado : y.Resultado;
                    ordenExamen.Observacion = (ordenExamen.Estado == States.Validado) ? ordenExamen.Observacion : command.Observacion;
                    ordenExamen.FechaResultado = (ordenExamen.Estado == States.Validado) ? ordenExamen.FechaResultado : ((y.Resultado == null) ? null : ((ordenExamen.FechaResultado == null) ? DateTime.Now : ordenExamen.FechaResultado));

                    ordenExamen.UsuarioValMed = (ordenExamen.Estado == States.Validado) ? ordenExamen.UsuarioValMed : ((y.Resultado == null) ? null : command.user);
                    ordenExamen.FechaUsuarioValMed = (ordenExamen.Estado == States.Validado) ? ordenExamen.FechaUsuarioValMed : ((y.Resultado == null) ? null : ((ordenExamen.FechaUsuarioValMed == null) ? DateTime.Now : ordenExamen.FechaUsuarioValMed));
                    ordenExamen.EstadoUsuarioMed = (ordenExamen.Estado == States.Validado) ? ordenExamen.EstadoUsuarioMed : ((y.Resultado == null) ? null : States.Validado);

                    ordenExamen.Estado = (ordenExamen.Estado == States.Validado) ? ordenExamen.Estado : ((y.Resultado == null) ? States.Pendiente : States.Validado);


                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Validar(Forms.Orden), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                response = Configurations.Response(new Messages().ErrorValidar(Forms.Orden), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> QuitarValidacion(string id, string idArea, string user)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                //Orden
                var ordenExamen = _dbContext.OrdenExamen.Where(x => x.IdOrden == id && x.IdArea == idArea).ToList();

                ordenExamen.ForEach(y =>
                {
                    y.Estado = States.PorValidar;
                    y.Modificado_por = user;
                    y.Fecha_modificacion = DateTime.Now;
                    y.UsuarioValMed = null;
                    y.FechaUsuarioValMed = null;
                    y.Accion = Actions.Modificado;

                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().QuitarValidacion(Forms.Orden), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                response = Configurations.Response(new Messages().ErrorQuitarValidacion(Forms.Orden), TypeResponse.Error);
                return response;
            }
        }
    }
}