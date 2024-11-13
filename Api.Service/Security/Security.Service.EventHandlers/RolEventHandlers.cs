using Common.Config;
using Common.Utility;
using Persistence.Database;
using Silac.Domain;

namespace Security.Service.EventHandlers
{
    public interface IRolEventHandlers
    {
        Task<ResponseCreateCommand> Post(RolCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, RolCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class RolEventHandlers : IRolEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public RolEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var rol = _dbContext.Rol.FirstOrDefault(x => x.IdRol == id);

                if (rol != null)
                {
                    rol.Modificado_por = usuario;
                    rol.Fecha_modificacion = DateTime.Now;
                    rol.Accion = Actions.Modificado;
                    rol.Estado = (rol.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Rol), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Rol), TypeResponse.Alert);
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
                var rol = _dbContext.Rol.FirstOrDefault(x => x.IdRol == id);

                if (rol != null)
                {
                    rol.Modificado_por = usuario;
                    rol.Fecha_modificacion = DateTime.Now;
                    rol.Accion = Actions.Modificado;
                    rol.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Rol), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Rol), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Rol), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(RolCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var rol = DtoMapperExtension.MapTo<Rol>(command);

                rol.IdRol = Ulid.NewUlid().ToString();
                rol.Creado_por = command.user;
                rol.Fecha_creacion = DateTime.Now;
                rol.Estado = States.Activo;
                rol.Accion = Actions.Creado;

                await _dbContext.Rol.AddAsync(rol);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Rol), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Rol), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, RolCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var rol = _dbContext.Rol.FirstOrDefault(x => x.IdRol == id);

                if (rol != null)
                {
                    rol.Nombre = command.Nombre;
                    rol.Modificado_por = command.user;
                    rol.Fecha_modificacion = DateTime.Now;
                    rol.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Rol), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Rol), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Rol), TypeResponse.Error);
                return response;
            }
        }
    }
}