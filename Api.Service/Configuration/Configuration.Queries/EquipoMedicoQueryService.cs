using Common.Config;
using Common.Utility;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface IEquipoMedicoQueryService
    {
        Task<DataCollection<EquipoMedicoQuery>> Get(string? valor, int page, int pages, string column);
        Task<EquipoMedicoQuery> Find(string? id);
    }

    public class EquipoMedicoQueryService : IEquipoMedicoQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        public EquipoMedicoQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<EquipoMedicoQuery>> Get(string? valor, int page, int pages, string column)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var response = await (from e in _dbContext.EquipoMedico
                                      join ta in _dbContext.TablaMaestra on e.Estado equals ta.Codigo
                                      join la in _dbContext.Laboratorio on e.IdLaboratorio equals la.IdLaboratorio
                                      join ar in _dbContext.Area on e.IdArea equals ar.IdArea
                                      where
                                         (valor == null || e.Nombre!.Contains(valor!)) &&
                                         ta.Tabla == Opciones.States &&
                                         e.Estado != States.Eliminado
                                      select new EquipoMedicoQuery
                                      {
                                          IdEquipoMedico = e.IdEquipoMedico,
                                          Codigo = e.Codigo,
                                          Nombre = e.Nombre,
                                          NombreLaboratorio = la.Nombre,
                                          NombreArea = ar.Nombre,
                                          Detalle = e.Detalle,
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

        public async Task<EquipoMedicoQuery> Find(string? id)
        {
            try
            {
                EquipoMedicoQuery equipoMedicoQuery = new EquipoMedicoQuery();

                if (!string.IsNullOrEmpty(id))
                {
                    var equipo = await (from e in _dbContext.EquipoMedico
                                        where
                                        e.IdEquipoMedico == id
                                        select new EquipoMedicoQuery
                                        {
                                            IdEquipoMedico = e.IdEquipoMedico,
                                            Nombre = e.Nombre,
                                            Detalle = e.Detalle,
                                            Estado = e.Estado,
                                            IdLaboratorio = e.IdLaboratorio,
                                            IdArea = e.IdArea
                                        }).FirstOrDefaultAsync();

                    var analizador = await (from e in _dbContext.EquipoMedicoAnalizador
                                            where
                                             e.IdEquipoMedico == id &&
                                             e.Estado != States.Eliminado
                                            select new EquipoMedicoAnalizadorQuery
                                            {
                                                IdEquipoMedicoAnalizador = e.IdEquipoMedicoAnalizador,
                                                IdEquipoMedico = e.IdEquipoMedico,
                                                SerialPuerto = e.SerialPuerto,
                                                SerialBaudrate = e.SerialBaudrate,
                                                SerialDataBit = e.SerialDataBit
                                            }).ToListAsync();

                    equipoMedicoQuery = equipo!;
                    equipoMedicoQuery.ListaEquipoMedicoAnalizador = analizador;
                }

                var laboratorio = await (from la in _dbContext.Laboratorio
                                         where
                                         la.Estado == States.Activo
                                         select new OptionQuery
                                         {
                                             Id = la.IdLaboratorio,
                                             Nombre = la.Nombre,
                                             Tipo = Forms.Laboratorio
                                         }).ToListAsync();

                var area = await (from ar in _dbContext.Area
                                  where
                                  ar.Estado == States.Activo
                                  select new OptionQuery
                                  {
                                      Id = ar.IdArea,
                                      Nombre = ar.Nombre,
                                      Tipo = Forms.Area
                                  }).ToListAsync();


                equipoMedicoQuery.ListaOpciones.AddRange(laboratorio);
                equipoMedicoQuery.ListaOpciones.AddRange(area);

                return equipoMedicoQuery!;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
