using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface ILaboratorioEventHandlers
    {
        Task<ResponseCreateCommand> Post(LaboratorioCommand command);
        Task<ResponseCreateCommand> Put(string id, LaboratorioCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> State(string id, string? usuario);
    }
    public class LaboratorioEventHandlers : ILaboratorioEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public LaboratorioEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var laboratorio = _dbContext.Laboratorio.FirstOrDefault(x => x.IdLaboratorio == id);

                if (laboratorio != null)
                {
                    var existArea = _dbContext.Area.Any(y => y.IdLaboratorio == id);

                    if (existArea) return Configurations.Response(new Messages().ErrorEliminarRelacion("", Forms.Area), TypeResponse.Alert);

                    laboratorio.Fecha_modificacion = DateTime.Now;
                    laboratorio.Modificado_por = usuario;
                    laboratorio.Estado = States.Eliminado;
                    laboratorio.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Laboratorio), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Laboratorio), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.Laboratorio), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(LaboratorioCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.Laboratorio.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.Laboratorio), TypeResponse.Alert);

                var laboratorio = DtoMapperExtension.MapTo<Laboratorio>(command);

                laboratorio.IdLaboratorio = Ulid.NewUlid().ToString();
                laboratorio.Estado = States.Activo;
                laboratorio.Accion = Actions.Creado;
                laboratorio.Creado_por = command.user;
                laboratorio.Fecha_creacion = DateTime.Now;

                await _dbContext.Laboratorio.AddAsync(laboratorio);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Laboratorio), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Laboratorio), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, LaboratorioCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var laboratorio = _dbContext.Laboratorio.FirstOrDefault(x => x.IdLaboratorio == id);

                if (laboratorio != null)
                {
                    laboratorio.CodigoLaboratorio = command.CodigoLaboratorio;
                    laboratorio.Nombre = command.Nombre;

                    laboratorio.Fecha_modificacion = DateTime.Now;
                    laboratorio.Modificado_por = command.user;
                    laboratorio.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.Laboratorio), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Laboratorio), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.Laboratorio), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> State(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var laboratorio = _dbContext.Laboratorio.FirstOrDefault(x => x.IdLaboratorio == id);

                if (laboratorio != null)
                {
                    var existArea = _dbContext.Area.Any(y => y.IdLaboratorio == id && y.Laboratorio!.Estado == States.Activo);

                    if (existArea) return Configurations.Response(new Messages().ErrorDesactivarRelacion("", Forms.Area), TypeResponse.Alert);

                    laboratorio.Fecha_modificacion = DateTime.Now;
                    laboratorio.Modificado_por = usuario;
                    laboratorio.Estado = (laboratorio.Estado == States.Activo ? States.Desactivado : States.Activo);
                    laboratorio.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Laboratorio), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error, ex.Message);
            }
        }
    }
}
