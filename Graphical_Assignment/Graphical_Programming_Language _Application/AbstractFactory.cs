using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{
    public abstract class AbstractFactory
    {
        public abstract Shape getShape(String shapeType);

        
    }
}
