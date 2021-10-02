using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObservePattern
{
    public class SendMail
    {
        public static void Send(string mail)
        {

            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            client.Credentials = new NetworkCredential("lalamuradova2021@outlook.com", "lala1995");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            message.To.Add(mail);
            message.From = new MailAddress("lalamuradova2021@outlook.com", "Shop");
            message.Subject = "Shop";
            message.Body = "Hormetli musteri istediyiniz mehsul artiq magazamizdadir. Yaxinlasib baxa bilersiniz. Unvan: E.Ehmedov 14";
            client.Send(message);
            Console.Clear();
            Console.WriteLine("Email sent\n");

        }
    }
}

