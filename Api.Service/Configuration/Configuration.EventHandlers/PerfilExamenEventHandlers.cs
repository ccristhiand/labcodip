using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain.Conf;

namespace Configuration.Service.EventHandlers
{
    public interface IPerfilExamenEventHandlers
    {
        Task<ResponseCreateCommand> Post(PerfilExamenCommand command);
        Task<ResponseCreateCommand> Delete(string idPerfil, string usuario);
        Task<ResponseCreateCommand> Put(PerfilExamenCommand command, string idPerfil);
        Task<ResponseCreateCommand> PostMasivo(List<PerfilExamenCommand>? command, string User);

    }
    public class PerfilExamenEventHandlers : IPerfilExamenEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public PerfilExamenEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string idPerfil, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var perfilExamen = _dbContext.PerfilExamen.SingleOrDefault(x => x.IdPerfil == idPerfil);
                if (perfilExamen != null)
                {
                    perfilExamen.Estado = States.Eliminado;
                    perfilExamen.Accion = Actions.Eliminado;
                    perfilExamen.Fecha_modificacion = DateTime.Now;
                    perfilExamen.Modificado_por = usuario;
                    await _dbContext.SaveChangesAsync();
                    response = Configurations.Response(new Messages().Eliminar(Forms.PerfilExamen), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().Eliminar(Forms.PerfilExamen), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.PerfilExamen), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Put(PerfilExamenCommand command, string idPerfilExamen)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var perfilExamen = _dbContext.PerfilExamen.SingleOrDefault(x => x.IdPerfil == idPerfilExamen);
                if (perfilExamen != null)
                {
                    perfilExamen.IdPerfil = command.IdPerfil;
                    perfilExamen.IdPerfil = command.IdExamen;

                    perfilExamen.Estado = States.Activo;
                    perfilExamen.Accion = Actions.Modificado;
                    perfilExamen.Fecha_modificacion = DateTime.Now;
                    perfilExamen.Modificado_por = command.User;
                    await _dbContext.SaveChangesAsync();
                    response = Configurations.Response(new Messages().Actualizar(Forms.Perfil), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().ErrorActualizar(Forms.Perfil), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().Eliminar(Forms.Perfil), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(PerfilExamenCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var perfil = DtoMapperExtension.MapTo<PerfilExamen>(command);
                perfil.IdPerfilExamen = Ulid.NewUlid().ToString();
                perfil.Fecha_creacion = DateTime.Now;
                perfil.Estado = States.Activo;
                perfil.Accion = Actions.Creado;
                perfil.Creado_por = command.User;

                await _dbContext.AddAsync(perfil);
                await _dbContext.SaveChangesAsync();
                response = Configurations.Response(new Messages().Guardar(Forms.Perfil), TypeResponse.Success);
                return response;
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Perfil), TypeResponse.Error);
                return response;
            }
        }
        public async Task<ResponseCreateCommand> PostMasivo(List<PerfilExamenCommand>? command, string User)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            List<PerfilExamen> perfilExamenesAdd = new List<PerfilExamen>();
            try
            {
                var perfilExamenExists = _dbContext.PerfilExamen.Where(x => x.IdPerfil == command[0].IdPerfil).ToList();
                _dbContext.PerfilExamen.RemoveRange(perfilExamenExists);
                foreach (var perfilExamen in command)
                {
                    var perfil = DtoMapperExtension.MapTo<PerfilExamen>(perfilExamen);
                    perfil.IdPerfilExamen = Ulid.NewUlid().ToString();
                    perfil.Fecha_creacion = DateTime.Now;
                    perfil.Estado = States.Activo;
                    perfil.Accion = Actions.Creado;
                    perfil.Creado_por = User;
                    perfilExamenesAdd.Add(perfil);
                }
                await _dbContext.PerfilExamen.AddRangeAsync(perfilExamenesAdd);
                await _dbContext.SaveChangesAsync();
                response = Configurations.Response(new Messages().Guardar(Forms.PerfilExamen), TypeResponse.Success);
                return response;
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.PerfilExamen), TypeResponse.Error);
                return response;
            }
        }
    }
}
