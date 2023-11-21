using Domain.Configuration;
using Domain.Models;

namespace Infra.Interfaces
{
    public interface SenderEmail
    {
        void SendEmail(string to, SmtpOptions smtp, List<Maintenance> maintenances);
    }
}
