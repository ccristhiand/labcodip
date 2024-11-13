using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace QualityControl.Service.Queries
{
    public interface IQCResultadoQueryService
    {
        Task<QCResultadoQuery> GetArea();
        Task<QCResultadoQuery> GetControl(string id);
        Task<QCResultadoQuery> GetExamen(string id);
        Task<QCResultadoQuery> GetResultado(string? idreactivodet, string? idexamen, string? idlote, string? idnivel, DateTime? dateini, DateTime? datefin);
    }
    public class QCResultadoQueryService : IQCResultadoQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public QCResultadoQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QCResultadoQuery> GetArea()
        {
            try
            {
                QCResultadoQuery qCResultadoQuery = new QCResultadoQuery();

                var laboratorio = await _dbContext
                                   .Laboratorio.AsNoTracking()
                                   .Where(la => la.Estado == States.Activo)
                                   .Select(la => new OptionQuery
                                   {
                                       Id = la.IdLaboratorio,
                                       Nombre = la.Nombre,
                                       Tipo = Forms.Laboratorio
                                   }).ToListAsync();

                var area = await _dbContext
                                  .Area.AsNoTracking()
                                  .Where(ar => ar.Estado == States.Activo)
                                  .Select(ar => new OptionQuery
                                  {
                                      Id = ar.IdArea,
                                      Nombre = ar.Nombre,
                                      Tipo = Forms.Area
                                  }).ToListAsync();

                qCResultadoQuery.ListaOpciones.AddRange(laboratorio);
                qCResultadoQuery.ListaOpciones.AddRange(area);

                return qCResultadoQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<QCResultadoQuery> GetControl(string id)
        {
            try
            {
                QCResultadoQuery qCResultadoQuery = new QCResultadoQuery();

                var control = await (from de in _dbContext.ReactivoDet
                                     join re in _dbContext.Reactivo on de.IdReactivo equals re.IdReactivo
                                     join eq in _dbContext.EquipoMedico on re.IdEquipoMedico equals eq.IdEquipoMedico
                                     join ar in _dbContext.Area on eq.IdArea equals ar.IdArea
                                     where
                                      re.Estado != States.Eliminado &&
                                      ar.IdArea == id
                                     select new OptionQuery
                                     {
                                         Id = de.IdReactivoDet,
                                         Nombre = de.Nombre,
                                         Tipo = Forms.Control
                                     }).ToListAsync();

                qCResultadoQuery.ListaOpciones.AddRange(control);

                return qCResultadoQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<QCResultadoQuery> GetExamen(string id)
        {
            try
            {
                QCResultadoQuery qCResultadoQuery = new QCResultadoQuery();

                var loteNivel = await _dbContext
                                  .Lote.AsNoTracking()
                                  .Where(la => la.Estado != States.Eliminado && la.IdReactivoDet == id)
                                  .Select(la => new OptionQuery
                                  {
                                      Id = la.IdLote,
                                      Nombre = la.Nombre,
                                      Tipo = Forms.Lote
                                  }).Union(_dbContext
                                    .Nivel.AsNoTracking()
                                    .Where(la => la.Estado != States.Eliminado && la.IdReactivoDet == id)
                                    .Select(la => new OptionQuery
                                    {
                                        Id = la.IdNivel,
                                        Nombre = la.Nombre,
                                        Tipo = Forms.Nivel
                                    })).ToListAsync();

                var examen = await (from re in _dbContext.ReactivoExamen.AsNoTracking()
                                    join ex in _dbContext.Examen.AsNoTracking() on re.IdExamen equals ex.IdExamen into leftExamen
                                    from ex in leftExamen.DefaultIfEmpty()
                                    where
                                     re.Estado != States.Eliminado &&
                                     re.IdReactivoDet == id
                                    select new OptionQuery
                                    {
                                        Id = re.IdExamen,
                                        Nombre = ex.Nombre,
                                        Tipo = Forms.Examen
                                    }).ToListAsync();

                qCResultadoQuery.ListaOpciones.AddRange(loteNivel);
                qCResultadoQuery.ListaOpciones.AddRange(examen);

                return qCResultadoQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<QCResultadoQuery> GetResultado(string? idreactivodet, string? idexamen, string? idlote, string? idnivel, DateTime? dateini, DateTime? datefin)
        {
            try
            {
                QCResultadoQuery qCResultadoQuery = new QCResultadoQuery();
                ConfigRangoQuery rangoMaximo = new ConfigRangoQuery();
                ConfigRangoQuery rangoMinimo = new ConfigRangoQuery();
                ConfigRangoQuery rangoMedio = new ConfigRangoQuery();
                ConfigRangoQuery desviacion = new ConfigRangoQuery();

                var valorMedio = "0.00";
                var valorMaximo = "0.00";
                var valorMinimo = "0.00";

                var data = await _dbContext
                                      .QCResultado.AsNoTracking()
                                      .Where(la => la.IdReactivoDet == idreactivodet &&
                                             la.IdExamen == idexamen &&
                                             la.IdLote == idlote &&
                                             la.IdNivel == idnivel &&
                                             la.FechaResultado.Value.Date >= dateini && la.FechaResultado.Value.Date <= datefin
                                             )
                                      .Select(la => new ResultadoQuery
                                      {
                                          Resultado = la.Resultado,
                                          FechaResultado = la.FechaResultado,
                                          HoraResultado = la.HoraResultado,
                                      }).ToListAsync();

                var rango = await _dbContext
                                    .QCRango.AsNoTracking()
                                    .Where(la => la.IdReactivoDet == idreactivodet &&
                                           la.IdExamen == idexamen &&
                                           la.IdLote == idlote &&
                                           la.IdNivel == idnivel)
                                    .Select(la => new RangoQuery
                                    {
                                        RangoMaximo = la.RangoMaximo,
                                        RangoMedio = la.RangoMedio,
                                        RangoMinimo = la.RangoMinimo,
                                        Desviacion = la.Desviacion,
                                    }).FirstOrDefaultAsync();


                if (data.Count > 0)
                {
                    var resultadoSilac = data.Select(y => y.Resultado).ToList();
                    var resultadoEquipo = data.Select(y => y.Resultado).ToList();
                    var dia = data.Select(y => y.FechaResultado!.Value.ToString("dd/MM/yyyy")).ToList();

                    #region  WESTGARD POR SILAC
                    resultadoSilac.Add(rango!.RangoMaximo.ToString());
                    resultadoSilac.Add(rango!.RangoMedio.ToString());
                    resultadoSilac.Add(rango!.RangoMinimo.ToString());
                    #endregion

                    #region WESTGARD POR EL EQUIPO MEDICO
                    valorMedio = ((Convert.ToDecimal(resultadoEquipo.Max()) + Convert.ToDecimal(resultadoEquipo.Min())) / 2).ToString();
                    valorMaximo = resultadoEquipo.Max();
                    valorMinimo = resultadoEquipo.Min();

                    resultadoEquipo.Add(valorMedio);
                    #endregion

                    qCResultadoQuery.listaResultadoSilac = resultadoSilac!;
                    qCResultadoQuery.ListaResultadoEquipo = resultadoEquipo!;
                    qCResultadoQuery.ListaDia = dia!;
                }

                if (rango != null)
                {
                    #region  WESTGARD POR SILAC
                    rangoMaximo = new ConfigRangoQuery();
                    rangoMinimo = new ConfigRangoQuery();
                    rangoMedio = new ConfigRangoQuery();
                    desviacion = new ConfigRangoQuery();

                    qCResultadoQuery.RangoMedioSilac = rango!.RangoMedio;
                    qCResultadoQuery.DesviacionSilac = rango!.Desviacion;

                    rangoMinimo.Transaction = Transaccion.RangoMinimo;
                    rangoMinimo.Amount = rango!.RangoMinimo;
                    rangoMinimo.Icon = IconRango.RangoMinimo;
                    rangoMinimo.IconColor = ColorRango.RangoMinimo;
                    rangoMinimo.AmountColor = ColorRango.RangoMinimo;

                    rangoMedio.Transaction = Transaccion.RangoMedio;
                    rangoMedio.Amount = rango!.RangoMedio;
                    rangoMedio.Icon = IconRango.RangoMedio;
                    rangoMedio.IconColor = ColorRango.RangoMedio;
                    rangoMedio.AmountColor = ColorRango.RangoMedio;

                    desviacion.Transaction = Transaccion.Desviacion;
                    desviacion.Amount = rango!.Desviacion;
                    desviacion.Icon = IconRango.Desviacion;
                    desviacion.IconColor = ColorRango.Desviacion;
                    desviacion.AmountColor = ColorRango.Desviacion;

                    rangoMaximo.Transaction = Transaccion.RangoMaximo;
                    rangoMaximo.Amount = rango!.RangoMaximo;
                    rangoMaximo.Icon = IconRango.RangoMaximo;
                    rangoMaximo.IconColor = ColorRango.RangoMaximo;
                    rangoMaximo.AmountColor = ColorRango.RangoMaximo;

                    qCResultadoQuery.ListaConfigRangoSilac.Add(rangoMinimo);
                    qCResultadoQuery.ListaConfigRangoSilac.Add(rangoMedio);
                    qCResultadoQuery.ListaConfigRangoSilac.Add(desviacion);
                    qCResultadoQuery.ListaConfigRangoSilac.Add(rangoMaximo);
                    #endregion

                    #region WESTGARD POR EL EQUIPO MEDICO
                    rangoMaximo = new ConfigRangoQuery();
                    rangoMinimo = new ConfigRangoQuery();
                    rangoMedio = new ConfigRangoQuery();
                    desviacion = new ConfigRangoQuery();

                    qCResultadoQuery.RangoMedioEquipo = Convert.ToDecimal(valorMedio);
                    qCResultadoQuery.DesviacionEquipo = (Convert.ToDecimal(valorMaximo) - Convert.ToDecimal(valorMinimo)) / 4;

                    rangoMinimo.Amount = Convert.ToDecimal(valorMinimo);
                    rangoMinimo.Transaction = Transaccion.RangoMinimo;
                    rangoMinimo.Icon = IconRango.RangoMinimo;
                    rangoMinimo.IconColor = ColorRango.RangoMinimo;
                    rangoMinimo.AmountColor = ColorRango.RangoMinimo;

                    rangoMedio.Amount = Convert.ToDecimal(valorMedio);
                    rangoMedio.Transaction = Transaccion.RangoMedio;
                    rangoMedio.Icon = IconRango.RangoMedio;
                    rangoMedio.IconColor = ColorRango.RangoMedio;
                    rangoMedio.AmountColor = ColorRango.RangoMedio;

                    desviacion.Amount = (Convert.ToDecimal(valorMaximo) - Convert.ToDecimal(valorMinimo)) / 4;
                    desviacion.Transaction = Transaccion.Desviacion;
                    desviacion.Icon = IconRango.Desviacion;
                    desviacion.IconColor = ColorRango.Desviacion;
                    desviacion.AmountColor = ColorRango.Desviacion;

                    rangoMaximo.Amount = Convert.ToDecimal(valorMaximo);
                    rangoMaximo.Transaction = Transaccion.RangoMaximo;
                    rangoMaximo.Icon = IconRango.RangoMaximo;
                    rangoMaximo.IconColor = ColorRango.RangoMaximo;
                    rangoMaximo.AmountColor = ColorRango.RangoMaximo;

                    qCResultadoQuery.ListaConfigRangoEquipo.Add(rangoMinimo);
                    qCResultadoQuery.ListaConfigRangoEquipo.Add(rangoMedio);
                    qCResultadoQuery.ListaConfigRangoEquipo.Add(desviacion);
                    qCResultadoQuery.ListaConfigRangoEquipo.Add(rangoMaximo);
                    #endregion

                }


                qCResultadoQuery.ListaData = data!;

                return qCResultadoQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
