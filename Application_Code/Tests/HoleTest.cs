using System;
using System.Drawing;
using System.Windows.Forms;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HoleTest
    {
        [TestMethod]
        public void TestApproximateCoordinate() {
            Hole holeToApproximate = new Hole();
            holeToApproximate.Location = new PointContainer();
            holeToApproximate.Location.X = 124;
            holeToApproximate.Location.Y = 235;
            int approximationX = holeToApproximate.ApproximateCoordinate(holeToApproximate.Location.X);
            int approximationY = holeToApproximate.ApproximateCoordinate(holeToApproximate.Location.Y);
            int[] approximation = { approximationX, approximationY };
            int[] approximationExpected = { 100, 250 };
            CollectionAssert.AreEqual(approximation, approximationExpected);
        }

        [TestMethod]
        public void TestGetAppropiateLocation() {
            Hole holeToApproximate = new Hole();
            holeToApproximate.Location = new PointContainer();
            Point holePoint = new Point(98, 198);
            Point holePointApproximated = holeToApproximate.GetAppropiateLocation(holePoint);
            holeToApproximate.Location.X = holePointApproximated.X;
            holeToApproximate.Location.Y = holePointApproximated.Y;
            Point approximationExpected = new Point(100, 200);
            Assert.AreEqual(holePointApproximated, approximationExpected);
        }

        [TestMethod]
        public void TestEqualsHoleTrue()  {
            Hole oneHole = new Hole();
            oneHole.Location = new PointContainer();
            oneHole.Location.X = 150;
            oneHole.Location.Y = 200;
            Hole otherHole = new Hole();
            otherHole.Location = new PointContainer();
            otherHole.Location.X = 150;
            otherHole.Location.Y = 200;
            Assert.IsTrue(oneHole.Equals(otherHole));
        }

        [TestMethod]
        public void TestEqualsHoleFalse() {
            Hole oneHole = new Hole();
            oneHole.Location = new PointContainer();
            oneHole.Location.X = 150;
            oneHole.Location.Y = 200;
            Hole otherHole = new Hole();
            otherHole.Location = new PointContainer();
            otherHole.Location.X = 100;
            otherHole.Location.Y = 200;
            Assert.IsFalse(oneHole.Equals(otherHole));
        }

        [TestMethod]
        public void TestEqualsHoleNull() {
            Hole oneHole = new Hole();
            oneHole.Location = new PointContainer();
            oneHole.Location.X = 150;
            oneHole.Location.Y = 200;
            Hole otherHole = null;
            Assert.IsFalse(oneHole.Equals(otherHole));
        }

        [TestMethod]
        public void TestHoleIsPointInsideWall()
        {
            Point pointToCheck = new Point(100, 100);
            Hole oneHole = new Hole();
            oneHole.Location = new PointContainer();
            Assert.IsFalse(oneHole.IsPointInsideWall(pointToCheck));
        }

        [TestMethod]
        public void TestHoleIsPointOnHole()
        {
            Point pointToCheck = new Point(100, 100);
            Hole oneHole = new Hole();
            Assert.IsFalse(oneHole.IsPointOnHole(pointToCheck));
        }

        [TestMethod]
        public void TestHoleIsBigDoorOfPoint()
        {
            Point pointToCheck = new Point(100, 100);
            Hole oneHole = new Hole();
            Assert.IsFalse(oneHole.IsBigDoorOfPoint(pointToCheck));
        }

        [TestMethod]
        public void TestHoleIsWall()
        {
            Hole oneHole = new Hole();
            Assert.IsFalse(oneHole.IsWall());
        }

        [TestMethod]
        public void TestHoleCalculateMoney()
        {
            Hole oneHole = new Hole();
            Assert.IsNull(oneHole.CalculateMoney(null));
        }

        [TestMethod]
        public void TestHoleGetElementMoney()
        {
            Hole oneHole = new Hole();
            Assert.IsNull(oneHole.GetElementMoney());
        }

        [TestMethod]
        public void TestHoleEmptyMethods() { // Just for COVERAGE PURPOSES
            Panel panelWhereToDraw = new Panel();
            Graphics graphWhereToDraw = panelWhereToDraw.CreateGraphics();
            Hole oneHole = new Hole();
            oneHole.Draw(ref graphWhereToDraw);
            oneHole.CountElements(null);
            oneHole.UpdateMoneyData(null);
        }

        [TestMethod]
        public void TestIsSmallHoleTrue()
        {
            Hole oneHole = new Hole();
            oneHole.SetActualSize(0.5, 1);
            Assert.IsTrue(oneHole.IsSmallHole());
        }

        [TestMethod]
        public void TestIsSmallHoleFalse()
        {
            Hole oneHole = new Hole();
            oneHole.SetActualSize(2, 1);
            Assert.IsFalse(oneHole.IsSmallHole());
        }

        [TestMethod]
        public void TestIsMediumHoleTrue()
        {
            Hole oneHole = new Hole();
            oneHole.SetActualSize(1.8, 1);
            Assert.IsTrue(oneHole.IsMediumHole());
        }

        [TestMethod]
        public void TestIsMediumHoleFalse()
        {
            Hole oneHole = new Hole();
            oneHole.SetActualSize(3, 1);
            Assert.IsFalse(oneHole.IsMediumHole());
        }

        [TestMethod]
        public void TestIsBigHoleTrue()
        {
            Hole oneHole = new Hole();
            oneHole.SetActualSize(2.4, 1);
            Assert.IsTrue(oneHole.IsBigHole());
        }

        [TestMethod]
        public void TestIsBigHoleFalseWhenSmall()
        {
            Hole oneHole = new Hole();
            oneHole.SetActualSize(0.6, 1);
            Assert.IsFalse(oneHole.IsBigHole());
        }

        [TestMethod]
        public void TestIsBigHoleFalseWhenMedium()
        {
            Hole oneHole = new Hole();
            oneHole.SetActualSize(1.5, 1);
            Assert.IsFalse(oneHole.IsBigHole());
        }


    }
}
