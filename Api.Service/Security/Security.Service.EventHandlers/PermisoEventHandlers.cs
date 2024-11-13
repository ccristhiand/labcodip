using Common.Config;
using Common.Utility;
using Persistence.Database;
using Silac.Domain;

namespace Security.Service.EventHandlers
{
    public interface IPermisoEventHandlers
    {
        Task<ResponseCreateCommand> Post(PermisoCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, PermisoCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class PermisoEventHandlers : IPermisoEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public PermisoEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var permiso = _dbContext.Permiso.FirstOrDefault(x => x.IdPermiso == id);

                if (permiso != null)
                {
                    permiso.Modificado_por = usuario;
                    permiso.Fecha_modificacion = DateTime.Now;
                    permiso.Accion = Actions.Modificado;
                    permiso.Estado = (permiso.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Permiso), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Permiso), TypeResponse.Alert);
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
                var permiso = _dbContext.Permiso.FirstOrDefault(x => x.IdPermiso == id);

                if (permiso != null)
                {
                    permiso.Modificado_por = usuario;
                    permiso.Fecha_modificacion = DateTime.Now;
                    permiso.Accion = Actions.Modificado;
                    permiso.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Permiso), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Permiso), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Permiso), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(PermisoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var permiso = DtoMapperExtension.MapTo<Permiso>(command);

                permiso.IdPermiso = Ulid.NewUlid().ToString();
                permiso.Creado_por = command.user;
                permiso.Fecha_creacion = DateTime.Now;
                permiso.Estado = States.Activo;
                permiso.Accion = Actions.Creado;

                await _dbContext.Permiso.AddAsync(permiso);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Permiso), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Permiso), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, PermisoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var permiso = _dbContext.Permiso.FirstOrDefault(x => x.IdPermiso == id);

                if (permiso != null)
                {
                    permiso.Nombre = command.Nombre;
                    permiso.Modificado_por = command.user;
                    permiso.Fecha_modificacion = DateTime.Now;
                    permiso.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Permiso), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Permiso), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Permiso), TypeResponse.Error);
                return response;
            }
        }
    }
}