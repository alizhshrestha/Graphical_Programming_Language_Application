using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language__Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application.Tests
{
    [TestClass()]
    public class VariableDefinationTest
    {
        [TestMethod()]
        
        public void checkVariableCharacters_ifAlphabets_returnTrue()
        {
            //arrange
            VariableDefination variableDefination = new VariableDefination();
            String word;
            bool result;

            //act
            word =  "Shape";
            result = variableDefination.isAlphabeticalVariable(word);
            

            //assert
            Assert.IsTrue(result);

        }
    }


}



