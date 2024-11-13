using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace QualityControl.Service.Queries
{
    public interface IReactivoQueryService
    {
        Task<DataCollection<ReactivoQuery>> Get(string? idarea, int page, int pages);
        Task<ReactivoQuery> Find(string? id);
    }
    public class ReactivoQueryService : IReactivoQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public ReactivoQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<ReactivoQuery>> Get(string? idarea, int page, int pages)
        {
            try
            {

                var reactivo = await (from re in _dbContext.Reactivo
                                      join eq in _dbContext.EquipoMedico on re.IdEquipoMedico equals eq.IdEquipoMedico
                                      join la in _dbContext.Laboratorio on eq.IdLaboratorio equals la.IdLaboratorio
                                      join ar in _dbContext.Area on eq.IdArea equals ar.IdArea
                                      join ta in _dbContext.TablaMaestra on re.Estado equals ta.Codigo
                                      where
                                       ta.Tabla == Opciones.States &&
                                       re.Estado != States.Eliminado
                                      select new ReactivoQuery
                                      {
                                          IdReactivo = re.IdReactivo,
                                          IdModo = re.IdModo,
                                          Codigo = re.Codigo,
                                          IdArea = ar.IdArea,
                                          Nombre = re.Nombre,
                                          NombreEquipo = eq.Nombre,
                                          NombreLaboratorio = la.Nombre,
                                          NombreArea = ar.Nombre,
                                      }).GetPagedAsync(page, pages);

                return reactivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReactivoQuery> Find(string? id)
        {
            try
            {
                ReactivoQuery reactivoQuery = new ReactivoQuery();

                if (!string.IsNullOrEmpty(id))
                {
                    var reactivo = await (from re in _dbContext.Reactivo
                                          join eq in _dbContext.EquipoMedico on re.IdEquipoMedico equals eq.IdEquipoMedico
                                          join la in _dbContext.Laboratorio on eq.IdLaboratorio equals la.IdLaboratorio
                                          join ar in _dbContext.Area on eq.IdArea equals ar.IdArea
                                          where
                                           re.IdReactivo == id
                                          select new ReactivoQuery
                                          {
                                              IdReactivo = re.IdReactivo,
                                              Codigo = re.Codigo,
                                              Nombre = re.Nombre,
                                              IdEquipoMedico = re.IdEquipoMedico,
                                              IdLaboratorio = la.IdLaboratorio,
                                              IdArea = ar.IdArea,
                                              IdModo = re.IdModo
                                          }).FirstOrDefaultAsync();

                    reactivoQuery = reactivo!;

                }

                var modo = await _dbContext
                                .TablaMaestra.AsNoTracking()
                                .Where(u => u.Tabla == Forms.Modo)
                                .Select(u => new OptionQuery
                                {
                                    Id = u.Codigo,
                                    Nombre = u.Nombre,
                                    Tipo = u.Tabla
                                }).ToListAsync();

                var equipo = await (from eq in _dbContext.EquipoMedico
                                    join la in _dbContext.Laboratorio on eq.IdLaboratorio equals la.IdLaboratorio
                                    join ar in _dbContext.Area on eq.IdArea equals ar.IdArea
                                    where
                                   eq.Estado == States.Activo
                                    select new OptionQuery
                                    {
                                        Id = eq.IdEquipoMedico,
                                        Nombre = la.Nombre + " | " + ar.Nombre + " | " + eq.Nombre,
                                        Tipo = Forms.EquipoMedico
                                    }).ToListAsync();

                reactivoQuery.ListaOpciones.AddRange(modo);
                reactivoQuery.ListaOpciones.AddRange(equipo);

                return reactivoQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
