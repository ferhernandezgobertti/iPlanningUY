using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUsable
    {
        void AddChartsHelped(ref SketchItApp currentProgram);
        void AddClientsHelped(ref SketchItApp currentProgram);
        String GetUserName();

    }
}
