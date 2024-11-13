using Common.Config;
using Common.Utility;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;


namespace Configuration.Service.Queries
{
    public interface IPerfilExamenQueryService
    {
        Task<DataCollection<PerfilExamenQuery>> Get(string? valor, int page, int pages, string column);
        Task<List<PerfilExamenQuery>> Get();

        Task<List<PerfilExamenQuery>> FindByIdPerfil(string? idPerfil);
    }
    public class PerfilExamenQueryService : IPerfilExamenQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        public PerfilExamenQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<PerfilExamenQuery>> Get(string? valor, int page, int pages, string column)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var response = await (from pe in _dbContext.PerfilExamen
                                      join e in _dbContext.Examen on pe.IdExamen equals e.IdExamen
                                      join p in _dbContext.Perfil on pe.IdExamen equals p.IdPerfil
                                      where (valor == null || p.Nombre!.Contains(valor!)) &&
                                       p.Estado == Opciones.States &&
                                       p.Estado != States.Eliminado
                                      select new PerfilExamenQuery
                                      {
                                          IdPerfil = pe.IdPerfil,
                                          Estado = pe.Estado,
                                          IdExamen = pe.IdExamen,
                                          AbreviaturaExamen = e.Abreviatura,
                                          IdPerfilExamen = pe.IdPerfilExamen,
                                          NombreExamen = e.Nombre,
                                          NombrePerfil = p.Nombre,

                                      }).GetPagedAsync(page, pages, column);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PerfilExamenQuery>> Get()
        {
            try
            {

                var response = await (from pe in _dbContext.PerfilExamen
                                      join e in _dbContext.Examen on pe.IdExamen equals e.IdExamen
                                      join p in _dbContext.Perfil on pe.IdExamen equals p.IdPerfil
                                      where p.Estado == Opciones.States &&
                                       p.Estado != States.Eliminado
                                      select new PerfilExamenQuery
                                      {
                                          IdPerfil = pe.IdPerfil,
                                          Estado = pe.Estado,
                                          IdExamen = pe.IdExamen,
                                          AbreviaturaExamen = e.Abreviatura,
                                          IdPerfilExamen = pe.IdPerfilExamen,
                                          NombreExamen = e.Nombre,
                                          NombrePerfil = p.Nombre,

                                      }).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<PerfilExamenQuery>> FindByIdPerfil(string? id)
        {
            try
            {
                var response = await (from pe in _dbContext.PerfilExamen
                                      join e in _dbContext.Examen on pe.IdExamen equals e.IdExamen
                                      join p in _dbContext.Perfil on pe.IdExamen equals p.IdPerfil
                                      select new PerfilExamenQuery
                                      {
                                          IdPerfil = pe.IdPerfil,
                                          Estado = pe.Estado,
                                          IdExamen = pe.IdExamen,
                                          AbreviaturaExamen = e.Abreviatura,
                                          IdPerfilExamen = pe.IdPerfilExamen,
                                          NombreExamen = e.Nombre,
                                          NombrePerfil = p.Nombre,

                                      }).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
