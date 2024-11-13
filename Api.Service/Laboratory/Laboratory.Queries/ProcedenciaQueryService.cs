using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Laboratory.Service.Queries
{
    public interface IProcedenciaQueryService
    {
        Task<DataCollection<ProcedenciaQuery>> Get(string? valor, int page, int pages);
        Task<ProcedenciaQuery> Find(string id);
    }
    public class ProcedenciaQueryService : IProcedenciaQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public ProcedenciaQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<ProcedenciaQuery>> Get(string? valor, int page, int pages)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var procedencia = await (from pr in _dbContext.Procedencia
                                         join ta in _dbContext.TablaMaestra on pr.Estado equals ta.Codigo
                                         where
                                         (valor == null || pr.Nombre!.Contains(valor!)) &&
                                          ta.Tabla == Opciones.States &&
                                          pr.Estado != States.Eliminado
                                         select new ProcedenciaQuery
                                         {
                                             IdProcedencia = pr.IdProcedencia,
                                             Codigo = pr.Codigo,
                                             Nombre = pr.Nombre,
                                             Estado = ta.Nombre,
                                             Color = ta.Color,
                                         }).GetPagedAsync(page, pages, "Codigo");

                return procedencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProcedenciaQuery> Find(string id)
        {
            try
            {
                var procedencia = await (from pr in _dbContext.Procedencia
                                         join ta in _dbContext.TablaMaestra on pr.Estado equals ta.Codigo
                                         where
                                         pr.IdProcedencia == id &&
                                         ta.Tabla == Opciones.States
                                         select new ProcedenciaQuery
                                         {
                                             IdProcedencia = pr.IdProcedencia,
                                             Codigo = pr.Codigo,
                                             Nombre = pr.Nombre,
                                             Estado = ta.Nombre
                                         }).FirstOrDefaultAsync();


                return procedencia!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
