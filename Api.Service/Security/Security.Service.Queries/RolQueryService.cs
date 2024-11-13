using Common.Config;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Security.Service.Queries
{
    public interface IRolQueryService
    {
        Task<DataCollection<RolQuery>> Get();
        Task<RolQuery> Find(string id);
    }
    public class RolQueryService : IRolQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public RolQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<RolQuery>> Get()
        {
            try
            {
                var rol = await (from c in _dbContext.Rol
                                 select new RolQuery
                                 {
                                     Codigo = c.Codigo,
                                     Nombre = c.Nombre
                                 }).GetPagedAsync();

                return rol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RolQuery> Find(string id)
        {
            try
            {
                var rol = await (from ro in _dbContext.Rol
                                 where
                                 ro.IdRol == id
                                 select new RolQuery
                                 {
                                     IdRol = ro.IdRol,
                                     Codigo = ro.Codigo,
                                     Nombre = ro.Nombre,
                                     Estado = ro.Estado
                                 }).FirstOrDefaultAsync();

                return rol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
