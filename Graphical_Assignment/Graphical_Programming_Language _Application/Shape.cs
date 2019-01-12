using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language__Application
{
    public abstract class Shape
    {
        //variable declaration and initialization
        protected int x = 0, y = 0;


        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public Shape()
        {
        }


        /// <summary>
        /// X setter
        /// </summary>
        /// <param name="x"></param>
        public void setX(int x)
        {
            this.x = x;
        }


        /// <summary>
        /// X getter
        /// </summary>
        /// <returns></returns>
        public int getX()
        {
            return x;
        }


        /// <summary>
        /// Y setter
        /// </summary>
        /// <param name="y"></param>
        public void setY(int y)
        {
            this.y = y;
        }



        /// <summary>
        /// Y getter
        /// </summary>
        /// <returns></returns>
        public int getY()
        {
            return y;
        }


        /// <summary>
        /// draw method
        /// </summary>
        /// <param name="g"></param>
        public abstract void draw(Graphics g, Color c);
    }
}
