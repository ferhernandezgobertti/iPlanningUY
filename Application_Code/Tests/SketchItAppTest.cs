using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SketchItAppTest
    {

        public SketchItApp newProgram;

        [TestInitialize]
        public void TestInitialize() {
            this.newProgram = SketchItApp.GetInstance();
            Designer aDesigner = new Designer();
            aDesigner.UserName = "Pedro2000";
            aDesigner.Password = "Ped.To4";
            aDesigner.Name = "Pedro";
            aDesigner.Surname = "Lopez";
            Designer otherDesigner = new Designer();
            otherDesigner.UserName = "Carlos5050";
            otherDesigner.Password = "Carl.4Ever";
            otherDesigner.Name = "Carlitos";
            otherDesigner.Surname = "Cabrera";

            Client aClient = new Client();
            aClient.UserName = "Fer5040";
            aClient.Password = "Far#5d2";
            aClient.Name = "Fernando";
            aClient.Surname = "Hernandez";
            aClient.NumberID = "4.851.112-6";
            aClient.Telephone = "098742547";
            aClient.Address = "Canelones 1267";
            Client otherClient = new Client();
            otherClient.UserName = "CaroRod33";
            otherClient.Password = "CaroFer.44";
            otherClient.Name = "Carolina";
            otherClient.Surname = "Rodriguez";
            otherClient.NumberID = "4.987.342-9";
            otherClient.Telephone = "098783456";
            otherClient.Address = "Malvin 1330";

            Architect anArchitect = new Architect();
            anArchitect.Name = "Leonardo";
            anArchitect.Surname = "Cecilia";
            anArchitect.UserName = "Leo4ORT";
            anArchitect.Password = "Leo.4ORT";
            Architect otherArchitect = new Architect();
            otherArchitect.UserName = "Nico2020";
            otherArchitect.Password = "Nico.2020";
            otherArchitect.Name = "Nico";
            otherArchitect.Surname = "Fornaro";

            Chart aChart = new Chart(aDesigner, aClient);
            aChart.Name = "AChart";
            int[] aChartDimensions = { 600, 600 };
            aChart.Dimensions.Width = aChartDimensions[0];
            aChart.Dimensions.Length = aChartDimensions[1];
            aChart.Money.Price = 600;
            Point[] oneWallDimensions = { new Point(100, 100), new Point(200, 100) };
            aChart.Elements.Add(new Wall(oneWallDimensions));
            Point[] otherWallDimensions = { new Point(200, 100), new Point(200, 200) };
            aChart.Elements.Add(new Wall(otherWallDimensions));
            aChart.Elements.Add(new Beam(new Point(100, 100)));
            aChart.Elements.Add(new Beam(new Point(200, 100)));
            aChart.Elements.Add(new Beam(new Point(200, 200)));
            aChart.Elements.Add(new Window(new Point(150, 100)));
            aChart.Elements.Add(new Door(new Point(200, 150)));
            Chart otherChart = new Chart(aDesigner, otherClient);
            otherChart.Name = "OtherChart";
            int[] otherChartDimensions = { 400, 400 };
            otherChart.Dimensions.Width = otherChartDimensions[0];
            otherChart.Dimensions.Length = otherChartDimensions[1];
            otherChart.Money.Price = 300;
            Point[] aWallDimensions = { new Point(100, 100), new Point(100, 200) };
            otherChart.Elements.Add(new Wall(aWallDimensions));
            Point[] anotherWallDimensions = { new Point(100, 200), new Point(200, 200) };
            otherChart.Elements.Add(new Wall(anotherWallDimensions));
            otherChart.Elements.Add(new Beam(new Point(100, 100)));
            otherChart.Elements.Add(new Beam(new Point(100, 200)));
            otherChart.Elements.Add(new Beam(new Point(200, 200)));
            otherChart.Elements.Add(new Window(new Point(100, 150)));
            otherChart.Elements.Add(new Door(new Point(150, 200)));
            newProgram.Users.Add(aDesigner);
            newProgram.Users.Add(otherDesigner);
            newProgram.Users.Add(aClient);
            newProgram.Users.Add(otherClient);
            newProgram.Users.Add(anArchitect);
            newProgram.Users.Add(otherArchitect);
            newProgram.Charts.Add(aChart);
            newProgram.Charts.Add(otherChart);
            
        }

        
        [TestMethod]
        public void TestGetChartFromListExisting() {

            Designer designerOfChart = new Designer();
            designerOfChart.UserName = "Pedro2000";
            designerOfChart.Password = "Ped.To4";
            designerOfChart.Name = "Pedro";
            designerOfChart.Surname = "Lopez";
            Client clientOfChart = new Client();
            clientOfChart.UserName = "CaroRod33";
            clientOfChart.Password = "CaroFer.44";
            clientOfChart.Name = "Carolina";
            clientOfChart.Surname = "Rodriguez";
            clientOfChart.NumberID = "4.987.342-9";
            clientOfChart.Telephone = "098783456";
            clientOfChart.Address = "Malvin 1330";
            Chart chartToGet = new Chart(designerOfChart, clientOfChart);
            chartToGet.Name = "OtherChart";
            int[] chartToGetDimensions = { 400, 400 };
            chartToGet.Dimensions.Width = chartToGetDimensions[0];
            chartToGet.Dimensions.Length = chartToGetDimensions[1];
            chartToGet.Money.Price = 300;
            Point[] aWallDimensions = { new Point(100, 100), new Point(100, 200) };
            chartToGet.Elements.Add(new Wall(aWallDimensions));
            Point[] anotherWallDimensions = { new Point(100, 200), new Point(200, 200) };
            chartToGet.Elements.Add(new Wall(anotherWallDimensions));
            chartToGet.Elements.Add(new Beam(new Point(100, 100)));
            chartToGet.Elements.Add(new Beam(new Point(100, 200)));
            chartToGet.Elements.Add(new Beam(new Point(200, 200)));
            chartToGet.Elements.Add(new Window(new Point(100, 150)));
            chartToGet.Elements.Add(new Door(new Point(150, 200)));
            Assert.AreEqual(this.newProgram.GetChartFromList(chartToGet), chartToGet);
        }
        
        [TestMethod]
        public void TestGetClientFromDesigner() {
            Designer designerSelected = new Designer();
            designerSelected.UserName = "Pedro2000";
            designerSelected.Password = "Ped.To4";
            designerSelected.Name = "Pedro";
            designerSelected.Surname = "Lopez";
            List<Client> clientsOfDesigner = this.newProgram.GetClientsFromDesigner(designerSelected);
            List<Client> clientsExpected = new List<Client>();
            Client aClient = new Client();
            aClient.UserName = "Fer5040";
            aClient.Password = "Far#5d2";
            aClient.Name = "Fernando";
            aClient.Surname = "Hernandez";
            aClient.NumberID = "4.851.112-6";
            aClient.Telephone = "098742547";
            aClient.Address = "Canelones 1267";
            Client otherClient = new Client();
            otherClient.UserName = "CaroRod33";
            otherClient.Password = "CaroFer.44";
            otherClient.Name = "Carolina";
            otherClient.Surname = "Rodriguez";
            otherClient.NumberID = "4.987.342-9";
            otherClient.Telephone = "098783456";
            otherClient.Address = "Malvin 1330";
            clientsExpected.Add(aClient);
            clientsExpected.Add(otherClient);

            CollectionAssert.AreEqual(clientsOfDesigner, clientsExpected);
        }
        
        [TestMethod]
        public void TestGetDesignerFromList() {
            Designer designerToGet = new Designer();
            designerToGet.UserName = "Carlos5050";
            designerToGet.Password = "Carl.4Ever";
            designerToGet.Name = "Carlitos";
            designerToGet.Surname = "Cabrera";
            Assert.AreEqual(this.newProgram.GetDesignerFromList(designerToGet), designerToGet);
        }

        [TestMethod]
        public void TestGetClientFromList()
        {
            Client clientToGet = new Client();
            clientToGet.UserName = "Fer5040";
            clientToGet.Password = "Far#5d2";
            clientToGet.Name = "Fernando";
            clientToGet.Surname = "Hernandez";
            clientToGet.NumberID = "4.851.112-6";
            clientToGet.Telephone = "098742547";
            clientToGet.Address = "Canelones 1267";
            Assert.AreEqual(this.newProgram.GetClientFromList(clientToGet), clientToGet);
        }

        [TestMethod]
        public void TestGetChartsFromDesigner() {
            Designer designerSelected = new Designer();
            designerSelected.UserName = "Pedro2000";
            designerSelected.Password = "Ped.To4";
            designerSelected.Name = "Pedro";
            designerSelected.Surname = "Lopez";
            List<IChartable> chartsExpected = this.newProgram.Charts;
            CollectionAssert.AreEqual(this.newProgram.GetChartsFromDesigner(designerSelected), chartsExpected);
        }

        [TestMethod]
        public void TestIsClientAvailableToAddTrue()
        {
            Client clientToAdd = new Client();
            clientToAdd.UserName = "Leo3030";
            clientToAdd.Password = "Leo.4Ever";
            clientToAdd.Name = "Leonardo";
            clientToAdd.Surname = "Cecilia";
            clientToAdd.NumberID = "1.873.234-8";
            clientToAdd.Telephone = "098889932";
            clientToAdd.Address = "Carrasco 8280";
            Assert.IsTrue(this.newProgram.IsClientAvailableToAdd(clientToAdd));
        }

        [TestMethod]
        [ExpectedException(typeof(Domain.Exceptions.InvalidFormatException))]
        public void TestIsClientAvailableToAddFalseNotWellRegistered()
        {
            Client clientToAdd = new Client();
            clientToAdd.UserName = "Fer5";
            clientToAdd.Password = "Fard2";
            clientToAdd.Name = "Fer";
            clientToAdd.Surname = "Hernandez";
            clientToAdd.NumberID = "4851112-6";
            clientToAdd.Telephone = "098742547";
            clientToAdd.Address = "Canelones 1267";
            bool clientAvailable = this.newProgram.IsClientAvailableToAdd(clientToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(Domain.Exceptions.AlreadyExistingUserException))]
        public void TestIsClientAvailableToAddFalseAlreadyRegistered()
        {
            Client clientToAdd = new Client();
            clientToAdd.UserName = "Fer5040";
            clientToAdd.Password = "Far#5d2";
            clientToAdd.Name = "Fernando";
            clientToAdd.Surname = "Hernandez";
            clientToAdd.NumberID = "4.851.112-6";
            clientToAdd.Telephone = "098742547";
            clientToAdd.Address = "Canelones 1267";
            bool clientAvailable = this.newProgram.IsClientAvailableToAdd(clientToAdd);
        }

        [TestMethod]
        public void TestIsDesignerAvailableToAddTrue()
        {
            Designer designerToAdd = new Designer();
            designerToAdd.UserName = "Nico808";
            designerToAdd.Password = "Nico.4ORT";
            designerToAdd.Name = "Nicolas";
            designerToAdd.Surname = "Fornaro";
            Assert.IsTrue(this.newProgram.IsDesignerAvailableToAdd(designerToAdd));
        }

        [TestMethod]
        [ExpectedException(typeof(Domain.Exceptions.InvalidFormatException))]
        public void TestIsDesignerAvailableToAddFalseNotWellRegistered()
        {
            Designer designerToAdd = new Designer();
            designerToAdd.UserName = "Carlos5";
            designerToAdd.Password = "CarlEver";
            designerToAdd.Name = "Carl";
            designerToAdd.Surname = "Cabrera";
            bool designerAvailable = this.newProgram.IsDesignerAvailableToAdd(designerToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(Domain.Exceptions.AlreadyExistingUserException))]
        public void TestIsDesignerAvailableToAddFalseAlreadyRegistered()
        {
            Designer designerToAdd = new Designer();
            designerToAdd.UserName = "Carlos5050";
            designerToAdd.Password = "Carl.4Ever";
            designerToAdd.Name = "Carlitos";
            designerToAdd.Surname = "Cabrera";
            bool designerAvailable = this.newProgram.IsDesignerAvailableToAdd(designerToAdd);
        }

        [TestMethod]
        public void TestIsArchitectAvailableToAddTrue()
        {
            Architect architectToAdd = new Architect();
            architectToAdd.UserName = "Fer2092";
            architectToAdd.Password = "Fer.2092";
            architectToAdd.Name = "Fernan2";
            architectToAdd.Surname = "Hernan2";
            Assert.IsTrue(this.newProgram.IsArchitectAvailableToAdd(architectToAdd));
        }

        [TestMethod]
        [ExpectedException(typeof(Domain.Exceptions.InvalidFormatException))]
        public void TestIsArchitectAvailableToAddFalseNotWellRegistered()
        {
            Architect architectToAdd = new Architect();
            architectToAdd.UserName = "Fer2092";
            architectToAdd.Password = "fer90";
            architectToAdd.Name = "Fernan2 August";
            architectToAdd.Surname = "Hernan2";
            bool architectAvailable = this.newProgram.IsArchitectAvailableToAdd(architectToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(Domain.Exceptions.AlreadyExistingUserException))]
        public void TestIsArchitectAvailableToAddFalseAlreadyRegistered()
        {
            Architect architectToAdd = new Architect();
            architectToAdd.UserName = "Nico2020";
            architectToAdd.Password = "Nico.2020";
            architectToAdd.Name = "Nico";
            architectToAdd.Surname = "Fornaro";
            bool architectAvailable = this.newProgram.IsArchitectAvailableToAdd(architectToAdd);
        }

        [TestMethod]
        public void TestIsArchitectNotYetRegisteredTrue()
        {
            Architect architectToCheck = new Architect();
            architectToCheck.UserName = "Fer2092";
            architectToCheck.Name = "Fernan2";
            architectToCheck.Surname = "Hernan2";
            Assert.IsTrue(this.newProgram.IsArchitectNotYetRegistered(architectToCheck));
        }

        [TestMethod]
        public void TestIsArchitectNotYetRegisteredFalse()
        {
            Assert.IsFalse(this.newProgram.IsArchitectNotYetRegistered((Architect)this.newProgram.GetArchitectsFromUsers()[0]));
        }

        [TestMethod]
        public void TestIsChartNotYetRegisteredTrue()
        {
            Designer designerOfChart = new Designer();
            designerOfChart.UserName = "Pablo7000";
            designerOfChart.Password = "Paul.To4";
            designerOfChart.Name = "Pablo";
            designerOfChart.Surname = "Gomez";
            Client clientOfChart = new Client();
            clientOfChart.UserName = "CaroRod33";
            clientOfChart.Password = "CaroFer.44";
            clientOfChart.Name = "Carolina";
            clientOfChart.Surname = "Rodriguez";
            clientOfChart.NumberID = "4.987.342-9";
            clientOfChart.Telephone = "098783456";
            clientOfChart.Address = "Malvin 1330";
            Chart chartToCheck = new Chart(designerOfChart, clientOfChart);
            chartToCheck.Name = "ExtraChart";
            int[] chartToGetDimensions = { 500, 500 };
            chartToCheck.Dimensions.Width = chartToGetDimensions[0];
            chartToCheck.Dimensions.Length = chartToGetDimensions[1];
            chartToCheck.Money.Price = 400;
            Point[] oneWallDimensions = { new Point(100, 100), new Point(50, 100) };
            chartToCheck.Elements.Add(new Wall(oneWallDimensions));
            Point[] otherWallDimensions = { new Point(50, 100), new Point(50, 50) };
            chartToCheck.Elements.Add(new Wall(otherWallDimensions));
            chartToCheck.Elements.Add(new Beam(new Point(100, 100)));
            chartToCheck.Elements.Add(new Beam(new Point(50, 100)));
            chartToCheck.Elements.Add(new Beam(new Point(50, 50)));
            chartToCheck.Elements.Add(new Door(new Point(50, 100)));
            Assert.IsTrue(this.newProgram.IsChartNotYetRegistered(chartToCheck));
        }
        
        [TestMethod]
        public void TestIsChartNotYetRegisteredFalse()
        {
            Designer aDesigner = new Designer();
            aDesigner.UserName = "Pedro2000";
            aDesigner.Password = "Ped.To4";
            aDesigner.Name = "Pedro";
            aDesigner.Surname = "Lopez";
            Client aClient = new Client();
            aClient.UserName = "Fer5040";
            aClient.Password = "Far#5d2";
            aClient.Name = "Fernando";
            aClient.Surname = "Hernandez";
            aClient.NumberID = "4.851.112-6";
            aClient.Telephone = "098742547";
            aClient.Address = "Canelones 1267";
            Chart chartToCheck = new Chart(aDesigner, aClient);
            chartToCheck.Name = "AChart";
            int[] aChartDimensions = { 600, 600 };
            chartToCheck.Dimensions.Width = aChartDimensions[0];
            chartToCheck.Dimensions.Length = aChartDimensions[1];
            chartToCheck.Money.Price = 600;
            Point[] oneWallDimensions = { new Point(100, 100), new Point(200, 100) };
            chartToCheck.Elements.Add(new Wall(oneWallDimensions));
            Point[] otherWallDimensions = { new Point(200, 100), new Point(200, 200) };
            chartToCheck.Elements.Add(new Wall(otherWallDimensions));
            chartToCheck.Elements.Add(new Beam(new Point(100, 100)));
            chartToCheck.Elements.Add(new Beam(new Point(200, 100)));
            chartToCheck.Elements.Add(new Beam(new Point(200, 200)));
            chartToCheck.Elements.Add(new Window(new Point(150, 100)));
            chartToCheck.Elements.Add(new Door(new Point(200, 150)));
            Assert.IsFalse(this.newProgram.IsChartNotYetRegistered(chartToCheck));
        }

        [TestMethod]
        public void TestIsClientRemovableTrue(){
            Client clientToRemove = new Client();
            clientToRemove.UserName = "CaroRod33";
            clientToRemove.Password = "CaroFer.44";
            clientToRemove.Name = "Carolina";
            clientToRemove.Surname = "Rodriguez";
            clientToRemove.NumberID = "4.987.342-9";
            clientToRemove.Telephone = "098783456";
            clientToRemove.Address = "Malvin 1330";
            Assert.IsTrue(this.newProgram.IsClientRemovable(clientToRemove));
        }

        [TestMethod]
        public void TestIsClientRemovableFalse()
        {
            Client clientToRemove = new Client();
            clientToRemove.UserName = "CaroFer33";
            clientToRemove.Password = "CaroSol.44";
            clientToRemove.Name = "Caro";
            clientToRemove.Surname = "Dominguez";
            clientToRemove.NumberID = "4.898.323-9";
            clientToRemove.Telephone = "098543556";
            clientToRemove.Address = "Portones 2020";
            Assert.IsFalse(this.newProgram.IsClientRemovable(clientToRemove));
        }

        [TestMethod]
        public void TestIsDesignerRemovableTrue()
        {
            Designer designerToRemove = new Designer();
            designerToRemove.UserName = "Pedro2000";
            designerToRemove.Password = "Ped.To4";
            designerToRemove.Name = "Pedro";
            designerToRemove.Surname = "Lopez";
            Assert.IsTrue(this.newProgram.IsDesignerRemovable(designerToRemove));
        }

        [TestMethod]
        public void TestIsDesignerRemovableFalse()
        {
            Designer designerToRemove = new Designer();
            designerToRemove.UserName = "Pablo3333";
            designerToRemove.Password = "Paul.To4";
            designerToRemove.Name = "Pablo";
            designerToRemove.Surname = "Gomez";
            Assert.IsFalse(this.newProgram.IsDesignerRemovable(designerToRemove));
        }

        [TestMethod]
        public void TestCalculateCostAndPrice() {
            double[] costAndPrice = this.newProgram.CalculateCostAndPrice(this.newProgram.Charts[0]);
            double[] costAndPriceExpected = { 4*50 + 3*50 + 1*50 + 1*50, 4*100 + 3*100 + 1*100 + 1*75};
            CollectionAssert.AreEqual(costAndPrice, costAndPriceExpected);
        }

        [TestMethod]
        public void TestGetChartsFromClient() {
            Client clientToGet = new Client();
            clientToGet.UserName = "CaroRod33";
            clientToGet.Password = "CaroFer.44";
            clientToGet.Name = "Carolina";
            clientToGet.Surname = "Rodriguez";
            clientToGet.NumberID = "4.987.342-9";
            clientToGet.Telephone = "098783456";
            clientToGet.Address = "Malvin 1330";
            List<IChartable> chartsFromClient = this.newProgram.GetChartsFromClient(clientToGet);
            List<IChartable> chartsFromClientExpected = new List<IChartable>();
            chartsFromClientExpected.Add(this.newProgram.Charts[1]);
            CollectionAssert.AreEqual(chartsFromClient, chartsFromClientExpected);
        }

        [TestMethod]
        public void TestAddChartsSigned()
        {
            Signature oneSignature = new Signature((Architect)this.newProgram.GetArchitectsFromUsers()[1]);
            this.newProgram.Charts[0].GetSignatures().Add(oneSignature);
            Architect architectToSign = (Architect)this.newProgram.GetArchitectsFromUsers()[0];
            this.newProgram.AddChartsSigned((Chart)this.newProgram.Charts[0], architectToSign);
            Assert.AreEqual(architectToSign.ChartsSigned, 1);
        }

        [TestMethod]
        public void TestDivideChartsIntoSingleSignaturesWhenOnlyOneSignature()
        {
            Signature oneSignature = new Signature((Architect)this.newProgram.GetArchitectsFromUsers()[0]);
            this.newProgram.Charts[0].GetSignatures().Add(oneSignature);
            this.newProgram.Charts[1].GetSignatures().Add(oneSignature);
            CollectionAssert.AreEqual(this.newProgram.DivideChartIntoSingleSignatures(this.newProgram.Charts), this.newProgram.Charts);
        }

        /* [TestMethod]
         public void TestDivideChartsIntoSingleSignaturesWhenMoreThanOneSignature()
         {
             Signature oneSignature = new Signature(this.newProgram.Architects[0]);
             this.newProgram.Charts[0].Signatures.Add(oneSignature);
             this.newProgram.Charts[0].GetSignatureWithOneSigning().RegisterSecondSignature(this.newProgram.Architects[1]);
             this.newProgram.Charts[1].Signatures.Add(oneSignature);
             List<Chart> chartsWithSingleSignatures = this.newProgram.DivideChartIntoSingleSignatures(this.newProgram.Charts);
             Assert.AreEqual(chartsWithSingleSignatures.Count, 3);
         }*/

        [TestMethod]
        public void TestGetHoleFromHoleTypes() {
            Hole newHoleType = new Hole();
            newHoleType.Location = new PointContainer();
            newHoleType.Money = new DoubleContainer();
            newHoleType.Name = "Great Hole";
            newHoleType.SetActualSize(2, 1);
            newHoleType.Money.Cost = 40;
            newHoleType.Money.Price = 80;
            this.newProgram.HoleTypes.Add(newHoleType);
            Assert.AreEqual(this.newProgram.GetHoleFromHoleTypes("Great Hole"), newHoleType);
        }

        [TestMethod]
        public void TestUpdateChartsDataWhenDoorMoneyChanged() {
            double[] newMoney = new double[2] { 100, 200 };
            this.newProgram.HoleTypes[0].Money.Cost = newMoney[0];
            this.newProgram.HoleTypes[0].Money.Price = newMoney[1];
            this.newProgram.UpdateChartsData();
            CollectionAssert.AreEqual(this.newProgram.Charts[0].GetElements()[6].GetElementMoney(), newMoney);
        }

        [TestMethod]
        public void TestUpdateChartsDataWhenWindowMoneyChanged()
        {
            double[] newMoney = new double[2] { 100, 200 };
            this.newProgram.HoleTypes[1].Money.Cost = newMoney[0];
            this.newProgram.HoleTypes[1].Money.Price = newMoney[1];
            this.newProgram.UpdateChartsData();
            CollectionAssert.AreEqual(this.newProgram.Charts[0].GetElements()[5].GetElementMoney(), newMoney);
        }

        [TestMethod]
        public void TestOnClosingProgram() { // Just for COVERAGE PURPOSES
            this.newProgram.OnClosingProgram();
        }

        [TestCleanup]
        public void TestCleanUp() {
            if(File.Exists(@"C:/Users/Public/AdministratorORTTest.txt"))
                File.Delete(@"C:/Users/Public/AdministratorORTTest.txt");
            if (File.Exists(@"C:/Users/Public/ClientsTest.txt"))
                File.Delete(@"C:/Users/Public/ClientsTest.txt");
            if (File.Exists(@"C:/Users/Public/DesignersTest.txt"))
                File.Delete(@"C:/Users/Public/DesignersTest.txt");
            if (File.Exists(@"C:/Users/Public/ChartsTest.txt"))
                File.Delete(@"C:/Users/Public/ChartsTest.txt");
            if (File.Exists(@"C:/Users/Public/ArchitectsTest.txt"))
                File.Delete(@"C:/Users/Public/ArchitectsTest.txt");
            
        }



    }
}
