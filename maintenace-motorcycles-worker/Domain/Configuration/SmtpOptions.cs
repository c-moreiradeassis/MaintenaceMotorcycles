namespace Domain.Configuration
{
    public sealed class SmtpOptions
    {
        public string? From { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
    }
}
