namespace Identity.Domain.Models.DTO
{
    public class JWTSettingsDTO
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpirationTimeInSeconds { get; set; }
    }
}
