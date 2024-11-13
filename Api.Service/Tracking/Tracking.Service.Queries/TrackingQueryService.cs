using Common.Config;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Tracking.Service.Queries.Query;

namespace Tracking.Service.Queries
{
    public interface ITrackingQueryService
    {
        public Task<DataCollection<TrackingQuery>> GetTracking(DateTime? dateini, DateTime? DateFin, string text, int page, int pages);
    }
    public class TrackingQueryService : ITrackingQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public TrackingQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<TrackingQuery>> GetTracking(DateTime? Dateini, DateTime? DateFin, string? text, int page, int pages)
        {
            try
            {
                DataCollection<TrackingQuery> dataCollection = new DataCollection<TrackingQuery>();
                List<TrackingQuery> trackingQueries = new List<TrackingQuery>();
                List<TrackingQuery> Tracking =
                   await (from t in _dbContext.Tracking
                          join e in _dbContext.Examen on t.IdExamen equals e.IdExamen
                          join o in _dbContext.Orden on t.IdOrden equals o.IdOrden
                          join m in _dbContext.TipoMuestra on t.IdTipoMuestra equals m.IdTipoMuestra

                          where
                                t.FechaImpresionEtiqueta.Value.Date >= Dateini &&
                                t.FechaImpresionEtiqueta.Value.Date <= DateFin &&
                                      (o.NroOrden.Contains(text) ||
                                      m.Nombre.Contains(text) ||
                                      t.DocumentoPaciente.Contains(text) ||
                                      t.NombrePaciente.Contains(text) ||
                                      t.ApellidoMaternoPaciente.Contains(text) ||
                                      t.ApellidoPaternoPaciente.Contains(text) ||
                                      e.Nombre.Contains(text))

                          orderby t.IdTracking descending
                          select new TrackingQuery
                          {
                              IdTracking = t.IdTracking,
                              CodigoOrden = o.NroOrden,
                              TipoMuestra = m.Nombre,
                              ExamenName = e.Nombre,
                              DocumentoPaciente = t.DocumentoPaciente,
                              NombreCompletoPaciente = $"{t.NombrePaciente} {t.ApellidoPaternoPaciente} {t.ApellidoMaternoPaciente}",

                              EstadoImpresionEtiqueta = t.EstadoImpresionEtiqueta,
                              UsuarioImpresionEtiqueta = t.UsuarioImpresionEtiqueta,
                              FechaImpresionEtiqueta = t.FechaImpresionEtiqueta,

                              EstadoEnvioResultados = t.EstadoEnvioResultados,
                              UsuarioEnvioResultados = t.UsuarioEnvioResultados,
                              FechaEnvioResultados = t.FechaEnvioResultados,

                              EstadoValidacion = t.EstadoValidacion,
                              UsuarioValidacion = t.UsuarioValidacion,
                              FechaValidacion = t.FechaValidacion,
                              TimeTrackingMin = e.TiempoTrackingMin
                              //TiempoDeTracking = new TiempoDeTracking()
                              //{
                              //    MinutosInicioValidacion =
                              //            ObtenerMinutosSegundos(t.FechaImpresionEtiqueta==null?DateTime.Now:t.FechaImpresionEtiqueta.Value, t.FechaValidacion==null?DateTime.Now:t.FechaValidacion.Value, MinutosSegundos.Minutos),
                              //    SegundosInicioValidacion =
                              //            ObtenerMinutosSegundos(t.FechaImpresionEtiqueta == null ? DateTime.Now : t.FechaImpresionEtiqueta.Value, t.FechaValidacion == null ? DateTime.Now : t.FechaValidacion.Value, MinutosSegundos.Segundos),
                              //    MinutosInicioActual =
                              //            ObtenerMinutosSegundos(t.FechaImpresionEtiqueta == null ? DateTime.Now : t.FechaImpresionEtiqueta.Value, DateTime.Now, MinutosSegundos.Minutos),
                              //    SegundosInicioActual =
                              //            ObtenerMinutosSegundos(t.FechaImpresionEtiqueta == null ? DateTime.Now : t.FechaImpresionEtiqueta.Value, DateTime.Now, MinutosSegundos.Segundos),

                              //    Estadotracking =
                              //              GetEstadoTracking(e.TiempoTrackingMin,
                              //              ObtenerMinutosSegundos(t.FechaImpresionEtiqueta == null ? DateTime.Now : t.FechaImpresionEtiqueta.Value, t.FechaValidacion == null ? DateTime.Now : t.FechaValidacion.Value, MinutosSegundos.Minutos),
                              //              ObtenerMinutosSegundos(t.FechaImpresionEtiqueta == null ? DateTime.Now : t.FechaImpresionEtiqueta.Value, DateTime.Now, MinutosSegundos.Minutos),
                              //              t.EstadoValidacion
                              //            ),

                              //    EstadoColortracking =
                              //              GetEstadoColorTracking(e.TiempoTrackingMin,
                              //              ObtenerMinutosSegundos(t.FechaImpresionEtiqueta == null ? DateTime.Now : t.FechaImpresionEtiqueta.Value, t.FechaValidacion == null ? DateTime.Now : t.FechaValidacion.Value, MinutosSegundos.Minutos),
                              //              ObtenerMinutosSegundos(t.FechaImpresionEtiqueta == null ? DateTime.Now : t.FechaImpresionEtiqueta.Value, DateTime.Now, MinutosSegundos.Minutos),
                              //              t.EstadoValidacion)
                              //}

                          }).
                        ToListAsync();

                //GetPagedAsync(page,pages);

                foreach (var item in Tracking)
                {
                    TrackingQuery trackingQuery = new TrackingQuery();
                    trackingQuery = item;
                    trackingQuery.MinutosInicioValidacion =
                                    ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value,
                                    item.FechaValidacion == null ? DateTime.Now : item.FechaValidacion.Value, MinutosSegundos.Minutos);

                    trackingQuery.SegundosInicioValidacion =
                                    ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value,
                                    item.FechaValidacion == null ? DateTime.Now : item.FechaValidacion.Value, MinutosSegundos.Minutos);
                    trackingQuery.MinutosInicioActual =
                                    ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value,
                                    DateTime.Now, MinutosSegundos.Minutos);
                    trackingQuery.SegundosInicioActual =
                                    ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value
                                    , DateTime.Now, MinutosSegundos.Segundos);

                    trackingQuery.Estadotracking =
                            GetEstadoTracking(item.TimeTrackingMin,
                            ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value,
                                                    item.FechaValidacion == null ? DateTime.Now : item.FechaValidacion.Value, MinutosSegundos.Minutos),
                            ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value, DateTime.Now, MinutosSegundos.Minutos),
                            item.EstadoValidacion
                            );

                    trackingQuery.EstadoColortracking =
                            GetEstadoColorTracking(item.TimeTrackingMin,
                            ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value,
                                                    item.FechaValidacion == null ? DateTime.Now : item.FechaValidacion.Value, MinutosSegundos.Minutos),
                            ObtenerMinutosSegundos(item.FechaImpresionEtiqueta == null ? DateTime.Now : item.FechaImpresionEtiqueta.Value, DateTime.Now, MinutosSegundos.Minutos),
                            item.EstadoValidacion);
                    trackingQueries.Add(trackingQuery);
                }
                DateTime CombertDateNotNull(DateTime date)
                {
                    if (date == null)
                    {
                        return DateTime.Now;
                    }
                    else
                    {
                        return date;
                    }
                }

                dataCollection.Items = trackingQueries;
                return dataCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerMinutosSegundos(DateTime FechaInicio, DateTime FechaFin, MinutosSegundos minutosSegundos)
        {
            var Dif = FechaFin - FechaInicio;
            switch (minutosSegundos)
            {
                case MinutosSegundos.Minutos: return (int)Dif.TotalMinutes;
                case MinutosSegundos.Segundos: return (int)Dif.TotalSeconds;
                default: return 0;
            }
        }
        public EstadoTracking GetEstadoTracking(int? tiempoMinExamen, int MinutosInicioValidacion, int MinutosInicioActual, bool? estadovalidacion)
        {
            if (estadovalidacion == true)
            {
                if (tiempoMinExamen >= MinutosInicioValidacion)
                {
                    return EstadoTracking.Procesado;
                }
                else
                {
                    return EstadoTracking.FueraTiempo;
                }
            }
            else
            {
                if (tiempoMinExamen <= MinutosInicioActual)
                {
                    return EstadoTracking.Proceso;
                }
                else
                {
                    return EstadoTracking.SinAcciones;
                }
            }
        }
        public EstadoColortracking GetEstadoColorTracking(int? tiempoMinExamen, int MinutosInicioValidacion, int MinutosInicioActual, bool? estadovalidacion)
        {
            if (estadovalidacion == true)
            {
                if (tiempoMinExamen >= MinutosInicioValidacion)
                {
                    return EstadoColortracking.Green;
                }
                else
                {
                    return EstadoColortracking.Red;
                }
            }
            else
            {
                if (tiempoMinExamen >= MinutosInicioActual)
                {
                    return EstadoColortracking.Yellow;
                }
                else
                {
                    return EstadoColortracking.Gray;
                }

            }
        }
    }

    public enum MinutosSegundos
    {
        Minutos, Segundos
    }


}
