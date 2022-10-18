using System;
using System.Drawing;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DoorTest
    {
        [TestMethod]
        public void TestRotateVerticalDoor() {
            Door doorToRotate = new Door(new Point(50, 50));
            doorToRotate.RotateDoor();
            int orientationExpected = 3;
            Assert.AreEqual(doorToRotate.OrientationDoor, orientationExpected);
        }

        [TestMethod]
        public void TestRotateHorizontalDoor() {
            Door doorToRotate = new Door(new Point(50, 50));
            doorToRotate.OrientationDoor = 1;
            doorToRotate.RotateDoor();
            int orientationExpected = 2;
            Assert.AreEqual(doorToRotate.OrientationDoor, orientationExpected);
        }

        [TestMethod]
        public void TestRotateDoorWhenLimitCase() {
            Door doorToRotate = new Door(new Point(50, 50));
            doorToRotate.OrientationDoor = 4;
            doorToRotate.RotateDoor();
            int orientationExpected = 1;
            Assert.AreEqual(doorToRotate.OrientationDoor, orientationExpected);
        }

        [TestMethod]
        public void TestCountElementsDoor() {
            Door oneDoor = new Door(new Point(50, 50));
            int[] currentElementsQuantity = { 1, 2, 0, 0, 0 };
            oneDoor.CountElements(currentElementsQuantity);
            int[] currentElementsQuantityExpected = { 1, 2, 1, 0, 0 };
            CollectionAssert.AreEqual(currentElementsQuantity, currentElementsQuantityExpected);
        }

        [TestMethod]
        public void TestGetDoorFromHole()
        {
            Hole originalHole = new Hole();
            originalHole.Location = new PointContainer();
            originalHole.Dimension = new IntContainer();
            originalHole.Money = new DoubleContainer();
            originalHole.Name = "Testing Hole";
            originalHole.Dimension.Width = 2;
            originalHole.Dimension.Length = 1;
            originalHole.HeightFromFloor = 1;
            originalHole.Money.Cost = 30;
            originalHole.Money.Price = 60;
            Door oneDoor = new Door(new Point(50, 50));
            oneDoor.GetDoorFromHole(originalHole);
            bool doorOK = oneDoor.Name.Equals(originalHole.Name) && oneDoor.Dimension.Equals(originalHole.Dimension) &&
                oneDoor.HeightFromFloor.Equals(originalHole.HeightFromFloor) && oneDoor.Money.Equals(originalHole.Money);
            Assert.IsTrue(doorOK);
        }

        [TestMethod]
        public void TestGetDoorBorderPointsWhenHorizontal()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.SetActualSize(2, 1);
            Point[] borderPointsOfWindow = oneDoor.GetBorderPoints();
            Point[] borderPointsExpected = new Point[2] { new Point(150, 200), new Point(250, 200) };
            CollectionAssert.AreEqual(borderPointsOfWindow, borderPointsExpected);
        }

        [TestMethod]
        public void TestGetDoorBorderPointsWhenVertical()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.OrientationDoor = 1;
            oneDoor.SetActualSize(2, 1);
            Point[] borderPointsOfWindow = oneDoor.GetBorderPoints();
            Point[] borderPointsExpected = new Point[2] { new Point(200, 150), new Point(200, 250) };
            CollectionAssert.AreEqual(borderPointsOfWindow, borderPointsExpected);
        }

        [TestMethod]
        public void TestIsBigDoorOfPointTrue()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.SetActualSize(2.5, 1);
            Point locationToCheck = new Point(oneDoor.Location.X, oneDoor.Location.Y);
            Assert.IsTrue(oneDoor.IsBigDoorOfPoint(locationToCheck));
        }

        [TestMethod]
        public void TestIsBigDoorOfPointFalseWhenNotOnPoint()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.SetActualSize(2.5, 1);
            Assert.IsFalse(oneDoor.IsBigDoorOfPoint(new Point(1000,1000)));
        }

        [TestMethod]
        public void TestIsBigDoorOfPointFalseWhenNotBigDoor()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.SetActualSize(1, 1);
            Point locationToCheck = new Point(oneDoor.Location.X, oneDoor.Location.Y);
            Assert.IsFalse(oneDoor.IsBigDoorOfPoint(locationToCheck));
        }

        [TestMethod]
        public void TestIsPointOnDoorTrueWhenHorizontal()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.SetActualSize(2, 1);
            Point pointOnHole = new Point(150, 200);
            Assert.IsTrue(oneDoor.IsPointOnHole(pointOnHole));
        }

        [TestMethod]
        public void TestIsPointOnDoorTrueWhenVertical()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.OrientationDoor = 1;
            oneDoor.SetActualSize(2, 1);
            Point pointOnHole = new Point(200, 150);
            Assert.IsTrue(oneDoor.IsPointOnHole(pointOnHole));
        }

        [TestMethod]
        public void TestIsPointOnDoorFalseWhenHorizontal()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.SetActualSize(2, 1);
            Point pointOnHole = new Point(150, 250);
            Assert.IsFalse(oneDoor.IsPointOnHole(pointOnHole));
        }

        [TestMethod]
        public void TestIsPointOnDoorFalseWhenVertical()
        {
            Door oneDoor = new Door(new Point(200, 200));
            oneDoor.OrientationDoor = 1;
            oneDoor.SetActualSize(2, 1);
            Point pointOnHole = new Point(250, 150);
            Assert.IsFalse(oneDoor.IsPointOnHole(pointOnHole));
        }

    }
}
