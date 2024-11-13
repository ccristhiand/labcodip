using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Laboratory.Service.Queries
{
    public interface IPersonaQueryService
    {
        Task<PersonaQuery> Find(string? id);
    }
    public class PersonaQueryService : IPersonaQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public PersonaQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PersonaQuery> Find(string? id)
        {
            try
            {
                var persona = await (from pe in _dbContext.Persona
                                     where
                                     pe.NroDocumento == id
                                     select new PersonaQuery
                                     {
                                         NroDocumento = pe.NroDocumento,
                                         ApePaterno = pe.ApePaterno,
                                         ApeMaterno = pe.ApeMaterno,
                                         Nombre = pe.Nombre,
                                         IdSexo = pe.IdSexo,
                                         FechaNacimiento = pe.FechaNacimiento
                                     }).FirstOrDefaultAsync();

                if (persona != null)
                {
                    persona!.Edad = Configurations.calcularEdad(persona.FechaNacimiento);
                }


                return persona!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
