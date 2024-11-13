using Common.Config;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface ITablaMaestraQueryService
    {
        Task<DataCollection<TablaMaestraQuery>> Get();
        Task<TablaMaestraQuery> Find(string id);
    }
    public class TablaMaestraQueryService : ITablaMaestraQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        public async Task<TablaMaestraQuery> Find(string id)
        {
            try
            {
                using (var dbContext = _dbContext)
                {
                    var response = await (
                        from t in dbContext.TablaMaestra
                        where t.Tabla == id
                        select new TablaMaestraQuery
                        {
                            Accion = t.Accion,
                            Codigo = t.Codigo,
                            IdTablaMaestra = t.IdTablaMaestra,
                            Nombre = t.Nombre,
                            Tabla = t.Tabla,

                        }).FirstOrDefaultAsync();
                    return response!;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<DataCollection<TablaMaestraQuery>> Get()
        {
            using (var dbContext = _dbContext)
            {
                var response = await (
                    from t in dbContext.TablaMaestra
                    select new TablaMaestraQuery
                    {
                        Accion = t.Accion,
                        Codigo = t.Codigo,
                        IdTablaMaestra = t.IdTablaMaestra,
                        Nombre = t.Nombre,
                        Tabla = t.Tabla,
                    }).GetPagedAsync();
                return response!;
            }
        }
    }
}

