using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain.Conf;

namespace Configuration.Service.EventHandlers
{
    public interface IPerfilEventHandlers
    {
        Task<ResponseCreateCommand> Post(PerfilCommand command);
        Task<ResponseCreateCommand> Delete(string idPerfil, string usuario);
        Task<ResponseCreateCommand> Put(PerfilCommand command, string idPerfil);
        Task<ResponseCreateCommand> Patch(string idPerfil, string usuario);

    }
    public class PerfilEventHandlers : IPerfilEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public PerfilEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string idPerfil, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var perfilSearch = _dbContext.Perfil.SingleOrDefault(x => x.IdPerfil == idPerfil);
                if (perfilSearch != null)
                {
                    perfilSearch.Estado = States.Eliminado;
                    perfilSearch.Accion = Actions.Eliminado;
                    perfilSearch.Fecha_modificacion = DateTime.Now;
                    perfilSearch.Modificado_por = usuario;
                    await _dbContext.SaveChangesAsync();
                    response = Configurations.Response(new Messages().Eliminar(Forms.Perfil), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().Eliminar(Forms.Perfil), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Perfil), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Put(PerfilCommand command, string idPerfil)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var perfilSearch = _dbContext.Perfil.SingleOrDefault(x => x.IdPerfil == idPerfil);
                if (perfilSearch != null)
                {
                    perfilSearch.Nombre = command.Nombre;
                    perfilSearch.Estado = States.Activo;
                    perfilSearch.Accion = Actions.Modificado;
                    perfilSearch.Fecha_modificacion = DateTime.Now;
                    perfilSearch.Modificado_por = command.User;
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

        public async Task<ResponseCreateCommand> Post(PerfilCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var perfil = DtoMapperExtension.MapTo<Perfil>(command);
                perfil.IdPerfil = Ulid.NewUlid().ToString();
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

        public async Task<ResponseCreateCommand> Patch(string idPerfil, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var perfilSearch = _dbContext.Perfil.SingleOrDefault(x => x.IdPerfil == idPerfil);
                if (perfilSearch != null)
                {
                    perfilSearch.Estado = States.Desactivado;
                    perfilSearch.Accion = Actions.Modificado;
                    perfilSearch.Fecha_modificacion = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error);
                return response;
            }
        }
    }
}
