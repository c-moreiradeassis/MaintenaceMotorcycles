using Domain.Configuration;
using Domain.Models;
using Infra.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Infra.Services
{
    public class SenderEmailImp : SenderEmail
    {
        public void SendEmail(string to, SmtpOptions smtp, List<Maintenance> maintenances)
        {
            try
            {
                MailMessage msg = new MailMessage();

                msg.From = new MailAddress(smtp.From);
                msg.To.Add(to);
                msg.Subject = "Manutenção Preventiva";
                msg.Body = $@"
                <!doctype html>
                    <html lang=""pt-br"">
                    <head>
                        <meta charset=""utf-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65"" crossorigin=""anonymous"">
                    </head>
                    <body>
                        <p>Olá, tudo bem?</p></br>
                        <p>Estou passando para te avisar que sua última revisão foi realizada no dia {maintenances.First().LastMaintenance.ToString("dd/MM/yyyy")}
                           e os itens abaixo precisarão ser revisados nos próximos dias:</p></br>
                        <table class""table"">
                            <thead>
                                <tr>
                                    <th>Item</th>
                                    <th>Operação</th>
                                </tr>
                                <tr>
                            </thead>";

                foreach (var maintenance in maintenances)
                {
                    msg.Body += $@"<tbody>
                            <td>{maintenance.Item}</td>
                            <td>{maintenance.Operation}</td></tbody>";
                }

                msg.Body += "</tr></table></br><p>Atenciosamente.</p></body></html>";
                msg.IsBodyHtml = true;
                msg.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                msg.BodyEncoding = Encoding.GetEncoding("UTF-8");

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtp.From, smtp.Password);
                    client.Host = smtp.Host;
                    client.Port = smtp.Port;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(msg);
                }
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }
    }
}
