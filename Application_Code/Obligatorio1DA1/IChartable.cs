using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public abstract class IChartable
    {

        public abstract Client GetClientTarget();
        public abstract Worker GetUserCreator();
        public abstract List<Signature> GetSignatures();
        public abstract List<IDrawable> GetElements();
        public abstract double[] CalculateMoney(double[,] materialMoney);
    }
}
