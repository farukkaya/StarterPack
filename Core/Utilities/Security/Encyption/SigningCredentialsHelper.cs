using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption
{
    public class SigningCredentialsHelper
    {
        /// <summary>
        /// Güvenlik anahtarı ve algoritma belirlenerek Credentials(Kimlik Bilgileri) oluşturur ve döner
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return  new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
