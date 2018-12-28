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

        public Circle(int x, int y, int radius):base(x, y)
        {
            this.radius = radius; 

        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Red);
            g.DrawEllipse(p, 50,50, 100, 100);
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
