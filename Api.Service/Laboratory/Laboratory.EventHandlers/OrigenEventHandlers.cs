using Common.Config;
using Common.Utility;
using Persistence.Database;
using Silac.Domain;

namespace Laboratory.Service.EventHandlers
{
    public interface IOrigenEventHandlers
    {
        Task<ResponseCreateCommand> Post(OrigenCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, OrigenCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class OrigenEventHandlers : IOrigenEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public OrigenEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var origen = _dbContext.Origen.FirstOrDefault(x => x.IdOrigen == id);

                if (origen != null)
                {
                    origen.Modificado_por = usuario;
                    origen.Fecha_modificacion = DateTime.Now;
                    origen.Accion = Actions.Modificado;
                    origen.Estado = (origen.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Origen), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Origen), TypeResponse.Alert);
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
                var origen = _dbContext.Origen.FirstOrDefault(x => x.IdOrigen == id);

                if (origen != null)
                {
                    origen.Modificado_por = usuario;
                    origen.Fecha_modificacion = DateTime.Now;
                    origen.Accion = Actions.Modificado;
                    origen.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Origen), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Origen), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Origen), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(OrigenCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var origen = DtoMapperExtension.MapTo<Origen>(command);

                origen.IdOrigen = Ulid.NewUlid().ToString();
                origen.Creado_por = command.user;
                origen.Fecha_creacion = DateTime.Now;
                origen.Estado = States.Activo;
                origen.Accion = Actions.Creado;

                await _dbContext.Origen.AddAsync(origen);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Origen), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Origen), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, OrigenCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var origen = _dbContext.Origen.FirstOrDefault(x => x.IdOrigen == id);

                if (origen != null)
                {
                    origen.Nombre = command.Nombre;
                    origen.Modificado_por = command.user;
                    origen.Fecha_modificacion = DateTime.Now;
                    origen.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Origen), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Origen), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Origen), TypeResponse.Error);
                return response;
            }
        }
    }
}