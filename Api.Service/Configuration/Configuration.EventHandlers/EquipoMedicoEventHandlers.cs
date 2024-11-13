using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface IEquipoMedicoEventHandlers
    {
        Task<ResponseCreateCommand> Post(EquipoMedicoCommand command);
        Task<ResponseCreateCommand> Put(string id, EquipoMedicoCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> DeleteAnalizador(string id, string? usuario);
        Task<ResponseCreateCommand> State(string id, string? usuario);
    }
    public class EquipoMedicoEventHandlers : IEquipoMedicoEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public EquipoMedicoEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var equipoMedico = _dbContext.EquipoMedico.FirstOrDefault(x => x.IdEquipoMedico == id);

                if (equipoMedico != null)
                {
                    var existEquipo = _dbContext.EquipoMedicoExamen.Any(y => y.IdEquipoMedico == id && y.Estado == States.Activo);

                    if (existEquipo) return Configurations.Response(new Messages().ErrorEliminarRelacion("", Forms.EquipoMedicoExamen), TypeResponse.Alert);

                    equipoMedico.Fecha_modificacion = DateTime.Now;
                    equipoMedico.Modificado_por = usuario;
                    equipoMedico.Estado = States.Eliminado;
                    equipoMedico.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.EquipoMedico), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.EquipoMedico), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.EquipoMedico), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> DeleteAnalizador(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var analizador = _dbContext.EquipoMedicoAnalizador.FirstOrDefault(x => x.IdEquipoMedicoAnalizador == id);

                if (analizador != null)
                {
                    analizador.Fecha_modificacion = DateTime.Now;
                    analizador.Modificado_por = usuario;
                    analizador.Estado = States.Eliminado;
                    analizador.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.EquipoMedicoAnalizador), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.ExamenRango), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.ExamenRango), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(EquipoMedicoCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var equipoMedico = DtoMapperExtension.MapTo<EquipoMedico>(command);

                equipoMedico.IdEquipoMedico = Ulid.NewUlid().ToString();
                equipoMedico.Estado = States.Activo;
                equipoMedico.Accion = Actions.Creado;
                equipoMedico.Creado_por = command.user;
                equipoMedico.Fecha_creacion = DateTime.Now;

                await _dbContext.EquipoMedico.AddAsync(equipoMedico);

                command.ListaEquipoMedicoAnalizador.ForEach(y =>
                {
                    EquipoMedicoAnalizador equipoMedicoAnalizador = new EquipoMedicoAnalizador();

                    equipoMedicoAnalizador.IdEquipoMedicoAnalizador = Ulid.NewUlid().ToString();
                    equipoMedicoAnalizador.IdEquipoMedico = equipoMedico.IdEquipoMedico;
                    equipoMedicoAnalizador.SerialPuerto = y.SerialPuerto;
                    equipoMedicoAnalizador.SerialBaudrate = y.SerialBaudrate;
                    equipoMedicoAnalizador.SerialDataBit = y.SerialDataBit;
                    equipoMedicoAnalizador.Estado = States.Activo;
                    equipoMedicoAnalizador.Accion = Actions.Creado;
                    equipoMedicoAnalizador.Creado_por = command.user;
                    equipoMedicoAnalizador.Fecha_creacion = DateTime.Now;

                    _dbContext.EquipoMedicoAnalizador.AddAsync(equipoMedicoAnalizador);
                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.EquipoMedico), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.EquipoMedico), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, EquipoMedicoCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var equipoMedico = _dbContext.EquipoMedico.FirstOrDefault(x => x.IdEquipoMedico == id);

                if (equipoMedico != null)
                {
                    equipoMedico.IdLaboratorio = command.IdLaboratorio;
                    equipoMedico.IdArea = command.IdArea;
                    equipoMedico.Nombre = command.Nombre;
                    equipoMedico.Detalle = command.Detalle;
                    equipoMedico.Fecha_modificacion = DateTime.Now;
                    equipoMedico.Modificado_por = command.user;
                    equipoMedico.Accion = Actions.Modificado;

                    var analizador = _dbContext.EquipoMedicoAnalizador.AsNoTracking().Where(y => y.IdEquipoMedico == equipoMedico.IdEquipoMedico && y.Estado != States.Eliminado);

                    foreach (var item in analizador)
                    {
                        _dbContext.EquipoMedicoAnalizador.Remove(item);
                    }

                    command.ListaEquipoMedicoAnalizador.ForEach(y =>
                    {
                        EquipoMedicoAnalizador equipoMedicoAnalizador = new EquipoMedicoAnalizador();

                        equipoMedicoAnalizador.IdEquipoMedicoAnalizador = Ulid.NewUlid().ToString();
                        equipoMedicoAnalizador.IdEquipoMedico = equipoMedico.IdEquipoMedico;
                        equipoMedicoAnalizador.SerialPuerto = y.SerialPuerto;
                        equipoMedicoAnalizador.SerialBaudrate = y.SerialBaudrate;
                        equipoMedicoAnalizador.SerialDataBit = y.SerialDataBit;
                        equipoMedicoAnalizador.Estado = States.Activo;
                        equipoMedicoAnalizador.Accion = Actions.Creado;
                        equipoMedicoAnalizador.Creado_por = command.user;
                        equipoMedicoAnalizador.Fecha_creacion = DateTime.Now;

                        _dbContext.EquipoMedicoAnalizador.AddAsync(equipoMedicoAnalizador);
                    });

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.EquipoMedico), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.EquipoMedico), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.EquipoMedico), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> State(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var equipoMedico = _dbContext.EquipoMedico.FirstOrDefault(x => x.IdEquipoMedico == id);

                if (equipoMedico != null)
                {
                    var existEquipo = _dbContext.EquipoMedicoExamen.Any(y => y.IdEquipoMedico == id && y.Estado == States.Activo);

                    if (existEquipo) return Configurations.Response(new Messages().ErrorDesactivarRelacion("", Forms.EquipoMedicoExamen), TypeResponse.Alert);

                    equipoMedico.Fecha_modificacion = DateTime.Now;
                    equipoMedico.Modificado_por = usuario;
                    equipoMedico.Estado = (equipoMedico.Estado == States.Activo ? States.Desactivado : States.Activo);
                    equipoMedico.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.EquipoMedico), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error, ex.Message);
            }
        }
    }
}
