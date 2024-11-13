using Common.Config;
using Common.Utility;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface ISistemaClienteExamenQueryService
    {
        Task<DataCollection<SistemaClienteExamenQuery>> Get(string? valor, string? id, int page, int pages, string column);
    }
    public class SistemaClienteExamenQueryService : ISistemaClienteExamenQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public SistemaClienteExamenQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<SistemaClienteExamenQuery>> Get(string? valor, string? id, int page, int pages, string column)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var response = await (from em in _dbContext.SistemaClienteExamen
                                      join ex in _dbContext.Examen on em.IdExamen equals ex.IdExamen
                                      join ta in _dbContext.TablaMaestra on em.Estado equals ta.Codigo
                                      join ar in _dbContext.Area on ex.IdArea equals ar.IdArea
                                      where
                                         (valor == null || ex.Nombre!.Contains(valor!)) &&
                                         em.IdSistemaCliente == id &&
                                         ta.Tabla == Opciones.States &&
                                         em.Estado != States.Eliminado
                                      select new SistemaClienteExamenQuery
                                      {
                                          IdSistemaClienteExamen = em.IdSistemaClienteExamen,
                                          IdSistemaCliente = em.IdSistemaCliente,
                                          IdExamen = em.IdExamen,
                                          NombreExamen = ex.Nombre,
                                          NombreArea = ar.Nombre,
                                          CodRecibe = em.CodRecibe,
                                          CodDevuelve = em.CodDevuelve,
                                          UnidadMedida = ex.UnidadMedida
                                      }).GetPagedAsync(page, pages, column);

                response.Valor = await (from em in _dbContext.SistemaCliente
                                        where
                                           em.IdSistemaCliente == id &&
                                           em.Estado != States.Eliminado
                                        select em.Nombre).FirstOrDefaultAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
