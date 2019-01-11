using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{
    public class VariableDefination
    {
        public bool isAlphabeticalVariable(String word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }

    }
}
