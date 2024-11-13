using Common.Config;
using Common.Utility;
using Persistence.Database;
using Silac.Domain;

namespace Laboratory.Service.EventHandlers
{
    public interface IServicioEventHandlers
    {
        Task<ResponseCreateCommand> Post(ServicioCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, ServicioCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class ServicioEventHandlers : IServicioEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public ServicioEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var servicio = _dbContext.Servicio.FirstOrDefault(x => x.IdServicio == id);

                if (servicio != null)
                {
                    servicio.Modificado_por = usuario;
                    servicio.Fecha_modificacion = DateTime.Now;
                    servicio.Accion = Actions.Modificado;
                    servicio.Estado = (servicio.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Servicio), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Servicio), TypeResponse.Alert);
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
                var servicio = _dbContext.Servicio.FirstOrDefault(x => x.IdServicio == id);

                if (servicio != null)
                {
                    servicio.Modificado_por = usuario;
                    servicio.Fecha_modificacion = DateTime.Now;
                    servicio.Accion = Actions.Modificado;
                    servicio.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Servicio), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Servicio), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Servicio), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(ServicioCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var servicio = DtoMapperExtension.MapTo<Servicio>(command);

                servicio.IdServicio = Ulid.NewUlid().ToString();
                servicio.Creado_por = command.user;
                servicio.Fecha_creacion = DateTime.Now;
                servicio.Estado = States.Activo;
                servicio.Accion = Actions.Creado;

                await _dbContext.Servicio.AddAsync(servicio);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Servicio), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Servicio), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, ServicioCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var servicio = _dbContext.Servicio.FirstOrDefault(x => x.IdServicio == id);

                if (servicio != null)
                {
                    servicio.Nombre = command.Nombre;
                    servicio.Modificado_por = command.user;
                    servicio.Fecha_modificacion = DateTime.Now;
                    servicio.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Servicio), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Servicio), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Servicio), TypeResponse.Error);
                return response;
            }
        }
    }
}