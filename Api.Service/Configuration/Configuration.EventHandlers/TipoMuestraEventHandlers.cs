using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface ITipoMuestraEventHandlers
    {
        Task<ResponseCreateCommand> Post(TipoMuestraCommand command);
        Task<ResponseCreateCommand> Put(string id, TipoMuestraCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> State(string id, string? usuario);
    }

    public class TipoMuestraEventHandlers : ITipoMuestraEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public TipoMuestraEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var tipoMuestra = _dbContext.TipoMuestra.Single(x => x.IdTipoMuestra == id);

                if (tipoMuestra != null)
                {
                    var existExamen = _dbContext.Examen.Any(y => y.IdArea == id && y.Estado == States.Activo);

                    if (existExamen) return Configurations.Response(new Messages().ErrorEliminarRelacion("", Forms.TipoMuestra), TypeResponse.Alert);


                    tipoMuestra.Fecha_modificacion = DateTime.Now;
                    tipoMuestra.Modificado_por = usuario;
                    tipoMuestra.Estado = States.Eliminado;
                    tipoMuestra.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.TipoMuestra), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.TipoMuestra), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.TipoMuestra), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(TipoMuestraCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.TipoMuestra.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.TipoMuestra), TypeResponse.Alert);

                var tipoMuestra = DtoMapperExtension.MapTo<TipoMuestra>(command);

                tipoMuestra.IdTipoMuestra = Ulid.NewUlid().ToString();
                tipoMuestra.Estado = States.Activo;
                tipoMuestra.Accion = Actions.Creado;
                tipoMuestra.Creado_por = command.user;
                tipoMuestra.Fecha_creacion = DateTime.Now;

                await _dbContext.TipoMuestra.AddAsync(tipoMuestra);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.TipoMuestra), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.TipoMuestra), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, TipoMuestraCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var tipoMuestra = _dbContext.TipoMuestra.FirstOrDefault(x => x.IdTipoMuestra == id);

                if (tipoMuestra != null)
                {
                    tipoMuestra.Nombre = command.Nombre;
                    tipoMuestra.Descripcion = command.Descripcion;
                    tipoMuestra.CodigoTipoMuestra = command.CodigoTipoMuestra;

                    tipoMuestra.Fecha_modificacion = DateTime.Now;
                    tipoMuestra.Modificado_por = command.user;
                    tipoMuestra.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.TipoMuestra), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.TipoMuestra), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.TipoMuestra), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> State(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var tipoMuestra = _dbContext.TipoMuestra.FirstOrDefault(x => x.IdTipoMuestra == id);

                if (tipoMuestra != null)
                {
                    var existExamen = _dbContext.Examen.Any(y => y.IdArea == id && y.Estado == States.Activo);

                    if (existExamen) return Configurations.Response(new Messages().ErrorDesactivarRelacion("", Forms.TipoMuestra), TypeResponse.Alert);

                    tipoMuestra.Fecha_modificacion = DateTime.Now;
                    tipoMuestra.Modificado_por = usuario;
                    tipoMuestra.Estado = (tipoMuestra.Estado == States.Activo ? States.Desactivado : States.Activo);
                    tipoMuestra.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.TipoMuestra), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error, ex.Message);
            }
        }
    }
}
