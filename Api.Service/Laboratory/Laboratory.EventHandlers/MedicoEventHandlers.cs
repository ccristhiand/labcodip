using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Silac.Domain;

namespace Laboratory.Service.EventHandlers
{
    public interface IMedicoEventHandlers
    {
        Task<ResponseCreateCommand> Post(MedicoCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, MedicoCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class MedicoEventHandlers : IMedicoEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public MedicoEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var medico = _dbContext.Medico.FirstOrDefault(x => x.IdMedico == id);

                if (medico != null)
                {
                    medico.Modificado_por = usuario;
                    medico.Fecha_modificacion = DateTime.Now;
                    medico.Accion = Actions.Modificado;
                    medico.Estado = (medico.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Medico), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Medico), TypeResponse.Alert);
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
                var medico = _dbContext.Medico.FirstOrDefault(x => x.IdMedico == id);

                if (medico != null)
                {
                    medico.Modificado_por = usuario;
                    medico.Fecha_modificacion = DateTime.Now;
                    medico.Accion = Actions.Modificado;
                    medico.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Medico), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Medico), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Medico), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(MedicoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var id = _dbContext.Persona.SingleOrDefault(x => x.NroDocumento == command.NroDocumento)?.IdPersona;
                var medicoQuery = _dbContext.Medico.AsNoTracking().Where(x => x.IdPersona == id).Any();

                if (!medicoQuery)
                {
                    var medico = DtoMapperExtension.MapTo<Medico>(command);

                    medico.IdMedico = Ulid.NewUlid().ToString();
                    medico.Creado_por = command.user;
                    medico.Fecha_creacion = DateTime.Now;
                    medico.Estado = States.Activo;
                    medico.Accion = Actions.Creado;

                    //Persona
                    Configurations configurations = new Configurations(_dbContext);

                    string idPersona = configurations.AddPersona(command.IdTipoDocu, command.NroDocumento, command.ApePaterno, command.ApeMaterno, command.Nombre, command.FechaNacimiento, command.IdSexo, command.user);

                    medico.IdPersona = idPersona;

                    await _dbContext.Medico.AddAsync(medico);

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Medico), TypeResponse.Success);

                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().YaExiste(Forms.Medico), TypeResponse.Alert);

                    return response;
                }
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Medico), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, MedicoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var medico = _dbContext.Medico.FirstOrDefault(x => x.IdMedico == id);

                if (medico != null)
                {
                    medico.Modificado_por = command.user;
                    medico.Fecha_modificacion = DateTime.Now;
                    medico.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Medico), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Medico), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Medico), TypeResponse.Error);
                return response;
            }
        }
    }
}