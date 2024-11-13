using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;


namespace Configuration.Service.EventHandlers
{
    public interface ISistemaClienteExamenEventHandlers
    {

        Task<ResponseCreateCommand> Post(SistemaClienteExamenCommand command);
        Task<ResponseCreateCommand> Put(string id, SistemaClienteExamenCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
    }

    public class SistemaClienteExamenEventHandlers : ISistemaClienteExamenEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public SistemaClienteExamenEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var sistemaClienteExamen = _dbContext.SistemaClienteExamen.FirstOrDefault(x => x.IdSistemaClienteExamen == id);

                if (sistemaClienteExamen != null)
                {
                    sistemaClienteExamen.Fecha_modificacion = DateTime.Now;
                    sistemaClienteExamen.Modificado_por = usuario;
                    sistemaClienteExamen.Estado = States.Eliminado;
                    sistemaClienteExamen.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.SistemaClienteExamen), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.SistemaClienteExamen), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.SistemaClienteExamen), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(SistemaClienteExamenCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                foreach (var item in command.ListaIdExamen!)
                {
                    SistemaClienteExamen sistemaCliente = new SistemaClienteExamen();
                    sistemaCliente.IdSistemaClienteExamen = Ulid.NewUlid().ToString();
                    sistemaCliente.IdExamen = item;
                    sistemaCliente.IdSistemaCliente = command.IdSistemaCliente;
                    sistemaCliente.Estado = States.Activo;
                    sistemaCliente.Accion = Actions.Creado;
                    sistemaCliente.Creado_por = command.user;
                    sistemaCliente.Fecha_creacion = DateTime.Now;

                    await _dbContext.SistemaClienteExamen.AddAsync(sistemaCliente);
                }

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.SistemaClienteExamen), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.SistemaClienteExamen), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, SistemaClienteExamenCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var sistemaClienteExamen = _dbContext.SistemaClienteExamen.FirstOrDefault(x => x.IdSistemaClienteExamen == id);

                if (sistemaClienteExamen != null)
                {
                    sistemaClienteExamen.CodRecibe = (command.tipoCodigo == "R") ? command.CodRecibe : sistemaClienteExamen.CodRecibe;
                    sistemaClienteExamen.CodDevuelve = (command.tipoCodigo == "D") ? command.CodDevuelve : sistemaClienteExamen.CodDevuelve;
                    sistemaClienteExamen.Fecha_modificacion = DateTime.Now;
                    sistemaClienteExamen.Modificado_por = command.user;
                    sistemaClienteExamen.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.SistemaClienteExamen), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.SistemaClienteExamen), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.SistemaClienteExamen), TypeResponse.Error, ex.Message);
            }

        }

    }
}
