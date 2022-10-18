using System;
using System.Drawing;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WallTest
    {
        [TestMethod]
        public void TestCalculateLengthSameLine()
        {
            Point[] coordinates = { new Point(55, 55), new Point(101, 55) };
            Wall aWall = new Wall(coordinates);
            int wallLength = aWall.CalculateLength();
            Assert.AreEqual(wallLength, 50);
        }
        [TestMethod]
        public void TestCalculateLengthDiagonal()
        {
            Point[] coordinates = { new Point(50, 50), new Point(200, 250) };
            Wall aWall = new Wall(coordinates);
            int wallLength = aWall.CalculateLength(); //NOT ALWAYS INTEGER
            Assert.AreEqual(wallLength, 250);
        }
        [TestMethod]
        public void TestCheckLengthLessMaxLength()
        {
            Point[] coordinates = { new Point(100, 150), new Point(100, 50) };
            Wall aWall = new Wall(coordinates);
            int wallDivision = aWall.CheckLength();
            Assert.AreEqual(wallDivision, 0);
        }
        [TestMethod]
        public void TestCheckLengthMoreMaxLength()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 550) };
            Wall aWall = new Wall(coordinates);
            int wallDivision = aWall.CheckLength();
            Assert.AreEqual(wallDivision, 2);
        }
        [TestMethod]
        public void TestIsInSameLineTrue()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 150) };
            Wall aWall = new Wall(coordinates);
            bool sameLine = aWall.IsInSameLine();
            Assert.IsTrue(sameLine);
        }
        [TestMethod]
        public void TestIsInSameLineFalse()
        {
            Point[] coordinates = { new Point(100, 50), new Point(250, 150) };
            Wall aWall = new Wall(coordinates);
            bool sameLine = aWall.IsInSameLine();
            Assert.IsFalse(sameLine);
        }
        [TestMethod]
        public void TestApproximateLinesDown()
        {
            Point[] coordinates = { new Point(52, 52), new Point(112, 52) };
            Point[] initializeWall = { new Point(50, 50), new Point(100, 50) };
            Wall aWall = new Wall(initializeWall);
            coordinates = aWall.ApproximateWall(coordinates);
            Point[] correctAnswer = { new Point(50, 50), new Point(100, 50) };
            CollectionAssert.AreEqual(coordinates, correctAnswer);
        }
        [TestMethod]
        public void TestApproximateLinesUp()
        {
            Point[] coordinates = { new Point(90, 82), new Point(112, 52) };
            Point[] initializeWall = { new Point(50, 50), new Point(100, 50) };
            Wall aWall = new Wall(initializeWall);
            coordinates = aWall.ApproximateWall(coordinates);
            Point[] correctAnswer = { new Point(100, 100), new Point(100, 50) };
            CollectionAssert.AreEqual(coordinates, correctAnswer);
        }
        [TestMethod]
        public void TestAddLengthToOriginWhenVerticalCoord1To0() {
            Point[] coordinates = { new Point(100, 300), new Point(100, 100) };
            Wall oneWall = new Wall(coordinates);
            Point withAddedLength = oneWall.AddLengthToOrigin(100);
            Point withAddedLengthExpected = new Point(100, 200);
            Assert.AreEqual(withAddedLength, withAddedLengthExpected);
        }
        [TestMethod]
        public void TestAddLengthToOriginWhenHorizontalCoord0To1() {
            Point[] coordinates = { new Point(100, 100), new Point(300, 100) };
            Wall oneWall = new Wall(coordinates);
            Point withAddedLength = oneWall.AddLengthToOrigin(100);
            Point withAddedLengthExpected = new Point(200, 100);
            Assert.AreEqual(withAddedLength, withAddedLengthExpected);
        }
        [TestMethod]
        public void TestAddLengthToOriginWhenHorizontalCoord1To0() {
            Point[] coordinates = { new Point(300, 100), new Point(100, 100) };
            Wall oneWall = new Wall(coordinates);
            Point withAddedLength = oneWall.AddLengthToOrigin(100);
            Point withAddedLengthExpected = new Point(200, 100);
            Assert.AreEqual(withAddedLength, withAddedLengthExpected);
        }
        [TestMethod]
        public void TestIsPointInsideHorizontalIfCoord1ToCoord0() {
            Point[] coordinates = { new Point(300, 100), new Point(100, 100) };
            Wall oneWall = new Wall(coordinates);
            Assert.IsTrue(oneWall.IsPointInsideWall(new Point(200, 100)));
        }
        [TestMethod]
        public void TestIsPointInsideVerticalIfCoord1ToCoord0() {
            Point[] coordinates = { new Point(100, 300), new Point(100, 100) };
            Wall oneWall = new Wall(coordinates);
            Assert.IsTrue(oneWall.IsPointInsideWall(new Point(100, 200)));
        }
        [TestMethod]
        public void TestNextPointIfHorizontalCoord1ToCoord0() {
            Point[] coordinates = { new Point(300, 100), new Point(100, 100) };
            Wall oneWall = new Wall(coordinates);
            Point coordinatesOfWall = new Point(oneWall.Coordinates.OriginX, oneWall.Coordinates.OriginY);
            Point nextPoint = oneWall.NextPointOfWall(coordinatesOfWall);
            Point nextPointExpected = new Point(250, 100);
            Assert.AreEqual(nextPoint, nextPointExpected);
        }
        [TestMethod]
        public void TestNextPointIfVerticalCoord1ToCoord0(){
            Point[] coordinates = { new Point(100, 300), new Point(100, 100) };
            Wall oneWall = new Wall(coordinates);
            Point coordinatesOfWall = new Point(oneWall.Coordinates.OriginX, oneWall.Coordinates.OriginY);
            Point nextPoint = oneWall.NextPointOfWall(coordinatesOfWall);
            Point nextPointExpected = new Point(100, 250);
            Assert.AreEqual(nextPoint, nextPointExpected);
        }
        [TestMethod]
        public void TestEqualsWallTrue()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 100) };
            Wall aWall = new Wall(coordinates);

            Point[] anotherCoordinates = { new Point(100, 50), new Point(100, 100) };
            Wall otherWall = new Wall(anotherCoordinates);

            Assert.IsTrue(aWall.Equals(otherWall));
        }
        [TestMethod]
        public void TestEqualsWallFalse()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 20) };
            Wall aWall = new Wall(coordinates);

            Point[] anotherCoordinates = { new Point(50, 50), new Point(100, 50) };
            Wall otherWall = new Wall(anotherCoordinates);

            Assert.IsFalse(aWall.Equals(otherWall));
        }
        [TestMethod]
        public void TestEqualsWallNull()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 80) };
            Wall aWall = new Wall(coordinates);

            Wall otherWall = null;

            Assert.IsFalse(aWall.Equals(otherWall));
        }

        [TestMethod]
        public void TestCountElementsWall()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 150) };
            Wall aWall = new Wall(coordinates);
            int[] currentElementsQuantity = { 0, 0, 0, 0, 0 };
            aWall.CountElements(currentElementsQuantity);
            int[] currentElementsQuantityExpected = { 2, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(currentElementsQuantity, currentElementsQuantityExpected);
        }

        [TestMethod]
        public void TestWallIsBigDoorOfPoint()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 150) };
            Wall aWall = new Wall(coordinates);
            Point coordinatesOfWall = new Point(aWall.Coordinates.OriginX, aWall.Coordinates.OriginY);
            Assert.IsFalse(aWall.IsBigDoorOfPoint(coordinatesOfWall));
        }

        [TestMethod]
        public void TestWallIsPointOnHole()
        {
            Point[] coordinates = { new Point(100, 50), new Point(100, 150) };
            Wall aWall = new Wall(coordinates);
            Point coordinatesOfWall = new Point(aWall.Coordinates.OriginX, aWall.Coordinates.OriginY);
            Assert.IsFalse(aWall.IsPointOnHole(coordinatesOfWall));
        }

        [TestMethod]
        public void TestGetWallElementMoney()
        {
            Point[] coordinates = { new Point(500, 150), new Point(500, 350) };
            Wall aWall = new Wall(coordinates);
            Assert.IsNull(aWall.GetElementMoney());
        }
    }
}
