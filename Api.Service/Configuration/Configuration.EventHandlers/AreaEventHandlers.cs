using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{

    public interface IAreaEventHandlers
    {
        Task<ResponseCreateCommand> Post(AreaCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, AreaCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> State(string id, string? usuario);
    }

    public class AreaEventHandlers : IAreaEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;
        public AreaEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var area = _dbContext.Area.FirstOrDefault(x => x.IdArea == id);

                if (area != null)
                {
                    var existExamen = _dbContext.Examen.Any(y => y.IdArea == id && y.Estado == States.Activo);

                    if (existExamen) return Configurations.Response(new Messages().ErrorEliminarRelacion("", Forms.Examen), TypeResponse.Alert);

                    area.Fecha_modificacion = DateTime.Now;
                    area.Modificado_por = usuario;
                    area.Estado = States.Eliminado;
                    area.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Area), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Area), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.Area), TypeResponse.Error, ex.Message);
            }
        }
        public async Task<ResponseCreateCommand> Post(AreaCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.Area.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.Area), TypeResponse.Alert);

                var area = DtoMapperExtension.MapTo<Area>(command);

                area.IdArea = Ulid.NewUlid().ToString();
                area.Estado = States.Activo;
                area.Accion = Actions.Creado;
                area.Creado_por = command.user;
                area.Fecha_creacion = DateTime.Now;

                await _dbContext.Area.AddAsync(area);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Area), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Area), TypeResponse.Error);
            }
        }
        public async Task<ResponseCreateCommand> Put(string id, AreaCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var area = _dbContext.Area.FirstOrDefault(x => x.IdArea == id);

                if (area != null)
                {
                    area.Nombre = command.Nombre;
                    area.Descripcion = command.Descripcion;
                    area.IdLaboratorio = command.IdLaboratorio;
                    area.Fecha_modificacion = DateTime.Now;
                    area.Modificado_por = command.user;
                    area.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.Area), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Area), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.Area), TypeResponse.Error, ex.Message);
            }
        }
        public async Task<ResponseCreateCommand> State(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var area = _dbContext.Area.FirstOrDefault(x => x.IdArea == id);

                if (area != null)
                {
                    var existExamen = _dbContext.Examen.Any(y => y.IdArea == id && y.Estado == States.Activo);

                    if (existExamen) return Configurations.Response(new Messages().ErrorDesactivarRelacion("", Forms.Examen), TypeResponse.Alert);

                    area.Fecha_modificacion = DateTime.Now;
                    area.Modificado_por = usuario;
                    area.Estado = (area.Estado == States.Activo ? States.Desactivado : States.Activo);
                    area.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Area), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error, ex.Message);
            }
        }
    }
}
