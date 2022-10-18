using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public static class ConstantsHole {
        public const int BLOCKLENGTH = 50;
        public const int MAX_WIDTH = 150; // 3 metres * 50 pixels
        public const int MAX_LENGTH = 100; // 2 metres * 50 pixels
    }

   
    public class Hole : IDrawable {

        public String Name { get; set; }
        public virtual PointContainer Location { get; set; }
        public virtual IntContainer Dimension { get; set; }
        public double HeightFromFloor { get; set; }
        public virtual DoubleContainer Money { get; set; } // {COST, PRICE}

        public Hole()
        {
            //Location = new PointContainer();
            //Dimension = new IntContainer();
            //Money = new DoubleContainer();
        }
        public void SetActualSize(double lengthEntered, double heightEntered) {
            this.Dimension = new IntContainer();
            this.Dimension.Width = (int)(lengthEntered * ConstantsHole.BLOCKLENGTH);
            this.Dimension.Length = (int)(heightEntered * ConstantsHole.BLOCKLENGTH);
        }

        public int ApproximateCoordinate(int oneCoordinate)
        {
            int approximation = 0;
            if ((approximation = oneCoordinate % ConstantsHole.BLOCKLENGTH) <= ConstantsHole.BLOCKLENGTH / 2) {
                oneCoordinate = oneCoordinate - approximation;
            } else {
                oneCoordinate = oneCoordinate + (ConstantsHole.BLOCKLENGTH - approximation);
            }
            return oneCoordinate;
        }

        public Point GetAppropiateLocation(Point selectedLocation) {
            Point appropiateLocation = new Point(this.ApproximateCoordinate(selectedLocation.X), this.ApproximateCoordinate(selectedLocation.Y));
            return appropiateLocation;
        }

        public bool IsSmallHole()
        {
            return this.Dimension.Width <= 50;
        }

        public bool IsMediumHole()
        {
            return this.Dimension.Width <= 100 && !this.IsSmallHole();
        }

        public bool IsBigHole()
        {
            return this.Dimension.Width <= 150 && !this.IsMediumHole() && !this.IsSmallHole();
        }

        public override bool Equals(object anObject)
        {
            Hole aHole = anObject as Hole;

            if (aHole == null)
                return false;

            return this.Location.X.Equals(aHole.Location.X) && this.Location.Y.Equals(aHole.Location.Y);
        }

        public override void Draw(ref Graphics whereToDraw) { }
        public override bool IsPointInsideWall(Point pointToFind) { return false;  }
        public override bool IsWall() { return false; }
        public override double[] CalculateMoney(double[,] materialMoney) { return null; }
        public override void CountElements(int[] quantityOfElement) { }
        public override bool IsPointOnHole(Point pointToCheck) { return false; }
        public override bool IsBigDoorOfPoint(Point pointToCheck) { return false; }
        public override void UpdateMoneyData(SketchItApp currentProgram) { }
        public override double[] GetElementMoney() { return null; }


    }
}
