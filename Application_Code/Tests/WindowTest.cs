using System;
using System.Drawing;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WindowTest
    {
        [TestMethod]
        public void TestRotateVerticalWindow() {
            Window windowToRotate = new Window(new Point(250, 450)); //Default: Orientation 2
            windowToRotate.RotateWindow();
            int orientationExpected = 1;
            Assert.AreEqual(windowToRotate.OrientationWindow, orientationExpected);
        }

        [TestMethod]
        public void TestRotateHorizontalWindow() {
            Window windowToRotate = new Window(new Point(250, 450)); //Default: Orientation 2
            windowToRotate.OrientationWindow = 1;
            windowToRotate.RotateWindow();
            int orientationExpected = 2;
            Assert.AreEqual(windowToRotate.OrientationWindow, orientationExpected);
        }

        [TestMethod]
        public void TestCountElementsWindow() {
            Window oneWindow = new Window(new Point(50, 50));
            int[] currentElementsQuantity = { 1, 2, 1, 0, 0 };
            oneWindow.CountElements(currentElementsQuantity);
            int[] currentElementsQuantityExpected = { 1, 2, 1, 1, 0 };
            CollectionAssert.AreEqual(currentElementsQuantity, currentElementsQuantityExpected);
        }

        [TestMethod]
        public void TestGetWindowFromHole()  {
            Hole originalHole = new Hole();
            originalHole.Location = new PointContainer();
            originalHole.Money = new DoubleContainer();
            originalHole.Name = "Testing Hole";
            originalHole.SetActualSize(2, 1);
            originalHole.HeightFromFloor = 1;
            originalHole.Money.Cost = 30;
            originalHole.Money.Price = 60;
            Window oneWindow = new Window(new Point(50, 50));
            oneWindow.GetWindowFromHole(originalHole);
            bool windowsOK = oneWindow.Name.Equals(originalHole.Name) && oneWindow.Dimension.Equals(originalHole.Dimension) &&
                oneWindow.HeightFromFloor.Equals(originalHole.HeightFromFloor) && oneWindow.Money.Equals(originalHole.Money);
            Assert.IsTrue(windowsOK);
        }

        [TestMethod]
        public void TestGetWindowsBorderPointsWhenHorizontal() {
            Window oneWindow = new Window(new Point(200, 200));
            oneWindow.OrientationWindow = 1;
            oneWindow.SetActualSize(2, 1);
            Point[] borderPointsOfWindow = oneWindow.GetBorderPoints();
            Point[] borderPointsExpected = new Point[2] { new Point(150, 200), new Point(250, 200) };
            CollectionAssert.AreEqual(borderPointsOfWindow, borderPointsExpected);
        }

        [TestMethod]
        public void TestGetWindowsBorderPointsWhenVertical()
        {
            Window oneWindow = new Window(new Point(200, 200));
            oneWindow.SetActualSize(2, 1);
            Point[] borderPointsOfWindow = oneWindow.GetBorderPoints();
            Point[] borderPointsExpected = new Point[2] { new Point(200, 150), new Point(200, 250) };
            CollectionAssert.AreEqual(borderPointsOfWindow, borderPointsExpected);
        }

        [TestMethod]
        public void TestIsPointOnWindowsTrueWhenHorizontal()
        {
            Window oneWindow = new Window(new Point(200, 200));
            oneWindow.OrientationWindow = 1;
            oneWindow.SetActualSize(2, 1);
            Point pointOnHole = new Point(150, 200);
            Assert.IsTrue(oneWindow.IsPointOnHole(pointOnHole));
        }

        [TestMethod]
        public void TestIsPointOnWindowsTrueWhenVertical() {
            Window oneWindow = new Window(new Point(200, 200));
            oneWindow.SetActualSize(2, 1);
            Point pointOnHole = new Point(200, 150);
            Assert.IsTrue(oneWindow.IsPointOnHole(pointOnHole));
        }

        [TestMethod]
        public void TestIsPointOnWindowsFalseWhenHorizontal() {
            Window oneWindow = new Window(new Point(200, 200));
            oneWindow.OrientationWindow = 1;
            oneWindow.SetActualSize(2, 1);
            Point pointOnHole = new Point(150, 250);
            Assert.IsFalse(oneWindow.IsPointOnHole(pointOnHole));
        }

        [TestMethod]
        public void TestIsPointOnWindowsFalseWhenVertical() {
            Window oneWindow = new Window(new Point(200, 200));
            oneWindow.SetActualSize(2, 1);
            Point pointOnHole = new Point(250, 150);
            Assert.IsFalse(oneWindow.IsPointOnHole(pointOnHole));
        }

        [TestMethod]
        public void TestBeamIsBigDoorOfPoint()
        {
            Window oneWindow = new Window(new Point(100, 100));
            Point windowLocation = new Point(oneWindow.Location.X, oneWindow.Location.Y);
            Assert.IsFalse(oneWindow.IsBigDoorOfPoint(windowLocation));
        }

    }
}
