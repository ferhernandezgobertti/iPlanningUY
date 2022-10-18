using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{ 
    public static class ConstantsDoor {
        public const double WIDTH = 0.85;
        public const double LENGTH = 2.20;
        public const double HEIGHTFROMFLOOR = 0.0;
        public const double MONEY_COST = 50;
        public const double MONEY_PRICE = 100;
        public const double COST = 0.5;  // 50/100
        public const int BLOCKLENGTH = 50;
        public const int HORIZONTAL_RIGHT_ROTATION = 1;
        public const int VERTICAL_UP_ROTATION = 2;
        public const int HORIZONTAL_LEFT_ROTATION = 3;
        public const int VERTICAL_DOWN_ROTATION = 4;
        public const int MIN_ROTATION = 1;
        public const int MAX_ROTATION = 4;
        
    }

   
    public class Door : Hole {
        public int OrientationDoor { get; set; } // {1,2,3,4} where 1=0 Grades, 2=90Grades, 3=180Grades, 4=270Grades

        public Door()
        {

        }
        public Door (Point doorLocation) {
            Location = new PointContainer();
            Dimension = new IntContainer();
            Money = new DoubleContainer();
            this.Name = "DoorDefault";
            this.Location.X = doorLocation.X;
            this.Location.Y = doorLocation.Y;
            this.SetActualSize(ConstantsDoor.WIDTH, ConstantsDoor.LENGTH);
            this.HeightFromFloor = ConstantsDoor.HEIGHTFROMFLOOR;
            this.OrientationDoor = ConstantsDoor.VERTICAL_UP_ROTATION; //Default Orientation
            this.Money.Cost = ConstantsDoor.MONEY_COST;
            this.Money.Price = ConstantsDoor.MONEY_PRICE;
        }

        public override bool IsPointInsideWall(Point pointToFind) {
            return false;
        }

        public override bool IsWall() {
            return false;
        }
        public override void CountElements(int[] quantityOfElement) {
            quantityOfElement[2]++;
        }

        public override double[] CalculateMoney(double[,] materialMoney) {
            double[] moneyOfDoor = { this.Money.Cost, this.Money.Price };
            return moneyOfDoor;
        }

        public override void Draw(ref Graphics graphUsed) {
            Brush doorBrush = new SolidBrush(Color.Blue);
            Rectangle doorBorder;
            if (this.OrientationDoor == ConstantsDoor.HORIZONTAL_RIGHT_ROTATION) {
                doorBorder = new Rectangle(this.Location.X - this.Dimension.Width, (int)(this.Location.Y - 1.5 * this.Dimension.Width), 2 * this.Dimension.Width, 2 * this.Dimension.Width);
                graphUsed.FillPie(doorBrush, doorBorder, 0, 90);
            }
            if (this.OrientationDoor == ConstantsDoor.VERTICAL_UP_ROTATION) {
                doorBorder = new Rectangle((int)(this.Location.X - 1.5 * this.Dimension.Width), this.Location.Y - this.Dimension.Width, 2 * this.Dimension.Width, 2 * this.Dimension.Width);
                graphUsed.FillPie(doorBrush, doorBorder, 0, -90);
            }
            if (this.OrientationDoor == ConstantsDoor.HORIZONTAL_LEFT_ROTATION) {
                doorBorder = new Rectangle(this.Location.X - this.Dimension.Width, (int)(this.Location.Y - 1.5 * this.Dimension.Width), 2 * this.Dimension.Width, 2 * this.Dimension.Width);
                graphUsed.FillPie(doorBrush, doorBorder, -180, -90);
            }
            if (this.OrientationDoor == ConstantsDoor.VERTICAL_DOWN_ROTATION) {
                doorBorder = new Rectangle((int)(this.Location.X - 1.5 * this.Dimension.Width), this.Location.Y - this.Dimension.Width, 2 * this.Dimension.Width, 2 * this.Dimension.Width);
                graphUsed.FillPie(doorBrush, doorBorder, 0, 90);
            }
        }

        public void RotateDoor() {
            if (this.OrientationDoor != ConstantsDoor.MAX_ROTATION) {
                this.OrientationDoor++;
            } else {
                this.OrientationDoor = ConstantsDoor.MIN_ROTATION;
            }
        }

        public void GetDoorFromHole(Hole holeToConvert)
        {
            this.Name = holeToConvert.Name;
            this.Dimension = holeToConvert.Dimension;
            this.HeightFromFloor = holeToConvert.HeightFromFloor;
            this.Money = holeToConvert.Money;
        }

        public Point[] GetBorderPoints()
        {
            Point[] borderPoints = new Point[2];
            if (this.OrientationDoor == ConstantsDoor.VERTICAL_UP_ROTATION || this.OrientationDoor == ConstantsDoor.VERTICAL_DOWN_ROTATION)
            {
                borderPoints[0] = new Point(this.Location.X - this.Dimension.Width/2, this.Location.Y);
                borderPoints[1] = new Point(this.Location.X + this.Dimension.Width/2, this.Location.Y);
            }
            if (this.OrientationDoor == ConstantsDoor.HORIZONTAL_RIGHT_ROTATION || this.OrientationDoor == ConstantsDoor.HORIZONTAL_LEFT_ROTATION) {
                borderPoints[0] = new Point(this.Location.X, this.Location.Y - this.Dimension.Width/2);
                borderPoints[1] = new Point(this.Location.X, this.Location.Y + this.Dimension.Width/2);
            }
            return borderPoints;
        }

        public override bool IsPointOnHole(Point pointToCheck)
        {
            Point[] borderPoints = this.GetBorderPoints();
            bool isOnDoorWhenHorizontal = (this.OrientationDoor == ConstantsDoor.VERTICAL_UP_ROTATION || this.OrientationDoor == ConstantsDoor.VERTICAL_DOWN_ROTATION) && borderPoints[0].Y == pointToCheck.Y && borderPoints[0].X <= pointToCheck.X && borderPoints[1].X >= pointToCheck.X;
            bool isOnDoorWhenVertical = (this.OrientationDoor == ConstantsDoor.HORIZONTAL_RIGHT_ROTATION || this.OrientationDoor == ConstantsDoor.HORIZONTAL_LEFT_ROTATION) && borderPoints[0].X == pointToCheck.X && borderPoints[0].Y <= pointToCheck.Y && borderPoints[1].Y >= pointToCheck.Y;
            return isOnDoorWhenHorizontal || isOnDoorWhenVertical;
        }

        public override bool IsBigDoorOfPoint(Point pointToCheck) {
            return this.Location.X.Equals(pointToCheck.X) && this.Location.Y.Equals(pointToCheck.Y) && this.IsBigHole();
        }

        public override void UpdateMoneyData(SketchItApp currentProgram) {
            this.Money = currentProgram.GetHoleFromHoleTypes(this.Name).Money;
        }

        public override double[] GetElementMoney()
        {
            double[] moneyOfDoor = { this.Money.Cost, this.Money.Price };
            return moneyOfDoor;
        }

    }
}
