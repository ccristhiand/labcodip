using Common.Config;
using Common.Utility;
using Laboratory.Service.EventHandlers;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Silac.Domain;

namespace QualityControl.Service.EventHandlers
{
    public interface IQCResultadoEventHandlers
    {
        Task<ResponseCreateCommand> Post(ResultadoCreateCommand command);
    }

    public class QCResultadoEventHandlers : IQCResultadoEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public QCResultadoEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Post(ResultadoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var idEquipoMedico = _dbContext.ReactivoDet.AsNoTracking().Where(y => y.IdReactivoDet == command.IdReactivoDet).Select(y => y.Reactivo!.IdEquipoMedico).FirstOrDefault();
                var model = _dbContext.QCResultado.AsNoTracking().OrderByDescending(y => y.Fecha_creacion).FirstOrDefault();
                var resultado = DtoMapperExtension.MapTo<QCResultado>(command);

                if (model != null)
                {
                    DateTime fecha = model.FechaResultado!.Value.AddDays(1);

                    resultado.FechaResultado = fecha;
                    resultado.HoraResultado = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    resultado.FechaResultado = fecha;
                    resultado.HoraResultado = DateTime.Now.ToString("HH:mm:ss");
                }

                resultado.IdQCResultado = Ulid.NewUlid().ToString();
                resultado.IdEquipoMedico = idEquipoMedico;
                resultado.Creado_por = command.user;
                resultado.Fecha_creacion = DateTime.Now;
                resultado.Accion = Actions.Creado;

                await _dbContext.QCResultado.AddAsync(resultado);

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Resultado), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Resultado), TypeResponse.Error);
            }
        }

    }
}