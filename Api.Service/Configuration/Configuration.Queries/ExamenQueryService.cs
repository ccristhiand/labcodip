using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;


namespace Configuration.Service.Queries
{
    public interface IExamenQueryService
    {
        Task<DataCollection<ExamenQuery>> Get(string? valor, int page, int pages, string column);
        Task<ExamenQuery> Find(string? id);
        Task<DataCollection<ExamenQuery>> GetExamenPorEquiMedico(string? valor, string id, int page, int pages, string column);
        Task<DataCollection<ExamenQuery>> GetExamenPorSistemaExterno(string? valor, string id, int page, int pages, string column);
        Task<List<ExamenQuery>> GetExamenByIdArea(string? idArea, string? nombreExam);
    }
    public class ExamenQueryService : IExamenQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        public ExamenQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<ExamenQuery>> Get(string? valor, int page, int pages, string column)
        {

            try
            {
                var response = await (from e in _dbContext.Examen
                                      join t in _dbContext.TipoMuestra on e.IdTipoMuestra equals t.IdTipoMuestra
                                      join a in _dbContext.Area on e.IdArea equals a.IdArea
                                      join ta in _dbContext.TablaMaestra on e.Estado equals ta.Codigo
                                      where
                                      (valor == null || e.Nombre!.Contains(valor!) || e.Abreviatura!.Contains(valor!)) &&
                                      ta.Tabla == Opciones.States &&
                                      e.Estado != States.Eliminado
                                      select new ExamenQuery
                                      {
                                          IdExamen = e.IdExamen,
                                          Codigo = e.Codigo,
                                          Nombre = e.Nombre,
                                          Abreviatura = e.Abreviatura,
                                          NombreArea = a.Nombre,
                                          NombreTipoMuestra = t.Nombre,
                                          UnidadMedida = e.UnidadMedida,
                                          Estado = ta.Nombre,
                                          Color = ta.Color,
                                          TiempoTrackingMin = e.TiempoTrackingMin

                                      }).GetPagedAsync();

                return response!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExamenQuery> Find(string? id)
        {
            try
            {
                ExamenQuery examenQuery = new ExamenQuery();

                List<string> options = new List<string>();
                options.Add(Opciones.Sexo);
                options.Add(Opciones.Interpretado);
                options.Add(Opciones.TipoConfRango);
                options.Add(Opciones.SignoComparativo);
                options.Add(Opciones.Interpretado2);

                if (!String.IsNullOrEmpty(id))
                {
                    var examen = await (from e in _dbContext.Examen
                                        where
                                        e.IdExamen == id
                                        select new ExamenQuery
                                        {
                                            IdExamen = e.IdExamen,
                                            Codigo = e.Codigo,
                                            Nombre = e.Nombre,
                                            Abreviatura = e.Abreviatura,
                                            IdArea = e.IdArea,
                                            IdTipoMuestra = e.IdTipoMuestra,
                                            Calculado = e.Calculado,
                                            UnidadMedida = e.UnidadMedida,
                                            RangoMostrar = e.RangoMostrar,
                                            CantidadDecimal = e.CantidadDecimal,
                                            TipoCongRango = e.TipoCongRango,
                                            Color = e.Color,
                                            TiempoTrackingMin = e.TiempoTrackingMin
                                        }).FirstOrDefaultAsync();


                    var examenRango = await (from e in _dbContext.ExamenRango
                                             join ta in _dbContext.TablaMaestra on e.Estado equals ta.Codigo
                                             join re in _dbContext.TablaMaestra on e.IdInterpretado equals re.Codigo into leftResultado
                                             from re in leftResultado.DefaultIfEmpty()
                                             where
                                             e.IdExamen == id &&
                                             e.Estado != States.Eliminado
                                             select new ExamenRangoQuery
                                             {
                                                 IdExamenRango = e.IdExamenRango,
                                                 IdExamen = e.IdExamen,
                                                 IdInterpretado = e.IdInterpretado,
                                                 Interpretado = re.Nombre,
                                                 EdadInicio = e.EdadInicio,
                                                 EdadFinal = e.EdadFinal,
                                                 ValorMinimo = e.ValorMinimo,
                                                 ValorMaximo = e.ValorMaximo,
                                                 SigComparativo = e.SigComparativo,
                                                 Estado = ta.Nombre,
                                                 Color = ta.Color
                                             }).ToListAsync();


                    List<string> listaInterpretado1 = new List<string>();
                    listaInterpretado1.Add(Opciones.AMBOS);
                    listaInterpretado1.Add(Opciones.MASCULINO);
                    listaInterpretado1.Add(Opciones.FEMENINO);

                    List<string> listaInterpretado2 = new List<string>();
                    listaInterpretado2.Add(Opciones.POSITIVO);
                    listaInterpretado2.Add(Opciones.INDETERMI);
                    listaInterpretado2.Add(Opciones.NEGATIVO);

                    List<string> listaInterpretado3 = new List<string>();
                    listaInterpretado3.Add(Opciones.NOREACTIVO);
                    listaInterpretado3.Add(Opciones.INDETERMINADO);
                    listaInterpretado3.Add(Opciones.REACTIVO);

                    List<string> listaInterpretado4 = new List<string>();
                    listaInterpretado4.Add(Opciones.RangoNumerico);

                    examenQuery = examen!;
                    examenQuery.ListaExamenRango1 = examenRango.Where(y => listaInterpretado1.Contains(y.IdInterpretado!)).ToList();
                    examenQuery.ListaExamenRango2 = examenRango.Where(y => listaInterpretado2.Contains(y.IdInterpretado!)).ToList();
                    examenQuery.ListaExamenRango3 = examenRango.Where(y => listaInterpretado3.Contains(y.IdInterpretado!)).ToList();
                    examenQuery.ListaExamenRango4 = examenRango.Where(y => listaInterpretado4.Contains(y.IdInterpretado!)).ToList();

                }

                var listadoInterpretado = await (from ta in _dbContext.TablaMaestra
                                                 where
                                                 options.Contains(ta.Tabla!)
                                                 select new OptionQuery
                                                 {
                                                     Id = ta.Codigo,
                                                     Nombre = ta.Nombre,
                                                     Tipo = ta.Tabla
                                                 }).ToListAsync();

                var listadoArea = await (from ar in _dbContext.Area
                                         where
                                         ar.Estado == States.Activo &&
                                         ar.IdArea != UserLaboratorio.Emergencia
                                         select new OptionQuery
                                         {
                                             Id = ar.IdArea,
                                             Nombre = ar.Nombre,
                                             Tipo = Forms.Area
                                         }).ToListAsync();

                var listaTipoMuestra = await (from ti in _dbContext.TipoMuestra
                                              where
                                              ti.Estado == States.Activo
                                              select new OptionQuery
                                              {
                                                  Id = ti.IdTipoMuestra,
                                                  Nombre = ti.Nombre,
                                                  Tipo = Forms.TipoMuestra
                                              }).ToListAsync();


                examenQuery.ListaOpciones.AddRange(listadoInterpretado);
                examenQuery.ListaOpciones.AddRange(listadoArea);
                examenQuery.ListaOpciones.AddRange(listaTipoMuestra);

                return examenQuery!;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<DataCollection<ExamenQuery>> GetExamenPorEquiMedico(string? valor, string id, int page, int pages, string column)
        {

            try
            {
                var equipomecico = _dbContext.EquipoMedico.AsNoTracking().Where(y => y.IdEquipoMedico == id).FirstOrDefault();

                var idarea = (equipomecico != null) ? equipomecico!.IdArea : "";

                var listaIdExamen = _dbContext.EquipoMedicoExamen.AsNoTracking().Where(y => y.IdEquipoMedico == id && y.Estado != States.Eliminado).Select(y => y.IdExamen).ToList();


                var response = await (from e in _dbContext.Examen
                                      join t in _dbContext.TipoMuestra on e.IdTipoMuestra equals t.IdTipoMuestra
                                      join a in _dbContext.Area on e.IdArea equals a.IdArea
                                      join ta in _dbContext.TablaMaestra on e.Estado equals ta.Codigo
                                      where
                                      (valor == null || e.Nombre!.Contains(valor!) || e.Abreviatura!.Contains(valor!)) &&
                                      (ta.Tabla == Opciones.States) &&
                                      (!listaIdExamen.Contains(e.IdExamen)) &&
                                      (e.Estado != States.Eliminado) &&
                                      (a.IdArea == idarea)
                                      select new ExamenQuery
                                      {
                                          IdExamen = e.IdExamen,
                                          Codigo = e.Codigo,
                                          Nombre = e.Nombre,
                                          Abreviatura = e.Abreviatura,
                                          NombreArea = a.Nombre,
                                          NombreTipoMuestra = t.Nombre,
                                          UnidadMedida = e.UnidadMedida,
                                          Estado = ta.Nombre,
                                          Color = ta.Color
                                      }).GetPagedAsync(page, pages, column);

                return response!;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataCollection<ExamenQuery>> GetExamenPorSistemaExterno(string? valor, string id, int page, int pages, string column)
        {

            try
            {
                var listaIdExamen = (from e in _dbContext.SistemaClienteExamen
                                     where
                                     e.IdSistemaCliente == id &&
                                     e.Estado != States.Eliminado
                                     select e.IdExamen).ToList();


                var response = await (from e in _dbContext.Examen
                                      join t in _dbContext.TipoMuestra on e.IdTipoMuestra equals t.IdTipoMuestra
                                      join a in _dbContext.Area on e.IdArea equals a.IdArea
                                      join ta in _dbContext.TablaMaestra on e.Estado equals ta.Codigo
                                      where
                                      (valor == null || e.Nombre!.Contains(valor!) || e.Abreviatura!.Contains(valor!)) &&
                                      (ta.Tabla == Opciones.States) &&
                                      (!listaIdExamen.Contains(e.IdExamen)) &&
                                      (e.Estado != States.Eliminado)
                                      select new ExamenQuery
                                      {
                                          IdExamen = e.IdExamen,
                                          Codigo = e.Codigo,
                                          Nombre = e.Nombre,
                                          Abreviatura = e.Abreviatura,
                                          NombreArea = a.Nombre,
                                          NombreTipoMuestra = t.Nombre,
                                          UnidadMedida = e.UnidadMedida,
                                          Estado = ta.Nombre,
                                          Color = ta.Color
                                      }).GetPagedAsync(page, pages, column);

                return response!;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ExamenQuery>> GetExamenByIdArea(string? idArea, string? nombreExam)
        {
            try
            {
                var response = await (from e in _dbContext.Examen
                                      join t in _dbContext.TipoMuestra on e.IdTipoMuestra equals t.IdTipoMuestra
                                      join a in _dbContext.Area on e.IdArea equals a.IdArea
                                      join ta in _dbContext.TablaMaestra on e.Estado equals ta.Codigo
                                      where
                                      (nombreExam == null || e.Nombre!.Contains(nombreExam!) || e.Abreviatura!.Contains(nombreExam!)) &&
                                      (e.IdArea == idArea) &&
                                      (ta.Tabla == Opciones.States) &&
                                      (e.Estado == States.Activo)
                                      select new ExamenQuery
                                      {
                                          IdExamen = e.IdExamen,
                                          Codigo = e.Codigo,
                                          Nombre = e.Nombre,
                                          Abreviatura = e.Abreviatura,
                                          NombreArea = a.Nombre,
                                          NombreTipoMuestra = t.Nombre,
                                          UnidadMedida = e.UnidadMedida,
                                          Estado = ta.Nombre,
                                          Color = ta.Color
                                      }).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
