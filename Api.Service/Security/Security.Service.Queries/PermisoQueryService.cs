using Common.Config;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Security.Service.Queries
{
    public interface IPermisoQueryService
    {
        Task<DataCollection<PermisoQuery>> Get();
        Task<PermisoQuery> Find(string id);
    }
    public class PermisoQueryService : IPermisoQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public PermisoQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<PermisoQuery>> Get()
        {
            try
            {
                var permiso = await (from pe in _dbContext.Permiso
                                     select new PermisoQuery
                                     {
                                         IdPermiso = pe.IdPermiso,
                                         Codigo = pe.Codigo,
                                         Nombre = pe.Nombre
                                     }).GetPagedAsync();

                return permiso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PermisoQuery> Find(string id)
        {
            try
            {
                var permiso = await (from pe in _dbContext.Permiso
                                     where
                                     pe.IdPermiso == id
                                     select new PermisoQuery
                                     {
                                         IdPermiso = pe.IdPermiso,
                                         Codigo = pe.Codigo,
                                         Nombre = pe.Nombre
                                     }).FirstOrDefaultAsync();

                return permiso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
