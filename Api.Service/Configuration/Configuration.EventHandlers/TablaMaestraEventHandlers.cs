using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface ITablaMaestraEventHandlers
    {
        Task<ResponseCreateCommand> Post(TablaMaestraCommand command);
        Task<ResponseCreateCommand> Put(int id, TablaMaestraCommand command);
        Task<ResponseCreateCommand> Delete(int id, string? usuario);
        //Task<ResponseCreateCommand> State(int id, string? usuario);
    }
    public class TablaMaestraEventHandlers : ITablaMaestraEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public TablaMaestraEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(int id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var tablaMaestra = _dbContext.TablaMaestra.Single(x => x.IdTablaMaestra == id);
                if (tablaMaestra != null)
                {
                    tablaMaestra.Fecha_modificacion = DateTime.Now;
                    tablaMaestra.Modificado_por = usuario;

                    tablaMaestra.Accion = Actions.Eliminado;
                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.TablaMaestra), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.TablaMaestra), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.TablaMaestra), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(TablaMaestraCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var tablaMaestra = DtoMapperExtension.MapTo<TablaMaestra>(command);

                tablaMaestra.Accion = Actions.Creado;
                tablaMaestra.Creado_por = command.user;
                tablaMaestra.Fecha_creacion = DateTime.Now;

                await _dbContext.TablaMaestra.AddAsync(tablaMaestra);
                await _dbContext.SaveChangesAsync();
                response = Configurations.Response(new Messages().Guardar(Forms.TablaMaestra), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.TablaMaestra), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(int id, TablaMaestraCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var tablaMaestra = _dbContext.TablaMaestra.Single(x => x.IdTablaMaestra == id);

                if (tablaMaestra != null)
                {
                    tablaMaestra.Tabla = command.Tabla;
                    tablaMaestra.Codigo = command.Codigo;
                    tablaMaestra.Nombre = command.Nombre;

                    tablaMaestra.Fecha_modificacion = DateTime.Now;
                    tablaMaestra.Modificado_por = command.user;
                    tablaMaestra.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.TablaMaestra), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.TablaMaestra), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.TablaMaestra), TypeResponse.Error, ex.Message);
            }
        }
    }
}
