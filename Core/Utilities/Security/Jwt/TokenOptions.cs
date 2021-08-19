namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        /// <summary>
        /// Kullancı kitlesi
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// İmzalayan
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Token Yaşam Süresi
        /// </summary>
        public int AccessTokenExpiration { get; set; }
        /// <summary>
        /// Güvenlik Anahtarı
        /// </summary>
        public string SecurityKey { get; set; }
    }
}
