using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.Database;
using Persistence.Database.CurrentUser.Dto;
using Silac.Domain;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using static Common.Utility.movimientoTracking;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Common.Utility
{
    public class Configurations
    {
        private readonly PersistenceDatabase _dbContext;

        public Configurations(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public static int calcularEdad(DateTime? FechaNacimiento)
        {
            try
            {
                DateTime now = DateTime.Today;
                int edad = DateTime.Today.Year - FechaNacimiento!.Value.Year;

                if (DateTime.Today < FechaNacimiento!.Value.AddYears(edad))
                    return --edad;
                else
                    return edad;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string generarCorrelativo(string valor)
        {
            double number;
            string result = null!;

            if (double.TryParse(valor, out number))
            {
                number = Convert.ToInt32(valor);
                //number = number + 1;

                result = number.ToString().PadLeft(7, '0');
            }
            else
            {
                result = number.ToString().PadLeft(7, '0');
            }

            return result;
        }

        public static string Encrypt(string? plainText)
        {

            byte[] initVectorBytes;
            initVectorBytes = Encoding.ASCII.GetBytes(SecurityParameter.initVector);

            byte[] saltValueBytes;
            saltValueBytes = Encoding.ASCII.GetBytes(SecurityParameter.saltValue);

            byte[] plainTextBytes;
            plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password;
            password = new PasswordDeriveBytes(SecurityParameter.passPhrase,
                                               saltValueBytes,
                                               SecurityParameter.hashAlgorithm,
                                               SecurityParameter.passwordIterations);

            byte[] keyBytes;
            keyBytes = password.GetBytes(SecurityParameter.keySize / 8);

            RijndaelManaged symmetricKey;
            symmetricKey = new RijndaelManaged();

            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor;
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream;
            memoryStream = new MemoryStream();

            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream,
                                            encryptor,
                                            CryptoStreamMode.Write);

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes;
            cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText;
            cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }

        public static string Decrypt(string? cipherText)
        {
            byte[] initVectorBytes;
            initVectorBytes = Encoding.ASCII.GetBytes(SecurityParameter.initVector);

            byte[] saltValueBytes;
            saltValueBytes = Encoding.ASCII.GetBytes(SecurityParameter.saltValue);

            byte[] cipherTextBytes;
            cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes password;
            password = new PasswordDeriveBytes(SecurityParameter.passPhrase, saltValueBytes, SecurityParameter.hashAlgorithm, SecurityParameter.passwordIterations);

            byte[] keyBytes;
            keyBytes = password.GetBytes(SecurityParameter.keySize / 8);

            RijndaelManaged symmetricKey;
            symmetricKey = new RijndaelManaged();

            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform decryptor;
            decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream;
            memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream;
            cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] plainTextBytes;
            plainTextBytes = new byte[cipherTextBytes.Length + 1];

            int decryptedByteCount;
            decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            string plainText;
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            return plainText;
        }
        public static ResponseCreateCommand Response(string msg, string type, string id = "")
        {
            ResponseCreateCommand response = new ResponseCreateCommand();

            response.Id = id;
            response.Message = msg;
            response.Key = KeyMessage.Key;

            switch (type)
            {
                case TypeResponse.Success:
                    response.TypeResponse = TypeResponse.Success;
                    response.Summary = Summary.Success;
                    break;
                case TypeResponse.Alert:
                    response.TypeResponse = TypeResponse.Alert;
                    response.Summary = Summary.Alert;
                    break;
                case TypeResponse.Error:
                    response.TypeResponse = TypeResponse.Error;
                    response.Summary = Summary.Error;
                    break;

            }

            return response!;
        }

        public string AddPersona(string? idTipoDocu,
                                 string? nroDocumento,
                                 string? apePaterno,
                                 string? apeMaterno,
                                 string? nombre,
                                 DateTime? fechaNacimiento,
                                 string? idSexo,
                                 string? user
            )
        {
            var entityPersona = _dbContext.Persona.FirstOrDefault(x => x.NroDocumento == nroDocumento);

            string IdPersona = "";

            if (entityPersona != null)
            {
                entityPersona.IdTipoDocu = idTipoDocu;
                entityPersona.NroDocumento = nroDocumento;
                entityPersona.ApePaterno = apePaterno;
                entityPersona.ApeMaterno = apeMaterno;
                entityPersona.Nombre = nombre;
                entityPersona.FechaNacimiento = fechaNacimiento;
                entityPersona.IdSexo = idSexo;
                entityPersona.Modificado_por = user;
                entityPersona.Fecha_modificacion = DateTime.Now;
                entityPersona.Accion = Actions.Modificado;

                IdPersona = entityPersona.IdPersona!;
            }
            else
            {
                Persona persona = new Persona();

                persona.IdPersona = Ulid.NewUlid().ToString();
                persona.IdTipoDocu = idTipoDocu;
                persona.NroDocumento = nroDocumento;
                persona.ApePaterno = apePaterno;
                persona.ApeMaterno = apeMaterno;
                persona.Nombre = nombre;
                persona.FechaNacimiento = fechaNacimiento;
                persona.IdSexo = idSexo;
                persona.Creado_por = user;
                persona.Fecha_creacion = DateTime.Now;
                persona.Estado = States.Activo;
                persona.Accion = Actions.Creado;

                IdPersona = persona.IdPersona!;

                _dbContext.Persona.AddAsync(persona);
            }

            return IdPersona;
        }
        public void CreateTracking(string IdOrden, string IdTipoMuestra, string UsuarioImpresionEtiqueta)
        {
            using (var context = _dbContext)
            {
                context.Database.ExecuteSqlRaw("EXEC trak.Tracking_Agregar @IdOrden, @IdTipoMuestra, @UsuarioImpresionEtiqueta",
                new SqlParameter("@IdOrden", IdOrden),
                new SqlParameter("@IdTipoMuestra", IdTipoMuestra),
                new SqlParameter("@UsuarioImpresionEtiqueta", UsuarioImpresionEtiqueta)
                );
            }
        }

        public string Updatetracking(int movimientoTracking, string? idOrdenExamen, string? usuario)
        {
            var tracking = _dbContext.Tracking.FirstOrDefault(x => x.IdOrdenExamen == idOrdenExamen);
            if (tracking != null)
            {
                switch (movimientoTracking)
                {
                    case TrcImpresionEtiqueta:
                        tracking.EstadoImpresionEtiqueta = true;
                        tracking.UsuarioImpresionEtiqueta = usuario;
                        tracking.FechaImpresionEtiqueta = tracking.FechaLecturaEtiqueta != null ? tracking.FechaImpresionEtiqueta : DateTime.Now;
                        break;
                    case TrcLecturaDeEquipoMedico:
                        tracking.EstadoLecturaEtiqueta = true;
                        tracking.UsuarioEnvioResultados = usuario;
                        tracking.FechaLecturaEtiqueta = tracking.FechaLecturaEtiqueta != null ? tracking.FechaLecturaEtiqueta : DateTime.Now;
                        break;
                    case TrcEnvioDeResultado:
                        tracking.EstadoEnvioResultados = true;
                        tracking.UsuarioEnvioResultados = usuario;
                        tracking.FechaEnvioResultados = tracking.FechaEnvioResultados != null ? tracking.FechaEnvioResultados : DateTime.Now;
                        break;
                    case TrcPrevalidacionMedica:
                        tracking.EstadoPrevalidacion = true;
                        tracking.UsuarioPrevalidacion = usuario;
                        tracking.FechaPrevalidacion = tracking.FechaPrevalidacion != null ? tracking.FechaPrevalidacion : DateTime.Now;
                        break;
                    case TrcValidacionMedica:
                        tracking.EstadoValidacion = true;
                        tracking.UsuarioValidacion = usuario;
                        tracking.FechaValidacion = tracking.FechaValidacion != null ? tracking.FechaValidacion : DateTime.Now;
                        break;
                    default: break;

                }
            }
            else
            {
                return "";
            }
            return idOrdenExamen;
        }
    }
}
