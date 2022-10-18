using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UserTest
    {

        private User userToTest;

        [TestInitialize]
        public void TestInitialize()
        {
            userToTest = new User();
            userToTest.Name = "Fernando";
            userToTest.Surname = "Hernandez";
            userToTest.UserName = "SoftwareORT";
            userToTest.Password = "ORT.4Ever";
        }

        [TestMethod]
        public void TestIsPasswordWithSymbol() {
            userToTest.Password = "ORT#Software";
            Assert.IsTrue(userToTest.IsWordWithSymbol(userToTest.Password, ".,;<>|/#&^!"));
        }
        [TestMethod]
        public void TestIsNotPasswordWithSymbol() {
            userToTest.Password = "ORT#Software";
            Assert.IsFalse(userToTest.IsWordWithSymbol(userToTest.Password, "0123456789"));
        }
        [TestMethod]
        public void TestIsPasswordWithUpper() {
            userToTest.Password = "ORT.Software";
            Assert.IsTrue(userToTest.IsPasswordWithUpper());
        }
        [TestMethod]
        public void TestIsNotPasswordWithUpper() {
            userToTest.Password = "ort.software";
            Assert.IsFalse(userToTest.IsPasswordWithUpper());
        }
        [TestMethod]
        public void TestIsPasswordRight() {
            userToTest.Password = "da1.ORT";
            Assert.IsTrue(userToTest.IsPasswordRight());
        }
        [TestMethod]
        public void TestIsNotPasswordRight() {
            userToTest.Password = "da1";
            Assert.IsFalse(userToTest.IsPasswordRight());
        }

        [TestMethod]
        public void TestEqualsUserTrue() {
            User anUser = new User();
            anUser.Name = "Fernando";
            anUser.Surname = "Hernandez";
            anUser.UserName = "carofer-1";
            anUser.Password = "SoftwareORT";
            User otherUser = new User();
            otherUser.Name = "Carolina";
            otherUser.Surname = "Rodriguez";
            otherUser.UserName = "carofer-1";
            otherUser.Password = "SoftwareORT";
            Assert.IsTrue(anUser.Equals(otherUser));
        }
        [TestMethod]
        public void TestEqualsUserFalse() {
            User anUser = new User();
            anUser.Name = "Fernando";
            anUser.Surname = "Hernandez";
            anUser.UserName = "fer2032";
            anUser.Password = "SoftwareORT";
            User otherUser = new User();
            otherUser.Name = "Carolina";
            otherUser.Surname = "Rodriguez";
            otherUser.UserName = "carorod96";
            otherUser.Password = "SoftwareORT";
            Assert.IsFalse(anUser.Equals(otherUser));
        }

        [TestMethod]
        public void TestEqualsUserNull()
        {
            User anUser = new User();
            anUser.Name = "Carolina";
            anUser.Surname = "Rodriguez";
            anUser.UserName = "carorod96";
            anUser.Password = "SoftwareORT";

            User otherUser = null;
            Assert.IsFalse(anUser.Equals(otherUser));
        }

        [TestMethod]
        public void TestUpdateEntryClient() {
            User anUser = new User();
            DateTime lastEntryPrevious = anUser.LastEntry;
            System.Threading.Thread.Sleep(2000);
            anUser.UpdateLastEntry();
            DateTime lastEntryUpdated = anUser.LastEntry;
            Assert.AreNotEqual(lastEntryPrevious, lastEntryUpdated);
        }

        [TestMethod]
        public void TestGetFirstEntry() {
            User anUser = new User();
            Assert.IsTrue(anUser.FirstEntry);
        }

        [TestMethod]
        public void TestUserIsDesigner()
        {
            User anUser = new User();
            Assert.IsFalse(anUser.IsDesigner());
        }

        [TestMethod]
        public void TestUserIsClient()
        {
            User anUser = new User();
            Assert.IsFalse(anUser.IsClient());
        }

        [TestMethod]
        public void TestUserIsArchitect()
        {
            User anUser = new User();
            Assert.IsFalse(anUser.IsArchitect());
        }

    }
}
