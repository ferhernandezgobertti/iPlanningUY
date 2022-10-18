using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Domain
{
    
    public abstract class IDrawable {

        
        public int Id { get; set; }

        public abstract void Draw(ref Graphics whereToDraw);
        public abstract bool IsPointInsideWall(Point pointToFind);
        public abstract bool IsWall();
        public abstract double[] CalculateMoney(double[,] materialMoney);
        public abstract void CountElements(int[] quantityOfElement);
        public abstract bool IsPointOnHole(Point pointToCheck);
        public abstract bool IsBigDoorOfPoint(Point pointToCheck);
        public abstract void UpdateMoneyData(SketchItApp currentProgram);
        public abstract double[] GetElementMoney();
       // public abstract IntContainer GetDimensions();

        //ALTERNATIVES:
        /*
        Point GetIntersection (Chart aChart, Wall otherWall);
        Point GetIntersection(Chart aChart, Beam otherBeam);
        Point GetIntersection(Chart aChart, Door otherDoor);
        Point GetIntersection(Chart aChart, Window otherWindow);
        */

    }
}
