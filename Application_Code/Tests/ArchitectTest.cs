using System;
using System.Text;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ArchitectTest
    {

        private Architect architectToTest;

        [TestInitialize]
        public void TestInitialize()
        {
            architectToTest = new Architect();
            architectToTest.Name = "Leonardo";
            architectToTest.Surname = "Cecilia";
            architectToTest.UserName = "Leo4ORT";
            architectToTest.Password = "Leo.4ORT";
        }

        [TestMethod]
        public void TestCheckArchitectLogInWhenNotPossible()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Architect otherArchitect = new Architect();
            otherArchitect = (Architect)otherArchitect.CheckLogIn(oneTest.newProgram, "Fer5050", "Fer.5");
            Assert.AreEqual(otherArchitect, null);
        }

        [TestMethod]
        public void TestCheckArchitectLogIn()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Architect otherArchitect = new Architect();
            otherArchitect = (Architect)otherArchitect.CheckLogIn(oneTest.newProgram, this.architectToTest.UserName, this.architectToTest.Password);
            Assert.AreNotEqual(otherArchitect, null);
        }

        [TestMethod]
        public void TestChangeArchitectPassword()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            String newPassword = "Caro.Rodd3";
            Architect architectToModify = (Architect)oneTest.newProgram.GetArchitectsFromUsers()[0];
            architectToModify.ChangePassword(oneTest.newProgram, newPassword);
            Assert.AreEqual(architectToModify.Password, newPassword);
        }

        [TestMethod]
        public void TestStoreArchitectDataTrue()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Architect architectToStore = new Architect();
            architectToStore.UserName = "Fer202";
            architectToStore.Password = "Fer.202";
            architectToStore.Name = "Fer";
            architectToStore.Surname = "Gonzalez";
            Architect architectToReplace = new Architect();
            architectToReplace.UserName = "Nico2020";
            architectToReplace.Password = "Nico.2020";
            architectToReplace.Name = "Nico";
            architectToReplace.Surname = "Fornaro";
            Assert.IsTrue(architectToReplace.StoreData(oneTest.newProgram, architectToStore));
        }

        [TestMethod]
        public void TestStoreArchitectDataFalse()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Architect architectToStore = new Architect();
            architectToStore.UserName = "Fer202";
            architectToStore.Password = "Fer.202";
            architectToStore.Name = "Fer";
            architectToStore.Surname = "Gonzalez";
            Architect architectToReplace = new Architect();
            architectToReplace.UserName = "Renzo8989";
            architectToReplace.Password = "Ren.989";
            architectToReplace.Name = "Renzo";
            architectToReplace.Surname = "Perez";
            Assert.IsFalse(architectToReplace.StoreData(oneTest.newProgram, architectToStore));
        }

        //[TestMethod]
        //public void TestGetUserNameArchitect()
        //{
        //    String usernameToCheck = architectToTest.GetUserName();
        //    Assert.AreEqual(usernameToCheck, "Leo4ORT");
        //}

        [TestMethod]
        public void TestArchitectAddChartsAndClientsHelped()
        { // Just for COVERAGE PURPOSES
            SketchItApp newProgram = SketchItApp.GetInstance();
            newProgram.Users.Add(this.architectToTest);
            this.architectToTest.AddChartsHelped(ref newProgram);
            this.architectToTest.AddClientsHelped(ref newProgram);
        }

        [TestMethod]
        public void TestToStringArchitectTrue()
        {
            StringBuilder buildOfExpected = new StringBuilder();
            buildOfExpected.Append("UserName: Leo4ORT Password: Leo.4ORT Name: Leonardo" +
                " Surname: Cecilia Registration Date: ");
            buildOfExpected.Append(architectToTest.Registration);
            buildOfExpected.Append(" Last Entry: ");
            buildOfExpected.Append(architectToTest.LastEntry);
            Assert.AreEqual(architectToTest.ToString(), buildOfExpected.ToString());
        }


    }
}
