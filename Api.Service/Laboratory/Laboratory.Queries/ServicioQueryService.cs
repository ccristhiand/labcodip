using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Laboratory.Service.Queries
{
    public interface IServicioQueryService
    {
        Task<DataCollection<ServicioQuery>> Get(string? valor, int page, int pages);
        Task<ServicioQuery> Find(string id);
    }
    public class ServicioQueryService : IServicioQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public ServicioQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<ServicioQuery>> Get(string? valor, int page, int pages)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var servicio = await (from sr in _dbContext.Servicio
                                      join ta in _dbContext.TablaMaestra on sr.Estado equals ta.Codigo
                                      where
                                      (valor == null || sr.Nombre!.Contains(valor!)) &&
                                       ta.Tabla == Opciones.States &&
                                       sr.Estado != States.Eliminado
                                      select new ServicioQuery
                                      {
                                          IdServicio = sr.IdServicio,
                                          Codigo = sr.Codigo,
                                          Nombre = sr.Nombre,
                                          Estado = ta.Nombre,
                                          Color = ta.Color,
                                      }).GetPagedAsync(page, pages, "Codigo");

                return servicio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServicioQuery> Find(string id)
        {
            try
            {
                var servicio = await (from sr in _dbContext.Servicio
                                      join ta in _dbContext.TablaMaestra on sr.Estado equals ta.Codigo
                                      where
                                      sr.IdServicio == id
                                      select new ServicioQuery
                                      {
                                          IdServicio = sr.IdServicio,
                                          Codigo = sr.Codigo,
                                          Nombre = sr.Nombre,
                                          Estado = ta.Nombre
                                      }).FirstOrDefaultAsync();


                return servicio!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
