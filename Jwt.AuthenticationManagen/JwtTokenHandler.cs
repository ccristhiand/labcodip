using Common.Utility;
using Dapper;
using Jwt.AuthenticationManagen.Models;
using Microsoft.IdentityModel.Tokens;
using Persistence.Database.CurrentUser;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt.AuthenticationManagen
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "!SDFT$$$$&F(/GF7&F7f))?=0'===IY(&&%$%$!H(U/GFD%VBN(MI YT% %RCGRCVBBUJNU(NN";
        public const int JWT_TOKEN_VALIDITY_MINS = 180;
        public readonly string _conexion;

        public JwtTokenHandler(string Conexion)
        {
            _conexion = Conexion;
        }

        public TokenUsuarioQuery GenerateJwtToken(string user, string password, string domain)
        {
            TokenUsuarioQuery token = new TokenUsuarioQuery();
            var response = Metodo.GetByConnection();
            var connection = response!.Connection.Where(y => y.Domain == domain)!.FirstOrDefault();

            var usuario = PostLogin(user, password, domain, connection!.Cns!).Result;


            if (usuario != null)
            {

                var claims = new List<Claim>
                {
                    new Claim("usuario",(usuario.Usuario==null || usuario.Usuario=="")?user:usuario.Usuario),
                    new Claim("nombre", (usuario.Nombres==null || usuario.Nombres=="" )?user: usuario.Nombres),
                    new Claim("documento", (usuario.Documento==null || usuario.Documento=="")?"99999999":usuario.Documento),
                    new Claim("idrol",(usuario.IdRol==null || usuario.IdRol=="")?user:usuario.IdRol),
                    new Claim("permisoEscritura",usuario.Permiso_Escritura.ToString()??"false"),
                    new Claim("idClient", connection!.IdClient!),
                    new Claim("idUser",(usuario.IdUser==null || usuario.IdUser=="")?"":usuario.IdUser),
                };


                var key = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(JWT_TOKEN_VALIDITY_MINS),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                token.Access_token = tokenHandler.WriteToken(createdToken);
                token.Key = KeyMessage.Key;
                token.TypeResponse = TypeResponse.Success;
                token.Summary = Summary.Success;
                token.Message = MsgUser.SuccesUser;
                token.IdUser = usuario.IdUser;
            }
            else
            {
                token.Key = KeyMessage.Key;
                token.TypeResponse = TypeResponse.Error;
                token.Summary = Summary.Error;
                token.Message = MsgUser.ErrorUser;
            }

            return token;
        }

        public TokenUsuarioQuery RefreshJwtToken(string tokens)
        {
            TokenUsuarioQuery token = new TokenUsuarioQuery();

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadJwtToken(tokens);

            var claims1 = securityToken.Claims.ToArray();

            var claims = new List<Claim>
            {
               new Claim("usuario",claims1[0].Value),
               new Claim("nombre", claims1[1].Value),
               new Claim("documento", claims1[2].Value),
               new Claim("idrol", claims1[3].Value),
               new Claim("permisoEscritura", claims1[4].Value),
               new Claim("idClient", claims1[5].Value),
               new Claim("idUser", claims1[6].Value),
            };

            var key = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(JWT_TOKEN_VALIDITY_MINS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            token.Access_token = tokenHandler.WriteToken(createdToken);

            return token;
        }

        public async Task<UsuarioResponseQuery> PostLogin(string user, string password, string domain, string cns)
        {
            UsuarioResponseQuery usuarioResponseQuery = new UsuarioResponseQuery();

            using (var sqlConnection = new SqlConnection(cns))
            {
                try
                {
                    sqlConnection.Open();

                    var parameters = new DynamicParameters();

                    var contrasenia = Configurations.Encrypt(password);

                    parameters.AddDynamicParams(new { @user = user, @contrasenia = contrasenia });

                    var result = sqlConnection.QueryMultiple(UsuarioProcedure.spIniciarSession, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: DbConnectionTime.TimeOut);

                    if (result != null)
                    {
                        usuarioResponseQuery = result.Read<UsuarioResponseQuery>().FirstOrDefault()!;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            return usuarioResponseQuery;
        }
    }
}