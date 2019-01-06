using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language__Application
{
    class DrawController
    {
        static Circle circle; //declaration of circle
        static List<Circle> circleObjects; //list to hold circle objects
        static List<int> circleParameterList;

        DrawController()
        {
            circle = new Circle();
            circleObjects = new List<Circle>();
            circleParameterList = new List<int>();
        }


        public static Boolean checkParameterListVacancy(List<int> ParameterList, int parameter, int maxParameterValue, int loopCounter, int initialParameterCountno)
        {
            if ((ParameterList.Count < maxParameterValue) || ParameterList == null)
            {
                MessageBox.Show("parameter empty........ adding");
                ParameterList.Add(parameter); //initially added to parameter list
                return true;
            }
            else
            {
                MessageBox.Show("Parameter passed exceeds its limitation");
                Boolean isChecked = checkParameterListValueWithPrevValue(ParameterList, parameter, loopCounter, initialParameterCountno);
                return isChecked;
            }
        }


        public static Boolean checkParameterListValueWithPrevValue(List<int> ParameterList, int parameter, int loopCounter, int initialParameterCountno)
        {
            if (ParameterList.ElementAt(loopCounter - initialParameterCountno) == parameter) //if previous value of parameter list matched recent value
            {
                MessageBox.Show("same parameter passed");
                foreach (int parameterList in ParameterList)
                {
                    MessageBox.Show("ParameterList 1: " + parameterList);
                }
            }
            else
            {
                int value = ParameterList[ParameterList.FindIndex(ind => ind.Equals(ParameterList.ElementAt(loopCounter - initialParameterCountno)))] = parameter;
                return true;
                //MessageBox.Show("Replace Element be like: " + value.ToString());
            }

            return false;
        }


        public static void drawRectObjects(Boolean drawRect, Rectangle rectangle, int moveX, int moveY, List<int> rectangleParameterList, List<Rectangle> rectangleObjects)
        {
            drawRect = true; //draw rectangle
            MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
            rectangle = new Rectangle(moveX, moveY);
            //rectangle = new Rectangle();  //creates new rectangle
            rectangle.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
            rectangle.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height
            rectangleObjects.Add(rectangle);
        }

        public static void drawRectObjects(Boolean drawRect, Rectangle rectangle, List<int> rectangleParameterList, List<Rectangle> rectangleObjects)
        {
            drawRect = true; //draw rectangle
            MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
            rectangle = new Rectangle();
            //rectangle = new Rectangle();  //creates new rectangle
            rectangle.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
            rectangle.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height
            rectangleObjects.Add(rectangle);
        }
    }
}
