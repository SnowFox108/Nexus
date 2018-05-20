using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Nexus.Core.Email
{
    public static class EmailMgr
    {
        [ObsoleteAttribute("SendMail is obsoleted for this type.  Please use SendMail(string SendFrom, string SendTo, string BccTo, string ReplyTo, string Body, string Subject, bool isHtml) instead.")]
        public static void SendMail(string SendTo, string Body, string Subject)
        {
            MailAddress From = new MailAddress(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_MailFrom_Default"));
            MailAddress To = new MailAddress(SendTo);

            MailMessage email = new MailMessage(From, To);

            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = MailPriority.High;

            email.Subject = Subject;

            email.Body = Body;

            SmtpClient client = new SmtpClient(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_SMTP"));
            client.Send(email);

        }

        [ObsoleteAttribute("SendMail is obsoleted for this type.  Please use SendMail(string SendFrom, string SendTo, string BccTo, string ReplyTo, string Body, string Subject, bool isHtml) instead.")]
        public static void SendMail(string SendTo, string Body, string Subject, bool isHtml)
        {
            MailAddress From = new MailAddress(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_MailFrom_Default"));
            MailAddress To = new MailAddress(SendTo);

            MailMessage email = new MailMessage(From, To);

            email.IsBodyHtml = isHtml;
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = MailPriority.High;

            email.Subject = Subject;

            email.Body = Body;

            SmtpClient client = new SmtpClient(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_SMTP"));
            client.Send(email);

        }

        [ObsoleteAttribute("SendMail is obsoleted for this type.  Please use SendMail(string SendFrom, string SendTo, string BccTo, string ReplyTo, string Body, string Subject, bool isHtml) instead.")]
        public static void SendMail(string SendTo, string BccTo, string Body, string Subject)
        {
            MailAddress From = new MailAddress(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_MailFrom_Default"));
            MailAddress To = new MailAddress(SendTo);
            MailAddress Bcc = new MailAddress(BccTo);

            MailMessage email = new MailMessage(From, To);

            email.Bcc.Add(Bcc);

            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = MailPriority.High;

            email.Subject = Subject;

            email.Body = Body;

            SmtpClient client = new SmtpClient(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_SMTP"));
            client.Send(email);

        }

        [ObsoleteAttribute("SendMail is obsoleted for this type.  Please use SendMail(string SendFrom, string SendTo, string BccTo, string ReplyTo, string Body, string Subject, bool isHtml) instead.")]
        public static void SendMail(string SendTo, string BccTo, string Body, string Subject, bool isHtml)
        {
            MailAddress From = new MailAddress(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_MailFrom_Default"));
            MailAddress To = new MailAddress(SendTo);
            MailAddress Bcc = new MailAddress(BccTo);

            MailMessage email = new MailMessage(From, To);

            email.Bcc.Add(Bcc);

            email.IsBodyHtml = isHtml;
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = MailPriority.High;

            email.Subject = Subject;

            email.Body = Body;

            SmtpClient client = new SmtpClient(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_SMTP"));
            client.Send(email);

        }

        [ObsoleteAttribute("SendMail is obsoleted for this type.  Please use SendMail(string SendFrom, string SendTo, string BccTo, string ReplyTo, string Body, string Subject, bool isHtml) instead.")]
        public static void SendMail(string SendFrom, string SendTo, string BccTo, string Body, string Subject)
        {
            MailAddress From = new MailAddress(SendFrom);
            MailAddress To = new MailAddress(SendTo);
            MailAddress Bcc = new MailAddress(BccTo);

            MailMessage email = new MailMessage(From, To);

            email.Bcc.Add(Bcc);

            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = MailPriority.High;

            email.Subject = Subject;

            email.Body = Body;

            SmtpClient client = new SmtpClient(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_SMTP"));
            client.Send(email);

        }

        [ObsoleteAttribute("SendMail is obsoleted for this type.  Please use SendMail(string SendFrom, string SendTo, string BccTo, string ReplyTo, string Body, string Subject, bool isHtml) instead.")]
        public static void SendMail(string SendFrom, string SendTo, string BccTo, string Body, string Subject, bool isHtml)
        {
            MailAddress From = new MailAddress(SendFrom);
            MailAddress To = new MailAddress(SendTo);
            MailAddress Bcc = new MailAddress(BccTo);

            MailMessage email = new MailMessage(From, To);

            email.Bcc.Add(Bcc);

            email.IsBodyHtml = isHtml;
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = MailPriority.High;

            email.Subject = Subject;

            email.Body = Body;

            SmtpClient client = new SmtpClient(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_SMTP"));
            client.Send(email);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SendFrom">accept null</param>
        /// <param name="SendTo"></param>
        /// <param name="BccTo">accept null</param>
        /// <param name="ReplyTo">accept null</param>
        /// <param name="Body"></param>
        /// <param name="Subject"></param>
        /// <param name="isHtml"></param>
        public static void SendMail(string SendFrom, string SendTo, string BccTo, string ReplyTo, string Body, string Subject, bool isHtml)
        {
            MailAddress From;
            if (string.IsNullOrEmpty(SendFrom))
            {
                From = new MailAddress(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_MailFrom_Default"));
            }
            else
            {
                From = new MailAddress(SendFrom);
            }

            MailAddress To = new MailAddress(SendTo);

            // Create Mail
            MailMessage email = new MailMessage(From, To);

            if (!string.IsNullOrEmpty(BccTo))
            {
                MailAddress Bcc = new MailAddress(BccTo);
                email.Bcc.Add(Bcc);
            }

            if (!string.IsNullOrEmpty(ReplyTo))
            {
                email.ReplyToList.Add(new MailAddress(ReplyTo));
            }

            email.IsBodyHtml = isHtml;
            email.BodyEncoding = System.Text.Encoding.UTF8;
            email.Priority = MailPriority.High;

            email.Subject = Subject;

            email.Body = Body;

            SmtpClient client = new SmtpClient(Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_Email_SMTP"));
            client.Send(email);

        }

    }
}
