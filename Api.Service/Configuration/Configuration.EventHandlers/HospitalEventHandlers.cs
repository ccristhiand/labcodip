using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface IHospitalEventHandlers
    {
        Task<ResponseCreateCommand> Post(HospitalCommand command);
    }
    public class HospitalEventHandlers : IHospitalEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public HospitalEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Post(HospitalCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var hospital = _dbContext.Hospital.FirstOrDefault();

                if (hospital == null)
                {
                    var model = DtoMapperExtension.MapTo<Hospital>(command);

                    model.IdHospital = Ulid.NewUlid().ToString();
                    model.Estado = States.Activo;
                    model.Accion = Actions.Creado;
                    model.Fecha_creacion = DateTime.Now;

                    await _dbContext.Hospital.AddAsync(model);
                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Guardar(Forms.Hospital), TypeResponse.Success);

                    return response;
                }
                else
                {
                    hospital.Nombre = command.Nombre;
                    hospital.Titulo = command.Titulo;
                    hospital.SubTitulo = command.SubTitulo;
                    hospital.PiePagina = command.PiePagina;
                    hospital.Direccion = command.Direccion;

                    hospital.Fecha_modificacion = DateTime.Now;
                    hospital.Modificado_por = command.user;
                    hospital.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.Hospital), TypeResponse.Success);

                    return response;
                }

            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Hospital), TypeResponse.Error);
            }
        }
    }
}
