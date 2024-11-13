using Common.Config;
using Common.Utility;
using Persistence.Database;
using Silac.Domain;

namespace Security.Service.EventHandlers
{
    public interface INavbarEventHandlers
    {
        Task<ResponseCreateCommand> Post(NavbarCreateCommand command);
        Task<ResponseCreateCommand> Put(int id, NavbarCreateCommand command);
        Task<ResponseCreateCommand> Delete(int id, string usuario);
        Task<ResponseCreateCommand> State(int id, string usuario);
    }

    public class NavbarEventHandlers : INavbarEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public NavbarEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(int id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var navbar = _dbContext.Navbar.FirstOrDefault(x => x.IdNavbar == id);

                if (navbar != null)
                {
                    navbar.Modificado_por = usuario;
                    navbar.Fecha_modificacion = DateTime.Now;
                    navbar.Accion = Actions.Modificado;
                    navbar.Estado = (navbar.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Navbar), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Navbar), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Delete(int id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var navbar = _dbContext.Navbar.FirstOrDefault(x => x.IdNavbar == id);

                if (navbar != null)
                {
                    navbar.Modificado_por = usuario;
                    navbar.Fecha_modificacion = DateTime.Now;
                    navbar.Accion = Actions.Modificado;
                    navbar.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Navbar), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Navbar), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Navbar), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(NavbarCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var navbar = DtoMapperExtension.MapTo<Navbar>(command);

                navbar.Creado_por = command.user;
                navbar.Fecha_creacion = DateTime.Now;
                navbar.Estado = States.Activo;
                navbar.Accion = Actions.Creado;

                await _dbContext.Navbar.AddAsync(navbar);
                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Navbar), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Navbar), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(int id, NavbarCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var navbar = _dbContext.Navbar.FirstOrDefault(x => x.IdNavbar == id);

                if (navbar != null)
                {
                    //navbar.Nombre = command.Nombre;
                    navbar.Modificado_por = command.user;
                    navbar.Fecha_modificacion = DateTime.Now;
                    navbar.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Navbar), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Navbar), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Navbar), TypeResponse.Error);
                return response;
            }
        }
    }
}