using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{
    class Code_Attributes
    {
        String command, obj, variable_name;
        int[] parameter;
        
        public Code_Attributes()
        {

        }

        public void setCommand(String command)
        {
            this.command = command;
        }

        public String getCommand()
        {
            return this.command;
        }

        public void setObj(String obj)
        {
            this.obj = obj;
        }

        public String getObj()
        {
            return this.obj;
        }

        public void setVariableName(String variable_name)
        {
            this.variable_name = variable_name;
        }

        public String getVariableName()
        {
            return this.variable_name;
        }

        public  void setParameter(int[] parameter)
        {
            this.parameter = parameter;
        }


        public int[] getParameter()
        {
            return this.parameter;
        }


    }
}
