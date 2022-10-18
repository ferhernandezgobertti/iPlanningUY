using System;
using System.Drawing;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ColumnTest
    {
        [TestMethod]
        public void TestEqualsColumnTrue()
        {
            Column oneColumn = new Column(new Point(250, 100));
            Column otherColumn = new Column(new Point(250, 100));
            Assert.IsTrue(oneColumn.Equals(otherColumn));
        }

        [TestMethod]
        public void TestEqualsColumnFalse()
        {
            Column oneColumn = new Column(new Point(250, 100));
            Column otherColumn = new Column(new Point(200, 100));
            Assert.IsFalse(oneColumn.Equals(otherColumn));
        }

        [TestMethod]
        public void TestGetBeamElementMoney() {
            Column oneColumn = new Column(new Point(250, 100));
            Assert.IsNull(oneColumn.GetElementMoney());
        }

        [TestMethod]
        public void TestColumnUpdateMoneyData()
        {
            SketchItApp newProgram = SketchItApp.GetInstance();
            Column oneColumn = new Column(new Point(200, 200));
            oneColumn.UpdateMoneyData(newProgram);
        }

        [TestMethod]
        public void TestCountElementsBeam()
        {
            Column oneColumn= new Column(new Point(500, 500));
            int[] currentElementsQuantity = { 1, 2, 1, 1, 0 };
            oneColumn.CountElements(currentElementsQuantity);
            int[] currentElementsQuantityExpected = { 1, 2, 1, 1, 1 };
            CollectionAssert.AreEqual(currentElementsQuantity, currentElementsQuantityExpected);
        }

        [TestMethod]
        public void TestEqualsColumnNull()
        {
            Column oneColumn = new Column(new Point(500, 500));
            Column otherColumn = null;
            Assert.IsFalse(oneColumn.Equals(otherColumn));
        }

        [TestMethod]
        public void TestColumnIsBigDoorOfPoint()
        {
            Column oneColumn = new Column(new Point(500, 500));
            Point locationToCheck = new Point(oneColumn.Location.X, oneColumn.Location.Y);
            Assert.IsFalse(oneColumn.IsBigDoorOfPoint(locationToCheck));
        }

        [TestMethod]
        public void TestColumnIsPointOnHole()
        {
            Column oneColumn = new Column(new Point(500, 500));
            Point locationToCheck = new Point(oneColumn.Location.X, oneColumn.Location.Y);
            Assert.IsFalse(oneColumn.IsPointOnHole(locationToCheck));
        }

    }
}
