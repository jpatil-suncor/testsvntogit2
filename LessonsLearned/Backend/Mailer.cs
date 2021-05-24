using System;
using System.Net.Mail;
using System.Data;
using System.Configuration;
using System.Collections.Specialized;
using Backend;


namespace Backend
{
	/// <summary>
	/// Summary description for Mailer.
	/// </summary>
	public class Mailer
	{
		
		public struct mailEvents
		{
           	public const string userSecurityChanged         = "USER SECURITY CHANGED";
            public const string creditFacilityApproval      = "CREDIT FACILITY APPROVAL";
            public const string rollingExpiryUpdate         = "ROLLING EXPIRY UPDATE";
            public const string divisionUpdate              = "DIVISION UPDATE";
            public const string systemSettingsUpdate        = "SYSTEM SETTINGS UPDATE";
            public const string creditFacilityLCPush        = "L/C FEE UPDATE";
		}

		public Mailer()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void SendMail(string mailEvent, string messageText)
		{
			///**** note the server must be set up here before we go into production
			try
			{
               // DataTable dt;
                ////EmailAddress address = new EmailAddress();
                //string environment = ConfigurationManager.AppSettings["Environmnet"];
                //string smtpServer = ConfigurationManager.AppSettings["ErrorEmailSmtpServer"];
                
                //string subject = mailEvent + environment;
                //dt = address.GetByEmailEvent(mailEvent);

                //foreach (DataRow dr in dt.Rows)
                //{
                //    MailMessage mail = new MailMessage();
                //    mail.To.Add(dr["EMAIL_ADDRESS"].ToString());
                //    mail.From = new MailAddress("LOCNotifications@loc.com");
                //    mail.Subject = subject;
                //    mail.IsBodyHtml = false;
                //    mail.Body = messageText;

                //    SmtpClient client = new SmtpClient(smtpServer);
                //    client.Send(mail);
                //}

			}
			catch(Exception)
			{
				//Eat the exception, we never wish to have an issue with mail prevent the system from 
				//completing the processing...
				//TODO: Add Log 4 net here...
				;
			}
		}

        public static void SendMail(string tolist, string from, string subject, string body)
        {
            try
            {
                string smtpServer = ConfigurationManager.AppSettings["ErrorEmailSmtpServer"];
                String[] toListArray = tolist.Split(';');

                MailMessage Message = new MailMessage();
                foreach (String to in toListArray)
                {
                    Message.To.Add(to);
                }
                Message.From = new MailAddress(from);
                Message.Subject = subject;
                Message.Body = body;

                SmtpClient client = new SmtpClient(smtpServer);
                client.Send(Message);
            }
            catch
            {
            }
        }


        public static void SendMail(string to, string cc, string from, string subject, string body)
        {
            try
            {
                string smtpServer = ConfigurationManager.AppSettings["ErrorEmailSmtpServer"];

                MailMessage Message = new MailMessage();
                Message.To.Add(to);
                Message.CC.Add(cc);
                Message.From = new MailAddress(from);
                Message.Subject = subject;
                Message.Body = body;
                SmtpClient client = new SmtpClient(smtpServer);
                client.Send(Message);
            }
            catch
            {
            }
        }

        public static void SendMail(string to, string cc, string from, string subject, string body, Attachment attachmentObj)
        {
            if (to.Length > 0)
            {
                try
                {
                    string smtpServer = ConfigurationManager.AppSettings["ErrorEmailSmtpServer"];

                    MailMessage Message = new MailMessage();
                    Message.To.Add(to);
                    Message.CC.Add(cc);
                    Message.From = new MailAddress(from);
                    Message.Subject = subject;
                    Message.Body = body;

                    Message.Attachments.Add(attachmentObj);

                    SmtpClient client = new SmtpClient(smtpServer);
                    client.Send(Message);
                }
                catch
                {
                }
            }
        }

        public static void AlertException(NameValueCollection additionalInfo, string stackTrace)
        {
            string to = ConfigurationManager.AppSettings["ErrorEmailTo"];
            string from = ConfigurationManager.AppSettings["ErrorEmailFrom"];
            string environment = ConfigurationManager.AppSettings["Environmnet"];
            string subject = "LL Exception - " + environment;
            string body = "";
            if (to.Length > 0)
            {
                try
                {
                    body = "An exception occured:\n\n\n";
                    for (int i = 0; i < additionalInfo.Count; i++)
                    {
                        body += additionalInfo.GetKey(i) + ": " + additionalInfo.Get(i) + "\n";
                    }

                    body += "\n\nStackTrace\n\n" + stackTrace;
                    SendMail(to, from, subject, body);
                }
                catch
                {
                }
            }
        }
     
	}
}
