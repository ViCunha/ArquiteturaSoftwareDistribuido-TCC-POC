namespace Identity.Domain.Models.DTO
{
    public class CustomerJWT
    {
        public Customer Customer { get; set; }
        public JWTSettingsDTO JWTSettingsDTO { get; set; }
    }
}
