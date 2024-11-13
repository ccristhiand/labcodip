using Common.Config;
using Common.Utility;
using Laboratory.Service.EventHandlers;
using Persistence.Database;
using Silac.Domain;

namespace QualityControl.Service.EventHandlers
{
    public interface ILoteEventHandlers
    {
        Task<ResponseCreateCommand> Post(LoteCreateCommand command);
    }

    public class LoteEventHandlers : ILoteEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public LoteEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Post(LoteCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.Lote.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado && y.IdReactivoDet == command.IdReactivoDet);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.Lote), TypeResponse.Alert);

                var lote = DtoMapperExtension.MapTo<Lote>(command);

                lote.IdLote = Ulid.NewUlid().ToString();
                lote.Creado_por = command.user;
                lote.Fecha_creacion = DateTime.Now;
                lote.Estado = States.Activo;
                lote.Accion = Actions.Creado;

                await _dbContext.Lote.AddAsync(lote);

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Lote), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Lote), TypeResponse.Error);
            }
        }
    }
}