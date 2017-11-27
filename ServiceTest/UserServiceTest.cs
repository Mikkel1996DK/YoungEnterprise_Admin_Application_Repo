using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTest
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void TestHashPassword()
        {
            //e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855 = "TESTPASSWORD"
            Assert.AreEqual("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", HashPassword("TESTPASSWORD"));
        }

    }
}
