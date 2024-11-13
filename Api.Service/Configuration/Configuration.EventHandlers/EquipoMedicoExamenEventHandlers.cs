using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface IEquipoMedicoExamenEventHandlers
    {
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> Post(EquipoMedicoExamenCommand command);
        Task<ResponseCreateCommand> Put(string id, EquipoMedicoExamenCommand command);
    }
    public class EquipoMedicoExamenEventHandlers : IEquipoMedicoExamenEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public EquipoMedicoExamenEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var equipoMedicoExamen = _dbContext.EquipoMedicoExamen.FirstOrDefault(x => x.IdEquipoMedicoExamen == id);

                if (equipoMedicoExamen != null)
                {
                    equipoMedicoExamen.Fecha_modificacion = DateTime.Now;
                    equipoMedicoExamen.Modificado_por = usuario;
                    equipoMedicoExamen.Estado = States.Eliminado;
                    equipoMedicoExamen.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.EquipoMedicoExamen), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.EquipoMedicoExamen), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.EquipoMedicoExamen), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(EquipoMedicoExamenCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                foreach (var item in command.ListaIdExamen!)
                {
                    EquipoMedicoExamen equipoMedicoExamen = new EquipoMedicoExamen();
                    equipoMedicoExamen.IdEquipoMedicoExamen = Ulid.NewUlid().ToString();
                    equipoMedicoExamen.IdExamen = item;
                    equipoMedicoExamen.IdEquipoMedico = command.IdEquipoMedico;
                    equipoMedicoExamen.Estado = States.Activo;
                    equipoMedicoExamen.Accion = Actions.Creado;
                    equipoMedicoExamen.Creado_por = command.user;
                    equipoMedicoExamen.Fecha_creacion = DateTime.Now;

                    await _dbContext.EquipoMedicoExamen.AddAsync(equipoMedicoExamen);

                }

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.EquipoMedicoExamen), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.EquipoMedico), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, EquipoMedicoExamenCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var equipoMedicoExamen = _dbContext.EquipoMedicoExamen.FirstOrDefault(x => x.IdEquipoMedicoExamen == id);

                if (equipoMedicoExamen != null)
                {
                    equipoMedicoExamen.CodRecibe = (command.tipoCodigo == "R") ? command.CodRecibe : equipoMedicoExamen.CodRecibe;
                    equipoMedicoExamen.CodDevuelve = (command.tipoCodigo == "D") ? command.CodDevuelve : equipoMedicoExamen.CodDevuelve;
                    equipoMedicoExamen.Fecha_modificacion = DateTime.Now;
                    equipoMedicoExamen.Modificado_por = command.user;
                    equipoMedicoExamen.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.EquipoMedicoExamen), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.EquipoMedicoExamen), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.EquipoMedicoExamen), TypeResponse.Error, ex.Message);
            }
        }

    }
}
