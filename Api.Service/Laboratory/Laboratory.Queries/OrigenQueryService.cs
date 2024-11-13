using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Laboratory.Service.Queries
{
    public interface IOrigenQueryService
    {
        Task<DataCollection<OrigenQuery>> Get(string? valor, int page, int pages);
        Task<OrigenQuery> Find(string id);
    }
    public class OrigenQueryService : IOrigenQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public OrigenQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<OrigenQuery>> Get(string? valor, int page, int pages)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var origen = await (from or in _dbContext.Origen
                                    join ta in _dbContext.TablaMaestra on or.Estado equals ta.Codigo
                                    where
                                    (valor == null || or.Nombre!.Contains(valor!)) &&
                                    ta.Tabla == Opciones.States &&
                                     or.Estado != States.Eliminado
                                    select new OrigenQuery
                                    {
                                        IdOrigen = or.IdOrigen,
                                        Codigo = or.Codigo,
                                        Nombre = or.Nombre,
                                        Estado = ta.Nombre,
                                        Color = ta.Color,
                                    }).GetPagedAsync(page, pages, "Codigo");

                return origen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrigenQuery> Find(string id)
        {
            try
            {
                var origen = await (from or in _dbContext.Origen
                                    join ta in _dbContext.TablaMaestra on or.Estado equals ta.Codigo
                                    where
                                    or.IdOrigen == id
                                    select new OrigenQuery
                                    {
                                        IdOrigen = or.IdOrigen,
                                        Codigo = or.Codigo,
                                        Nombre = or.Nombre,
                                        Estado = ta.Nombre
                                    }).FirstOrDefaultAsync();


                return origen!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
