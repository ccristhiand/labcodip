using Common.Config;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface IPersonaQueryService
    {
        Task<DataCollection<PersonaQuery>> Get();
        Task<PersonaQuery> Find(string iddocu);
    }
    public class PersonaQueryService : IPersonaQueryService
    {
        public readonly PersistenceDatabase _dbContext;
        public async Task<PersonaQuery> Find(string docu)
        {
            try
            {
                using (var dbContext = _dbContext)
                {
                    var response = await (
                        from p in dbContext.Persona
                        where p.IdPersona == docu
                        select new PersonaQuery
                        {
                            ApeMaterno = p.ApeMaterno,
                            ApePaterno = p.ApePaterno,
                            Estado = p.Estado,
                            FechaNacimiento = p.FechaNacimiento,
                            IdPersona = p.IdPersona,
                            IdSexo = p.IdSexo,
                            IdTipoDocu = p.IdTipoDocu,
                            Nombre = p.Nombre,
                            NroDocumento = p.NroDocumento
                        }).FirstOrDefaultAsync();

                    return response!;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DataCollection<PersonaQuery>> Get()
        {
            try
            {
                using (var dbContext = _dbContext)
                {
                    var response = await (
                        from p in dbContext.Persona
                        where p.Estado == "ACTI"
                        select new PersonaQuery
                        {
                            ApeMaterno = p.ApeMaterno,
                            ApePaterno = p.ApePaterno,
                            Estado = p.Estado,
                            FechaNacimiento = p.FechaNacimiento,
                            IdPersona = p.IdPersona,
                            IdSexo = p.IdSexo,
                            IdTipoDocu = p.IdTipoDocu,
                            Nombre = p.Nombre,
                            NroDocumento = p.NroDocumento
                        }).GetPagedAsync();
                    return response!;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
