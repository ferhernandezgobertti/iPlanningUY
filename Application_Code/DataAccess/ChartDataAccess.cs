using DataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChartDataAccess
    {
        private ClientDataAccess clientDataAccess = new ClientDataAccess();
        public ChartDataAccess()
        {
        }

        public void SaveChanges()
        {
            using (Context context = new Context())
            {
                context.SaveChanges();
            }
        }

        public void AddChart(Chart chartToBeAdded)
        {
            using (var context = new Context())
            {
                context.Clients.Attach(chartToBeAdded.ClientTarget);
                if (chartToBeAdded.UserCreator.IsDesigner())
                {
                    context.Designers.Attach((Designer)chartToBeAdded.UserCreator);
                }
                if (chartToBeAdded.UserCreator.IsArchitect())
                {
                    context.Architects.Attach((Architect)chartToBeAdded.UserCreator);
                }
                context.Charts.Add(chartToBeAdded);
                context.SaveChanges();
            }
        }

        public void AddSignatureToChart(Chart chart, Signature signature)
        {
            List<Signature> chartSignatures = new List<Signature>();
            chartSignatures.Add(signature);
            using (Context context = new Context())
            {
                chart = context.Charts.Find(chart.Id);
                chart.Signatures = chartSignatures;
                context.Entry(chart).State = EntityState.Modified;
                context.SaveChanges(); 
            }
        }
        
        public void AddElementsToChart(Chart chart, List<IDrawable> Elements)
        {
            using (Context context = new Context())
            {
                chart = context.Charts.Find(chart.Id);
                chart.Elements = Elements;
                context.Entry(chart).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void ModifyElementsToChart(Chart chart, List<IDrawable> newElements)
        {
            using (Context context = new Context())
            {
                chart = context.Charts.Include(c => c.Elements).First(a => a.Id == chart.Id);
                List<IDrawable> oldElements = chart.Elements.ToList();
                foreach (IDrawable item in newElements)
                {
                    if (!oldElements.Contains(item))
                    {
                        chart.Elements.Add(item);

                    }
                }
                context.Entry(chart).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void AddMoneyToChart(Chart chart, DoubleContainer Money)
        {
            using (Context context = new Context())
            {
                chart = context.Charts.Find(chart.Id);
                chart.Money.Cost = Money.Cost;
                chart.Money.Price = Money.Price;
                context.Entry(chart).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void ConfigurationOfChart(Chart chart, String Name, IntContainer Dimensions)
        {
            using (Context context = new Context())
            {
                chart = context.Charts.Find(chart.Id);
                chart.Name = Name;

                chart.Dimensions.Width = Dimensions.Width;
                chart.Dimensions.Length = Dimensions.Length;

                context.Entry(chart).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public List<IDrawable> GetElementsOfChart(Chart chart)
        {
            List<IDrawable> elementsOfChart = new List<IDrawable>();
            List<Chart> charts = new List<Chart>();
            using (Context context = new Context())
            {
                chart = context.Charts.Include(c => c.Elements).First(a => a.Id == chart.Id);

                foreach (var item in chart.Elements)
                {
                    if (item is Wall)
                    {
                        
                        PointCoordinatesContainer coordWall = ((Wall)item).Coordinates;
                    }
                    else if (item is Beam)
                    {
                        PointContainer coordBeam = ((Beam)item).Dimensions;
                    }
                    else if (item is Hole)
                    {
                        PointContainer coordHoleLocation = ((Hole)item).Location;
                        IntContainer coordHoleDimension = ((Hole)item).Dimension;
                        DoubleContainer coordHoleMoney = ((Hole)item).Money;

                    }
                }

                elementsOfChart = chart.Elements;

                return elementsOfChart;
            }
        }

        public void RemoveChart(Chart chartForRemoval)
        {
            using (Context context = new Context())
            {
                chartForRemoval.ClientTarget = null;
                chartForRemoval.UserCreator = null;
                chartForRemoval.Dimensions = null;
                chartForRemoval.Money = null;
                
                context.Entry(chartForRemoval).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void RemoveChartBecauseOfClient(int chartForRemovalID)
        {
            Chart chartForRemoval;
            using (Context context = new Context())
            {
                chartForRemoval = context.Charts.Find(chartForRemovalID);
                chartForRemoval.ClientTarget = null;
                chartForRemoval.UserCreator = null;
                chartForRemoval.Dimensions = null;
                chartForRemoval.Money = null;

                context.Entry(chartForRemoval).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void RemoveElementsFromChart(Chart chartForRemoval)
        {
            using (Context context = new Context())
            {
                chartForRemoval = context.Charts.Include(c => c.Elements).First(a => a.Id == chartForRemoval.Id);
                List<IDrawable> elementsToEliminate = new List<IDrawable>();
                elementsToEliminate = chartForRemoval.Elements.ToList();

                foreach (IDrawable item in elementsToEliminate)
                {
                    chartForRemoval.Elements.Remove(item);
                }
            }
        }

        public List<Chart> GetCharts()
        {
            List<Chart> charts = new List<Chart>();
            using (Context context = new Context())
            {
                charts = context.Charts.Include(c => c.ClientTarget).Include(c => c.UserCreator).ToList();

            }
            return charts;
        }

        public Chart GetChart(Chart chart)
        {
            Chart returnChart = null;
            using (Context context = new Context())
            {
                returnChart = context.Charts.Include(c=>c.Dimensions).First(a => a.Id == chart.Id);
            }
            return returnChart;
        }
    }
}
