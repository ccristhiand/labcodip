using Common.Config;
using Common.Utility;
using Laboratory.Service.EventHandlers;
using Persistence.Database;
using Silac.Domain;

namespace QualityControl.Service.EventHandlers
{
    public interface IReactivoDetEventHandlers
    {
        Task<ResponseCreateCommand> Post(ReactivoDetCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, ReactivoDetCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class ReactivoDetEventHandlers : IReactivoDetEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public ReactivoDetEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var reactivoDet = _dbContext.ReactivoDet.FirstOrDefault(x => x.IdReactivoDet == id);

                if (reactivoDet != null)
                {
                    reactivoDet.Modificado_por = usuario;
                    reactivoDet.Fecha_modificacion = DateTime.Now;
                    reactivoDet.Accion = Actions.Modificado;
                    reactivoDet.Estado = (reactivoDet.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.ReactivoDet), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.ReactivoDet), TypeResponse.Alert);
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
                var reactivoDet = _dbContext.ReactivoDet.FirstOrDefault(x => x.IdReactivoDet == id);

                if (reactivoDet != null)
                {
                    reactivoDet.Modificado_por = usuario;
                    reactivoDet.Fecha_modificacion = DateTime.Now;
                    reactivoDet.Accion = Actions.Modificado;
                    reactivoDet.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.ReactivoDet), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.ReactivoDet), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.ReactivoDet), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(ReactivoDetCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var reactivoDet = DtoMapperExtension.MapTo<ReactivoDet>(command);

                reactivoDet.IdReactivoDet = Ulid.NewUlid().ToString();
                reactivoDet.Creado_por = command.user;
                reactivoDet.Fecha_creacion = DateTime.Now;
                reactivoDet.Estado = States.Activo;
                reactivoDet.Accion = Actions.Creado;

                await _dbContext.ReactivoDet.AddAsync(reactivoDet);

                command.ListaReactivoExamen.ForEach(y =>
                {
                    ReactivoExamen reactivoExamen = new ReactivoExamen();

                    reactivoExamen.IdReactivoExamen = Ulid.NewUlid().ToString();
                    reactivoExamen.IdReactivoDet = reactivoDet.IdReactivoDet;
                    reactivoExamen.IdExamen = y.IdExamen;
                    reactivoExamen.Creado_por = command.user;
                    reactivoExamen.Fecha_creacion = DateTime.Now;
                    reactivoExamen.Estado = States.Activo;
                    reactivoExamen.Accion = Actions.Creado;

                    _dbContext.ReactivoExamen.AddAsync(reactivoExamen);
                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.ReactivoDet), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.ReactivoDet), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, ReactivoDetCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var reactivoDet = _dbContext.ReactivoDet.FirstOrDefault(x => x.IdReactivoDet == id);

                if (reactivoDet != null)
                {
                    reactivoDet.Modificado_por = command.user;
                    reactivoDet.Fecha_modificacion = DateTime.Now;
                    reactivoDet.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.ReactivoDet), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.ReactivoDet), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.ReactivoDet), TypeResponse.Error);
                return response;
            }
        }
    }
}