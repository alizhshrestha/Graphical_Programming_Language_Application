using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language__Application
{
    class Circle : Shape
    {
        
        int radius;

        static int param_no = 1;

        List<int> parameters = new List<int>();

        public void setParameters(List<int> parameters)
        {
            this.parameters = parameters;
        }

        public List<int> getParameters()
        {
            return this.parameters;
        }


        public Circle(int x, int y, int radius):base(x, y)
        {
            this.radius = radius; 

        }

        public Circle()
        {

        }


        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Red);
            g.DrawEllipse(p, x,y, radius, radius);
        }



        public void setRadius(int radius)
        {
            this.radius = radius;
        }


        public int getRadius()
        {
            return this.radius;
        }
    }
}
