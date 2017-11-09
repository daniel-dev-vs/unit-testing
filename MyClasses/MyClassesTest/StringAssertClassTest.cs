using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("Daniel Ferreira")]
        public void ConstainsTest()
        {
            string str1 = "Daniel Ferreira";
            string str2 = "Ferreira";

            StringAssert.Contains(str1, str2);
        }
        [TestMethod]
        [Owner("Daniel Ferreira")]
        public void StartWithTest()
        {
            string str1 = "All Lower Case";
            string str2 = "All Lower";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Daniel")]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        [Owner("Daniel")]
        public void IsANotllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("All Lower Case", r);
        }
    }
}
