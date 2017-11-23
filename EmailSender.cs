using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YoungEnterprise_Admin_Application
{
    public class EmailSender
    {
        // The SmtpClient in order to send the email
        // The MailMessage to send to the recipient
        // The senderAddress in order to store the senders email to send multiple in a row.
        private SmtpClient client = null;
        private MailMessage mailMessage = null;
        public string senderAddress = "";
        
        public EmailSender(string mailHost, int mailPort, bool enableSSL, string senderEmail, string senderPassword)
        {
            // Initialization of the smtpclient
            SetMailAddress(mailHost, mailPort, enableSSL, senderEmail, senderPassword);
        }

        // Created a method to change the email in case the administrator wants to change the email address being used
        public void SetMailAddress (string mailHost, int mailPort, bool enableSSL, string senderEmail, string senderPassword)
        {
            client = new SmtpClient(mailHost, mailPort);
            client.Host = mailHost;
            client.Port = mailPort;
            client.EnableSsl = enableSSL;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);

            senderAddress = senderEmail;
        }

        // The reciever being the recievers email address, the title being the title of the mail and the content being the mail itself.
        public void SendMail (string reciever, string title, string content)
        {
            //Sends the email
            mailMessage = new MailMessage(senderAddress, reciever, title, content);
            client.Send(mailMessage);

            // Sets the mailmessage to null which is the mailMessage's initial state
            mailMessage = null;
        }
    }
}
