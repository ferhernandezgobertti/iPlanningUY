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
    public static class ConstantsWall {
        public const int MAXLENGTH = 5;
        public const int BLOCKLENGTH = 50;
        public const int HEIGHT = 3;
        public const double WIDTH = 0.20;
        public const double COST_PER_METER = 0.5; // 50/100
    }


    public class Wall : IDrawable {
        public virtual PointCoordinatesContainer Coordinates { get; set; }

        public Wall()
        {

        }

        public Wall(Point[] someCoordinates) {
            Coordinates = new PointCoordinatesContainer(); // [ Origin, Destination ]
            Point[] approximation = ApproximateWall(someCoordinates);
            this.Coordinates.OriginX = approximation[0].X;
            this.Coordinates.OriginY = approximation[0].Y;
            this.Coordinates.DestinationX = approximation[1].X;
            this.Coordinates.DestinationY = approximation[1].Y;
        }

        public override void Draw(ref Graphics graphUsed) {
            Pen wallFormat = new Pen(Color.Green, (float)(ConstantsWall.WIDTH * ConstantsWall.BLOCKLENGTH));
            Point originCoordinates = new Point(this.Coordinates.OriginX, this.Coordinates.OriginY);
            Point destinationCoordinates = new Point(this.Coordinates.DestinationX, this.Coordinates.DestinationY);
            graphUsed.DrawLine(wallFormat, originCoordinates, destinationCoordinates);
        }

        public override bool IsWall() {
            return true;
        }

        public override void CountElements(int[] quantityOfElement) {
            quantityOfElement[0] += this.CalculateLength() / ConstantsWall.BLOCKLENGTH;
        }

        public int CalculateLength() {
            Point originCoordinates = new Point(this.Coordinates.OriginX, this.Coordinates.OriginY);
            Point destinationCoordinates = new Point(this.Coordinates.DestinationX, this.Coordinates.DestinationY);
            int length = (int)Math.Sqrt(Math.Pow((destinationCoordinates.Y - originCoordinates.Y), 2) + Math.Pow((destinationCoordinates.X - originCoordinates.X), 2));
            return (int)Math.Sqrt(Math.Pow((destinationCoordinates.Y - originCoordinates.Y), 2) + Math.Pow((destinationCoordinates.X - originCoordinates.X), 2));
        }

        public int CheckLength() {
            int result = (this.CalculateLength() / (ConstantsWall.MAXLENGTH*ConstantsWall.BLOCKLENGTH));
            return (int) (this.CalculateLength() / (ConstantsWall.MAXLENGTH*ConstantsWall.BLOCKLENGTH));
        }

        public Point[] ApproximateWall(Point[] someCoordinates) {
            Point[] approximateCoordinates = new Point[2];
            for (int position = 0; position < 2; position++) {
                approximateCoordinates[position].X = this.ApproximateCoordinate(someCoordinates[position].X);
                approximateCoordinates[position].Y = this.ApproximateCoordinate(someCoordinates[position].Y);
            }
            return approximateCoordinates;
        }

        public int ApproximateCoordinate(int oneCoordinate) {
            int approximation = 0;
            if ((approximation = oneCoordinate % ConstantsWall.BLOCKLENGTH) <= ConstantsWall.BLOCKLENGTH / 2) {
                oneCoordinate = oneCoordinate - approximation;
            } else {
                oneCoordinate = oneCoordinate + (ConstantsWall.BLOCKLENGTH - approximation);
            }
            return oneCoordinate;
        }

        public bool IsInSameLine() {
            return this.Coordinates.OriginX == this.Coordinates.DestinationX || this.Coordinates.OriginY == this.Coordinates.DestinationY;
        }

        public override bool Equals(object anObject) {
            Wall aWall = anObject as Wall;

            if (aWall == null)
                return false;

            Point originCoordinates = new Point(this.Coordinates.OriginX, this.Coordinates.OriginY);
            Point destinationCoordinates = new Point(this.Coordinates.DestinationX, this.Coordinates.DestinationY);
            Point otherOriginCoordinates = new Point(aWall.Coordinates.OriginX, aWall.Coordinates.OriginY);
            Point otherDestinationCoordinates = new Point(aWall.Coordinates.DestinationX, aWall.Coordinates.DestinationY);
            return (originCoordinates.Equals(otherOriginCoordinates) && destinationCoordinates.Equals(otherDestinationCoordinates))
                 || (originCoordinates.Equals(otherDestinationCoordinates) && destinationCoordinates.Equals(otherOriginCoordinates))
                 || (destinationCoordinates.Equals(otherOriginCoordinates) && originCoordinates.Equals(otherDestinationCoordinates));

        }

        public Point AddLengthToOrigin(int lengthToAdd) { //IMPROVE
            Point finalCoordinate = new Point(this.Coordinates.OriginX, this.Coordinates.OriginY);
            if (this.Coordinates.OriginX > this.Coordinates.DestinationX || this.Coordinates.OriginY > this.Coordinates.DestinationY) {
                if (this.Coordinates.OriginX == this.Coordinates.DestinationX) {  //VERTICAL WALL
                    finalCoordinate.Y = finalCoordinate.Y - lengthToAdd;
                }
                if (this.Coordinates.OriginY == this.Coordinates.DestinationY) { //HORIZONTAL WALL
                    finalCoordinate.X = finalCoordinate.X - lengthToAdd;
                }
            } else {
                if (this.Coordinates.OriginX == this.Coordinates.DestinationX) {  //VERTICAL WALL
                    finalCoordinate.Y = finalCoordinate.Y + lengthToAdd;
                }
                if (this.Coordinates.OriginY == this.Coordinates.DestinationY) { //HORIZONTAL WALL
                    finalCoordinate.X = finalCoordinate.X + lengthToAdd;
                }
            }
            return finalCoordinate;
        }

        public bool IsHorizontal() {
            return this.Coordinates.OriginY == this.Coordinates.DestinationY;
        }

        public bool IsVertical() {
            return this.Coordinates.OriginX == this.Coordinates.DestinationX;
        }

        public bool IsNullLength() {
            return this.Coordinates.OriginX == this.Coordinates.DestinationX && this.Coordinates.OriginY == this.Coordinates.DestinationY;
        }

        public override bool IsPointInsideWall(Point pointToFind) {
            bool insideHorizontalIfCoord0ToCoord1 = this.IsHorizontal() && this.Coordinates.OriginX <= pointToFind.X && this.Coordinates.DestinationX >= pointToFind.X && this.Coordinates.OriginY == pointToFind.Y;
            bool insideVerticalIfCoord0ToCoord1 = this.IsVertical() && this.Coordinates.OriginY <= pointToFind.Y && this.Coordinates.DestinationY >= pointToFind.Y && this.Coordinates.OriginX == pointToFind.X;
            bool insideHorizontalIfCoord1ToCoord0 = this.IsHorizontal() && this.Coordinates.DestinationX <= pointToFind.X && this.Coordinates.OriginX >= pointToFind.X && this.Coordinates.OriginY == pointToFind.Y;
            bool insideVerticalIfCoord1ToCoord0 = this.IsVertical() && this.Coordinates.DestinationY <= pointToFind.Y && this.Coordinates.OriginY >= pointToFind.Y && this.Coordinates.OriginX == pointToFind.X;
            return insideHorizontalIfCoord0ToCoord1 || insideVerticalIfCoord0ToCoord1 || insideHorizontalIfCoord1ToCoord0 || insideVerticalIfCoord1ToCoord0;
        }

        public override double[] CalculateMoney(double[,] materialMoney) {
            double wallCost = ((this.CalculateLength() * materialMoney[0, 0]) / (ConstantsWall.BLOCKLENGTH));
            double wallPrice = ((this.CalculateLength() * materialMoney[0, 1]) / (ConstantsWall.BLOCKLENGTH));
            double[] wallMoney = { wallCost, wallPrice };
            return wallMoney;
        }

        public Point NextPointOfWall(Point previousPoint) {
            Point nextPoint = new Point(0,0);
            if(this.IsHorizontal() && this.Coordinates.OriginX < this.Coordinates.DestinationX) {
                nextPoint = new Point(previousPoint.X + ConstantsWall.BLOCKLENGTH, previousPoint.Y);
            }
            if (this.IsHorizontal() && this.Coordinates.OriginX > this.Coordinates.DestinationX) {
                nextPoint = new Point(previousPoint.X - ConstantsWall.BLOCKLENGTH, previousPoint.Y);
            }
            if (this.IsVertical() && this.Coordinates.OriginY < this.Coordinates.DestinationY) {
                nextPoint = new Point(previousPoint.X, previousPoint.Y + ConstantsWall.BLOCKLENGTH);
            }
            if (this.IsVertical() && this.Coordinates.OriginY > this.Coordinates.DestinationY) {
                nextPoint = new Point(previousPoint.X, previousPoint.Y - ConstantsWall.BLOCKLENGTH);
            }
            return nextPoint;
        }

        public override bool IsPointOnHole(Point pointToCheck) {
            return false;
        }

        public override bool IsBigDoorOfPoint(Point pointToCheck) {
            return false;
        }

        public override void UpdateMoneyData(SketchItApp currentProgram) { }

        public override double[] GetElementMoney() {
            return null;
        }

    }
}
