using Common.Config;
using Common.Utility;
using Laboratory.Service.EventHandlers;
using Persistence.Database;
using Silac.Domain;

namespace QualityControl.Service.EventHandlers
{
    public interface INivelEventHandlers
    {
        Task<ResponseCreateCommand> Post(NivelCreateCommand command);
    }

    public class NivelEventHandlers : INivelEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public NivelEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Post(NivelCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.Nivel.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado && y.IdReactivoDet == command.IdReactivoDet);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.Nivel), TypeResponse.Alert);

                var nivel = DtoMapperExtension.MapTo<Nivel>(command);

                nivel.IdNivel = Ulid.NewUlid().ToString();
                nivel.Creado_por = command.user;
                nivel.Fecha_creacion = DateTime.Now;
                nivel.Estado = States.Activo;
                nivel.Accion = Actions.Creado;

                await _dbContext.Nivel.AddAsync(nivel);

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Nivel), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Nivel), TypeResponse.Error);
            }
        }
    }
}