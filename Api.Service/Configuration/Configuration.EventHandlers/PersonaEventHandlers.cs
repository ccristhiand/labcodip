using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface IPersonaEventHandlers
    {
        Task<ResponseCreateCommand> Post(PersonaCommand command);
        Task<ResponseCreateCommand> Put(string id, PersonaCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> State(string id, string? usuario);
    }
    public class PersonaEventHandlers : IPersonaEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public PersonaEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var hospital = _dbContext.Persona.Single(x => x.IdPersona == id);
                if (hospital != null)
                {
                    hospital.Fecha_modificacion = DateTime.Now;
                    hospital.Modificado_por = usuario;

                    hospital.Estado = States.Eliminado;

                    hospital.Accion = Actions.Eliminado;
                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Persona), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Persona), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.Persona), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> Post(PersonaCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var persona = DtoMapperExtension.MapTo<Persona>(command);

                persona.IdPersona = Ulid.NewUlid().ToString();
                persona.Estado = States.Activo;
                persona.Accion = Actions.Creado;
                persona.Creado_por = command.user;
                persona.Fecha_creacion = DateTime.Now;

                await _dbContext.Persona.AddAsync(persona);
                await _dbContext.SaveChangesAsync();
                response = Configurations.Response(new Messages().Guardar(Forms.Persona), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Persona), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, PersonaCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var persona = _dbContext.Persona.Single(x => x.IdPersona == id);

                if (persona != null)
                {
                    persona.IdTipoDocu = command.IdTipoDocu;
                    persona.NroDocumento = command.NroDocumento;
                    persona.ApePaterno = command.ApePaterno;
                    persona.ApeMaterno = command.ApeMaterno;
                    persona.Nombre = command.Nombre;
                    persona.FechaNacimiento = command.FechaNacimiento;
                    persona.IdSexo = command.IdSexo;
                    persona.Nombre = command.Nombre;

                    persona.Fecha_modificacion = DateTime.Now;
                    persona.Modificado_por = command.user;
                    persona.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.Persona), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Persona), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.Persona), TypeResponse.Error, ex.Message);
            }
        }

        public async Task<ResponseCreateCommand> State(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var persona = _dbContext.Persona.Single(x => x.IdPersona == id);

                if (persona != null)
                {
                    persona.Fecha_modificacion = DateTime.Now;
                    persona.Modificado_por = usuario;

                    persona.Estado = (persona.Estado == States.Activo ? States.Desactivado : States.Activo);

                    persona.Accion = Actions.Modificado;
                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);
                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Persona), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error, ex.Message);
            }
        }
    }
}
