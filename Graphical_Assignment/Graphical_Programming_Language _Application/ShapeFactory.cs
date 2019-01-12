using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{

    /// <summary>
    /// Factory class to get required shape
    /// </summary>
    public class ShapeFactory : AbstractFactory
    {
        /// <summary>
        /// Method to get required shape
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public override Shape getShape(String shapeType)
        {
            if (shapeType== null)
            {
                return null;
            }

            if (shapeType.Equals("Circle"))
            {
                return new Circle(0,0,100);

            } else if (shapeType.Equals("Rectangle"))
            {
                return new Rectangle(0,0, 50,50);
            }
            return null;
        }
    }
}
