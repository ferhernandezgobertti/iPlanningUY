using System;
using System.Text;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DesignerTest
    {

        private Designer designerToTest;
        
        [TestInitialize]
        public void TestInitialize() {
            designerToTest = new Designer();
            designerToTest.Name = "Nicolas";
            designerToTest.Surname = "Fornaro";
            designerToTest.UserName = "SoftwareORT";
            designerToTest.Password = "Design.4Ever";
        }

        [TestMethod]
        public void TestChartsHelpedInitiated() {
            Assert.AreEqual(this.designerToTest.ChartsHelped, 0);
        }

        [TestMethod]
        public void TestClientsHelpedInitiated() {
            Assert.AreEqual(this.designerToTest.ClientsHelped, 0);
        }

        [TestMethod]
        public void TestStoreDesignerDataTrue() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Designer designerToStore = new Designer();
            designerToStore.UserName = "Pablo3333";
            designerToStore.Password = "Paul.To4";
            designerToStore.Name = "Pablo";
            designerToStore.Surname = "Gomez";
            Designer designerToReplace = new Designer();
            designerToReplace.UserName = "Pedro2000";
            designerToReplace.Password = "Ped.To4";
            designerToReplace.Name = "Pedro";
            designerToReplace.Surname = "Lopez";
            Assert.IsTrue(designerToReplace.StoreData(oneTest.newProgram, designerToStore));
        }

        [TestMethod]
        public void TestStoreDesignerDataFalse() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Designer designerToStore = new Designer();
            designerToStore.UserName = "Pablo3333";
            designerToStore.Password = "Paul.To4";
            designerToStore.Name = "Pablo";
            designerToStore.Surname = "Gomez";
            Designer designerToReplace = new Designer();
            designerToReplace.UserName = "Renzo8989";
            designerToReplace.Password = "Ren.989";
            designerToReplace.Name = "Renzo";
            designerToReplace.Surname = "Gutierez";
            Assert.IsFalse(designerToReplace.StoreData(oneTest.newProgram, designerToStore));
        }

        [TestMethod]
        public void TestChangeDesignerPassword() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            String newPassword = "Fer.2020";
            Designer designerToModify = (Designer)oneTest.newProgram.GetDesignersFromUsers()[0];
            designerToModify.ChangePassword(oneTest.newProgram, newPassword);
            Assert.AreEqual(designerToModify.Password, newPassword);
        }

        [TestMethod]
        public void TestCheckDesignerLogInWhenNotPossible() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Designer otherDesigner = new Designer();
            otherDesigner = (Designer)otherDesigner.CheckLogIn(oneTest.newProgram, "Fer3030", "Fer.3030");
            Assert.AreEqual(otherDesigner, null);
        }

        [TestMethod]
        public void TestCheckDesignerLogIn() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Designer oneDesigner = (Designer)oneTest.newProgram.GetDesignersFromUsers()[0];
            Designer otherDesigner = new Designer();
            otherDesigner = (Designer)otherDesigner.CheckLogIn(oneTest.newProgram, oneDesigner.UserName, oneDesigner.Password);
            Assert.AreNotEqual(otherDesigner, null);
        }

        [TestMethod]
        public void TestToStringDesignerTrue() {

            StringBuilder buildOfExpected = new StringBuilder();
            buildOfExpected.Append("UserName: SoftwareORT Password: Design.4Ever Name: Nicolas" +
                " Surname: Fornaro Registration Date: ");
            buildOfExpected.Append(designerToTest.Registration);
            buildOfExpected.Append(" Last Entry: ");
            buildOfExpected.Append(designerToTest.LastEntry);
            Assert.AreEqual(designerToTest.ToString(), buildOfExpected.ToString());
        }

        [TestMethod]
        public void TestDesignerAddChartsHelped() {
            SketchItApp newProgram = SketchItApp.GetInstance();
            newProgram.Users.Add(this.designerToTest);
            this.designerToTest.AddChartsHelped(ref newProgram);
            int chartsHelpedExpected = 1;
            Assert.AreEqual(newProgram.GetDesignerFromList(this.designerToTest).ChartsHelped, chartsHelpedExpected);
        }

        [TestMethod]
        public void TestAddClientsHelped()
        {
            SketchItApp newProgram = SketchItApp.GetInstance();
            newProgram.Users.Add(this.designerToTest);
            this.designerToTest.AddClientsHelped(ref newProgram);
            int clientsHelpedExpected = 1;
            Assert.AreEqual(newProgram.GetDesignerFromList(this.designerToTest).ClientsHelped, clientsHelpedExpected);
        }

    }
}