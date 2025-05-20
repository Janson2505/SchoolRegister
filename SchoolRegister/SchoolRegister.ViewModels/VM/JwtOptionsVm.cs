namespace SchoolRegister.ViewModels.VM
{
    public class JwtOptionsVm
    {
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
        public int TokenExpirationMinutes { get; set; }
    }
}