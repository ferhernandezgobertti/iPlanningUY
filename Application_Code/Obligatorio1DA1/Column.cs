using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public static class ConstantsColumn
    {
        public const int BLOCKLENGTH = 50;
        public const double RADIUS = 0.25;
        public const int HEIGHT = 3; //Same as WALL
    }

    
    public class Column : Hole
    {
        public Column()
        {

        }

        public Column(Point columnLocation) {
            Location = new PointContainer();
            Dimension = new IntContainer();
            Money = new DoubleContainer();
            this.Location.X = columnLocation.X;
            this.Location.Y = columnLocation.Y;
        }

        public override void Draw(ref Graphics graphUsed)
        {
            SolidBrush columnFormat = new SolidBrush(Color.Brown);
            Rectangle columnBorder = new Rectangle(this.Location.X - (int)(ConstantsColumn.BLOCKLENGTH*ConstantsColumn.RADIUS), this.Location.Y - (int)(ConstantsColumn.BLOCKLENGTH * ConstantsColumn.RADIUS), 2 * (int)(ConstantsColumn.BLOCKLENGTH * ConstantsColumn.RADIUS), 2 * (int)(ConstantsColumn.BLOCKLENGTH * ConstantsColumn.RADIUS));
            graphUsed.FillEllipse(columnFormat, columnBorder);
        }
        public override bool IsPointInsideWall(Point pointToFind)
        {
            return false;
        }
        public override bool IsWall()
        {
            return false;
        }

        public override double[] CalculateMoney(double[,] materialMoney) {
            double columnCost = materialMoney[4, 0];
            double columnPrice = materialMoney[4, 1];
            double[] columnMoney = { columnCost, columnPrice };
            return columnMoney;
        }

        public override void CountElements(int[] quantityOfElement)
        {
            quantityOfElement[4]++;
        }

        public override bool IsPointOnHole(Point pointToCheck){
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
