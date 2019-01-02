using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language__Application
{
    class Rectangle : Shape
    {

        int height, width;
        static int param_no = 2;


        List<int> parameters = new List<int>();

        public void setParameters(List<int> parameters)
        {
            this.parameters = parameters;
        }

        public List<int> getParameters()
        {
            return this.parameters;
        }


        public Rectangle(int x, int y, int height, int width):base(x, y)
        {
            this.height = height;
            this.width = width;
        }

        public Rectangle(int x, int y) : base(x, y)
        {

        }

        public Rectangle()
        { 
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Red);
            g.DrawRectangle(p, x,y, height,width);
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public int getHeight()
        {
            return height;
        }


        public void setWidth(int width)
        {
            this.width = width;
        }

        public int getWidth()
        {
            return width;
        }

    }
}
