using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Laboratory.Service.Queries
{
    public interface IOrdenQueryService
    {
        Task<DataCollection<OrdenQuery>> ListarOrden(OrdenReqQuery ordenReqQuery);
        Task<OrdenQuery> Find(string? id, string? usuario);
        Task<List<OrdenExamenQuery>> FindExamen(string? id, string idarea, string? usuario);
        Task<List<OptionQuery>> Option(string? usuario);
        Task<List<OrdenExamenQuery>> Examen(string? id, string idArea, string? text);
        Task<ReporteQuery> ValTipoMuestra(RequestReport request);
    }
    public class OrdenQueryService : IOrdenQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public OrdenQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<OrdenQuery>> ListarOrden(OrdenReqQuery ordenReqQuery)
        {
            try
            {
                DataCollection<OrdenQuery> orden = null!;

                var usuarioRol = await (from ro in _dbContext.UsuarioRol.AsNoTracking()
                                        join us in _dbContext.Usuario.AsNoTracking() on ro.IdUsuario equals us.IdUsuario
                                        where
                                        us.UserName == ordenReqQuery.Usuario
                                        select new UsuarioQuery
                                        {
                                            IdUsuario = us.IdUsuario,
                                            IdRol = ro.IdRol
                                        }).ToListAsync();

                var superUsuario = usuarioRol.Any(y => y.IdRol == User.SuperUsuario);

                ordenReqQuery.Idlab = (superUsuario) ? null : ordenReqQuery.Idlab;
                ordenReqQuery.Idarea = (superUsuario) ? null : ordenReqQuery.Idarea;
                ordenReqQuery.Valor = (string.IsNullOrEmpty(ordenReqQuery.Valor)) ? null : ordenReqQuery.Valor;
                ordenReqQuery.Estado = (string.IsNullOrEmpty(ordenReqQuery.Estado)) ? null : ordenReqQuery.Estado;
                ordenReqQuery.Page = 0;
                ordenReqQuery.Pages = 1000;

                if (ordenReqQuery.TipoOrden == Opciones.PorOrden)
                {
                    List<string> listaId = new List<string>();

                    var queryOrden = await (from oe in _dbContext.OrdenExamen.AsNoTracking()
                                            where
                                            (ordenReqQuery.Idlab == null || oe.IdLaboratorio == ordenReqQuery.Idlab) &&
                                            (ordenReqQuery.Idarea == null || oe.IdArea == ordenReqQuery.Idarea) &&
                                            (ordenReqQuery.Valor == null || oe.Orden!.NroOrden!.Contains(ordenReqQuery.Valor!)) &&
                                            (ordenReqQuery.Estado == null || oe.Estado == ordenReqQuery.Estado) &&
                                            (ordenReqQuery.Desde == null || oe.Orden!.FechaOrden!.Value.Date >= ordenReqQuery.Desde!.Value.Date) &&
                                            (ordenReqQuery.Hasta == null || oe.Orden!.FechaOrden!.Value.Date <= ordenReqQuery.Hasta!.Value.Date)
                                            select oe.IdOrden).Distinct().GetPagedAsync(ordenReqQuery.Page, ordenReqQuery.Pages);

                    var listaIdOrden = (queryOrden.Items == null) ? listaId : queryOrden!.Items.Select(y => y).ToList();


                    orden = await (from or in _dbContext.Orden.AsNoTracking()
                                   join op in _dbContext.OrdenPaciente.AsNoTracking() on or.IdOrden equals op.IdOrden
                                   join pa in _dbContext.Paciente.AsNoTracking() on op.IdPaciente equals pa.IdPaciente
                                   join pe in _dbContext.Persona.AsNoTracking() on pa.IdPersona equals pe.IdPersona

                                   join pr in _dbContext.Procedencia.AsNoTracking() on op.IdProcedencia equals pr.IdProcedencia into leftPro
                                   from pr in leftPro.DefaultIfEmpty()

                                   join sr in _dbContext.Servicio.AsNoTracking() on op.IdServicio equals sr.IdServicio into leftServ
                                   from sr in leftServ.DefaultIfEmpty()

                                   join me in _dbContext.Medico.AsNoTracking() on op.IdMedico equals me.IdMedico into leftMedi
                                   from me in leftMedi.DefaultIfEmpty()

                                   join se in _dbContext.TablaMaestra.AsNoTracking() on pe.IdSexo equals se.Codigo

                                   join mae in _dbContext.TablaMaestra.AsNoTracking() on or.Estado equals mae.Codigo

                                   where
                                   se.Tabla == Opciones.Sexo &&
                                   mae.Tabla == Opciones.States &&
                                   listaIdOrden.Contains(or.IdOrden!)
                                   select new OrdenQuery
                                   {
                                       IdOrden = or.IdOrden,
                                       IdOrdenExamen = null,
                                       IdLaboratorio = null,
                                       IdArea = null,
                                       NroOrden = or.NroOrden,
                                       NroAtencion = or.NroAtencion,
                                       FechaOrden = or.FechaOrden,
                                       Estado = mae.Nombre,
                                       Color = mae.Color,
                                       NroDocumento = pe.NroDocumento,
                                       ApePaterno = pe.ApePaterno,
                                       ApeMaterno = pe.ApeMaterno,
                                       Nombre = pe.Nombre,
                                       FechaNacimiento = pe.FechaNacimiento,
                                       IdSexo = se.Nombre,
                                       IdProcedencia = pr.Nombre,
                                       IdMedico = me.Persona!.ApePaterno + ' ' + me.Persona!.Nombre,
                                       IdServicio = sr.Nombre
                                   }).GetPagedAsync(ordenReqQuery.Page, ordenReqQuery.Pages, "NroOrden", "asc");

                }
                else if (ordenReqQuery.TipoOrden == Opciones.PorExamen)
                {

                    orden = await (from oe in _dbContext.OrdenExamen.AsNoTracking()

                                   join or in _dbContext.Orden.AsNoTracking() on oe.IdOrden equals or.IdOrden into leftOrden
                                   from or in leftOrden.DefaultIfEmpty()

                                   join op in _dbContext.OrdenPaciente.AsNoTracking() on or.IdOrden equals op.IdOrden
                                   join pa in _dbContext.Paciente.AsNoTracking() on op.IdPaciente equals pa.IdPaciente
                                   join pe in _dbContext.Persona.AsNoTracking() on pa.IdPersona equals pe.IdPersona

                                   join ex in _dbContext.Examen.AsNoTracking() on oe.IdExamen equals ex.IdExamen into leftExamen
                                   from ex in leftExamen.DefaultIfEmpty()

                                   join se in _dbContext.TablaMaestra.AsNoTracking() on pe.IdSexo equals se.Codigo

                                   join mae in _dbContext.TablaMaestra.AsNoTracking() on oe.Estado equals mae.Codigo into leftMaestro
                                   from mae in leftMaestro.DefaultIfEmpty()

                                   where
                                   se.Tabla == Opciones.Sexo &&
                                   mae.Tabla == Opciones.PorEstado &&
                                   (ordenReqQuery.Idlab == null || oe.IdLaboratorio == ordenReqQuery.Idlab) &&
                                   (ordenReqQuery.Idarea == null || oe.IdArea == ordenReqQuery.Idarea) &&
                                   (ordenReqQuery.Valor == null || or.NroOrden!.Contains(ordenReqQuery.Valor!)) &&
                                   (ordenReqQuery.Estado == null || oe.Estado == ordenReqQuery.Estado) &&
                                   (ordenReqQuery.Desde == null || oe.Orden!.FechaOrden!.Value.Date >= ordenReqQuery.Desde!.Value.Date) &&
                                   (ordenReqQuery.Hasta == null || oe.Orden!.FechaOrden!.Value.Date <= ordenReqQuery.Hasta!.Value.Date)
                                   select new OrdenQuery
                                   {
                                       IdOrden = oe.IdOrden,
                                       IdOrdenExamen = oe.IdOrdenExamen,
                                       IdLaboratorio = oe.IdLaboratorio,
                                       IdArea = oe.IdArea,

                                       NroOrden = or.NroOrden,
                                       NroAtencion = or.NroAtencion,
                                       FechaOrden = or.FechaOrden,
                                       FechaResultado = oe.FechaResultado,

                                       NroDocumento = pe.NroDocumento,
                                       ApePaterno = pe.ApePaterno,
                                       ApeMaterno = pe.ApeMaterno,
                                       Nombre = pe.Nombre,

                                       Estado = mae.Nombre,
                                       Color = mae.Color,

                                       Resultado = oe.Resultado,

                                       FechaNacimiento = pe.FechaNacimiento,
                                       IdSexo = se.Nombre,
                                       IdProcedencia = op.IdProcedencia,
                                       IdMedico = op.IdMedico,
                                       IdServicio = op.IdServicio,

                                       UnidadMedida = ex.UnidadMedida,
                                       Examen = ex.Nombre
                                   }).GetPagedAsync(ordenReqQuery.Page, ordenReqQuery.Pages, "NroOrden", "asc");
                }

                return orden!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrdenQuery> Find(string? id, string? usuario)
        {
            try
            {
                OrdenQuery? ordenQuery = new OrdenQuery();

                List<string> options = new List<string>();
                options.Add(Opciones.Sexo);
                options.Add(Opciones.TipoDocumento);

                var usuarioRol = await (from ro in _dbContext.UsuarioRol
                                        join us in _dbContext.Usuario on ro.IdUsuario equals us.IdUsuario
                                        where
                                        us.UserName == usuario
                                        select new UsuarioQuery
                                        {
                                            IdUsuario = us.IdUsuario,
                                            IdRol = ro.IdRol
                                        }).ToListAsync();

                var superUsuario = usuarioRol.Any(y => y.IdRol == User.SuperUsuario);

                if (!string.IsNullOrEmpty(id))
                {
                    ordenQuery = await (from or in _dbContext.Orden
                                        join op in _dbContext.OrdenPaciente on or.IdOrden equals op.IdOrden
                                        join pa in _dbContext.Paciente on op.IdPaciente equals pa.IdPaciente
                                        join pe in _dbContext.Persona on pa.IdPersona equals pe.IdPersona
                                        where
                                        or.IdOrden == id
                                        select new OrdenQuery
                                        {
                                            IdTipoDocu = pe.IdTipoDocu,
                                            NroDocumento = pe.NroDocumento,
                                            ApePaterno = pe.ApePaterno,
                                            ApeMaterno = pe.ApeMaterno,
                                            Nombre = pe.Nombre,
                                            IdSexo = pe.IdSexo,
                                            FechaNacimiento = pe.FechaNacimiento,
                                            HistoriaClinica = op.HistoriaClinica,

                                            IdLaboratorio = null,
                                            IdArea = null,

                                            IdOrden = or.IdOrden,
                                            IdPaciente = op.IdPaciente,
                                            NroOrden = or.NroOrden,
                                            NroAtencion = or.NroAtencion,
                                            FechaOrden = or.FechaOrden,
                                            IdProcedencia = op.IdProcedencia,
                                            IdServicio = op.IdServicio,
                                            IdMedico = op.IdMedico,
                                            IdOrigen = op.IdOrigen,
                                            Cama = or.Cama
                                        }).FirstOrDefaultAsync();

                    if (ordenQuery != null)
                    {
                        ordenQuery!.Edad = Configurations.calcularEdad(ordenQuery.FechaNacimiento);
                    }
                    else
                    {
                        ordenQuery = new OrdenQuery();
                    }
                }

                var listadoMaestro = await (from ta in _dbContext.TablaMaestra
                                            where
                                             ta.Codigo != Opciones.AMBOS &&
                                            options.Contains(ta.Tabla!)
                                            select new OptionQuery
                                            {
                                                Id = ta.Codigo,
                                                Nombre = ta.Nombre,
                                                Tipo = ta.Tabla
                                            }).ToListAsync();

                var listadoProce = await (from pr in _dbContext.Procedencia
                                          where
                                          pr.Estado == States.Activo
                                          select new OptionQuery
                                          {
                                              Id = pr.IdProcedencia,
                                              Nombre = pr.Nombre,
                                              Tipo = Forms.Procedencia
                                          }).ToListAsync();

                var listadoServ = await (from sr in _dbContext.Servicio
                                         where
                                         sr.Estado == States.Activo
                                         select new OptionQuery
                                         {
                                             Id = sr.IdServicio,
                                             Nombre = sr.Nombre,
                                             Tipo = Forms.Servicio
                                         }).ToListAsync();

                var listadoOri = await (from or in _dbContext.Origen
                                        where
                                        or.Estado == States.Activo
                                        select new OptionQuery
                                        {
                                            Id = or.IdOrigen,
                                            Nombre = or.Nombre,
                                            Tipo = Forms.Origen
                                        }).ToListAsync();

                var listadoMed = await (from me in _dbContext.Medico
                                        where
                                       me.Estado == States.Activo
                                        select new OptionQuery
                                        {
                                            Id = me.IdMedico,
                                            Nombre = me.Persona!.ApePaterno + ' ' + me.Persona!.ApeMaterno + ' ' + me.Persona!.Nombre,
                                            Tipo = Forms.Medico
                                        }).ToListAsync();

                if (superUsuario)
                {
                    var listadoAre = await (from ar in _dbContext.Area
                                            where
                                            ar.Estado == States.Activo &&
                                            ar.IdArea != UserLaboratorio.Emergencia
                                            select new OptionQuery
                                            {
                                                Id = ar.IdArea,
                                                Nombre = ar.Nombre,
                                                Tipo = Forms.Area
                                            }).ToListAsync();

                    ordenQuery!.ListaOpciones.AddRange(listadoAre);
                }
                else
                {
                    var idUsuario = usuarioRol.FirstOrDefault()!.IdUsuario!;

                    var usuarioArea = await (from us in _dbContext.UsuarioArea
                                             join ar in _dbContext.Area on us.IdArea equals ar.IdArea
                                             where
                                             us.IdUsuario == idUsuario
                                             select new ExamenQuery
                                             {
                                                 IdArea = ar.IdArea,
                                                 IdLaboratorio = ar.IdLaboratorio,
                                             }).FirstOrDefaultAsync();

                    var idarea = (usuarioArea!.IdArea == UserLaboratorio.Emergencia) ? null : usuarioArea!.IdArea;

                    var listadoAre = await (from ar in _dbContext.Area
                                            where
                                            (idarea == null || ar.IdArea == idarea) &&
                                            ar.IdArea != UserLaboratorio.Emergencia &&
                                            ar.Estado == States.Activo
                                            select new OptionQuery
                                            {
                                                Id = ar.IdArea,
                                                Nombre = ar.Nombre,
                                                Tipo = Forms.Area
                                            }).ToListAsync();

                    ordenQuery!.ListaOpciones.AddRange(listadoAre);
                }

                ordenQuery!.ListaOpciones.AddRange(listadoMaestro);
                ordenQuery!.ListaOpciones.AddRange(listadoProce);
                ordenQuery!.ListaOpciones.AddRange(listadoServ);
                ordenQuery!.ListaOpciones.AddRange(listadoOri);
                ordenQuery!.ListaOpciones.AddRange(listadoMed);


                return ordenQuery!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrdenExamenQuery>> FindExamen(string? id, string idarea, string? usuario)
        {
            try
            {
                var ordenExamenQuery = new List<OrdenExamenQuery>();

                var usuarioArea = await (from usa in _dbContext.UsuarioArea.AsNoTracking()
                                         join us in _dbContext.Usuario.AsNoTracking() on usa.IdUsuario equals us.IdUsuario
                                         join ar in _dbContext.Area.AsNoTracking() on usa.IdArea equals ar.IdArea
                                         where
                                         us.UserName == usuario
                                         select new ExamenQuery
                                         {
                                             IdArea = ar.IdArea,
                                             IdLaboratorio = ar.IdLaboratorio,
                                         }).FirstOrDefaultAsync();

                var ordenExamen = await (from oe in _dbContext.OrdenExamen.AsNoTracking()
                                         join ex in _dbContext.Examen.AsNoTracking() on oe.IdExamen equals ex.IdExamen

                                         join mae in _dbContext.TablaMaestra on oe.Estado equals mae.Codigo into leftMaestro
                                         from mae in leftMaestro.DefaultIfEmpty()
                                         where
                                         oe.IdOrden == id &&
                                         (usuarioArea == null || oe.IdLaboratorio == usuarioArea!.IdLaboratorio) &&
                                         (idarea == "TODOS" || oe.IdArea == idarea) &&
                                         mae.Tabla == Opciones.PorEstado
                                         select new OrdenExamenQuery
                                         {

                                             IdOrdenExamen = oe.IdOrdenExamen,
                                             IdOrden = oe.IdOrden,
                                             IdExamen = oe.IdExamen,
                                             IdLaboratorio = oe.IdLaboratorio,
                                             IdArea = oe.IdArea,

                                             Abreviatura = ex.Abreviatura,
                                             NombreExamen = ex.Nombre,
                                             Resultado = oe.Resultado,
                                             UnidadMedida = ex.UnidadMedida,
                                             Observacion = oe.Observacion,

                                             Referencia = ex.RangoMostrar,
                                             FechaResultado = oe.FechaResultado,

                                             Estado = mae.Nombre,
                                             Color = mae.Color,

                                             Validado = (oe.Estado == States.Validado) ? true : false
                                         }).ToListAsync();

                var listIdExamen = ordenExamen.Select(y => y.IdExamen).ToList();

                var examenRango = await (from er in _dbContext.ExamenRango.AsNoTracking()
                                         where
                                         listIdExamen.Contains(er.IdExamen) &&
                                         er.Estado == States.Activo
                                         select new ExamenRangoQuery
                                         {
                                             IdExamen = er.IdExamen,
                                             StrValorMinimo = er.ValorMinimo,
                                             StrValorMaximo = er.ValorMaximo
                                         }).ToListAsync();

                foreach (var item in ordenExamen)
                {
                    var resultado = (string.IsNullOrEmpty(item.Resultado)) ? 0 : Convert.ToDecimal(item.Resultado);
                    var valorMinimo = examenRango.FirstOrDefault(y => y.IdExamen == item.IdExamen)?.ValorMinimo;
                    var valorMaximo = examenRango.FirstOrDefault(y => y.IdExamen == item.IdExamen)?.ValorMaximo;

                    item.SimboloResulatdo = (valorMinimo == null && valorMaximo == null) ? "" :
                                            (resultado <= valorMaximo && resultado >= valorMinimo) ? "" : ((resultado < valorMinimo) ? "pi-angle-double-down" : "pi-angle-double-up");
                }

                ordenExamenQuery = ordenExamen;

                return ordenExamenQuery!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OptionQuery>> Option(string? usuario)
        {
            try
            {
                List<OptionQuery> optionQueries = new List<OptionQuery>();

                List<string> options = new List<string>();
                options.Add(Opciones.TipoOrden);
                options.Add(Opciones.PorEstado);


                var usuarioRol = await _dbContext.UsuarioRol
                                        .AsNoTracking()
                                        .Where(us => us.Usuario!.UserName == usuario)
                                        .Select(us => new UsuarioQuery
                                        {
                                            IdUsuario = us.IdUsuario,
                                            IdRol = us.IdRol
                                        }).ToListAsync();

                var superUsuario = usuarioRol.Any(y => y.IdRol == User.SuperUsuario);

                if (superUsuario)
                {
                    var laboratorio = await _dbContext.Laboratorio
                                             .AsNoTracking()
                                             .Select(la => new OptionQuery
                                             {
                                                 Id = la.IdLaboratorio,
                                                 Nombre = la.Nombre,
                                                 Tipo = Forms.Laboratorio
                                             }).ToListAsync();

                    var area = await _dbContext.Area
                                      .AsNoTracking()
                                      .Where(ar => ar.IdArea != UserLaboratorio.Emergencia)
                                      .Select(ar => new OptionQuery
                                      {
                                          Id = ar.IdArea,
                                          Nombre = ar.Nombre,
                                          Tipo = Forms.Area
                                      }).ToListAsync();

                    var listadoMaestro = await (from ta in _dbContext.TablaMaestra.AsNoTracking()
                                                where
                                                options.Contains(ta.Tabla!)
                                                select new OptionQuery
                                                {
                                                    Id = ta.Codigo,
                                                    Nombre = ta.Nombre,
                                                    Tipo = ta.Tabla
                                                }).ToListAsync();

                    optionQueries.AddRange(listadoMaestro);
                    optionQueries.AddRange(laboratorio);
                    optionQueries.AddRange(area);
                }
                else
                {
                    var idUsuario = usuarioRol.FirstOrDefault()!.IdUsuario!;

                    var usuarioArea = await _dbContext.UsuarioArea
                                             .AsNoTracking()
                                             .Where(us => us.IdUsuario == idUsuario)
                                             .Select(us => new ExamenQuery
                                             {
                                                 IdArea = us.Area!.IdArea,
                                                 IdLaboratorio = us.Area!.IdLaboratorio,
                                             }).FirstOrDefaultAsync();

                    var laboratorio = await _dbContext.Laboratorio
                                             .AsNoTracking()
                                             .Where(la => la.IdLaboratorio == usuarioArea!.IdLaboratorio)
                                             .Select(la => new OptionQuery
                                             {
                                                 Id = la.IdLaboratorio,
                                                 Nombre = la.Nombre,
                                                 Tipo = Forms.Laboratorio
                                             }).ToListAsync();

                    var idarea = (usuarioArea!.IdArea == UserLaboratorio.Emergencia) ? null : usuarioArea!.IdArea;

                    var area = await (from ar in _dbContext.Area.AsNoTracking()
                                      where
                                      (idarea == null || ar.IdArea == idarea) &&
                                      ar.IdArea != UserLaboratorio.Emergencia
                                      select new OptionQuery
                                      {
                                          Id = ar.IdArea,
                                          Nombre = ar.Nombre,
                                          Tipo = Forms.Area
                                      }).ToListAsync();


                    var listadoMaestro = await (from ta in _dbContext.TablaMaestra.AsNoTracking()
                                                where
                                                options.Contains(ta.Tabla!)
                                                select new OptionQuery
                                                {
                                                    Id = ta.Codigo,
                                                    Nombre = ta.Nombre,
                                                    Tipo = ta.Tabla
                                                }).ToListAsync();

                    optionQueries.AddRange(listadoMaestro);
                    optionQueries.AddRange(laboratorio);
                    optionQueries.AddRange(area);
                }

                return optionQueries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrdenExamenQuery>> Examen(string? id, string idArea, string? text)
        {
            try
            {
                List<OrdenExamenQuery> ordenExamenQuery = new List<OrdenExamenQuery>();
                List<string> listaIdExamen = new List<string>();

                if (!string.IsNullOrEmpty(id))
                {
                    listaIdExamen = await (from or in _dbContext.OrdenExamen
                                           where
                                           or.IdOrden == id &&
                                           or.Estado != States.Eliminado &&
                                           or.Estado != States.Desactivado
                                           select or.IdExamen).ToListAsync();
                }

                var ordenExamen = await (from ex in _dbContext.Examen
                                         where
                                          (idArea == "TODOS" || ex.IdArea == idArea) &&
                                          ((string.IsNullOrEmpty(text) || ex.Nombre == text) ||
                                          (string.IsNullOrEmpty(text) || ex.Abreviatura == text)) &&
                                         ex.Estado == States.Activo &&
                                         !listaIdExamen.Contains(ex.IdExamen!)
                                         select new OrdenExamenQuery
                                         {
                                             Abreviatura = ex.Abreviatura,
                                             IdExamen = ex.IdExamen,
                                             NombreExamen = ex.Nombre,
                                             Resultado = null
                                         }).ToListAsync();


                ordenExamenQuery = ordenExamen;

                return ordenExamenQuery!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReporteQuery> ValTipoMuestra(RequestReport request)
        {
            try
            {
                ReporteQuery reporteQuery = new ReporteQuery();


                var idExamen = await (from or in _dbContext.OrdenExamen
                                      where
                                      request.Data!.Contains(or.IdOrden!)
                                      select or.IdExamen).ToListAsync();

                var idTipoMuestra = await (from ex in _dbContext.Examen
                                           where
                                           idExamen!.Contains(ex.IdExamen!)
                                           select ex.IdTipoMuestra).ToListAsync();

                var tipoMuestra = await (from ti in _dbContext.TipoMuestra
                                         where
                                         idTipoMuestra!.Contains(ti.IdTipoMuestra!)
                                         select new TipoMuestraQuery
                                         {
                                             Key = ti.IdTipoMuestra,
                                             Label = ti.Nombre,
                                             PartialSelected = false
                                         }).ToListAsync();

                var equipoMedico = await (from eqx in _dbContext.EquipoMedicoExamen
                                          join eqm in _dbContext.EquipoMedico on eqx.IdEquipoMedico equals eqm.IdEquipoMedico
                                          where eqm.Estado != States.Eliminado && idExamen!.Contains(eqx.IdExamen!)
                                          group eqm by eqm.IdEquipoMedico into equipoGroup
                                          select new OptionQuery
                                          {
                                              Id = equipoGroup.Key,
                                              Tipo = Forms.EquipoMedico,
                                              Nombre = equipoGroup.Select(y => y.Nombre).FirstOrDefault()
                                          }).ToListAsync();



                reporteQuery.ListaTipoMuestra.AddRange(tipoMuestra);
                reporteQuery.ListaOpciones.AddRange(equipoMedico);

                return reporteQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
