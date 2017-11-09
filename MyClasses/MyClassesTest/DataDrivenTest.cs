using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class DataDrivenTest
    {

        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient",
            "Server=NBBV027075\\SQLEXPRESS; DataBase=Sandbox ; Integrated Security=False;User ID=sa;Password=123456",
            "tests.FileProcessTest",
            DataAccessMethod.Sequential)]
        public void FileExistTestFromDB()
        {
            FileProcess fp = new FileProcess();

            bool fromCall;
            string fileName = TestContext.DataRow["FileName"].ToString();
            bool expectedValue = Convert.ToBoolean(TestContext.DataRow["ExpectedValue"]);
            bool causeException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);

            try
            {
                fromCall = fp.FileExists(fileName);

                Assert.AreEqual(expectedValue, fromCall, "File name {0} has failed it's existence test in test: FileExistTestFromDB()", fileName);
            }
            catch (AssertFailedException e)
            {

                throw e;
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(causeException);
            }

        }
    }
}
