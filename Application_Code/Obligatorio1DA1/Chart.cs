using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domain
{
    public static class ConstantsChart
    {
        public const int BLOCKPIXELS = 50;
        public const int MAXLENGTH = 100;
        public const int SOLID_LINE = 0;
        public const int DASHED_LINE = 1;
        public const int INVISIBLE_LINE = 2;
    }
   

    public class Chart : IChartable
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<IDrawable> Elements { get; set;}
        public List<Signature> Signatures { get; set; }
        public Client ClientTarget { get; set; }
        public Worker UserCreator { get; set; }
        public virtual IntContainer Dimensions { get; set; } // [ Width, Length ]
        public virtual DoubleContainer Money { get; set; } // [ Cost, Price ]
        public Grid tableGrid;

        public Chart()
        {

        }
        public Chart (Worker currentUser, Client currentClient)
        {
            Dimensions = new IntContainer();
            Money = new DoubleContainer();
            Elements = new List<IDrawable>();
            Signatures = new List<Signature>();
            this.UserCreator = currentUser;
            this.ClientTarget = currentClient;
            this.Money.Cost = 0;
            this.Money.Price = 0; // Initial Cost & Price
            this.tableGrid = new Grid();
        }

        public void DrawGrid(ref Graphics graphUsed, int gridToUse) {
            if(gridToUse == ConstantsChart.SOLID_LINE) {
                this.tableGrid = new Grid();
            }
            if (gridToUse == ConstantsChart.DASHED_LINE) {
                this.tableGrid = new DashedGrid();
            }
            if (gridToUse == ConstantsChart.INVISIBLE_LINE) {
                this.tableGrid = new InvisibleGrid();
            }
            this.tableGrid.Draw(ref graphUsed, this);
        }

        public void DrawElements(ref Graphics graphUsed) {
            if (this.Elements.Count != 0) {
                foreach (IDrawable anElement in this.Elements) {
                    anElement.Draw(ref graphUsed);
                }
            }
        }

        public override Client GetClientTarget()
        {
            return this.ClientTarget;
        }

        public override Worker GetUserCreator()
        {
            return this.UserCreator;
        }

        public override List<Signature> GetSignatures() {
            return this.Signatures;
        }

        public override List<IDrawable> GetElements() {
            return this.Elements;
        }

        public bool IsSigned() {
            if (this.Signatures != null)
            {
            foreach (Signature someSignature in this.Signatures) {
                if(someSignature.SecondSigner == null) {
                    return true;
                }
            }
            }
            
            return false;
        }

        public bool IsCompletelySigned() {
            return !this.IsSigned() && this.Signatures.Count != 0;
        }

        public bool IsWallAddable (Wall someWall) {
            bool wallAbleToAdd = this.IsWallNotYetRegistered(someWall) && !someWall.IsNullLength();
            if (wallAbleToAdd) {
                this.Elements.Add(someWall);
            }
            return wallAbleToAdd;
        }
        public void RemoveWall(Wall someWall) {
            this.Elements.Remove(someWall);
        }
        public int[] GetPixels() {
            int[] chartPixels = new int[2];
            chartPixels[0] = this.Dimensions.Width * ConstantsChart.BLOCKPIXELS;
            chartPixels[1] = this.Dimensions.Length * ConstantsChart.BLOCKPIXELS;
            return chartPixels;
        }

        public bool IsChartWellRegistered() {
            return !this.Name.Equals("") && !this.Name.Contains(" ") 
                && this.Dimensions.Width <= ConstantsChart.MAXLENGTH 
                && this.Dimensions.Width > 0 && this.Dimensions.Length > 0 
                && this.Dimensions.Length <= ConstantsChart.MAXLENGTH;
        }

        public bool IsEmpty() {
            return this.Elements.Count == 0; 
        }

        public bool IsWallNotYetRegistered(Wall interestedWall) {
            return !this.Elements.Contains(interestedWall);
        }

        public bool IsBeamNotYetRegistered(Beam interestedBeam) {
            return !this.Elements.Contains(interestedBeam);
        }

        public bool IsWallWellRegistered(Wall wallToRegister) {
            Point wallToRegisterCoordinatesOrigin = new Point(wallToRegister.Coordinates.OriginX, wallToRegister.Coordinates.OriginY);
            Point wallToRegisterCoordinatesDestination = new Point(wallToRegister.Coordinates.DestinationX, wallToRegister.Coordinates.DestinationY);
            return this.IsWallNotYetRegistered(wallToRegister)
                && this.IsPointOnChart(wallToRegisterCoordinatesOrigin) 
                && this.IsPointOnChart(wallToRegisterCoordinatesDestination);
        }

        public bool IsPointOnChart(Point interestedPoint) {
            return interestedPoint.X >= ConstantsWall.BLOCKLENGTH && interestedPoint.X <= this.GetPixels()[0] + ConstantsWall.BLOCKLENGTH
                && interestedPoint.Y >= ConstantsWall.BLOCKLENGTH && interestedPoint.Y <= this.GetPixels()[1] + ConstantsWall.BLOCKLENGTH;
        }

        public bool IsIntersection() {
            int initialQuantity = this.Elements.Count;
            List<IDrawable> newElements = new List<IDrawable>();
            newElements.InsertRange(0, this.Elements);
            int maxCount = this.Elements.Count;
            foreach (IDrawable aNewElement in newElements) {
                for (int position = 0; position < maxCount; position++) {
                    Point intersectionFound = new Point(0, 0);
                    if (!aNewElement.Equals(this.Elements.ElementAt(position)) && this.Elements.ElementAt(position).IsWall() && aNewElement.IsWall() && !(intersectionFound = this.GetIntersection((Wall)this.Elements.ElementAt(position), (Wall)aNewElement)).Equals(new Point(0, 0))) {
                        this.DivideWallIntoSmaller((Wall)this.Elements.ElementAt(position), intersectionFound);
                        this.DivideWallIntoSmaller(this.GetWallFromList(aNewElement), intersectionFound);
                    }
                }
            }
            return initialQuantity<this.Elements.Count;
        }

        public Point GetIntersection(Wall oneWall, Wall otherWall)
        {
            Point intersectionFound = new Point(0, 0);
            if (this.IsPossibleIntersection(oneWall, otherWall) && this.IsWallBetweenWall(oneWall, otherWall))
            {
                intersectionFound = this.CaptureIntersectionPoint(oneWall, otherWall);
            }
            return intersectionFound; //If it's (0,0), then it has not been found or it does not exist
        }

        public void AddBeamsDueToLength(Wall wallToCheck) {
            int chunksBetweenBeams = wallToCheck.CheckLength();
            if (chunksBetweenBeams == 0 || chunksBetweenBeams == 1) {
                this.IsWallAddable(wallToCheck);
            }
            for (int beamsDrawn = 0; beamsDrawn < chunksBetweenBeams && chunksBetweenBeams > 0; beamsDrawn++) {
                Point beamCoordinates = wallToCheck.AddLengthToOrigin(ConstantsWall.MAXLENGTH * ConstantsWall.BLOCKLENGTH);
                Point wallToCheckCoordinatesDestination = new Point(wallToCheck.Coordinates.DestinationX, wallToCheck.Coordinates.DestinationY);
                if (!beamCoordinates.Equals(wallToCheckCoordinatesDestination)) {
                    Beam beamToAdd = new Beam(beamCoordinates);
                    wallToCheck = this.DivideWallIntoSmaller(wallToCheck, beamCoordinates);
                    this.IsBeamToChartAddable(beamToAdd);
                    
                }
            }
        }

        public List<IDrawable> SortElements()
        {
            List<Wall> wallsOnList = new List<Wall>();
            List<IDrawable> sortedElements = new List<IDrawable>();
            sortedElements.InsertRange(0, this.Elements);
            foreach(IDrawable element in this.Elements) {
                if (element.IsWall()) {
                    wallsOnList.Add((Wall)element);
                    sortedElements.Remove(element);
                }
            }
            sortedElements.InsertRange(0, wallsOnList);
            return sortedElements;
        }

        public bool IsBeamNotYetRegisteredNearDoor (Door doorToCheck)
        {
            Point oneBlockRight = new Point(doorToCheck.Location.X + ConstantsBeam.BLOCKLENGTH, doorToCheck.Location.Y);
            Point oneBlockLeft = new Point(doorToCheck.Location.X - ConstantsBeam.BLOCKLENGTH, doorToCheck.Location.Y);
            Point oneBlockUp = new Point(doorToCheck.Location.X, doorToCheck.Location.Y - ConstantsBeam.BLOCKLENGTH);
            Point oneBlockDown = new Point(doorToCheck.Location.X, doorToCheck.Location.Y + ConstantsBeam.BLOCKLENGTH);

            bool availableIfDoorHorizontal = (doorToCheck.OrientationDoor == 1 || doorToCheck.OrientationDoor == 3) && IsBeamNotYetRegistered(new Beam(oneBlockDown)) && IsBeamNotYetRegistered(new Beam(oneBlockUp));
            bool availableIfDoorVertical = (doorToCheck.OrientationDoor == 2 || doorToCheck.OrientationDoor == 4) && IsBeamNotYetRegistered(new Beam(oneBlockLeft)) && IsBeamNotYetRegistered(new Beam(oneBlockRight));

            return availableIfDoorHorizontal || availableIfDoorVertical;
        }

        public bool IsWindowNotYetRegisteredNearDoor(Door doorToCheck, int distance) {
            Point oneBlockRight = new Point(doorToCheck.Location.X + distance * ConstantsBeam.BLOCKLENGTH, doorToCheck.Location.Y);
            Point oneBlockLeft = new Point(doorToCheck.Location.X - distance * ConstantsBeam.BLOCKLENGTH, doorToCheck.Location.Y);
            Point oneBlockUp = new Point(doorToCheck.Location.X, doorToCheck.Location.Y - distance * ConstantsBeam.BLOCKLENGTH);
            Point oneBlockDown = new Point(doorToCheck.Location.X, doorToCheck.Location.Y + distance * ConstantsBeam.BLOCKLENGTH);

            bool availableIfDoorHorizontal = (doorToCheck.OrientationDoor == 1 || doorToCheck.OrientationDoor == 3) && IsWindowNotYetRegistered(new Window(oneBlockDown)) && IsWindowNotYetRegistered(new Window(oneBlockUp));
            bool availableIfDoorVertical = (doorToCheck.OrientationDoor == 2 || doorToCheck.OrientationDoor == 4) && IsWindowNotYetRegistered(new Window(oneBlockLeft)) && IsWindowNotYetRegistered(new Window(oneBlockRight));

            return availableIfDoorHorizontal || availableIfDoorVertical;
        }

        public bool IsNoBigDoorInSurroundingsOfDoor(Door doorToCheck, int distanceX, int distanceY) {
            Point objectiveRightUp = new Point(doorToCheck.Location.X + distanceX * ConstantsDoor.BLOCKLENGTH, doorToCheck.Location.Y - distanceY * ConstantsDoor.BLOCKLENGTH);
            Point objectiveLeftUp = new Point(doorToCheck.Location.X - distanceX * ConstantsDoor.BLOCKLENGTH, doorToCheck.Location.Y - distanceY * ConstantsDoor.BLOCKLENGTH);
            Point objectiveLeftDown = new Point(doorToCheck.Location.X - distanceX * ConstantsDoor.BLOCKLENGTH, doorToCheck.Location.Y + distanceY * ConstantsDoor.BLOCKLENGTH);
            Point objectiveRightDown = new Point(doorToCheck.Location.X + distanceX * ConstantsDoor.BLOCKLENGTH, doorToCheck.Location.Y + distanceY * ConstantsDoor.BLOCKLENGTH);

            Door bigDoorRigthUp = GetBigDoorOnPoint(objectiveRightUp);
            Door bigDoorLeftUp = GetBigDoorOnPoint(objectiveLeftUp);
            Door bigDoorLeftDown = GetBigDoorOnPoint(objectiveLeftDown);
            Door bigDoorRigthDown = GetBigDoorOnPoint(objectiveRightDown);

            bool availableIfDoorOrientation1 = (doorToCheck.OrientationDoor == 1) && (bigDoorRigthDown == null || bigDoorRigthDown.OrientationDoor != 2) && (bigDoorRigthUp == null || bigDoorRigthUp.OrientationDoor != 4);
            bool availableIfDoorOrientation2 = (doorToCheck.OrientationDoor == 2) && (bigDoorLeftUp == null || bigDoorLeftUp.OrientationDoor != 1) && (bigDoorRigthUp == null || bigDoorRigthUp.OrientationDoor != 3);
            bool availableIfDoorOrientation3 = (doorToCheck.OrientationDoor == 3) && (bigDoorLeftDown == null || bigDoorLeftDown.OrientationDoor != 2) && (bigDoorLeftUp == null || bigDoorLeftUp.OrientationDoor != 4);
            bool availableIfDoorOrientation4 = (doorToCheck.OrientationDoor == 4) && (bigDoorRigthDown == null || bigDoorRigthDown.OrientationDoor != 3) && (bigDoorLeftDown == null || bigDoorLeftDown.OrientationDoor != 1);

            return availableIfDoorOrientation1 || availableIfDoorOrientation2 || availableIfDoorOrientation3 || availableIfDoorOrientation4;
        }

        public Door GetBigDoorOnPoint(Point pointToGet)
        {
            return (Door)this.Elements.FirstOrDefault(x => x.IsBigDoorOfPoint(pointToGet));
        }

        public bool IsDoorAvailable (Door interestedDoor, int distance) {
            bool availableIfDoorOrientation1 = (interestedDoor.OrientationDoor == 1) && !this.IsDoorCrossingWall(interestedDoor) && this.IsDoorNotYetRegistered(new Door(new Point(interestedDoor.Location.X + distance*ConstantsChart.BLOCKPIXELS,interestedDoor.Location.Y)));
            bool availableIfDoorOrientation2 = (interestedDoor.OrientationDoor == 2) && !this.IsDoorCrossingWall(interestedDoor) && this.IsDoorNotYetRegistered(new Door(new Point(interestedDoor.Location.X, interestedDoor.Location.Y - distance*ConstantsChart.BLOCKPIXELS)));
            bool availableIfDoorOrientation3 = (interestedDoor.OrientationDoor == 3) && !this.IsDoorCrossingWall(interestedDoor) && this.IsDoorNotYetRegistered(new Door(new Point(interestedDoor.Location.X - distance*ConstantsChart.BLOCKPIXELS, interestedDoor.Location.Y)));
            bool availableIfDoorOrientation4 = (interestedDoor.OrientationDoor == 4) && !this.IsDoorCrossingWall(interestedDoor) && this.IsDoorNotYetRegistered(new Door(new Point(interestedDoor.Location.X, interestedDoor.Location.Y + distance*ConstantsChart.BLOCKPIXELS)));

            bool surroundingsAvailable = availableIfDoorOrientation1 || availableIfDoorOrientation2 || availableIfDoorOrientation3 || availableIfDoorOrientation4;
            Point interestedDoorLocation = new Point(interestedDoor.Location.X, interestedDoor.Location.Y);
            bool existsWall = this.GetWallOfPoint(interestedDoorLocation) != null;
            return existsWall && surroundingsAvailable;
        }
        
        public void EliminateHoles(Wall wallSelected) {
           Point pointOnWall = new Point(wallSelected.Coordinates.OriginX, wallSelected.Coordinates.OriginY);
            Point wallSelectedCoordinatesDestination = new Point(wallSelected.Coordinates.DestinationX, wallSelected.Coordinates.DestinationY);
           while (!pointOnWall.Equals(wallSelectedCoordinatesDestination)) {
                if(!this.IsDoorNotYetRegistered(new Door(pointOnWall))){
                    this.Elements.Remove(this.Elements.Find(x => x.Equals(new Door(pointOnWall))));
                }
                if (!this.IsWindowNotYetRegistered(new Window(pointOnWall))){
                    this.Elements.Remove(this.Elements.Find(x => x.Equals(new Window(pointOnWall))));
                }
                pointOnWall = wallSelected.NextPointOfWall(pointOnWall);
            }
        }

        public void EliminateBeams(Wall wallSelected) {
            Point wallSelectedCoordinatesOrigin = new Point(wallSelected.Coordinates.OriginX, wallSelected.Coordinates.OriginY);
            Point wallSelectedCoordinatesDestination = new Point(wallSelected.Coordinates.DestinationX, wallSelected.Coordinates.DestinationY);
            if (this.GetWallOfPoint(wallSelectedCoordinatesOrigin) == null){
                this.Elements.Remove(this.Elements.Find(x => x.Equals(new Beam(wallSelectedCoordinatesOrigin))));
            }
            if (this.GetWallOfPoint(wallSelectedCoordinatesDestination) == null) {
                this.Elements.Remove(this.Elements.Find(x => x.Equals(new Beam(wallSelectedCoordinatesDestination))));
            }
        }

        public bool IsHoleInBetween(Wall interestedWall) {
            bool holeInBetween = false;
            Point interestedWallCoordinatesOrigin = new Point(interestedWall.Coordinates.OriginX, interestedWall.Coordinates.OriginY);
            Point interestedWallCoordinatesDestination = new Point(interestedWall.Coordinates.DestinationX, interestedWall.Coordinates.DestinationY);
            Point inBetweenWall = interestedWallCoordinatesOrigin;
            while (!inBetweenWall.Equals(interestedWallCoordinatesDestination) && !holeInBetween) {
                holeInBetween = !this.IsDoorNotYetRegistered(new Door(inBetweenWall)) || !this.IsWindowNotYetRegistered(new Window(inBetweenWall));
                inBetweenWall = interestedWall.NextPointOfWall(inBetweenWall);
            }
            return holeInBetween;
        }

        public bool IsBeamNotYetRegisteredNearWindow(Window windowToCheck, int distance)
        {
            Point oneBlockRight = new Point(windowToCheck.Location.X + distance * ConstantsBeam.BLOCKLENGTH, windowToCheck.Location.Y);
            Point oneBlockLeft = new Point(windowToCheck.Location.X - distance * ConstantsBeam.BLOCKLENGTH, windowToCheck.Location.Y);
            Point oneBlockUp = new Point(windowToCheck.Location.X, windowToCheck.Location.Y - distance * ConstantsBeam.BLOCKLENGTH);
            Point oneBlockDown = new Point(windowToCheck.Location.X, windowToCheck.Location.Y + distance * ConstantsBeam.BLOCKLENGTH);

            bool availableIfWindowOrientation1 = (windowToCheck.OrientationWindow == 1) && IsBeamNotYetRegistered(new Beam(oneBlockLeft)) && IsBeamNotYetRegistered(new Beam(oneBlockRight));
            bool availableIfWindowOrientation2 = (windowToCheck.OrientationWindow == 2) && IsBeamNotYetRegistered(new Beam(oneBlockDown)) && IsBeamNotYetRegistered(new Beam(oneBlockUp));
            
            return availableIfWindowOrientation1 || availableIfWindowOrientation2;
        }

        public bool IsDoorNotYetRegisteredNearWindow(Window windowToCheck, int distance)
        {
            Point oneBlockRight = new Point(windowToCheck.Location.X + distance * ConstantsBeam.BLOCKLENGTH, windowToCheck.Location.Y);
            Point oneBlockLeft = new Point(windowToCheck.Location.X - distance * ConstantsBeam.BLOCKLENGTH, windowToCheck.Location.Y);
            Point oneBlockUp = new Point(windowToCheck.Location.X, windowToCheck.Location.Y - distance * ConstantsBeam.BLOCKLENGTH);
            Point oneBlockDown = new Point(windowToCheck.Location.X, windowToCheck.Location.Y + distance * ConstantsBeam.BLOCKLENGTH);

            bool availableIfWindowOrientation1 = (windowToCheck.OrientationWindow == 1) && IsDoorNotYetRegistered(new Door(oneBlockLeft)) && IsDoorNotYetRegistered(new Door(oneBlockRight));
            bool availableIfWindowOrientation2 = (windowToCheck.OrientationWindow == 2) && IsDoorNotYetRegistered(new Door(oneBlockDown)) && IsDoorNotYetRegistered(new Door(oneBlockUp));
            
            return availableIfWindowOrientation1 || availableIfWindowOrientation2;
        }

        public bool IsWindowAvailable(Window interestedWindow, int distance) {
            bool availableIfWIndowOrientation1 = (interestedWindow.OrientationWindow == 1) && this.IsWindowNotYetRegistered(new Window(new Point(interestedWindow.Location.X + distance*ConstantsChart.BLOCKPIXELS, interestedWindow.Location.Y))) && this.IsWindowNotYetRegistered(new Window(new Point(interestedWindow.Location.X - distance*ConstantsChart.BLOCKPIXELS, interestedWindow.Location.Y)));
            bool availableIfWindowOrientation2 = (interestedWindow.OrientationWindow == 2) && this.IsWindowNotYetRegistered(new Window(new Point(interestedWindow.Location.X, interestedWindow.Location.Y - distance*ConstantsChart.BLOCKPIXELS))) && this.IsWindowNotYetRegistered(new Window(new Point(interestedWindow.Location.X, interestedWindow.Location.Y + distance*ConstantsChart.BLOCKPIXELS)));

            bool surroundingsAvailable = availableIfWIndowOrientation1 || availableIfWindowOrientation2;
            Point interestedWindowLocation = new Point(interestedWindow.Location.X, interestedWindow.Location.Y);
            return (this.GetWallOfPoint(interestedWindowLocation) != null) && surroundingsAvailable && this.IsWindowsWithSameOrientationWall(interestedWindow);
        }

        public bool IsWindowsWithSameOrientationWall(Window selectedWindow) {
            bool sameOrientation = false;
            Wall wallOfWindow;
            Point selectedWindowLocation = new Point(selectedWindow.Location.X, selectedWindow.Location.Y);
            if ((wallOfWindow = this.GetWallOfPoint(selectedWindowLocation)) != null) {
                sameOrientation = ((selectedWindow.OrientationWindow == 1) && wallOfWindow.IsHorizontal()) || ((selectedWindow.OrientationWindow == 2) && wallOfWindow.IsVertical()); 
            }
            return sameOrientation;
        }

        public bool IsDoorCrossingWall(Door interestedDoor) {
            Point interestedDoorLocation = new Point(interestedDoor.Location.X, interestedDoor.Location.Y);
            Wall wallOfDoorFound = this.GetWallOfPoint(interestedDoorLocation);
            if (wallOfDoorFound != null) {
                bool crossingIfDoorOrientation1 = (interestedDoor.OrientationDoor == 1) && wallOfDoorFound.IsHorizontal();
                bool crossingIfDoorOrientation2 = (interestedDoor.OrientationDoor == 2) && wallOfDoorFound.IsVertical();
                bool crossingIfDoorOrientation3 = (interestedDoor.OrientationDoor == 3) && wallOfDoorFound.IsHorizontal();
                bool crossingIfDoorOrientation4 = (interestedDoor.OrientationDoor == 4) && wallOfDoorFound.IsVertical();
                return crossingIfDoorOrientation1 || crossingIfDoorOrientation2 || crossingIfDoorOrientation3 || crossingIfDoorOrientation4;
            }
            return false;
        }

        public Wall DivideWallIntoSmaller(Wall wallToDivide, Point whereToDivide) {
            Point[] wallDefaultCoordinates = { new Point(0, 0), new Point(0, 0) };
            Wall secondWall = new Wall(wallDefaultCoordinates);
            if (wallToDivide != null) {
                Point wallToDivideCoordinatesOrigin = new Point(wallToDivide.Coordinates.OriginX, wallToDivide.Coordinates.OriginY);
                Point wallToDivideCoordinatesDestination = new Point(wallToDivide.Coordinates.DestinationX, wallToDivide.Coordinates.DestinationY);
                Point[] firstWallCoordinates = { wallToDivideCoordinatesOrigin, whereToDivide };
                Point[] secondWallCoordinates = { whereToDivide, wallToDivideCoordinatesDestination };
                Wall firstWall = new Wall(firstWallCoordinates);
                this.IsWallAddable(firstWall);
                secondWall = new Wall(secondWallCoordinates);
                this.IsWallAddable(secondWall);
                if (firstWall.CalculateLength() != 0 && secondWall.CalculateLength() != 0) {
                    this.RemoveWall(wallToDivide);
                }
            }
            return secondWall;
        }

        public bool IsPossibleIntersection (Wall oneWall, Wall otherWall) {
            return (oneWall.IsHorizontal() && otherWall.IsVertical()) || (oneWall.IsVertical() && otherWall.IsHorizontal());
        }

        

        public Point CaptureIntersectionPoint(Wall oneWall, Wall otherWall) {
            Point intersectionToFind = new Point(0, 0);
            if (oneWall.IsHorizontal() && otherWall.IsVertical()) {
                intersectionToFind = new Point(otherWall.Coordinates.OriginX, oneWall.Coordinates.OriginY);
                this.IsBeamToChartAddable(new Beam(intersectionToFind));
            }
            if(oneWall.IsVertical() && otherWall.IsHorizontal()) {
                intersectionToFind = new Point(oneWall.Coordinates.OriginX, otherWall.Coordinates.OriginY);
                this.IsBeamToChartAddable(new Beam(intersectionToFind));
            }
            return intersectionToFind; //If it's (0,0), then it has not been found or it does not exist
        }

        public Wall GetWallFromList(IDrawable anElement) {
            return (Wall)this.Elements.FirstOrDefault(x => x.Equals(anElement));
        }
        
        public bool IsCrossIntersection(Wall verticalWall, Wall horizontalWall) {
            bool isLeftUp = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isRightUp = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isLeftDown = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            bool isRightDown = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            return isLeftUp || isRightUp || isLeftDown || isRightDown;
        }

        public bool IsTeHorizontalIntersection(Wall verticalWall, Wall horizontalWall) {
            bool isLeftUpOut = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX == verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isRightUpOut = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX == verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isLeftDownOut = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX == verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            bool isRightDownOut = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX == verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            bool isOriginOutOfWall = isLeftUpOut || isRightUpOut || isLeftDownOut || isRightDownOut;

            bool isLeftUpCoinciding = (horizontalWall.Coordinates.OriginX == verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isRightUpCoinciding = (horizontalWall.Coordinates.OriginX == verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isLeftDownCoinciding = (horizontalWall.Coordinates.OriginX == verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            bool isRightDownCoinciding = (horizontalWall.Coordinates.OriginX == verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            bool isOriginCoincidingWithWall = isLeftUpCoinciding || isRightUpCoinciding || isLeftDownCoinciding || isRightDownCoinciding;

            return isOriginOutOfWall || isOriginCoincidingWithWall;
        }
        
        public bool IsWindowNotYetRegistered(Window windowToCheck) {
            return !this.Elements.Contains(windowToCheck);
        }

        public void AddWindow(Window windowToAdd) {
            if (this.IsWindowNotYetRegistered(windowToAdd)) {
                this.Elements.Add(windowToAdd);
            }
        }

        public void AddDoor(Door doorToAdd) {
            if (this.IsDoorNotYetRegistered(doorToAdd)) {
                this.Elements.Add(doorToAdd);
            }
        }

        public bool IsDoorNotYetRegistered(Door doorToCheck) {
            return !this.Elements.Contains(doorToCheck);
        }
        
        public bool IsTeVerticalIntersection(Wall verticalWall, Wall horizontalWall)
        {
            bool isLeftUpOut = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.DestinationY);
            bool isRightUpOut = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.DestinationY);
            bool isLeftDownOut = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.DestinationY);
            bool isRightDownOut = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.DestinationY);
            bool isOriginOutOfWall = isLeftUpOut || isRightUpOut || isLeftDownOut || isRightDownOut;

            bool isLeftUpCoinciding = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            bool isRightUpCoinciding = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY > verticalWall.Coordinates.DestinationY);
            bool isLeftDownCoinciding = (horizontalWall.Coordinates.OriginX < verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX > verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isRightDownCoinciding = (horizontalWall.Coordinates.OriginX > verticalWall.Coordinates.OriginX && horizontalWall.Coordinates.DestinationX < verticalWall.Coordinates.OriginX
                && horizontalWall.Coordinates.OriginY == verticalWall.Coordinates.OriginY && horizontalWall.Coordinates.OriginY < verticalWall.Coordinates.DestinationY);
            bool isOriginCoincidingWithWall = isLeftUpCoinciding || isRightUpCoinciding || isLeftDownCoinciding || isRightDownCoinciding;

            return isOriginOutOfWall || isOriginCoincidingWithWall;
        }

        public bool IsWallBetweenWall(Wall oneWall, Wall otherWall) {

            bool isCrossVerticalHorizontal = IsCrossIntersection(oneWall, otherWall);
            bool isCrossHorizontalVertical = IsCrossIntersection(otherWall, oneWall);
            
            bool isTeHorizontal = IsTeHorizontalIntersection(oneWall, otherWall);
            bool isTeVertical = IsTeVerticalIntersection(otherWall, oneWall);

            return isCrossVerticalHorizontal || isCrossHorizontalVertical || isTeVertical || isTeHorizontal;
        }

        public bool IsBeamToChartAddable(Beam beamToAdd) {
            bool isAddable = false;
            if (isAddable = this.IsBeamNotYetRegistered(beamToAdd)) {
                this.Elements.Add(beamToAdd);
            }
            return isAddable;
        }

        public Wall GetWallOfPoint(Point pointToFind) {
            foreach (IDrawable elementToLook in this.Elements) {
                if (elementToLook.IsPointInsideWall(pointToFind)) {
                    return (Wall)elementToLook;
                }
            }
            return null;
        }

        public override double[] CalculateMoney(double[,] materialMoney) {
            double costOfChart = 0, priceOfChart = 0;
            double[] moneyOfChart = { 0, 0 };
            if (this.Elements.Count != 0) {
                foreach (IDrawable consideredElement in this.Elements) {
                    moneyOfChart = consideredElement.CalculateMoney(materialMoney);
                    costOfChart = costOfChart + moneyOfChart[0];
                    priceOfChart = priceOfChart + moneyOfChart[1];
                }
            }
            //this.Money.Cost = costOfChart;
            //this.Money.Price = priceOfChart;
            double[] moneyChart = { costOfChart, priceOfChart};
            return moneyChart;
        }

        

        public override string ToString() {
            StringBuilder chartPresentation = new StringBuilder();
            if (this.IsSigned()) {
                chartPresentation.Append("- SIGNED - ");
            }
            chartPresentation.Append("CHART NAME: ");
            chartPresentation.Append(this.Name);
            //chartPresentation.Append(" :: CREATOR: ");
            //chartPresentation.Append(this.UserCreator.UserName);
            //chartPresentation.Append(" - Length: "); 
            //chartPresentation.Append(this.Dimensions.Width);
            //chartPresentation.Append(" - Width: ");
            //chartPresentation.Append(this.Dimensions.Length);
            //chartPresentation.Append(" - Cost: ");
            //chartPresentation.Append(this.Money.Cost);
            //chartPresentation.Append(" - Price: ");
            //chartPresentation.Append(this.Money.Price);
            return chartPresentation.ToString();
        }

        public override bool Equals(object anObject) {
            Chart aChart = anObject as Chart;

            if (aChart == null || this.Elements==null || aChart.Elements==null)
                return false;

            if(this.Elements.Count!= aChart.Elements.Count) {
                return false;
            }

            int position = 0;
            foreach (IDrawable anElement in this.Elements) {
                if (!anElement.Equals(aChart.Elements.ElementAt(position))) {
                    return false;
                }
                position++;
            }

            bool equality = this.UserCreator.Equals(aChart.UserCreator) && this.ClientTarget.Equals(aChart.ClientTarget);
            return equality;
        }

        public int[] CountElements() {
            int[] quantityOfElements = { 0, 0, 0, 0, 0 };
            foreach (IDrawable element in this.Elements)
            {
                element.CountElements(quantityOfElements);
            }
            return quantityOfElements;
        }

        public bool IsColumnAvailable(Column interestedColumn) {
            Point interestedColumnLocation = new Point(interestedColumn.Location.X, interestedColumn.Location.Y);
            return (this.GetWallOfPoint(interestedColumnLocation) == null);
        }

        public void AddColumn(Column columnToAdd) {
            if (this.IsColumnNotYetRegistered(columnToAdd)) {
                this.Elements.Add(columnToAdd);
            }
        }

        public bool IsColumnNotYetRegistered(Column columnToCheck) {
            return !this.Elements.Contains(columnToCheck);
        }

        public Signature GetSignatureWithOneSigning()
        {
            return this.Signatures.FirstOrDefault(x => x.SecondSigner == null);
        }

        public bool IsPointOnHole(Point pointToCheck) {
            return (this.Elements.FirstOrDefault(x => x.IsPointOnHole(pointToCheck))!=null);
        }

    }
}
