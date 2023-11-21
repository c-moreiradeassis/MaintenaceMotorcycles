using Application.Interfaces;
using Domain.Configuration;
using Domain.Models;
using Infra.Interfaces;

namespace Application.Services
{
    public sealed class EmailServiceImp : EmailService
    {
        private readonly SenderEmail _senderEmail;

        public EmailServiceImp(SenderEmail senderEmail)
        {
            _senderEmail = senderEmail;
        }

        public void SendEmail(string to, SmtpOptions smtp, List<Maintenance> maintenances)
        {
            _senderEmail.SendEmail(to, smtp, maintenances);
        }
    }
}
