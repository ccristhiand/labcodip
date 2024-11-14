using Common.Utility;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;
using External.Service.Reniec.Service;
using External.Service.Reniec;
using External.Service.Reniec.Dto;

namespace Laboratory.Service.Queries
{
    public interface IPersonaQueryService
    {
        Task<PersonaQuery> Find(string? id);
    }
    public class PersonaQueryService : IPersonaQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        private readonly Reniec _reniecService=new Reniec();

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
                else
                {
                    persona = new PersonaQuery();
                    ReniecDto person = await _reniecService.Get(id);
                   
                    if (person != null) {
                        
                        persona.Nombre = person.Nombre;
                        persona.NroDocumento = person.Dni;
                        persona.FechaNacimiento= person.FechaNacimiento;
                        persona!.Edad = Configurations.calcularEdad(persona.FechaNacimiento);
                        string[] apellidos = (person.Apellido ?? "").Split(' ');
                        persona.ApePaterno = apellidos.Length > 0 ? apellidos[0] : string.Empty;
                        if (apellidos.Length > 2)
                        {
                            foreach (var apell in apellidos.Skip(1))
                            {
                                persona.ApeMaterno = $"{persona.ApeMaterno} {apell}";
                            }
                        }
                        else
                        {
                            persona.ApeMaterno = apellidos[1];
                        }
                    }
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
