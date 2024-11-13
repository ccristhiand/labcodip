using Common.Config;
using Common.Utility;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface ILaboratorioQueryService
    {
        Task<DataCollection<LaboratorioQuery>> Get(string? valor, int page, int pages, string column);
        Task<LaboratorioQuery> Find(string? id);
    }
    public class LaboratorioQueryService : ILaboratorioQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public LaboratorioQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<LaboratorioQuery>> Get(string? valor, int page, int pages, string column)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var response = await (from l in _dbContext.Laboratorio
                                      join ta in _dbContext.TablaMaestra on l.Estado equals ta.Codigo
                                      where
                                      (valor == null || l.Nombre!.Contains(valor!)) &&
                                      ta.Tabla == Opciones.States &&
                                      l.Estado != States.Eliminado
                                      select new LaboratorioQuery
                                      {
                                          IdLaboratorio = l.IdLaboratorio,
                                          CodigoLaboratorio = l.CodigoLaboratorio,
                                          Codigo = l.Codigo,
                                          Nombre = l.Nombre,
                                          Estado = ta.Nombre,
                                          Color = ta.Color,
                                      }).GetPagedAsync(page, pages, column);

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LaboratorioQuery> Find(string? id)
        {
            try
            {
                var response = await (from l in _dbContext.Laboratorio
                                      join ta in _dbContext.TablaMaestra on l.Estado equals ta.Codigo
                                      where
                                      ta.Tabla == Opciones.States &&
                                      l.IdLaboratorio == id
                                      select new LaboratorioQuery
                                      {
                                          IdLaboratorio = l.IdLaboratorio,
                                          CodigoLaboratorio = l.CodigoLaboratorio,
                                          Codigo = l.Codigo,
                                          Nombre = l.Nombre,
                                          Estado = ta.Nombre
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
