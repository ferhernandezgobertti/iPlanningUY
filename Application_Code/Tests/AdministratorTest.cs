using System;
using System.Text;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AdministratorTest
    {

        [TestMethod]
        public void TestIsUsernameRight()
        {
            Administrator anAdmin = new Administrator();
            String usernameExample = "admin";
            anAdmin.UserName = usernameExample;
            Assert.IsTrue(anAdmin.IsUserNameRight());
        }
        [TestMethod]
        public void TestIsNotUsernameRight()
        {
            Administrator anAdmin = new Administrator();
            String usernameExample = "adminORT";
            anAdmin.UserName = usernameExample;
            Assert.IsFalse(anAdmin.IsUserNameRight());
        }

        [TestMethod]
        public void TestIsPasswordRight()
        {
            Administrator anAdmin = new Administrator();
            String passwordExample = "admin2018";
            anAdmin.Password = passwordExample;
            Assert.IsTrue(anAdmin.IsPasswordRight());
        }
        [TestMethod]
        public void TestIsNotPasswordRight()
        {
            Administrator anAdmin = new Administrator();
            String passwordExample = "adminORT";
            anAdmin.Password = passwordExample;
            Assert.IsFalse(anAdmin.IsPasswordRight());
        }

        [TestMethod]
        public void TestCheckLogIn() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Administrator oneAdmin = new Administrator();
            oneAdmin = (Administrator)oneAdmin.CheckLogIn(oneTest.newProgram, "admin", "admin2018");
            Assert.AreNotEqual(oneAdmin, null);
        }

        [TestMethod]
        public void TestCheckLogInWhenNotPossible() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Administrator oneAdmin = new Administrator();
            oneAdmin = (Administrator)oneAdmin.CheckLogIn(oneTest.newProgram, "Fer2020", "Fer.9090");
            Assert.AreEqual(oneAdmin, null);
        }

        [TestMethod]
        public void TestToStringAdministratorTrue()
        {
            Administrator anAdmin = new Administrator();
            StringBuilder buildOfExpected = new StringBuilder();
            buildOfExpected.Append("UserName: admin Password: admin2018 Name: adminSketchIt" +
                " Surname: adminSketchIt Registration Date: ");
            buildOfExpected.Append(anAdmin.Registration);
            buildOfExpected.Append(" Last Entry: ");
            buildOfExpected.Append(anAdmin.LastEntry);
            Assert.AreEqual(anAdmin.ToString(), buildOfExpected.ToString());
        }




    }
}
