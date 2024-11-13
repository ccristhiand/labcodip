using Common.Config;
using Common.Utility;
using Persistence.Database;
using System.Data;

namespace QualityControl.Service.Queries
{
    public interface ILoteQueryService
    {
        Task<DataCollection<LoteQuery>> Get(string id, int page, int pages);
    }
    public class LoteQueryService : ILoteQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public LoteQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<LoteQuery>> Get(string id, int page, int pages)
        {
            try
            {

                var lote = await (from lo in _dbContext.Lote
                                  where
                                  lo.IdReactivoDet == id &&
                                   lo.Estado != States.Eliminado
                                  select new LoteQuery
                                  {
                                      IdLote = lo.IdLote,
                                      Codigo = lo.Codigo,
                                      Nombre = lo.Nombre
                                  }).GetPagedAsync(page, pages);

                return lote;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
