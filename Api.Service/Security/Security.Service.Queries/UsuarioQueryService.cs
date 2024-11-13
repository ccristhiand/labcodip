using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Security.Service.Queries
{
    public interface IUsuarioQueryService
    {
        Task<DataCollection<UsuarioQuery>> Get(string idlab, string idarea, int page, int pages);
        Task<UsuarioQuery> Find(string? id);
    }
    public class UsuarioQueryService : IUsuarioQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public UsuarioQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<UsuarioQuery>> Get(string idlab, string idarea, int page, int pages)
        {
            try
            {
                var usuario = await (from us in _dbContext.Usuario
                                     join pe in _dbContext.Persona on us.IdPersona equals pe.IdPersona
                                     join ta in _dbContext.TablaMaestra on us.Estado equals ta.Codigo
                                     where
                                     ta.Tabla == Opciones.States &&
                                     us.UserName != "ADMIN"
                                     select new UsuarioQuery
                                     {
                                         IdUsuario = us.IdUsuario,
                                         Codigo = us.Codigo,
                                         UserName = us.UserName,
                                         Estado = ta.Nombre,

                                         IdPersona = pe.IdPersona,
                                         IdTipoDocu = pe.IdTipoDocu,
                                         NroDocumento = pe.NroDocumento,
                                         ApePaterno = pe.ApePaterno,
                                         ApeMaterno = pe.ApeMaterno,
                                         Nombre = pe.Nombre,
                                         FechaNacimiento = pe.FechaNacimiento,
                                         IdSexo = pe.IdSexo,
                                         Color = ta.Color

                                     }).GetPagedAsync(page, pages, "Codigo");

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioQuery> Find(string? id)
        {
            try
            {
                List<string> listaMaestra = new List<string>();
                listaMaestra.Add(Opciones.Sexo);
                listaMaestra.Add(Opciones.TipoDocumento);

                UsuarioQuery usuarioQuery = new UsuarioQuery();

                if (!string.IsNullOrEmpty(id))
                {
                    var usuario = await (from us in _dbContext.Usuario
                                         join pe in _dbContext.Persona on us.IdPersona equals pe.IdPersona
                                         join ta in _dbContext.TablaMaestra on us.Estado equals ta.Codigo
                                         where
                                         us.IdUsuario == id &&
                                         ta.Tabla == Opciones.States &&
                                          us.UserName != "ADMIN"
                                         select new UsuarioQuery
                                         {
                                             IdUsuario = us.IdUsuario,
                                             Codigo = us.Codigo,
                                             UserName = us.UserName,
                                             Password = us.Password,
                                             CodExterno = us.CodExterno,
                                             Estado = ta.Nombre,

                                             IdPersona = pe.IdPersona,
                                             IdTipoDocu = pe.IdTipoDocu,
                                             NroDocumento = pe.NroDocumento,
                                             ApePaterno = pe.ApePaterno,
                                             ApeMaterno = pe.ApeMaterno,
                                             Nombre = pe.Nombre,
                                             FechaNacimiento = pe.FechaNacimiento,
                                             IdSexo = pe.IdSexo,
                                             Permiso_Escritura = us.Permiso_Escritura,
                                             ListaUsuarioRol = (from ul in _dbContext.UsuarioRol where ul.IdUsuario == id select ul.IdRol).ToList(),
                                             ListaUsuarioArea = (from ul in _dbContext.UsuarioArea where ul.IdUsuario == id select ul.IdArea).ToList()
                                         }).FirstOrDefaultAsync();

                    usuarioQuery = usuario!;
                    usuarioQuery.Edad = Configurations.calcularEdad(usuarioQuery.FechaNacimiento);
                    usuarioQuery.Password = !string.IsNullOrEmpty(usuarioQuery.Password) ? Configurations.Decrypt(usuarioQuery.Password) : null;
                }


                var maestra = await (from mae in _dbContext.TablaMaestra
                                     where
                                     mae.Codigo != Opciones.AMBOS &&
                                     listaMaestra.Contains(mae.Tabla!)
                                     select new OptionQuery
                                     {
                                         Id = mae.Codigo,
                                         Nombre = mae.Nombre,
                                         Tipo = mae.Tabla
                                     }).ToListAsync();

                var rol = await (from ro in _dbContext.Rol
                                 select new RolesQuery
                                 {
                                     Key = ro.IdRol,
                                     Label = ro.Nombre,
                                     PartialSelected = false
                                 }).ToListAsync();

                var laboratorio = await (from la in _dbContext.Laboratorio
                                         where
                                         la.Estado == States.Activo
                                         select new LaboratorioQuery
                                         {
                                             Key = la.IdLaboratorio,
                                             Label = la.Nombre,
                                             Children = (from are in _dbContext.Area
                                                         where
                                                         are.IdLaboratorio == la.IdLaboratorio
                                                         select new AreaQuery
                                                         {
                                                             Key = are.IdArea,
                                                             Label = are.Nombre,
                                                             PartialSelected = false
                                                         }).ToList()
                                         }).ToListAsync();

                usuarioQuery.ListaOpciones.AddRange(maestra);
                usuarioQuery.ListaRoles.AddRange(rol);
                usuarioQuery.ListaLaboratorios.AddRange(laboratorio);

                if (usuarioQuery.ListaUsuarioArea.Count > 0)
                {
                    var areaSelect = await (from ar in _dbContext.Area
                                            where
                                               usuarioQuery.ListaUsuarioArea.Contains(ar.IdArea)
                                            select new LaboratorioQuery
                                            {
                                                Key = ar.IdArea,
                                                Label = ar.Nombre,
                                                Children = (from la in _dbContext.Laboratorio
                                                            where
                                                            la.IdLaboratorio == ar.IdLaboratorio
                                                            select new AreaQuery
                                                            {
                                                                Key = la.IdLaboratorio,
                                                                Label = la.Nombre,
                                                                PartialSelected = true
                                                            }).ToList()
                                            }).ToListAsync();

                    usuarioQuery.LaboratorioSelect.AddRange(areaSelect);
                }


                return usuarioQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
