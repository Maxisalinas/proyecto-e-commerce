namespace E_Commerce_Negocio.Config
{
    public class JwtConfig
    {
        public string Secret { get; set; } = string.Empty;
        public TimeSpan ExpiryTime { get; set; }
    }
}
