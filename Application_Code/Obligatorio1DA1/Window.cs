using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public static class ConstantsWindow {
        public const double WIDTH = 0.4; // Awfully chosen 0.8 metres
        public const double LENGTH = 1.0;
        public const double HEIGHT = 1.0;
        public const double HEIGHTFROMFLOOR = 1.0;
        public const double MONEY_COST = 50;
        public const double MONEY_PRICE = 75;
        public const double COST = 0.666;  // 50/75
        public const int BLOCKLENGTH = 50;
        public const int HORIZONTAL_ORIENTATION = 1;
        public const int VERTICAL_ORIENTATION = 2;
    }


    public class Window : Hole {
        public int OrientationWindow { get; set; } // {1,2} where 1 = Horizontal (0 Grades) and 2 = Vertical (90 Grades)

        public Window()
        {

        }
        public Window(Point windowLocation){

            Location = new PointContainer();
            Dimension = new IntContainer();
            Money = new DoubleContainer();

            this.Name = "WindowDefault";
            this.Location.X = windowLocation.X;
            this.Location.Y = windowLocation.Y;
            this.SetActualSize(ConstantsWindow.LENGTH, ConstantsWindow.WIDTH);
            this.HeightFromFloor = ConstantsWindow.HEIGHTFROMFLOOR;
            this.OrientationWindow = ConstantsWindow.VERTICAL_ORIENTATION; //Default Orientation
            this.Money.Cost = ConstantsWindow.MONEY_COST;
            this.Money.Price = ConstantsWindow.MONEY_PRICE;
        }

        public override bool IsPointInsideWall(Point pointToFind) {
            return false;
        }

        public override bool IsWall() {
            return false;
        }

        public override void CountElements(int[] quantityOfElement) {
            quantityOfElement[3]++;
        }

        public override double[] CalculateMoney(double[,] materialMoney) {
            double[] moneyOfWindow = { this.Money.Cost, this.Money.Price };
            return moneyOfWindow;
        }

        public override void Draw(ref Graphics graphUsed) {
            Brush windowBrush = new SolidBrush(Color.Blue);
            Rectangle windowBorder;
            if (this.OrientationWindow == ConstantsWindow.VERTICAL_ORIENTATION) {
                windowBorder = new Rectangle((int)(this.Location.X - 0.5 * ConstantsWindow.WIDTH*ConstantsWindow.BLOCKLENGTH), (int)(this.Location.Y - 0.5 * this.Dimension.Width), (int)(ConstantsWindow.WIDTH*ConstantsWindow.BLOCKLENGTH), (int)(this.Dimension.Width));
                graphUsed.FillRectangle(windowBrush, windowBorder);
            }
            if (this.OrientationWindow == ConstantsWindow.HORIZONTAL_ORIENTATION) {
                windowBorder = new Rectangle((int)(this.Location.X - 0.5 * this.Dimension.Width), (int)(this.Location.Y - 0.5 * ConstantsWindow.WIDTH*ConstantsWindow.BLOCKLENGTH), (int)(this.Dimension.Width), (int)(ConstantsWindow.WIDTH*ConstantsWindow.BLOCKLENGTH));
                graphUsed.FillRectangle(windowBrush, windowBorder);
            }
        }

        public void RotateWindow() {
            if (this.OrientationWindow != ConstantsWindow.VERTICAL_ORIENTATION) {
                this.OrientationWindow++;
            } else {
                this.OrientationWindow = ConstantsWindow.HORIZONTAL_ORIENTATION;
            }
        }

        public void GetWindowFromHole(Hole holeToConvert)
        {
            this.Name = holeToConvert.Name;
            this.Dimension = holeToConvert.Dimension;
            this.HeightFromFloor = holeToConvert.HeightFromFloor;
            this.Money = holeToConvert.Money;
        }

        public Point[] GetBorderPoints()
        {
            Point[] borderPoints = new Point[2];
            if(this.OrientationWindow == ConstantsWindow.HORIZONTAL_ORIENTATION) {
                borderPoints[0] = new Point(this.Location.X - this.Dimension.Width/2, this.Location.Y);
                borderPoints[1] = new Point(this.Location.X + this.Dimension.Width/2, this.Location.Y);
            }
            if (this.OrientationWindow == ConstantsWindow.VERTICAL_ORIENTATION) {
                borderPoints[0] = new Point(this.Location.X, this.Location.Y - this.Dimension.Width/2);
                borderPoints[1] = new Point(this.Location.X, this.Location.Y + this.Dimension.Width/2);
            }
            return borderPoints;
        }

        public override bool IsPointOnHole(Point pointToCheck) {
            Point[] borderPoints = this.GetBorderPoints();
            bool isOnWindowWhenHorizontal = (this.OrientationWindow == ConstantsWindow.HORIZONTAL_ORIENTATION) && borderPoints[0].Y == pointToCheck.Y && borderPoints[0].X <= pointToCheck.X && borderPoints[1].X >= pointToCheck.X;
            bool isOnWindowWhenVertical = (this.OrientationWindow == ConstantsWindow.VERTICAL_ORIENTATION) && borderPoints[0].X == pointToCheck.X && borderPoints[0].Y <= pointToCheck.Y && borderPoints[1].Y >= pointToCheck.Y;
            return isOnWindowWhenHorizontal || isOnWindowWhenVertical;
        }

        public override bool IsBigDoorOfPoint(Point pointToCheck) {
            return false;
        }

        public override void UpdateMoneyData(SketchItApp currentProgram) {
            this.Money = currentProgram.GetHoleFromHoleTypes(this.Name).Money;
        }

        public override double[] GetElementMoney()
        {
            double[] moneyOfWindow = { this.Money.Cost, this.Money.Price };
            return moneyOfWindow;
        }

    }
}
