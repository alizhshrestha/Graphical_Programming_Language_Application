using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{
    class Variables
    {
        public string variable { get; set; }
        public float value { get; set; }

        public void setVariable(string variable)
        {
            this.variable = variable;
        }

        public string getVariable()
        {
            return this.variable;
        }

        public void setValue(float value)
        {
            this.value = value;
        }

        public float getValue()
        {
            return this.value;
        }
    }
}
