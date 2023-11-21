using Domain.Configuration;
using Domain.Models;

namespace Application.Interfaces
{
    public interface EmailService
    {
        void SendEmail(string to, SmtpOptions smtp, List<Maintenance> maintenances);
    }
}
