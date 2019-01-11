using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{
    public class FactoryProducerDefination
    {
        public bool isShape(string type)
        {
            if (type=="shape")
            {
                return true;
            }
            return false;
        }
    }
}
