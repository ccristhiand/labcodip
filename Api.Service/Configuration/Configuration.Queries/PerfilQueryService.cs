using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries.Query
{
    public interface IPerfilQueryService
    {
        Task<DataCollection<PerfilQuey>> Get(string? valor, int page, int pages);
        Task<List<PerfilQuey>> Get();
        Task<PerfilQuey> Find(string? id);
    }
    public class PerfilQueryService : IPerfilQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        public PerfilQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<PerfilQuey>> Get(string? valor, int page, int pages)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var response = await (from p in _dbContext.Perfil
                                      join m in _dbContext.TablaMaestra on p.Estado equals m.Codigo
                                      where (valor == null || p.Nombre!.Contains(valor!)) &&
                                       p.Estado == States.Activo &&
                                       p.Estado != States.Eliminado &&
                                       m.Tabla == Opciones.States
                                      select new PerfilQuey
                                      {
                                          IdPerfil = p.IdPerfil,
                                          Estado = m.Nombre,
                                          Nombre = p.Nombre,
                                          Codigo = p.Codigo,
                                          PerfilExamenes = (from pe in _dbContext.PerfilExamen
                                                            join e in _dbContext.Examen on pe.IdExamen equals e.IdExamen
                                                            where pe.IdPerfil == p.IdPerfil
                                                            select new PerfilExamenQuery
                                                            {
                                                                IdPerfil = pe.IdPerfil,
                                                                AbreviaturaExamen = e.Abreviatura,
                                                                IdExamen = e.IdExamen,
                                                                IdPerfilExamen = pe.IdPerfilExamen,
                                                                NombreExamen = e.Nombre,
                                                                NombrePerfil = p.Nombre,
                                                                Estado = pe.Estado,

                                                            }).ToList()

                                      }).GetPagedAsync(page, pages);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<PerfilQuey>> Get()
        {
            try
            {
                var response = await (from p in _dbContext.Perfil
                                      join m in _dbContext.TablaMaestra on p.Estado equals m.Codigo
                                      where p.Estado == States.Activo &&
                                       p.Estado != States.Eliminado &&
                                       m.Tabla == Opciones.States
                                      select new PerfilQuey
                                      {
                                          IdPerfil = p.IdPerfil,
                                          Estado = m.Nombre,
                                          Nombre = p.Nombre,
                                          Codigo = p.Codigo,
                                          PerfilExamenes = (from pe in _dbContext.PerfilExamen
                                                            join e in _dbContext.Examen on pe.IdExamen equals e.IdExamen
                                                            where pe.IdPerfil == p.IdPerfil
                                                            select new PerfilExamenQuery
                                                            {
                                                                IdPerfil = pe.IdPerfil,
                                                                AbreviaturaExamen = e.Abreviatura,
                                                                IdExamen = e.IdExamen,
                                                                IdPerfilExamen = pe.IdPerfilExamen,
                                                                NombreExamen = e.Nombre,
                                                                NombrePerfil = p.Nombre,
                                                                Estado = pe.Estado,

                                                            }).ToList()

                                      }).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PerfilQuey> Find(string? id)
        {
            try
            {
                var response = await (from p in _dbContext.Perfil
                                      where p.IdPerfil == id
                                      select new PerfilQuey
                                      {
                                          IdPerfil = p.IdPerfil,
                                          Estado = p.Estado,
                                          Nombre = p.Nombre,

                                      }).FirstOrDefaultAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
