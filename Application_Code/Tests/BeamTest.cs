using System;
using System.Drawing;
using System.Windows.Forms;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BeamTest
    {
        [TestMethod]
        public void TestEqualsBeamTrue()
        {
            Beam oneBeam = new Beam(new Point(100, 100));
            Beam otherBeam = new Beam(new Point(100, 100));
            Assert.IsTrue(oneBeam.Equals(otherBeam));
        }

        [TestMethod]
        public void TestEqualsBeamFalse()
        {
            Beam oneBeam = new Beam(new Point(100, 100));
            Beam otherBeam = new Beam(new Point(200, 100));
            Assert.IsFalse(oneBeam.Equals(otherBeam));
        }

        [TestMethod]
        public void TestGetBeamElementMoney()
        {
            Beam oneBeam = new Beam(new Point(100, 100));
            Assert.IsNull(oneBeam.GetElementMoney());
        }

        [TestMethod]
        public void TestCountElementsBeam() {
            Beam oneBeam = new Beam(new Point(100, 100));
            int[] currentElementsQuantity = { 1, 1, 0, 0, 0 };
            oneBeam.CountElements(currentElementsQuantity);
            int[] currentElementsQuantityExpected = { 1, 2, 0, 0, 0 };
            CollectionAssert.AreEqual(currentElementsQuantity, currentElementsQuantityExpected);
        }

        [TestMethod]
        public void TestEqualsBeamNull()
        {
            Beam oneBeam = new Beam(new Point(100, 100));
            Beam otherBeam = null;
            Assert.IsFalse(oneBeam.Equals(otherBeam));
        }

        [TestMethod]
        public void TestBeamIsBigDoorOfPoint()
        {
            Beam oneBeam = new Beam(new Point(100, 100));
            Point dimensionsToCheck = new Point(oneBeam.Dimensions.X, oneBeam.Dimensions.Y);
            Assert.IsFalse(oneBeam.IsBigDoorOfPoint(dimensionsToCheck));
        }

        [TestMethod]
        public void TestBeamIsPointOnHole() {
            Beam oneBeam = new Beam(new Point(100, 100));
            Point dimensionsToCheck = new Point(oneBeam.Dimensions.X, oneBeam.Dimensions.Y);
            Assert.IsFalse(oneBeam.IsPointOnHole(dimensionsToCheck));
        }

    }
}
