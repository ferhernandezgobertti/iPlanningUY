using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    
    public abstract class IUserable
    {

        public abstract bool IsDesigner();
        public abstract bool IsClient();
        public abstract bool IsArchitect();

    }
}
