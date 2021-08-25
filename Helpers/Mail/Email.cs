using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;
 
namespace  Helpers.Mail
{
    public static class Email
    {
        public static void SendEmail(MailAddress fromAddress, MailAddress toAddress, string subject, string body)
        {
            try
            {
                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };

                //var client = new SmtpClient("smtp.dapajob.ir", 587);
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential("no_reply@dapajob.ir", "159263");
                //client.Send(message);

                var client = new SmtpClient("smtp.gmail.com", 587);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("dapajob@gmail.com", "dapa@159263");
                client.EnableSsl = true;
                client.Send(message);
            }
            catch { }
        }
    }
}
