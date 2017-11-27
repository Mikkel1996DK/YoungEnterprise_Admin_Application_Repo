using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace ServiceTest
{
    [TestClass]
    public class EmailServiceTest
    {
        private EmailService emailService = null;

        [TestMethod]
        public void TestRandomPassword()
        {
            emailService = new EmailService(null, 0, false, null, null);
            Assert.IsTrue(RandomPasswordTest(emailService.GetRandomPassword(8), 8));
            Console.Write("hello");
        }

        private bool RandomPasswordTest(string pw, int expectedLength)
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
                    }
                    else
                    {
                        testPassed = false;
                    }
                }
            }

            return testPassed;
        }
    }
}
