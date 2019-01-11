using System;
using Graphical_Programming_Language__Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ShapeTypeTest
    {
        [TestMethod]
        public void isCircle_stringCircle_returnTrue()
        {
            //arrange
            bool result;
            ShapeFactoryDefination sd = new ShapeFactoryDefination();

            //act
            result = sd.isCircle("circle");

            //assert
            Assert.IsTrue(result);
        }

        public void isRectangle_stringRectangle_returnTrue()
        {
            //arrange
            bool result;
            ShapeFactoryDefination sd = new ShapeFactoryDefination();

            //act
            result = sd.isCircle("rectangle");

            //assert
            Assert.IsTrue(result);
        }
    }
}
