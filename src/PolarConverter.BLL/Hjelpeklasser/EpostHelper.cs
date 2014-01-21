using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using SendGridMail;
using SendGridMail.Transport;

namespace PolarConverter.BLL.Hjelpeklasser
{
    public static class EpostHelper
    {
        public static void SendTilStrava(string stravaBrukernavn, List<string> filstier)
        {
            var message = SendGrid.GenerateInstance(
                new MailAddress("polarconverter@gmail.com", "PolarConverter"),
                new[] { new MailAddress("upload@strava.com") },
                new[] { new MailAddress("polarconverter@gmail.com") },
                null, 
                stravaBrukernavn, 
                "See attachment",
                "See attachment", 
                SendGridMail.TransportType.SMTP);

            foreach (var filsti in filstier)
            {
                message.AddAttachment(filsti);
            }
            try
            {
                SMTP.GenerateInstance(new NetworkCredential("goldnarms", "H0ffDass")).Deliver(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
