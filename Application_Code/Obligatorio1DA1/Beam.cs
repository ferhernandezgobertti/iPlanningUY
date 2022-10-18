using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{

    public static class ConstantsBeam {
        public const int WIDTH = 4;
        public const int RADIUS = 3;
        public const int HEIGHT = 3; //Same as WALL
        public const double COST = 0.5;
        public const int BLOCKLENGTH = 50;
    }

    
    public class Beam : IDrawable {
        public virtual PointContainer Dimensions { get; set; }
        public Beam()
        {

        }
        public Beam(Point someDimensions) {
            Dimensions = new PointContainer();
            this.Dimensions.X = someDimensions.X;
            this.Dimensions.Y = someDimensions.Y;
        }

        public override double[] CalculateMoney(double[,] materialMoney) {
            double beamCost = materialMoney[1, 0];
            double beamPrice = materialMoney[1, 1];
            double[] beamMoney = { beamCost, beamPrice };
            return beamMoney;
        }

        public override void Draw (ref Graphics graphUsed) {
            Pen beamFormat = new Pen(Color.Red, ConstantsBeam.WIDTH);
            Rectangle beamBorder = new Rectangle(this.Dimensions.X - ConstantsBeam.RADIUS, this.Dimensions.Y - ConstantsBeam.RADIUS, 2*ConstantsBeam.RADIUS, 2*ConstantsBeam.RADIUS);
            graphUsed.DrawEllipse(beamFormat, beamBorder);
        }

        public override bool IsPointInsideWall(Point pointToFind) {
            return false;
        }

        public override bool IsWall() {
            return false;
        }

        public override void CountElements(int[] quantityOfElement) {
            quantityOfElement[1]++;
        }

        public override bool Equals(object anObject) {
            Beam aBeam = anObject as Beam;

            if (aBeam == null)
                return false;

            return this.Dimensions.X.Equals(aBeam.Dimensions.X) && this.Dimensions.Y.Equals(aBeam.Dimensions.Y);
        }

        public override bool IsPointOnHole(Point pointToCheck) {
            return false;
        }

        public override bool IsBigDoorOfPoint(Point pointToCheck) {
            return false;
        }

        public override void UpdateMoneyData(SketchItApp currentProgram) { }

        public override double[] GetElementMoney()
        {
            return null;
        }

    }
}
