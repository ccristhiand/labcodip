using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Silac.Domain;

namespace Security.Service.EventHandlers
{
    public interface IUsuarioEventHandlers
    {
        Task<ResponseCreateCommand> Post(UsuarioCreateCommand command);
        Task<ResponseCreateCommand> Put(string id, UsuarioCreateCommand command);
        Task<ResponseCreateCommand> Delete(string id, string usuario);
        Task<ResponseCreateCommand> State(string id, string usuario);
    }

    public class UsuarioEventHandlers : IUsuarioEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public UsuarioEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> State(string id, string usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var user = _dbContext.Usuario.Single(x => x.IdUsuario == id);

                if (user != null)
                {
                    user.Modificado_por = usuario;
                    user.Fecha_modificacion = DateTime.Now;
                    user.Accion = Actions.Modificado;
                    user.Estado = (user.Estado == States.Desactivado) ? States.Activo : States.Desactivado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Desactivar(Forms.Usuario), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Usuario), TypeResponse.Alert);
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
                var user = _dbContext.Usuario.FirstOrDefault(x => x.IdUsuario == id);

                if (user != null)
                {
                    user.Modificado_por = usuario;
                    user.Fecha_modificacion = DateTime.Now;
                    user.Accion = Actions.Modificado;
                    user.Estado = States.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Usuario), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Usuario), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorEliminar(Forms.Usuario), TypeResponse.Error);
                return response;
            }
        }

        public async Task<ResponseCreateCommand> Post(UsuarioCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var validarUsuario = _dbContext.Usuario.AsNoTracking().Where(x => x.Persona!.NroDocumento == command.NroDocumento).Any();

                if (validarUsuario)
                {
                    response = Configurations.Response(new Messages().YaExiste(Forms.Usuario), TypeResponse.Alert);
                    return response;
                }

                validarUsuario = _dbContext.Usuario.AsNoTracking().Where(x => x.UserName.Replace(" ", "").ToLower() == command.UserName.Replace(" ", "").ToLower()).Any();

                if (validarUsuario)
                {
                    response = Configurations.Response(new Messages().YaExiste(Forms.Usuario), TypeResponse.Alert);
                    return response;
                }

                //Persona
                Configurations configurations = new Configurations(_dbContext);

                string idPersona = configurations.AddPersona(command.IdTipoDocu, command.NroDocumento, command.ApePaterno, command.ApeMaterno, command.Nombre, command.FechaNacimiento, command.IdSexo, command.user);

                //Usuario
                var usuario = DtoMapperExtension.MapTo<Usuario>(command);

                usuario.IdUsuario = Ulid.NewUlid().ToString();
                usuario.Password = !string.IsNullOrEmpty(command.Password) ? Configurations.Encrypt(command.Password) : null;
                usuario.IdPersona = idPersona;
                usuario.Creado_por = command.user;
                usuario.Fecha_creacion = DateTime.Now;
                usuario.Estado = States.Activo;
                usuario.Accion = Actions.Creado;

                await _dbContext.Usuario.AddAsync(usuario);

                //Usuario Rol
                command.ListaUsuarioRol.ForEach(async x =>
                {
                    UsuarioRol usuarioRol = new UsuarioRol();

                    usuarioRol.IdUsuarioRol = Ulid.NewUlid().ToString();
                    usuarioRol.IdUsuario = usuario.IdUsuario;
                    usuarioRol.IdRol = x;
                    usuarioRol.Creado_por = command.user;
                    usuarioRol.Fecha_creacion = DateTime.Now;
                    usuarioRol.Estado = States.Activo;
                    usuarioRol.Accion = Actions.Creado;

                    await _dbContext.UsuarioRol.AddAsync(usuarioRol);
                });


                //Usuario Area
                var listaUsuarioArea = _dbContext.Area
                     .AsNoTracking()
                     .Where(x => command.ListaUsuarioArea.Contains(x.IdArea))
                     .Select(y => y.IdArea)
                     .ToList();

                listaUsuarioArea.ForEach(x =>
                {
                    var userArea = new UsuarioArea
                    {
                        IdUsuarioArea = Ulid.NewUlid().ToString(),
                        IdUsuario = usuario.IdUsuario,
                        IdArea = x,
                        Creado_por = command.user,
                        Fecha_creacion = DateTime.Now,
                        Estado = States.Activo,
                        Accion = Actions.Creado
                    };

                    _dbContext.UsuarioArea.Add(userArea);
                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Usuario), TypeResponse.Success);
                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Usuario), TypeResponse.Error);
            }
        }

        public async Task<ResponseCreateCommand> Put(string id, UsuarioCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            try
            {
                var usuario = _dbContext.Usuario.FirstOrDefault(x => x.IdUsuario == id);

                if (usuario != null)
                {
                    command.ListaUsuarioArea = _dbContext.Area
                        .AsNoTracking()
                        .Where(x => command.ListaUsuarioArea.Contains(x.IdArea))
                        .Select(y => y.IdArea)
                        .ToList();

                    //Usuario
                    usuario.UserName = command.UserName;
                    usuario.Permiso_Escritura = command.Permiso_Escritura;
                    usuario.Password = !string.IsNullOrEmpty(command.Password) ? Configurations.Encrypt(command.Password) : null;
                    usuario.CodExterno = command.CodExterno;
                    usuario.Modificado_por = command.user;
                    usuario.Fecha_modificacion = DateTime.Now;
                    usuario.Accion = Actions.Modificado;

                    //Usuario Rol
                    var listaIdRolNuevo = command.ListaUsuarioRol;
                    var listaIdRolExiste = _dbContext.UsuarioRol.AsNoTracking().Where(x => x.IdUsuario == id).Select(x => x.IdRol).ToList();

                    //----Agregar----
                    var selectIdRolNuevo = listaIdRolNuevo.Where(x => !listaIdRolExiste.Contains(x!)).ToList();

                    selectIdRolNuevo.ForEach(async x =>
                    {
                        UsuarioRol usuarioRol = new UsuarioRol();

                        usuarioRol.IdUsuarioRol = Ulid.NewUlid().ToString();
                        usuarioRol.IdUsuario = usuario.IdUsuario;
                        usuarioRol.IdRol = x;
                        usuarioRol.Creado_por = command.user;
                        usuarioRol.Fecha_creacion = DateTime.Now;
                        usuarioRol.Estado = States.Activo;
                        usuarioRol.Accion = Actions.Creado;

                        await _dbContext.UsuarioRol.AddAsync(usuarioRol);
                    });

                    //----Eliminar----
                    var selectIdRolExiste = listaIdRolExiste.Where(x => !listaIdRolNuevo.Contains(x!)).ToList();

                    selectIdRolExiste.ForEach(y =>
                    {
                        var usuarioRol = _dbContext.UsuarioRol.Single(x => x.IdRol == y && x.IdUsuario == usuario.IdUsuario);

                        _dbContext.UsuarioRol.Remove(usuarioRol);
                    });


                    //Usuario Area
                    var listaIdUsuarioAreaNuevo = command.ListaUsuarioArea;
                    var listaIdUsuarioAreaExiste = _dbContext.UsuarioArea.AsNoTracking().Where(x => x.IdUsuario == id).Select(x => x.IdArea).ToList();

                    //----Agregar----
                    var selectIdUsuarioAreaNuevo = listaIdUsuarioAreaNuevo.Where(x => !listaIdUsuarioAreaExiste.Contains(x!)).ToList();

                    selectIdUsuarioAreaNuevo.ForEach(async x =>
                    {
                        UsuarioArea usuarioArea = new UsuarioArea();

                        usuarioArea.IdUsuarioArea = Ulid.NewUlid().ToString();
                        usuarioArea.IdUsuario = usuario.IdUsuario;
                        usuarioArea.IdArea = x;
                        usuarioArea.Creado_por = command.user;
                        usuarioArea.Fecha_creacion = DateTime.Now;
                        usuarioArea.Estado = States.Activo;
                        usuarioArea.Accion = Actions.Creado;

                        await _dbContext.UsuarioArea.AddAsync(usuarioArea);
                    });

                    //----Eliminar-----
                    var selectIdUsuarioAreaExiste = listaIdUsuarioAreaExiste.Where(x => !listaIdUsuarioAreaNuevo.Contains(x!)).ToList();

                    selectIdUsuarioAreaExiste.ForEach(y =>
                    {
                        var usuarioArea = _dbContext.UsuarioArea.Single(x => x.IdArea == y && x.IdUsuario == usuario.IdUsuario);

                        _dbContext.UsuarioArea.Remove(usuarioArea);
                    });

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Usuario), TypeResponse.Success);
                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.Usuario), TypeResponse.Alert);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Configurations.Response(new Messages().ErrorGuardar(Forms.Usuario), TypeResponse.Error);
                return response;
            }
        }
    }
}