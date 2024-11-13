using Common.Config;
using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Laboratory.Service.Queries
{
    public interface IMedicoQueryService
    {
        Task<DataCollection<MedicoQuery>> Get(string? valor, int page, int pages);
        Task<MedicoQuery> Find(string? id);
    }
    public class MedicoQueryService : IMedicoQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public MedicoQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<MedicoQuery>> Get(string? valor, int page, int pages)
        {
            try
            {
                valor = (valor == null) ? valor : (valor!.Replace(" ", ""));

                var medico = await (from me in _dbContext.Medico
                                    join pe in _dbContext.Persona on me.IdPersona equals pe.IdPersona
                                    join ta in _dbContext.TablaMaestra on me.Estado equals ta.Codigo
                                    where
                                     (valor == null || (pe.ApePaterno + pe.ApeMaterno + pe.Nombre + pe.NroDocumento).Contains(valor!)) &&
                                     ta.Tabla == Opciones.States &&
                                     me.Estado != States.Eliminado
                                    select new MedicoQuery
                                    {
                                        Codigo = me.Codigo,
                                        IdMedico = me.IdMedico,
                                        IdPersona = pe.IdPersona,
                                        IdTipoDocu = pe.IdTipoDocu,
                                        NroDocumento = pe.NroDocumento,
                                        ApePaterno = pe.ApePaterno,
                                        ApeMaterno = pe.ApeMaterno,
                                        Nombre = pe.Nombre,
                                        FechaNacimiento = pe.FechaNacimiento,
                                        Color = ta.Color,
                                        Estado = ta.Nombre
                                    }).GetPagedAsync(page, pages, "Codigo");

                return medico;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MedicoQuery> Find(string? id)
        {
            try
            {
                MedicoQuery medicoQuery = new MedicoQuery();

                if (!string.IsNullOrEmpty(id))
                {
                    var medico = await (from me in _dbContext.Medico
                                        join pe in _dbContext.Persona on me.IdPersona equals pe.IdPersona
                                        where
                                        me.IdMedico == id
                                        select new MedicoQuery
                                        {
                                            IdMedico = me.IdMedico,
                                            IdPersona = pe.IdPersona,
                                            IdTipoDocu = pe.IdTipoDocu,
                                            NroDocumento = pe.NroDocumento,
                                            ApePaterno = pe.ApePaterno,
                                            ApeMaterno = pe.ApeMaterno,
                                            Nombre = pe.Nombre,
                                            FechaNacimiento = pe.FechaNacimiento,
                                            IdSexo = pe.IdSexo
                                        }).FirstOrDefaultAsync();

                    medicoQuery = medico!;
                    medicoQuery.Edad = Configurations.calcularEdad(medicoQuery.FechaNacimiento);

                }

                List<string> listaMaestra = new List<string>();
                listaMaestra.Add(Opciones.Sexo);
                listaMaestra.Add(Opciones.TipoDocumento);

                var maestra = await (from ta in _dbContext.TablaMaestra
                                     where
                                     ta.Codigo != Opciones.AMBOS &&
                                     listaMaestra.Contains(ta.Tabla!)
                                     select new OptionQuery
                                     {
                                         Id = ta.Codigo,
                                         Nombre = ta.Nombre,
                                         Tipo = ta.Tabla
                                     }).ToListAsync();

                medicoQuery.ListaOpciones.AddRange(maestra);

                return medicoQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
