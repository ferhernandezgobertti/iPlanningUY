using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WorkerTest
    {

        private Worker workerToTest;

        [TestInitialize]
        public void TestInitialize()
        {
            workerToTest = new Worker();
            workerToTest.Name = "Carolina";
            workerToTest.Surname = "Rodriguez";
            workerToTest.UserName = "CaroLa5";
            workerToTest.Password = "Caro.La5";
        }

        [TestMethod]
        public void TestWorkerGetDataEditing()
        {
            String[] dataEditing = { "CaroLa5", "Carolina", "Rodriguez" };
            Worker otherWorker = new Worker();
            otherWorker.GetDataEditing(dataEditing);
            Assert.AreEqual(workerToTest, otherWorker);
        }

        [TestMethod]
        public void TestPasswordEqualsWorkerTrue()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            String newPassword = "Fer.2020";
            Designer designerToCompare = (Designer)oneTest.newProgram.GetDesignersFromUsers()[0];
            designerToCompare.Password = "Fer.2020";
            Assert.IsTrue(designerToCompare.PasswordEquals(newPassword));
        }

        [TestMethod]
        public void TestPasswordEqualsWorkerFalse()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            String newPassword = "Fer.2020";
            Designer designerToCompare = (Designer)oneTest.newProgram.GetDesignersFromUsers()[0];
            designerToCompare.Password = "Fer.9090";
            Assert.IsFalse(designerToCompare.PasswordEquals(newPassword));
        }

        [TestMethod]
        public void TestIsWorkerWellRegisteredTrue()
        {
            Assert.IsTrue(workerToTest.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWorkerWellRegisteredWrongName()
        {
            workerToTest.Name = "Carolina Maria";
            Assert.IsFalse(workerToTest.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWorkerWellRegisteredWrongSurname()
        {
            workerToTest.Surname = "Hernandez Rodriguez";
            Assert.IsFalse(workerToTest.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWorkerWellRegisteredWrongUserName()
        {
            workerToTest.UserName = "CaroRod96aaaaaaaaaaaaa";
            Assert.IsFalse(workerToTest.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWorkerWellRegisteredWrongPassword()
        {
            workerToTest.Password = "nada";
            Assert.IsFalse(workerToTest.IsWellRegistered());
        }

        [TestMethod]
        public void TestWorkerStoreData()
        {
            Assert.IsTrue(this.workerToTest.StoreData(null, null));
        }

        [TestMethod]
        public void TestWorkerChangePassword()
        {
            SketchItApp newProgram = SketchItApp.GetInstance();
            this.workerToTest.ChangePassword(newProgram, "Pass.Wor2");
        }

        [TestMethod]
        public void TestEqualsWorkerSameUserName()
        {

            Worker otherWorker = new Worker();
            otherWorker.Name = "Nicolas";
            otherWorker.Surname = "Fornaro";
            otherWorker.UserName = "CaroLa5";

            Assert.IsTrue(workerToTest.Equals(otherWorker));
        }

        [TestMethod]
        public void TestEqualsWorkerSameNameAndSurname()
        {
            Architect otherWorker = new Architect();
            otherWorker.Name = "Carolina";
            otherWorker.Surname = "Rodriguez";
            otherWorker.UserName = "SoftwareORT";

            Assert.IsTrue(workerToTest.Equals(otherWorker));
        }

        [TestMethod]
        public void TestEqualsWorkerFalse()
        {
            Worker otherWorker = new Worker();
            otherWorker.Name = "Nicolas";
            otherWorker.Surname = "Cecilia";
            otherWorker.UserName = "DesignORT";

            Assert.IsFalse(workerToTest.Equals(otherWorker));
        }

        [TestMethod]
        public void TestEqualsArchitectNull()
        {
            Worker otherWorker = null;
            Assert.IsFalse(workerToTest.Equals(otherWorker));
        }

    }
}
