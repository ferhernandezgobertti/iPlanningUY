using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Domain.Exceptions;
using System.Drawing;

namespace Domain
{
    public class SketchItApp{

        public List<IUserable> Users;
        private static SketchItApp instanceOfProgram;
        public List<Hole> HoleTypes;
        public Administrator Admin;
        public List<IChartable> Charts;
        public MoneyContainer elementsMoney; // {wallMoney, beamMoney, doorMoney, windowMoney, columnMoney} && {Column 1, Column 2} = { Cost, Price }

        public static SketchItApp GetInstance()
        {
            //if(instanceOfProgram == null)
            //{
                instanceOfProgram = new SketchItApp();
                
            //}
            return instanceOfProgram;
        }

        private SketchItApp() {
            elementsMoney = new MoneyContainer();
            this.elementsMoney.CostWall = 50;
            this.elementsMoney.PriceWall = 100;
            this.elementsMoney.CostBeam = 50;
            this.elementsMoney.PriceBeam = 100;
            this.elementsMoney.CostDoor = 50;
            this.elementsMoney.PriceDoor = 100;
            this.elementsMoney.CostWindow = 50;
            this.elementsMoney.PriceWindow = 75;
            this.elementsMoney.CostColumn = 25;
            this.elementsMoney.PriceColumn = 50;

            this.Admin = new Administrator();
            
            this.Users = new List<IUserable>();
            
            this.Charts = new List<IChartable>();
            
            this.HoleTypes = new List<Hole>();
            Door doorDefaultType = new Door(new Point(0, 0));
            this.HoleTypes.Add(doorDefaultType);
            Window windowDefaultType = new Window(new Point(0, 0));
            this.HoleTypes.Add(windowDefaultType);
            
        }

        public Hole GetHoleFromHoleTypes(String holeName) {
            return this.HoleTypes.FirstOrDefault(x => x.Name.Equals(holeName));
        }

        public void UpdateChartsData() {
            foreach (Chart registeredChart in this.Charts) {
                foreach (IDrawable element in registeredChart.Elements) {
                    element.UpdateMoneyData(this);
                }
            }
        }

        public List<IChartable> GetChartsFromClient(Client clientLogged) {
            return this.Charts.FindAll(x => x.GetClientTarget().Equals(clientLogged));
        }

        public bool IsChartNotYetRegistered(Chart someChart) {
            return !this.Charts.Contains(someChart);
        }

        public List<Client> GetClientsFromDesigner(Designer designerLogged)
        {
            List<Client> clientsFromDesigner = new List<Client>();
            foreach (Chart aChart in this.Charts) {
                if (aChart.UserCreator.Equals(designerLogged)) {
                    clientsFromDesigner.Add(aChart.ClientTarget);
                }
            }
            return clientsFromDesigner;
        }

        public List<IChartable> GetChartsFromDesigner(Designer designerLogged) {
            return this.Charts.FindAll(x => x.GetUserCreator().Equals(designerLogged));
        }

        public bool IsClientAvailableToAdd(Client clientToCheck) {
            if (!clientToCheck.IsWellRegistered())
            {
                throw new InvalidFormatException();
            }
            if (!this.IsClientNotYetRegistered(clientToCheck))
            {
                throw new AlreadyExistingUserException();
            }
            return this.IsClientNotYetRegistered(clientToCheck) && clientToCheck.IsWellRegistered();
        }

        public bool IsDesignerAvailableToAdd (Designer designerToCheck) {
            if (!designerToCheck.IsWellRegistered())
            {
                throw new InvalidFormatException();
            }
            if (!this.IsDesignerNotYetRegistered(designerToCheck))
            {
                throw new AlreadyExistingUserException();
            }
            return this.IsDesignerNotYetRegistered(designerToCheck) && designerToCheck.IsWellRegistered();
        }

        public bool IsArchitectAvailableToAdd(Architect architectToCheck) {
            if (!architectToCheck.IsWellRegistered())
            {
                throw new InvalidFormatException();
            }
            if (!this.IsArchitectNotYetRegistered(architectToCheck))
            {
                throw new AlreadyExistingUserException();
            }
            return this.IsArchitectNotYetRegistered(architectToCheck) && architectToCheck.IsWellRegistered();
        }

        public Chart GetChartFromList(Chart chartToFind) { // IDEM FIND() but problem with return
            return (Chart)this.Charts.FirstOrDefault(x => x.Equals(chartToFind));
        }

        public Client GetClientFromList(Client clientToFind) { // IDEM FIND() but using System.Predicate
            return (Client)this.GetClientsFromUsers().FirstOrDefault(x => x.Equals(clientToFind));
        }

        public Designer GetDesignerFromList(Designer designerToFind) { // IDEM FIND() but using System.Predicate
            return (Designer)this.GetDesignersFromUsers().FirstOrDefault(x => x.Equals(designerToFind));
        }

        public Architect GetArchitectFromList(Architect architectToFind) {
            return (Architect)this.GetArchitectsFromUsers().FirstOrDefault(x => x.Equals(architectToFind));
        }

        public void OnClosingProgram() {

        }

        public bool IsClientRemovable(Client clientToDelete) {
            return this.Users.Remove(clientToDelete);
        }

        public bool IsDesignerRemovable(Designer designerToDelete) {
            return this.Users.Remove(designerToDelete);
        }

        public bool IsDesignerNotYetRegistered(Designer someDesigner) {
            return !this.Users.Contains(someDesigner);
        }

        public bool IsClientNotYetRegistered(Client someClient) {
            return !this.Users.Contains(someClient);
        }

        public bool IsArchitectNotYetRegistered(Architect someArchitect) {
            return !this.Users.Contains(someArchitect);
        }

        public double[] CalculateCostAndPrice (IChartable utilizedChart) {
            double[,] moneyOfChart = new double[5, 2] { { 50, 100 }, { 50, 100 }, { 50, 100 }, { 50, 75 }, { 25, 50 } };
            return utilizedChart.CalculateMoney(moneyOfChart);
        }

        public List<Chart> DivideChartIntoSingleSignatures(List<IChartable> chartsSource) {
            List<Chart> chartsWithSingleSignatures = new List<Chart>();
            foreach (Chart programChart in chartsSource)
            {
                if (programChart.Signatures !=null && programChart.Signatures.Count != 0)
                {
                    foreach (Signature chartSignature in programChart.Signatures)
                    {
                        Chart singleChart = new Chart(programChart.UserCreator, programChart.ClientTarget);
                        singleChart.Elements = programChart.Elements;
                        singleChart.Dimensions = programChart.Dimensions;
                        singleChart.Money.Cost = programChart.Money.Cost;
                        singleChart.Money.Price = programChart.Money.Price;
                        singleChart.Name = programChart.Name;
                        singleChart.Signatures.Add(chartSignature);
                        chartsWithSingleSignatures.Add(singleChart);
                    }
                }
                else
                {
                    chartsWithSingleSignatures.Add(programChart);
                }
            }
            return chartsWithSingleSignatures;
        }

        public void AddChartsSigned(Chart chartSigned, Architect architectToAddChart)
        {
            if (!this.GetChartFromList(chartSigned).GetSignatureWithOneSigning().FirstSigner.Equals(architectToAddChart)) {
                this.GetArchitectFromList(architectToAddChart).ChartsSigned++;
            }
        }

        public List<IUserable> GetDesignersFromUsers()
        {
            return this.Users.FindAll(x => x.IsDesigner());
        }

        public List<IUserable> GetClientsFromUsers()
        {
            return this.Users.FindAll(x => x.IsClient());
        }

        public List<IUserable> GetArchitectsFromUsers()
        {
            return this.Users.FindAll(x => x.IsArchitect());
        }

    }
}
