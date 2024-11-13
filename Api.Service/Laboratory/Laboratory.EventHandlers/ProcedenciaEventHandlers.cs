using Common.Config;
using Common.Utility;
using Persistence.Database;
using Silac.Domain;

namespace Laboratory.Service.EventHandlers
{
    public interface IProcedenciaEventHandlers
    {
        Task<ResponseCreateCommand> Post(ProcedenciaCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, ProcedenciaCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class ProcedenciaEventHandlers : IProcedenciaEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public ProcedenciaEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var procedencia = _dbContext.Procedencia.FirstOrDefault(x => x.IdProcedencia == id);

                if (procedencia != null)
                {
                    procedencia.Modificado_por = usuario;
                    procedencia.Fecha_modificacion = DateTime.Now;
                    procedencia.Accion = Actions.Modificado;
                    procedencia.Estado = (procedencia.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Procedencia), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Procedencia), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Delete(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var procedencia = _dbContext.Procedencia.FirstOrDefault(x => x.IdProcedencia == id);

                if (procedencia != null)
                {
                    procedencia.Modificado_por = usuario;
                    procedencia.Fecha_modificacion = DateTime.Now;
                    procedencia.Accion = Actions.Modificado;
                    procedencia.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Procedencia), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Procedencia), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Procedencia), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(ProcedenciaCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var procedencia = DtoMapperExtension.MapTo<Procedencia>(command);

                procedencia.IdProcedencia = Ulid.NewUlid().ToString();
                procedencia.Creado_por = command.user;
                procedencia.Fecha_creacion = DateTime.Now;
                procedencia.Estado = States.Activo;
                procedencia.Accion = Actions.Creado;

                await _dbContext.Procedencia.AddAsync(procedencia);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Procedencia), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Procedencia), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, ProcedenciaCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var procedencia = _dbContext.Procedencia.FirstOrDefault(x => x.IdProcedencia == id);

                if (procedencia != null)
                {
                    procedencia.Nombre = command.Nombre;
                    procedencia.Modificado_por = command.user;
                    procedencia.Fecha_modificacion = DateTime.Now;
                    procedencia.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Procedencia), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Procedencia), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Procedencia), TypeResponse.Error);
                return response;
            }
        }
    }
}