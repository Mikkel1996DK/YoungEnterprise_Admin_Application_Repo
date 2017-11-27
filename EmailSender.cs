using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

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

        // Used for testing, if false it will send en email like normal. if true it will run tests and not send an email.
        private bool isTesting = false;
        



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
        public void SendMail (string reciever, string title, string name, string username)
        {
            //Sends the email
            string text = "Hej " + name + "." + Environment.NewLine + Environment.NewLine + "Du er hermed inviteret til YoungEnterprise event!" + Environment.NewLine +
                          "Brugernavn: " + username + Environment.NewLine +
                          "Kodeord   : " + GetRandomPassword(8);
            mailMessage = new MailMessage(senderAddress, reciever, title, text);
            
            if (isTesting)
            {
                Console.WriteLine(text);
                Console.WriteLine();
                Console.WriteLine("Testing the Test (Should return false): " + RandomPasswordTest(GetRandomPassword(9), 8));
                Console.WriteLine("Testing the Test (Should return false): " + RandomPasswordTest(GetRandomPassword(8), 9));
                Console.WriteLine("Testing the Test (Should return false): " + RandomPasswordTest("-.Abc123", 9));
                Console.WriteLine("Test: " + RandomPasswordTest(GetRandomPassword(8), 8));
                Console.WriteLine("Test: " + RandomPasswordTest(GetRandomPassword(10), 10));
                Console.WriteLine("Test: " + RandomPasswordTest(GetRandomPassword(16), 16));
            } else
            {
                client.Send(mailMessage);
            }

            // Sets the mailmessage to null which is the mailMessage's initial state
            mailMessage = null;
        }

        private string GetRandomPassword(int length)
        {
            //Discuss whether or not to include both upper and lowercase letters!
            string alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var characters = alphanumericCharacters.Distinct().ToArray();

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[length * 8];
            rng.GetBytes(buffer);
            char[] pass = new char[length];

            for (int i = 0; i < length; i++)
            {
                ulong val = BitConverter.ToUInt64(buffer, i * 8);
                pass[i] = characters[val % (uint)characters.Length];
            }

            return new string(pass);
        }

        #region ____ TESTS IN THIS REGION
        // test of random pass generation, returns false if there is non alphanumeric characters or the length doesnt match
        private bool RandomPasswordTest (string pw, int expectedLength)
        {
            bool testPassed = false;
            string alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            if (pw.ToCharArray().Length != expectedLength)
            {
                return false;
            }

            foreach (char pwLetter in pw.ToCharArray())
            {
                foreach (char acLetter in alphanumericCharacters.ToCharArray())
                {
                    if (pwLetter == acLetter)
                    {
                        testPassed = true;
                        break;
                    } else
                    {
                        testPassed = false;
                    }
                }
            }

            return testPassed;
        }
        #endregion
    }
}
