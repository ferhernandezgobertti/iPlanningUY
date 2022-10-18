using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MoneyContainer
    {
        public int Id { get; set; }
        public double CostWall { get; set; }
        public double PriceWall { get; set; }
        public double CostBeam { get; set; }
        public double PriceBeam { get; set; }
        public double CostDoor { get; set; }
        public double PriceDoor { get; set; }
        public double CostWindow { get; set; }
        public double PriceWindow { get; set; }
        public double CostColumn { get; set; }
        public double PriceColumn { get; set; }

        public MoneyContainer()
        {

        }

    }
}
