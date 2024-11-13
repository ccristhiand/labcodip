using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace QualityControl.Service.Queries
{
    public interface IQCRangoQueryService
    {
        Task<QCRangoQuery> Get(string? id, string? idlote, string? idnivel);
        Task<QCRangoQuery> Find(string? id, string? idlote, string? idnivel);
    }
    public class QCRangoQueryService : IQCRangoQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public QCRangoQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QCRangoQuery> Get(string? id, string? idlote, string? idnivel)
        {
            try
            {
                QCRangoQuery qCRangoQueries = new QCRangoQuery();

                var rango = await (from ra in _dbContext.QCRango
                                   join ex in _dbContext.Examen on ra.IdExamen equals ex.IdExamen
                                   where
                                   ra.IdReactivoDet == id &&
                                   ra.IdLote == idlote &&
                                   ra.IdNivel == idnivel &&
                                    ra.Estado != States.Eliminado
                                   select new QCRangoDetQuery
                                   {
                                       IdReactivoDet = ra.IdReactivoDet,
                                       IdQCRango = ra.IdQCRango,
                                       IdExamen = ra.IdExamen,
                                       IdLote = ra.IdLote,
                                       IdNivel = ra.IdNivel,
                                       RangoMinimo = ra.RangoMinimo,
                                       RangoMedio = ra.RangoMedio,
                                       RangoMaximo = ra.RangoMaximo,
                                       Desviacion = ra.Desviacion,
                                       NombreExamen = ex.Nombre
                                   }).ToListAsync();

                var listaIdExamen = rango.Select(y => y.IdExamen).ToList();

                var examen = await (from ra in _dbContext.ReactivoExamen
                                    join ex in _dbContext.Examen on ra.IdExamen equals ex.IdExamen
                                    where
                                     (ra.IdReactivoDet == id) &&
                                     (listaIdExamen.Count == 0 || !listaIdExamen.Contains(ra.IdExamen)) &&
                                     (ra.Estado != States.Eliminado)
                                    select new QCRangoDetQuery
                                    {
                                        IdReactivoDet = ra.IdReactivoDet,
                                        IdExamen = ra.IdExamen,
                                        NombreExamen = ex.Nombre
                                    }).ToListAsync();

                var fechaExperacion = await (from lo in _dbContext.Lote
                                             where
                                             lo.IdLote == idlote &&
                                              lo.Estado != States.Eliminado
                                             select lo.FechaExpiracion).FirstOrDefaultAsync();


                qCRangoQueries.FechaExpiracion = (fechaExperacion == null) ? "" : fechaExperacion.Value.ToString("dd-MM-yyyy");


                qCRangoQueries.ListaQCRangoDet.AddRange(rango);
                qCRangoQueries.ListaQCRangoDet.AddRange(examen);

                return qCRangoQueries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<QCRangoQuery> Find(string? id, string? idlote, string? idnivel)
        {
            try
            {
                QCRangoQuery qCRangoQueries = new QCRangoQuery();

                var lote = await (from lo in _dbContext.Lote
                                  where
                                  lo.IdReactivoDet == id &&
                                   lo.Estado != States.Eliminado
                                  select new OptionQuery
                                  {
                                      Id = lo.IdLote,
                                      Nombre = lo.Nombre,
                                      Tipo = Forms.Lote
                                  }).ToListAsync();

                var nivel = await (from ni in _dbContext.Nivel
                                   where
                                    ni.IdReactivoDet == id &&
                                   ni.Estado != States.Eliminado
                                   select new OptionQuery
                                   {
                                       Id = ni.IdNivel,
                                       Nombre = ni.Nombre,
                                       Tipo = Forms.Nivel
                                   }).ToListAsync();

                var reactivo = await (from ni in _dbContext.ReactivoDet
                                      join ex in _dbContext.Examen on ni.IdExamen equals ex.IdExamen into leftExamen
                                      from ex in leftExamen.DefaultIfEmpty()
                                      where
                                       ni.IdReactivoDet == id &&
                                      ni.Estado != States.Eliminado
                                      select (ni.IdExamen == null || ni.IdExamen == "") ? ni.Nombre : ex.Nombre).FirstOrDefaultAsync();

                qCRangoQueries.NombreControl = reactivo;
                qCRangoQueries.IdLote = (lote.Count != 0) ? (!string.IsNullOrEmpty(idlote) ? idlote : lote.FirstOrDefault()!.Id) : null;
                qCRangoQueries.IdNivel = (nivel.Count != 0) ? (!string.IsNullOrEmpty(idnivel) ? idnivel : nivel.FirstOrDefault()!.Id) : null;

                if (!string.IsNullOrEmpty(idlote))
                {
                    qCRangoQueries.FechaExpiracion = _dbContext.Lote.AsNoTracking().Where(y => y.IdLote == idlote).FirstOrDefault()!.FechaExpiracion!.Value.ToString("dd-MM-yyyy");
                }
                else
                {
                    qCRangoQueries.FechaExpiracion = (lote.Count != 0) ? _dbContext.Lote.AsNoTracking().Where(y => y.IdLote == lote.FirstOrDefault()!.Id).FirstOrDefault()!.FechaExpiracion!.Value.ToString("dd-MM-yyyy") : null;
                }

                qCRangoQueries.ListaOpciones.AddRange(lote!);
                qCRangoQueries.ListaOpciones.AddRange(nivel!);

                return qCRangoQueries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
