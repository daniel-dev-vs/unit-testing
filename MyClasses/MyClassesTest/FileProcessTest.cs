using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE = @"C:\BadFile.bad";
        private const string FILE_NAME = @"FileToDeploy.txt";
        private string _GoodFileName;

        #region Class Initialize
        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("Class initialized");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }
        #endregion

        #region Test Initialize
        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating the file:" + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some Text");

                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                TestContext.WriteLine("Deleting the file:" + _GoodFileName);
                File.Delete(_GoodFileName);
            }

        }

        #endregion

        private TestContext m_testContext;

        public TestContext TestContext

        {

            get { return m_testContext; }

            set { m_testContext = value; }

        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

        }

        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File DOES NOT EXIST.");
            
        }

        [TestMethod]
        public void FileNameDoesExistSimpleMessageWithFormatting()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File DOES NOT EXIST. {0}", _GoodFileName);

        }

        [TestMethod]
        [Owner("Daniel Ferreira")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentAttribute()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            string fileName;

            fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
            TestContext.WriteLine("Checking the file: {0}" + fileName);

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Timeout(3000)]
        public void TestTimeoutAttribute()
        {
            System.Threading.Thread.Sleep(4000);
        }

        [TestMethod]
        [Description("Check to see if the file does exist")]
        [Owner("Daniel Ferreira")]
        [Priority(0)]
        [TestCategory("NoException")]
        [Ignore()]
        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            fromCall = fp.FileExists(_GoodFileName);

            //Assert
            Assert.IsTrue(fromCall);

        }

        [TestMethod]
        [Description("Check to see if the file does NOT exist")]
        [Owner("Daniel Ferreira")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            fromCall = fp.FileExists(BAD_FILE);

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("JIMR")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpety_ThrowsArgumentNullExpcetion()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("JIMR")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpety_ThrowsArgumentNullExpcetion_UsingTryCath()
        {
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                throw;
            }

            Assert.Fail("Call to FileExists did NOT throw an ArgumentoNullException.");
        }

        #region AreEqual AreNotEqual
        [TestMethod]
        [Owner("Daniel")]
        public void AreEqualTest()
        {
            string str1 = "Daniel";
            string str2 = "Daniel";

            Assert.AreEqual(str1, str2);

        }


        [TestMethod]
        [Owner("Daniel")]
        public void AreNotEqualTest()
        {
            string str1 = "Daniel";
            string str2 = "Jhon";

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod]
        [Owner("JhowK")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Daniel";
            string str2 = "daniel";

            Assert.AreEqual(str1, str2, false);
        }
        #endregion

        #region Are Same/Are Not Same tests
        [TestMethod]
        [Owner("Daniel")]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x,y);

        }

        [TestMethod]
        [Owner("Daniel")]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);

        }
        #endregion

        #region IsInstanceOfType
        [TestMethod]
        public void IsInstanceOfType()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Daniel","Ferreira", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Ferreira", false);

            Assert.IsNull(per);
        }
        #endregion

       

    }
}
