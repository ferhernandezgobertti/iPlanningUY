using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ILoggable
    {
        ILoggable CheckLogIn(SketchItApp program, String userName, String password);
    }
}
