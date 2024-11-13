using Common.Config;
using Common.Utility;
using Persistence.Database;
using System.Data;

namespace QualityControl.Service.Queries
{
    public interface INivelQueryService
    {
        Task<DataCollection<NivelQuery>> Get(int page, int pages);
    }
    public class NivelQueryService : INivelQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public NivelQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<NivelQuery>> Get(int page, int pages)
        {
            try
            {

                var nivel = await (from ni in _dbContext.Nivel
                                   where
                                    ni.Estado != States.Eliminado
                                   select new NivelQuery
                                   {
                                       IdNivel = ni.IdNivel,
                                       Codigo = ni.Codigo,
                                       Nombre = ni.Nombre
                                   }).GetPagedAsync(page, pages);

                return nivel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
