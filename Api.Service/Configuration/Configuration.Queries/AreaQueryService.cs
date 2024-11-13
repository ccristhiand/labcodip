using Common.Config;
using Common.Utility;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface IAreaQueryService
    {
        Task<DataCollection<AreaQuery>> Get(string? valor, int page, int pages, string column);
        Task<AreaQuery> Find(string? id);
    }

    public class AreaQueryService : IAreaQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public AreaQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<AreaQuery>> Get(string? valor, int page, int pages, string column)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var response = await (from a in _dbContext.Area
                                      join ta in _dbContext.TablaMaestra on a.Estado equals ta.Codigo
                                      join la in _dbContext.Laboratorio on a.IdLaboratorio equals la.IdLaboratorio
                                      where
                                      (valor == null || a.Nombre!.Contains(valor!)) &&
                                      ta.Tabla == Opciones.States &&
                                      a.Estado != States.Eliminado
                                      select new AreaQuery
                                      {
                                          IdArea = a.IdArea,
                                          Codigo = a.Codigo,
                                          Nombre = a.Nombre,
                                          Descripcion = a.Descripcion,
                                          NombreLaboratorio = la.Nombre,
                                          Estado = ta.Nombre,
                                          Color = ta.Color
                                      }).GetPagedAsync(page, pages, column);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AreaQuery> Find(string? id)
        {
            try
            {
                AreaQuery areaQuery = new AreaQuery();

                if (!string.IsNullOrEmpty(id))
                {
                    var area = await (from a in _dbContext.Area
                                      where
                                      a.IdArea == id
                                      select new AreaQuery
                                      {
                                          IdArea = a.IdArea,
                                          Nombre = a.Nombre,
                                          Descripcion = a.Descripcion,
                                          IdLaboratorio = a.IdLaboratorio,
                                      }).FirstOrDefaultAsync();

                    areaQuery = area!;
                }

                var laboratorio = await (from la in _dbContext.Laboratorio
                                         where
                                         la.Estado == States.Activo
                                         select new OptionQuery
                                         {
                                             Id = la.IdLaboratorio,
                                             Nombre = la.Nombre
                                         }).ToListAsync();

                areaQuery.ListaOpciones.AddRange(laboratorio);

                return areaQuery!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
