using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{

    [TestClass]
    public class ChartTest
    {

        private Chart chartToTest;

        [TestInitialize]
        public void TestInitialize() {
            Designer designerOfChart = new Designer();
            designerOfChart.UserName = "Pedro2000";
            designerOfChart.Password = "Ped.To4";
            designerOfChart.Name = "Pedro";
            designerOfChart.Surname = "Lopez";
            Client clientOfChart = new Client();
            clientOfChart.UserName = "Fer5040";
            clientOfChart.Password = "Far#5d2";
            clientOfChart.Name = "Fernando";
            clientOfChart.Surname = "Hernandez";
            clientOfChart.NumberID = "4.851.112-6";
            clientOfChart.Telephone = "098742547";
            clientOfChart.Address = "Canelones 1267";
            this.chartToTest = new Chart(designerOfChart, clientOfChart);
            this.chartToTest.Name = "Chart01";
            int[] chartTestDimensions = { 20, 20 };
            this.chartToTest.Dimensions.Width = chartTestDimensions[0];
            this.chartToTest.Dimensions.Length = chartTestDimensions[1];
            Point[] verticalWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall verticalWall = new Wall(verticalWallCoordinates);
            this.chartToTest.Elements.Add(verticalWall);
            this.chartToTest.Elements.Add(new Beam(new Point(300, 100)));
            this.chartToTest.Elements.Add(new Beam(new Point(300, 300)));
            Point[] horizontalWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall horizontalWall = new Wall(horizontalWallCoordinates);
            this.chartToTest.Elements.Add(horizontalWall);
            this.chartToTest.Elements.Add(new Beam(new Point(150, 450)));
            this.chartToTest.Elements.Add(new Beam(new Point(400, 450)));
            Door oneDoor = new Door(new Point(300, 250));
            oneDoor.OrientationDoor = 1;
            this.chartToTest.Elements.Add(oneDoor);
            Window oneWindow = new Window(new Point(350, 450));
            oneWindow.OrientationWindow = 1;
            this.chartToTest.Elements.Add(oneWindow);
            this.chartToTest.Elements.Add(new Column(new Point(900, 100)));
            this.chartToTest.Elements.Add(new Column(new Point(800, 300)));

        }

        [TestMethod]
        public void TestSortElements() {
            Point[] otherWallCoordinates = { new Point(100, 250), new Point(150, 250) };
            Wall otherWall = new Wall(otherWallCoordinates);
            this.chartToTest.Elements.Add(otherWall);
            this.chartToTest.Elements = this.chartToTest.SortElements();
            List<IDrawable> elementsToCompare = new List<IDrawable>();
            Point[] verticalWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall verticalWall = new Wall(verticalWallCoordinates);
            elementsToCompare.Add(verticalWall);
            Point[] horizontalWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall horizontalWall = new Wall(horizontalWallCoordinates);
            elementsToCompare.Add(horizontalWall);
            elementsToCompare.Add(otherWall); // NEW WALL
            elementsToCompare.Add(new Beam(new Point(300, 100)));
            elementsToCompare.Add(new Beam(new Point(300, 300)));
            elementsToCompare.Add(new Beam(new Point(150, 450)));
            elementsToCompare.Add(new Beam(new Point(400, 450)));
            Door oneDoor = new Door(new Point(300, 250));
            oneDoor.OrientationDoor = 1;
            elementsToCompare.Add(oneDoor);
            Window oneWindow = new Window(new Point(350, 450));
            oneWindow.OrientationWindow = 1;
            elementsToCompare.Add(oneWindow);
            elementsToCompare.Add(new Column(new Point(900, 100)));
            elementsToCompare.Add(new Column(new Point(800, 300)));
            CollectionAssert.AreEqual(this.chartToTest.Elements, elementsToCompare);
        }

        [TestMethod]
        public void TestAddWallTrue() {
            Point[] otherWallCoordinates = { new Point(100, 250), new Point(150, 250) };
            Wall otherWall = new Wall(otherWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsWallAddable(otherWall));
        }

        [TestMethod]
        public void TestAddWallAlreadyRegistered() {
            Point[] otherWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall otherWall = new Wall(otherWallCoordinates);
            Assert.IsFalse(this.chartToTest.IsWallAddable(otherWall));
        }

        [TestMethod]
        public void TestAddWallLengthNull() {
            Point[] otherWallCoordinates = { new Point(100, 300), new Point(100, 300) };
            Wall otherWall = new Wall(otherWallCoordinates);
            Assert.IsFalse(this.chartToTest.IsWallAddable(otherWall));
        }

        [TestMethod]
        public void TestCheckDimensionsTrue() {
            int[] dimensionsExample = { 20, 20 };
            this.chartToTest.Name = "Chart2020";
            this.chartToTest.Dimensions.Width = dimensionsExample[0];
            this.chartToTest.Dimensions.Length = dimensionsExample[1];
            Assert.IsTrue(this.chartToTest.IsChartWellRegistered());
        }

        [TestMethod]
        public void TestCheckDimensionsBiggestSize() {
            int[] dimensionsExample = { 100, 100 };
            this.chartToTest.Name = "Chart100100";
            this.chartToTest.Dimensions.Width = dimensionsExample[0];
            this.chartToTest.Dimensions.Length = dimensionsExample[1];
            Assert.IsTrue(this.chartToTest.IsChartWellRegistered());
        }

        [TestMethod]
        public void TestCheckDimensionsWrongSize() {
            int[] dimensionsExample = { 200, 200 };
            this.chartToTest.Name = "Chart2018";
            this.chartToTest.Dimensions.Width = dimensionsExample[0];
            this.chartToTest.Dimensions.Length = dimensionsExample[1];
            Assert.IsFalse(this.chartToTest.IsChartWellRegistered());
        }

        [TestMethod]
        public void TestCheckDimensionsWrongName() {
            int[] dimensionsExample = { 50, 50 };
            this.chartToTest.Name = "A Chart";
            this.chartToTest.Dimensions.Width = dimensionsExample[0];
            this.chartToTest.Dimensions.Length = dimensionsExample[1];
            Assert.IsFalse(this.chartToTest.IsChartWellRegistered());
        }

        [TestMethod]
        public void TestCheckDimensionsEmptyName() {
            int[] dimensionsExample = { 50, 50 };
            this.chartToTest.Name = "";
            this.chartToTest.Dimensions.Width = dimensionsExample[0];
            this.chartToTest.Dimensions.Length = dimensionsExample[1];
            Assert.IsFalse(this.chartToTest.IsChartWellRegistered());
        }

        [TestMethod]
        public void TestGetPixels() {
            int[] dimensionsExample = { 20, 20 };
            this.chartToTest.Dimensions.Width = dimensionsExample[0];
            this.chartToTest.Dimensions.Length = dimensionsExample[1];
            int[] pixelsQuantity = this.chartToTest.GetPixels();
            int[] correctAnswer = { 1000, 1000 };
            CollectionAssert.AreEqual(pixelsQuantity, correctAnswer);
        }

        [TestMethod]
        public void TestEqualsChartTrue() {
            Designer designerOfChart = new Designer();
            designerOfChart.UserName = "Pedro2000";
            designerOfChart.Password = "Ped.To4";
            designerOfChart.Name = "Pedro";
            designerOfChart.Surname = "Lopez";
            Client clientOfChart = new Client();
            clientOfChart.UserName = "Fer5040";
            clientOfChart.Password = "Far#5d2";
            clientOfChart.Name = "Fernando";
            clientOfChart.Surname = "Hernandez";
            clientOfChart.NumberID = "4.851.112-6";
            clientOfChart.Telephone = "098742547";
            clientOfChart.Address = "Canelones 1267";
            Chart otherChart = new Chart(designerOfChart, clientOfChart);
            otherChart.Elements = this.chartToTest.Elements;
            Assert.IsTrue(this.chartToTest.Equals(otherChart));
        }

        [TestMethod]
        public void TestEqualsDifferentElements() {
            Designer designerOfChart = new Designer();
            designerOfChart.UserName = "Pedro2000";
            designerOfChart.Password = "Ped.To4";
            designerOfChart.Name = "Pedro";
            designerOfChart.Surname = "Lopez";
            Client clientOfChart = new Client();
            clientOfChart.UserName = "Fer5040";
            clientOfChart.Password = "Far#5d2";
            clientOfChart.Name = "Fernando";
            clientOfChart.Surname = "Hernandez";
            clientOfChart.NumberID = "4.851.112-6";
            clientOfChart.Telephone = "098742547";
            clientOfChart.Address = "Canelones 1267";
            Chart otherChart = new Chart(designerOfChart, clientOfChart);
            Point[] otherWallCoordinates = { new Point(100, 100), new Point(100, 200) };
            Wall otherWall = new Wall(otherWallCoordinates);
            otherChart.Elements.Add(otherWall);
            Assert.IsFalse(this.chartToTest.Equals(otherChart));
        }

        [TestMethod]
        public void TestEqualsDifferentDesigner() {
            Client clientOfChart = new Client();
            clientOfChart.UserName = "Fer5040";
            clientOfChart.Password = "Far#5d2";
            clientOfChart.Name = "Fernando";
            clientOfChart.Surname = "Hernandez";
            clientOfChart.NumberID = "4.851.112-6";
            clientOfChart.Telephone = "098742547";
            clientOfChart.Address = "Canelones 1267";
            Designer otherDesignerOfChart = new Designer();
            otherDesignerOfChart.UserName = "Carlos5050";
            otherDesignerOfChart.Password = "Carl.4Ever";
            otherDesignerOfChart.Name = "Carlitos";
            otherDesignerOfChart.Surname = "Cabrera";
            Chart otherChart = new Chart(otherDesignerOfChart, clientOfChart);
            otherChart.Elements = this.chartToTest.Elements;
            Assert.IsFalse(this.chartToTest.Equals(otherChart));
        }

        [TestMethod]
        public void TestEqualsDifferentClient() {
            Designer designerOfChart = new Designer();
            designerOfChart.UserName = "Pedro2000";
            designerOfChart.Password = "Ped.To4";
            designerOfChart.Name = "Pedro";
            designerOfChart.Surname = "Lopez";
            Client otherClientOfChart = new Client();
            otherClientOfChart.UserName = "CaroRod33";
            otherClientOfChart.Password = "CaroFer.44";
            otherClientOfChart.Name = "Carolina";
            otherClientOfChart.Surname = "Rodriguez";
            otherClientOfChart.NumberID = "4.987.342-9";
            otherClientOfChart.Telephone = "098783456";
            otherClientOfChart.Address = "Malvin 1330";
            Chart otherChart = new Chart(designerOfChart, otherClientOfChart);
            otherChart.Elements = this.chartToTest.Elements;
            Assert.IsFalse(this.chartToTest.Equals(otherChart));
        }

        [TestMethod]
        public void TestEqualsChartNull() {
            Chart otherChart = null;
            Assert.IsFalse(this.chartToTest.Equals(otherChart));
        }

        [TestMethod]
        public void TestIsPossibleIntersectionTrue() {
            Point[] firstWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(250, 250), new Point(400, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsPossibleIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsPossibleIntersectionFalse()
        {
            Point[] firstWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 250), new Point(200, 500) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsFalse(this.chartToTest.IsPossibleIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsWallBetweenWallTrue() {
            Point[] oneWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall oneWall = new Wall(oneWallCoordinates);
            Point[] otherWallCoordinates = { new Point(250, 250), new Point(250, 500) };
            Wall otherWall = new Wall(otherWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsWallBetweenWall(oneWall, otherWall));
        }

        [TestMethod]
        public void TestIsWallBetweenWallParallels() {
            Point[] oneWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall oneWall = new Wall(oneWallCoordinates);
            Point[] otherWallCoordinates = { new Point(200, 100), new Point(200, 250) };
            Wall otherWall = new Wall(otherWallCoordinates);
            Assert.IsFalse(this.chartToTest.IsWallBetweenWall(oneWall, otherWall));
        }

        [TestMethod]
        public void TestIsWallBetweenWallLenghtNotEnough() {
            Point[] oneWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall oneWall = new Wall(oneWallCoordinates);
            Point[] otherWallCoordinates = { new Point(100, 250), new Point(200, 250) };
            Wall otherWall = new Wall(otherWallCoordinates);
            Assert.IsFalse(this.chartToTest.IsWallBetweenWall(oneWall, otherWall));
        }

        [TestMethod]
        public void TestCaptureIntersectionPointVerticalHorizontal() {
            Point[] firstWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(250, 250), new Point(400, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(300, 250);
            Assert.AreEqual(this.chartToTest.CaptureIntersectionPoint(firstWall, secondWall), expectedIntersection);
        }

        [TestMethod]
        public void TestCaptureIntersectionPointHorizontalVertical() {
            Point[] firstWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(250, 250), new Point(250, 500) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(250, 450);
            Assert.AreEqual(this.chartToTest.CaptureIntersectionPoint(secondWall, firstWall), expectedIntersection);
        }

        [TestMethod]
        public void TestGetIntersectionWhenCrossIntersectionLeftUp() {
            Point[] firstWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 250), new Point(200, 500) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(200, 450);
            Assert.AreEqual(this.chartToTest.GetIntersection(secondWall, firstWall), expectedIntersection);
        }

        [TestMethod]
        public void TestGetIntersectionWhenCrossIntersectionRightUp() {
            Point[] firstWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(400, 250), new Point(250, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(300, 250);
            Assert.AreEqual(this.chartToTest.GetIntersection(firstWall, secondWall), expectedIntersection);
        }

        [TestMethod]
        public void TestGetIntersectionWhenCrossIntersectionLeftDown() {
            Point[] firstWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 500), new Point(200, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(200, 450);
            Assert.AreEqual(this.chartToTest.GetIntersection(firstWall, secondWall), expectedIntersection);
        }

        [TestMethod]
        public void TestGetIntersectionWhenCrossIntersectionRightDown() {
            Point[] firstWallCoordinates = { new Point(350, 400), new Point(350, 200) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(250, 250), new Point(400, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(350, 250);
            Assert.AreEqual(this.chartToTest.GetIntersection(firstWall, secondWall), expectedIntersection);
        }

        [TestMethod]
        public void TestGetIntersectionWhenTeIntersection() {
            Point[] firstWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 250), new Point(200, 450) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(200, 450);
            Assert.AreEqual(this.chartToTest.GetIntersection(firstWall, secondWall), expectedIntersection);
        }

        [TestMethod]
        public void TestGetIntersectionWhenNoIntersection() {
            Point[] firstWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 250), new Point(250, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Point expectedIntersection = new Point(0, 0);
            Assert.AreEqual(this.chartToTest.GetIntersection(firstWall, secondWall), expectedIntersection);
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionRightUpOutTrue() {
            Point[] firstWallCoordinates = { new Point(100, 200), new Point(100, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 250), new Point(100, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionRightUpCoincidingTrue() {
            Point[] firstWallCoordinates = { new Point(100, 200), new Point(100, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(100, 250), new Point(200, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionLeftUpCoincidingTrue() {
            Point[] firstWallCoordinates = { new Point(100, 200), new Point(100, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(100, 250), new Point(50, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionLeftUpOutTrue() {
            Point[] firstWallCoordinates = { new Point(100, 200), new Point(100, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(50, 250), new Point(100, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionLeftDownOutTrue() {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 200) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(50, 250), new Point(100, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionLeftDownCoincidingTrue() {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 200) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(100, 250), new Point(50, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionRightDownOutTrue() {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 200) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(150, 250), new Point(100, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeHorizontalIntersectionRightDownCoincidingTrue() {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 200) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(100, 250), new Point(150, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeHorizontalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeVerticalIntersectionRightUpOutTrue() {
            Point[] firstWallCoordinates = { new Point(100, 100), new Point(100, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 300), new Point(50, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeVerticalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeVerticalIntersectionRightDownOutTrue() {
            Point[] firstWallCoordinates = { new Point(100, 400), new Point(100, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 300), new Point(50, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeVerticalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeVerticalIntersectionRightDownCoincidingTrue() {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 100) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 300), new Point(50, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeVerticalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeVerticalIntersectionLeftDownCoincidingTrue() {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 100) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(50, 300), new Point(200, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeVerticalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeVerticalIntersectionLeftUpCoincidingTrue()  {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 400) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(50, 300), new Point(200, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeVerticalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestIsTeVerticalIntersectionRightUpCoincidingTrue() {
            Point[] firstWallCoordinates = { new Point(100, 300), new Point(100, 400) };
            Wall firstWall = new Wall(firstWallCoordinates);
            Point[] secondWallCoordinates = { new Point(200, 300), new Point(50, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsTeVerticalIntersection(firstWall, secondWall));
        }

        [TestMethod]
        public void TestDivideWallIntoSmallerWhenCrossIntersection() {
            Point[] secondWallCoordinates = { new Point(250, 250), new Point(400, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Wall division = this.chartToTest.DivideWallIntoSmaller(secondWall, new Point(300, 250));
            Point[] expectedDimensions = { new Point(300, 250), new Point(400, 250) };
            Wall expected = new Wall(expectedDimensions);
            Assert.AreEqual(division, expected);
        }
        [TestMethod]
        public void TestDivideWallIntoSmallerWhenTeIntersection() {
            Point[] secondWallCoordinates = { new Point(100, 250), new Point(150, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Wall division = this.chartToTest.DivideWallIntoSmaller(secondWall, new Point(100, 250));
            Point[] expectedDimensions = { new Point(100, 250), new Point(150, 250) };
            Wall expected = new Wall(expectedDimensions);
            Assert.AreEqual(division, expected);
        }
        [TestMethod]
        public void TestDivideWallIntoSmallerWhenWallOfLengthNull() {
            Point[] secondWallCoordinates = { new Point(100, 250), new Point(100, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Wall division = this.chartToTest.DivideWallIntoSmaller(secondWall, new Point(100, 250));
            Point[] expectedDimensions = { new Point(100, 250), new Point(100, 250) };
            Wall expected = new Wall(expectedDimensions);
            Assert.AreEqual(division, expected);
        }

        [TestMethod]
        public void TestGetWallFromList() {
            Point[] secondWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.AreEqual(this.chartToTest.GetWallFromList(secondWall), secondWall);
        }

        [TestMethod]
        public void TestIsWallWellRegisteredTrue() {
            Point[] secondWallCoordinates = { new Point(100, 200), new Point(100, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsWallWellRegistered(secondWall));
        }

        [TestMethod]
        public void TestIsWallWellRegisteredWhenAlreadyRegistered() {
            Point[] secondWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsFalse(this.chartToTest.IsWallWellRegistered(secondWall));
        }

        [TestMethod]
        public void TestIsWallWellRegisteredWhenPointNotOnChart() {
            Point[] secondWallCoordinates = { new Point(0, 0), new Point(100, 250) };
            Wall secondWall = new Wall(secondWallCoordinates);
            Assert.IsFalse(this.chartToTest.IsWallWellRegistered(secondWall));
        }

        [TestMethod]
        public void TestIsPointOnChartTrue() {
            Point pointToCheck = new Point(100, 250);
            Assert.IsTrue(this.chartToTest.IsPointOnChart(pointToCheck));
        }

        [TestMethod]
        public void TestIsPointOnChartWhenBeforeChart() {
            Point pointToCheck = new Point(0, 300);
            Assert.IsFalse(this.chartToTest.IsPointOnChart(pointToCheck));
        }

        [TestMethod]
        public void TestIsPointOnChartWhenAfterChart() {
            Point pointToCheck = new Point(100, this.chartToTest.Dimensions.Width*ConstantsWall.BLOCKLENGTH+100);
            Assert.IsFalse(this.chartToTest.IsPointOnChart(pointToCheck));
        }

        [TestMethod]
        public void TestToStringChart() {
            String expected = "CHART NAME: Chart01 :: CREATOR: Pedro2000 - Length: 20 - Width: 20 - Cost: 0 - Price: 0";
            Assert.AreEqual(this.chartToTest.ToString(), expected);
        }

        [TestMethod]
        public void TestToStringChartWhenSigned()
        {
            Architect firstSigner = new Architect();
            firstSigner.UserName = "John Paul";
            Signature firstSignature = new Signature(firstSigner);
            this.chartToTest.Signatures.Add(firstSignature);
            String expected = "- SIGNED - CHART NAME: Chart01 :: CREATOR: Pedro2000 - Length: 20 - Width: 20 - Cost: 0 - Price: 0";
            Assert.AreEqual(this.chartToTest.ToString(), expected);
        }

        [TestMethod]
        public void TestIsCompletelySignedTrue()
        {
            Architect firstAndSecondSigner = new Architect();
            firstAndSecondSigner.UserName = "John Paul";
            Signature firstSignature = new Signature(firstAndSecondSigner);
            this.chartToTest.Signatures.Add(firstSignature);
            this.chartToTest.GetSignatureWithOneSigning().RegisterSecondSignature(firstAndSecondSigner);
            Assert.IsTrue(this.chartToTest.IsCompletelySigned());
        }

        [TestMethod]
        public void TestIsCompletelySignedFalse()
        {
            Architect firstSigner = new Architect();
            firstSigner.UserName = "John Paul";
            Signature firstSignature = new Signature(firstSigner);
            this.chartToTest.Signatures.Add(firstSignature);
            Assert.IsFalse(this.chartToTest.IsCompletelySigned());
        }

        [TestMethod]
        public void TestGetSignatureWithOneSigningWhenItDoesExist()
        {
            Architect firstSigner = new Architect();
            firstSigner.UserName = "John Paul";
            Signature firstSignature = new Signature(firstSigner);
            this.chartToTest.Signatures.Add(firstSignature);
            Assert.AreEqual(this.chartToTest.GetSignatureWithOneSigning(), firstSignature);
        }

        [TestMethod]
        public void TestGetSignatureWithOneSigningWhenItDoesNotExist()
        {
            Assert.IsNull(this.chartToTest.GetSignatureWithOneSigning());
        }

        [TestMethod]
        public void TestAddBeamsDueToLength() {
            Point[] otherWallCoordinates = { new Point(100, 100), new Point(100, 600) };
            Wall otherWall = new Wall(otherWallCoordinates);
            this.chartToTest.AddBeamsDueToLength(otherWall);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 13; 
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestAddBeamsDueToLengthWhenNotNecessary() {
            Point[] otherWallCoordinates = { new Point(100, 100), new Point(100, 200) };
            Wall otherWall = new Wall(otherWallCoordinates);
            this.chartToTest.AddBeamsDueToLength(otherWall);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 11;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestAddDoor() {
            Door otherDoor = new Door(new Point(200, 450));
            this.chartToTest.AddDoor(otherDoor);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 11;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestAddDoorWhenNotWellRegistered() {
            Door otherDoor = new Door(new Point(300, 250));
            otherDoor.OrientationDoor = 1;
            this.chartToTest.AddDoor(otherDoor);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 10;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestAddWindow() {
            Window otherWindow = new Window(new Point(300, 150));
            this.chartToTest.AddWindow(otherWindow);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 11;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestAddWindowWhenNotWellRegistered() {
            Window otherWindow = new Window(new Point(350, 450));
            otherWindow.OrientationWindow = 1;
            this.chartToTest.AddWindow(otherWindow);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 10;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestAddColumn()
        {
            Column otherColumn = new Column(new Point(600, 200));
            this.chartToTest.AddColumn(otherColumn);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 11;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestAddColumnWhenNotWellRegistered()
        {
            Column otherColumn = new Column(new Point(900, 100));
            this.chartToTest.AddColumn(otherColumn);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 10;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestCalculateCost() {
            double[,] defaultElementsMoney = new double[5, 2] { { 50, 100 }, { 50, 100 }, { 50, 100 }, { 50, 75 }, { 25, 50 } };  //Default Values
            double costOfChartTested = this.chartToTest.CalculateMoney(defaultElementsMoney)[0];
            double costOfChartTestedExpected = 9*50 + 4*50 + 1*50 + 1*50 + 2*25;
            Assert.AreEqual(costOfChartTested, costOfChartTestedExpected);
        }

        [TestMethod]
        public void TestCalculatePrice() {
            double[,] defaultElementsMoney = new double[5, 2] { { 50, 100 }, { 50, 100 }, { 50, 100 }, { 50, 75 }, { 25, 50 } };  //Default Values
            double priceOfChartTested = this.chartToTest.CalculateMoney(defaultElementsMoney)[1];
            double priceOfChartTestedExpected = 9 * 100 + 4 * 100 + 1 * 100 + 1 * 75 + 2*50;
            Assert.AreEqual(priceOfChartTested, priceOfChartTestedExpected);
        }

        [TestMethod]
        public void TestEliminateBeams() {
            Point[] firstWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            this.chartToTest.RemoveWall(firstWall);
            this.chartToTest.EliminateBeams(firstWall);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 7;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestEliminateHolesWhenDoors() {
            Point[] firstWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall firstWall = new Wall(firstWallCoordinates);
            this.chartToTest.RemoveWall(firstWall);
            this.chartToTest.EliminateHoles(firstWall);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 8;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestEliminateHolesWhenWindows() {
            Point[] secondWallCoordinates = { new Point(150, 450), new Point(400, 450) };
            Wall secondWall = new Wall(secondWallCoordinates);
            this.chartToTest.RemoveWall(secondWall);
            this.chartToTest.EliminateHoles(secondWall);
            int elementsQuantity = this.chartToTest.Elements.Count;
            int elementsQuantityExpected = 8;
            Assert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestGetWallOfPointWhenNull() {
            Assert.IsNull(this.chartToTest.GetWallOfPoint(new Point(100, 100)));
        }

        [TestMethod]
        public void TestIsDoorAvailableWhenOrientation1() {
            Door otherDoor = new Door(new Point(300, 150));
            otherDoor.OrientationDoor = 1;
            Assert.IsTrue(this.chartToTest.IsDoorAvailable(otherDoor, 1));
        }

        [TestMethod]
        public void TestIsDoorAvailableWhenOrientation2() {
            Door otherDoor = new Door(new Point(200, 450));
            Assert.IsTrue(this.chartToTest.IsDoorAvailable(otherDoor, 1));
        }

        [TestMethod]
        public void TestIsDoorAvailableWhenOrientation3() {
            Door otherDoor = new Door(new Point(300, 150));
            otherDoor.OrientationDoor = 3;
            Assert.IsTrue(this.chartToTest.IsDoorAvailable(otherDoor, 1));
        }

        [TestMethod]
        public void TestIsDoorAvailableWhenOrientation4() {
            Door otherDoor = new Door(new Point(200, 450));
            otherDoor.OrientationDoor = 4;
            Assert.IsTrue(this.chartToTest.IsDoorAvailable(otherDoor, 1));
        }

        [TestMethod]
        public void TestIsDoorAvailableWhenNoWallExists() {
            Door otherDoor = new Door(new Point(100, 100));
            Assert.IsFalse(this.chartToTest.IsDoorAvailable(otherDoor, 1));
        }

        [TestMethod]
        public void TestIsDoorAvailableWhenCrossingLine() {
            Door otherDoor = new Door(new Point(300, 150));
            Assert.IsFalse(this.chartToTest.IsDoorAvailable(otherDoor, 1));
        }
        
        [TestMethod]
        public void TestIsWindowAvailableWhenOrientation1() {
            Window otherWindow = new Window(new Point(200, 450));
            otherWindow.OrientationWindow = 1;
            Assert.IsTrue(this.chartToTest.IsWindowAvailable(otherWindow, 1));
        }

        [TestMethod]
        public void TestIsWindowAvailableWhenOrientation2() {
            Window otherWindow = new Window(new Point(300, 150));
            Assert.IsTrue(this.chartToTest.IsWindowAvailable(otherWindow, 1));
        }

        [TestMethod]
        public void TestIsWindowAvailableWhenCrossingLine() {
            Window otherWindow = new Window(new Point(300, 150));
            otherWindow.OrientationWindow = 1;
            Assert.IsFalse(this.chartToTest.IsWindowAvailable(otherWindow, 1));
        }

        [TestMethod]
        public void TestIsWindowAvailableWhenNoWallExists() {
            Window otherWindow = new Window(new Point(100, 100));
            Assert.IsFalse(this.chartToTest.IsWindowAvailable(otherWindow, 1));
        }

        [TestMethod]
        public void TestIsWindowWithSameOrientationWhenVertical() {
            Window otherWindow = new Window(new Point(300, 150));
            Assert.IsTrue(this.chartToTest.IsWindowsWithSameOrientationWall(otherWindow));
        }

        [TestMethod]
        public void TestIsWindowWithSameOrientationWhenHorizontal() {
            Window otherWindow = new Window(new Point(200, 450));
            otherWindow.OrientationWindow = 1;
            Assert.IsTrue(this.chartToTest.IsWindowsWithSameOrientationWall(otherWindow));
        }

        [TestMethod]
        public void TestIsWindowWithSameOrientationWhenNoWallExists() {
            Window otherWindow = new Window(new Point(100, 100));
            Assert.IsFalse(this.chartToTest.IsWindowsWithSameOrientationWall(otherWindow));
        }

        [TestMethod]
        public void TestIsColumnAvailableTrue() {
            Column columnToCheck = new Column(new Point(600, 100));
            Assert.IsTrue(this.chartToTest.IsColumnAvailable(columnToCheck));
        }

        [TestMethod]
        public void TestIsColumnAvailableFalse() {
            Column columnToCheck = new Column(new Point(900, 100));
            Assert.IsTrue(this.chartToTest.IsColumnAvailable(columnToCheck));
        }

        [TestMethod]
        public void TestIsEmptyTrue() {
            Chart emptyChart = new Chart(new Designer(), new Client());
            Assert.IsTrue(emptyChart.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmptyFalse() {
            Assert.IsFalse(this.chartToTest.IsEmpty());
        }

        [TestMethod]
        public void TestIsHoleInBetweenTrue() {
            Point[] oneWallCoordinates = { new Point(300, 100), new Point(300, 300) };
            Wall oneWall = new Wall(oneWallCoordinates);
            Assert.IsTrue(this.chartToTest.IsHoleInBetween(oneWall));
        }

        [TestMethod]
        public void TestIsHoleInBetweenFalse() {
            Point[] oneWallCoordinates = { new Point(100, 100), new Point(100, 200) };
            Wall oneWall = new Wall(oneWallCoordinates);
            this.chartToTest.Elements.Add(oneWall);
            Assert.IsFalse(this.chartToTest.IsHoleInBetween(oneWall));
        }

        [TestMethod]
        public void TestIsIntersectionTrueVerticalHorizontal() {
            Point[] otherWallCoordinates = { new Point(200, 400), new Point(200, 500) };
            Wall otherWall = new Wall(otherWallCoordinates);
            this.chartToTest.Elements.Add(otherWall);
            Assert.IsTrue(this.chartToTest.IsIntersection());
        }

        [TestMethod]
        public void TestIsIntersectionFalseVerticalHorizontal() {
            Point[] otherWallCoordinates = { new Point(200, 200), new Point(200, 300) };
            Wall otherWall = new Wall(otherWallCoordinates);
            this.chartToTest.Elements.Add(otherWall);
            Assert.IsFalse(this.chartToTest.IsIntersection());
        }

        [TestMethod]
        public void TestIsIntersectionTrueHorizontalVertical()
        {
            Point[] otherWallCoordinates = { new Point(250, 250), new Point(250, 450) };
            Wall otherWall = new Wall(otherWallCoordinates);
            this.chartToTest.Elements.Add(otherWall);
            Assert.IsTrue(this.chartToTest.IsIntersection());
        }

        [TestMethod]
        public void TestIsIntersectionFalseHorizontalVertical() {
            Point[] otherWallCoordinates = { new Point(250, 100), new Point(250, 200) };
            Wall otherWall = new Wall(otherWallCoordinates);
            this.chartToTest.Elements.Add(otherWall);
            Assert.IsFalse(this.chartToTest.IsIntersection());
        }

        [TestMethod]
        public void TestCountElements() {
            int[] elementsQuantity = this.chartToTest.CountElements();
            int[] elementsQuantityExpected = new int[5] { 4+5, 2*2, 1, 1, 2};
            CollectionAssert.AreEqual(elementsQuantity, elementsQuantityExpected);
        }

        [TestMethod]
        public void TestIsPointOnHoleTrue() {
            Point pointToCheck = new Point(300,250);
            Assert.IsTrue(this.chartToTest.IsPointOnHole(pointToCheck));
        }

        [TestMethod]
        public void TestIsPointOnHoleFalse()
        {
            Point pointToCheck = new Point(500,250);
            Assert.IsFalse(this.chartToTest.IsPointOnHole(pointToCheck));
        }

        [TestMethod]
        public void TestIsDoorNotYetRegisteredNearWindowFalseWhenHorizontal()
        {
            Window oneWindow = new Window(new Point(350, 250));
            oneWindow.OrientationWindow = 1;
            Assert.IsFalse(this.chartToTest.IsDoorNotYetRegisteredNearWindow(oneWindow, 1));
        }

        [TestMethod]
        public void TestIsDoorNotYetRegisteredNearWindowFalseWhenVertical()
        {
            Window oneWindow = new Window(new Point(300, 200));
            Assert.IsFalse(this.chartToTest.IsDoorNotYetRegisteredNearWindow(oneWindow, 1));
        }

        [TestMethod]
        public void TestIsDoorNotYetRegisteredNearWindowTrue()
        {
            Window oneWindow = new Window(new Point(100, 250));
            oneWindow.OrientationWindow = 1;
            Assert.IsTrue(this.chartToTest.IsDoorNotYetRegisteredNearWindow(oneWindow, 1));
        }

        [TestMethod]
        public void TestIsBeamNotYetRegisteredNearWindowFalseWhenHorizontal()
        {
            Window oneWindow = new Window(new Point(350, 100));
            oneWindow.OrientationWindow = 1;
            Assert.IsFalse(this.chartToTest.IsBeamNotYetRegisteredNearWindow(oneWindow, 1));
        }

        [TestMethod]
        public void TestIsBeamNotYetRegisteredNearWindowFalseWhenVertical()
        {
            Window oneWindow = new Window(new Point(300, 150));
            Assert.IsFalse(this.chartToTest.IsBeamNotYetRegisteredNearWindow(oneWindow, 1));
        }

        [TestMethod]
        public void TestIsBeamNotYetRegisteredNearWindowTrue()
        {
            Window oneWindow = new Window(new Point(500, 250));
            oneWindow.OrientationWindow = 1;
            Assert.IsTrue(this.chartToTest.IsBeamNotYetRegisteredNearWindow(oneWindow, 1));
        }

        [TestMethod]
        public void TestIsWindowNotYetRegisteredNearDoorFalseWhenHorizontal()
        {
            Door oneDoor = new Door(new Point(350, 400));
            oneDoor.OrientationDoor = 1;
            Assert.IsFalse(this.chartToTest.IsWindowNotYetRegisteredNearDoor(oneDoor, 1));
        }

        [TestMethod]
        public void TestIsWindowNotYetRegisteredNearDoorFalseWhenVertical()
        {
            Door oneDoor = new Door(new Point(400, 450));
            Assert.IsFalse(this.chartToTest.IsWindowNotYetRegisteredNearDoor(oneDoor, 1));
        }

        [TestMethod]
        public void TestIsWindowNotYetRegisteredNearDoorTrue()
        {
            Door oneDoor = new Door(new Point(1000, 250));
            oneDoor.OrientationDoor = 1;
            Assert.IsTrue(this.chartToTest.IsWindowNotYetRegisteredNearDoor(oneDoor, 1));
        }

        [TestMethod]
        public void TestIsBeamNotYetRegisteredNearDoorFalseWhenHorizontal()
        {
            Door oneDoor = new Door(new Point(300, 250));
            oneDoor.OrientationDoor = 1;
            Assert.IsFalse(this.chartToTest.IsBeamNotYetRegisteredNearDoor(oneDoor));
        }

        [TestMethod]
        public void TestIsBeamNotYetRegisteredNearDoorFalseWhenVertical()
        {
            Door oneDoor = new Door(new Point(350, 300));
            Assert.IsFalse(this.chartToTest.IsBeamNotYetRegisteredNearDoor(oneDoor));
        }

        [TestMethod]
        public void TestIsBeamNotYetRegisteredNearDoorTrue()
        {
            Door oneDoor = new Door(new Point(500, 300));
            oneDoor.OrientationDoor = 1;
            Assert.IsTrue(this.chartToTest.IsBeamNotYetRegisteredNearDoor(oneDoor));
        }

        [TestMethod]
        public void TestIsNoBigDoorInSurroundingsOfDoorFalseWhenHorizontalLeft()
        {
            Door bigDoorToFind = new Door(new Point(1000, 250));
            bigDoorToFind.SetActualSize(2.5, 1);
            bigDoorToFind.OrientationDoor = 4;
            this.chartToTest.AddDoor(bigDoorToFind);
            Door referenceDoor = new Door(new Point(1100, 350));
            referenceDoor.OrientationDoor = 3;
            Assert.IsFalse(this.chartToTest.IsNoBigDoorInSurroundingsOfDoor(referenceDoor, 2, 2));
        }

        [TestMethod]
        public void TestIsNoBigDoorInSurroundingsOfDoorFalseWhenHorizontalRight()
        {
            Door bigDoorToFind = new Door(new Point(1000, 250));
            bigDoorToFind.SetActualSize(2.5, 1);
            bigDoorToFind.OrientationDoor = 2;
            this.chartToTest.AddDoor(bigDoorToFind);
            Door referenceDoor = new Door(new Point(900, 150));
            referenceDoor.OrientationDoor = 1;
            Assert.IsFalse(this.chartToTest.IsNoBigDoorInSurroundingsOfDoor(referenceDoor, 2, 2));
        }

        [TestMethod]
        public void TestIsNoBigDoorInSurroundingsOfDoorFalseWhenVerticalUp()
        {
            Door bigDoorToFind = new Door(new Point(1000, 250));
            bigDoorToFind.SetActualSize(2.5, 1);
            bigDoorToFind.OrientationDoor = 1;
            this.chartToTest.AddDoor(bigDoorToFind);
            Door referenceDoor = new Door(new Point(1100, 350));
            referenceDoor.OrientationDoor = 2;
            Assert.IsFalse(this.chartToTest.IsNoBigDoorInSurroundingsOfDoor(referenceDoor, 2, 2));
        }

        [TestMethod]
        public void TestIsNoBigDoorInSurroundingsOfDoorFalseWhenVerticalDown()
        {
            Door bigDoorToFind = new Door(new Point(1000, 250));
            bigDoorToFind.SetActualSize(2.5, 1);
            bigDoorToFind.OrientationDoor = 3;
            this.chartToTest.AddDoor(bigDoorToFind);
            Door referenceDoor = new Door(new Point(900, 150));
            referenceDoor.OrientationDoor = 4;
            Assert.IsFalse(this.chartToTest.IsNoBigDoorInSurroundingsOfDoor(referenceDoor, 2, 2));
        }

        [TestMethod]
        public void TestIsNoBigDoorInSurroundingsOfDoorTrue()
        {
            Door referenceDoor = new Door(new Point(1000, 500));
            referenceDoor.Location = new PointContainer();
            Assert.IsTrue(this.chartToTest.IsNoBigDoorInSurroundingsOfDoor(referenceDoor, 2, 2));
        }

        [TestMethod]
        public void TestGetBigDoorOfPoint()
        {
            Door doorToCheck = new Door(new Point(1000, 1000));
            //doorToCheck.Location = new PointContainer();
            doorToCheck.SetActualSize(2.8, 2);
            this.chartToTest.AddDoor(doorToCheck);
            Assert.AreEqual(this.chartToTest.GetBigDoorOnPoint(new Point(1000, 1000)), doorToCheck);
        }

        [TestMethod]
        public void TestGetBigDoorOfPointWhenNull()
        {
            Assert.IsNull(this.chartToTest.GetBigDoorOnPoint(new Point(500, 500)));
        }

        [TestMethod]
        public void TestChartDraw() { // Just for COVERAGE PURPOSES
            Window verticalWindow = new Window(new Point(200, 200));
            this.chartToTest.Elements.Add(verticalWindow);
            Door verticalUpDoor = new Door(new Point(100, 200));
            verticalUpDoor.OrientationDoor = ConstantsDoor.VERTICAL_UP_ROTATION;
            this.chartToTest.Elements.Add(verticalUpDoor);
            Door verticalDownDoor = new Door(new Point(200, 100));
            verticalDownDoor.OrientationDoor = ConstantsDoor.VERTICAL_DOWN_ROTATION;
            this.chartToTest.Elements.Add(verticalDownDoor);
            Door horizontalLeftDoor = new Door(new Point(300, 300));
            horizontalLeftDoor.OrientationDoor = ConstantsDoor.HORIZONTAL_LEFT_ROTATION;
            this.chartToTest.Elements.Add(horizontalLeftDoor);
            Panel panelWhereToDraw = new Panel();
            Graphics graphWhereToDraw = panelWhereToDraw.CreateGraphics();
            this.chartToTest.DrawElements(ref graphWhereToDraw);
            this.chartToTest.DrawGrid(ref graphWhereToDraw, 0);
            this.chartToTest.DrawGrid(ref graphWhereToDraw, 1);
            this.chartToTest.DrawGrid(ref graphWhereToDraw, 2);
        }

    }
}
