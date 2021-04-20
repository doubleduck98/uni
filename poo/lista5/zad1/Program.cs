using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace zad1
{
    class SmtpFacade
    {
        private string _password;

        public SmtpFacade(string password)
        {
            _password = password;
        }

        public void Send(string from, string to,
            string subject, string body,
            Stream attachment, string attachmentMimeType)
        {
            var msg = new MailMessage(from, to, subject, body);
            if (attachment != Stream.Null)
            {
                msg.Attachments.Add(new Attachment(attachment, attachmentMimeType));
            }

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, _password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            try
            {
                client.Send(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            var facade = new SmtpFacade("haslo");
            facade.Send("from@gmail.com", "to@gmail.com", "es", "sa", Stream.Null,
                "text/plain");
        }
    }
}