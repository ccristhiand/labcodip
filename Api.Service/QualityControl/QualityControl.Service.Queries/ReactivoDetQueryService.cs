using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace QualityControl.Service.Queries
{
    public interface IReactivoDetQueryService
    {
        Task<DataCollection<ReactivoDetQuery>> Get(string? id, int page, int pages);
        Task<ReactivoDetQuery> Find(string? id, string? idarea);
        Task<List<ReactivoExamenQuery>> FindExamen(string? id);
    }

    public class ReactivoDetQueryService : IReactivoDetQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public ReactivoDetQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<ReactivoDetQuery>> Get(string? id, int page, int pages)
        {
            try
            {

                var reactivo = await (from re in _dbContext.ReactivoDet
                                      where
                                      re.IdReactivo == id &&
                                      re.Estado != States.Eliminado
                                      select new ReactivoDetQuery
                                      {
                                          IdReactivoDet = re.IdReactivoDet,
                                          Nombre = re.Nombre
                                      }).GetPagedAsync(page, pages);

                return reactivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReactivoDetQuery> Find(string? id, string? idarea)
        {
            try
            {
                ReactivoDetQuery reactivoDetQuery = new ReactivoDetQuery();

                if (!string.IsNullOrEmpty(id))
                {
                    var reactivo = await (from re in _dbContext.ReactivoDet
                                          where
                                          re.IdReactivo == id
                                          select new ReactivoDetQuery
                                          {
                                              IdReactivoDet = re.IdReactivoDet,
                                              IdReactivo = re.IdReactivo,
                                              IdExamen = re.IdExamen,
                                              Nombre = re.Nombre
                                          }).FirstOrDefaultAsync();

                    reactivoDetQuery = reactivo!;

                }

                var examen = await (from ex in _dbContext.Examen
                                    where
                                    ex.IdArea == idarea &&
                                    ex.Estado == States.Activo
                                    select new ReactivoExamenQuery
                                    {
                                        IdExamen = ex.IdExamen,
                                        Nombre = ex.Nombre
                                    }).ToListAsync();


                reactivoDetQuery.ListaReactivoExamen = examen;

                return reactivoDetQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReactivoExamenQuery>> FindExamen(string? id)
        {
            try
            {
                var examen = await (from ex in _dbContext.Examen
                                    where
                                    ex.IdArea == id &&
                                    ex.Estado == States.Activo
                                    select new ReactivoExamenQuery
                                    {
                                        IdExamen = ex.IdExamen,
                                        Nombre = ex.Nombre
                                    }).ToListAsync();

                return examen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
