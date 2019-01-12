using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{
    class ConditionController
    {
        //declaration
        string variable;
        float value;

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
