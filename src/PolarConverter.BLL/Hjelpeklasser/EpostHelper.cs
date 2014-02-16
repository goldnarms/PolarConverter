﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using SendGridMail;

namespace PolarConverter.BLL.Hjelpeklasser
{
    public static class EpostHelper
    {
        public static void SendTilStrava(string stravaBrukernavn, List<string> filstier)
        {
            var message = SendGrid.GetInstance(
                new MailAddress("polarconverter@gmail.com", "PolarConverter"),
                new[] { new MailAddress("upload@strava.com") },
                new[] { new MailAddress("polarconverter@gmail.com") },
                null, 
                stravaBrukernavn, 
                "See attachment",
                "See attachment");

            foreach (var filsti in filstier)
            {
                message.AddAttachment(filsti);
            }
            try
            {
                var credentials = new NetworkCredential("goldnarms", "H0ffDass");

                var transportWeb = Web.GetInstance(credentials);
                transportWeb.Deliver(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
