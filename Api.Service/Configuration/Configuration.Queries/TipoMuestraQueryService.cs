using Common.Config;
using Common.Utility;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface ITipoMuestraQueryService
    {
        Task<DataCollection<TipoMuestraQuery>> Get(string? valor, int page, int pages, string column);
        Task<TipoMuestraQuery> Find(string? id);
    }
    public class TipoMuestraQueryService : ITipoMuestraQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        public TipoMuestraQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<TipoMuestraQuery>> Get(string? valor, int page, int pages, string column)
        {
            try
            {
                var response = await (from t in _dbContext.TipoMuestra
                                      join ta in _dbContext.TablaMaestra on t.Estado equals ta.Codigo
                                      where
                                      (valor == null || t.Nombre!.Contains(valor!)) &&
                                       ta.Tabla == Opciones.States &&
                                      t.Estado != States.Eliminado
                                      select new TipoMuestraQuery
                                      {
                                          IdTipoMuestra = t.IdTipoMuestra,
                                          Codigo = t.Codigo,
                                          Nombre = t.Nombre,
                                          Descripcion = t.Descripcion,
                                          CodigoTipoMuestra = t.CodigoTipoMuestra,
                                          Estado = ta.Nombre,
                                          Color = ta.Color
                                      }).GetPagedAsync(page, pages, column);

                return response!;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TipoMuestraQuery> Find(string? id)
        {
            try
            {
                var response = await (from t in _dbContext.TipoMuestra
                                      where
                                      t.IdTipoMuestra == id
                                      select new TipoMuestraQuery
                                      {
                                          IdTipoMuestra = t.IdTipoMuestra,
                                          Codigo = t.Codigo,
                                          Nombre = t.Nombre,
                                          Descripcion = t.Descripcion,
                                          CodigoTipoMuestra = t.CodigoTipoMuestra,
                                          Estado = t.Estado
                                      }).FirstOrDefaultAsync();

                return response!;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
