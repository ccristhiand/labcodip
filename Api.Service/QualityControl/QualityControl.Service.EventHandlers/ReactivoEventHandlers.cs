using Common.Config;
using Common.Utility;
using Laboratory.Service.EventHandlers;
using Persistence.Database;
using Silac.Domain;

namespace QualityControl.Service.EventHandlers
{
    public interface IReactivoEventHandlers
    {
        Task<ResponseCreateCommand> Post(ReactivoCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, ReactivoCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class ReactivoEventHandlers : IReactivoEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public ReactivoEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var reactivo = _dbContext.Reactivo.FirstOrDefault(x => x.IdReactivo == id);

                if (reactivo != null)
                {
                    var existReactivoDet = _dbContext.ReactivoDet.Any(y => y.IdReactivo == id && y.Estado == States.Activo);

                    if (existReactivoDet) return Configurations.Response(new Messages().ErrorDesactivarRelacion("", Forms.ReactivoDet), TypeResponse.Alert);

                    reactivo.Modificado_por = usuario;
                    reactivo.Fecha_modificacion = DateTime.Now;
                    reactivo.Accion = Actions.Modificado;
                    reactivo.Estado = (reactivo.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Reactivo), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Reactivo), TypeResponse.Alert);
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
                var reactivo = _dbContext.Reactivo.FirstOrDefault(x => x.IdReactivo == id);

                if (reactivo != null)
                {
                    var existReactivoDet = _dbContext.ReactivoDet.Any(y => y.IdReactivo == id && y.Estado == States.Activo);

                    if (existReactivoDet) return Configurations.Response(new Messages().ErrorEliminarRelacion("", Forms.ReactivoDet), TypeResponse.Alert);

                    reactivo.Modificado_por = usuario;
                    reactivo.Fecha_modificacion = DateTime.Now;
                    reactivo.Accion = Actions.Modificado;
                    reactivo.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Reactivo), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Reactivo), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Reactivo), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(ReactivoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.Reactivo.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado && y.IdEquipoMedico == command.IdEquipoMedico);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.Reactivo), TypeResponse.Alert);

                var reactivo = DtoMapperExtension.MapTo<Reactivo>(command);

                reactivo.IdReactivo = Ulid.NewUlid().ToString();
                reactivo.Creado_por = command.user;
                reactivo.Fecha_creacion = DateTime.Now;
                reactivo.Estado = States.Activo;
                reactivo.Accion = Actions.Creado;

                await _dbContext.Reactivo.AddAsync(reactivo);

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Reactivo), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Reactivo), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, ReactivoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var reactivo = _dbContext.Reactivo.FirstOrDefault(x => x.IdReactivo == id);

                if (reactivo != null)
                {
                    reactivo.Nombre = command.Nombre;
                    reactivo.IdEquipoMedico = command.IdEquipoMedico;
                    reactivo.IdModo = command.IdModo;
                    reactivo.Modificado_por = command.user;
                    reactivo.Fecha_modificacion = DateTime.Now;
                    reactivo.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Reactivo), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Reactivo), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Reactivo), TypeResponse.Error);
                return response;
            }
        }
    }
}