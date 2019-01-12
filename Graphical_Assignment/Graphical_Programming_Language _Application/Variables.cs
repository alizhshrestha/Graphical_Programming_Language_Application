using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{

    /// <summary>
    /// variable class
    /// </summary>
    public class Variables
    {

        /// <summary>
        /// settter and getter
        /// </summary>
        public string variable { get; set; }
        public float value { get; set; }


        /// <summary>
        /// variable setter
        /// </summary>
        /// <param name="variable"></param>
        public void setVariable(string variable)
        {
            this.variable = variable;
        }


        /// <summary>
        /// variable getter
        /// </summary>
        /// <returns></returns>
        public string getVariable()
        {
            return this.variable;
        }


        /// <summary>
        /// value setter
        /// </summary>
        /// <param name="value"></param>
        public void setValue(float value)
        {
            this.value = value;
        }


        /// <summary>
        /// value getter
        /// </summary>
        /// <returns></returns>
        public float getValue()
        {
            return this.value;
        }
    }
}
