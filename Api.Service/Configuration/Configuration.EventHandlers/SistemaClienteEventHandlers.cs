using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface ISistemaClienteEventHandlers
    {
        Task<ResponseCreateCommand> Post(SistemaClienteCommand command);
        Task<ResponseCreateCommand> Put(string id, SistemaClienteCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> State(string id, string? usuario);
    }
    public class SistemaClienteEventHandlers : ISistemaClienteEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public SistemaClienteEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var sistemaCliente = _dbContext.SistemaCliente.FirstOrDefault(x => x.IdSistemaCliente == id);

                if (sistemaCliente != null)
                {
                    var existSistemaExamen = _dbContext.SistemaClienteExamen.Any(y => y.IdSistemaCliente == id && y.Estado == States.Activo);

                    if (existSistemaExamen) return Configurations.Response(new Messages().ErrorEliminarRelacion("", Forms.SistemaClienteExamen), TypeResponse.Alert);

                    sistemaCliente.Fecha_modificacion = DateTime.Now;
                    sistemaCliente.Modificado_por = usuario;
                    sistemaCliente.Estado = States.Eliminado;
                    sistemaCliente.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.SistemaCliente), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.SistemaCliente), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.SistemaCliente), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(SistemaClienteCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.SistemaCliente.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.SistemaCliente), TypeResponse.Alert);

                var sistemaCliente = DtoMapperExtension.MapTo<SistemaCliente>(command);

                sistemaCliente.IdSistemaCliente = Ulid.NewUlid().ToString();
                sistemaCliente.Estado = States.Activo;
                sistemaCliente.Accion = Actions.Creado;
                sistemaCliente.Creado_por = command.user;
                sistemaCliente.Fecha_creacion = DateTime.Now;

                await _dbContext.SistemaCliente.AddAsync(sistemaCliente);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.SistemaCliente), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.SistemaCliente), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, SistemaClienteCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var sistemaCliente = _dbContext.SistemaCliente.FirstOrDefault(x => x.IdSistemaCliente == id);

                if (sistemaCliente != null)
                {
                    sistemaCliente.Server = command.Server;
                    sistemaCliente.BaseDeDatos = command.BaseDeDatos;
                    sistemaCliente.Usuario = command.Usuario;
                    sistemaCliente.Contrasena = command.Contrasena;
                    sistemaCliente.IdTipoBaseDato = command.IdTipoBaseDato;
                    sistemaCliente.Nombre = command.Nombre;
                    sistemaCliente.Fecha_modificacion = DateTime.Now;
                    sistemaCliente.Modificado_por = command.user;
                    sistemaCliente.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.SistemaCliente), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.SistemaCliente), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.SistemaCliente), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> State(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var sistemaCliente = _dbContext.SistemaCliente.FirstOrDefault(x => x.IdSistemaCliente == id);

                if (sistemaCliente != null)
                {
                    var existSistemaExamen = _dbContext.SistemaClienteExamen.Any(y => y.IdSistemaCliente == id && y.Estado == States.Activo);

                    if (existSistemaExamen) return Configurations.Response(new Messages().ErrorDesactivarRelacion("", Forms.SistemaClienteExamen), TypeResponse.Alert);

                    sistemaCliente.Fecha_modificacion = DateTime.Now;
                    sistemaCliente.Modificado_por = usuario;
                    sistemaCliente.Estado = (sistemaCliente.Estado == States.Activo ? States.Desactivado : States.Activo);
                    sistemaCliente.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.SistemaCliente), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error, ex.Message);
            }
        }
    }
}
