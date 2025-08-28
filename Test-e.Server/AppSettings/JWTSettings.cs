namespace Test_e.Server.AppSettings
{
    public class JWTSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Key { get; set; }
        public double? ExpiresMinutes { get; set; }
    }
}
