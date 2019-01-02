using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Programming_Language__Application
{
    public partial class Form1 : Form
    {
        Shape shape1, shape2; //declaration of shapeFactory
        List<Circle> circleObjects;
        List<Rectangle> rectangleObjects;
        Circle circle;
        Rectangle rectangle;
        Boolean drawCircle, drawRect, movePointer; //boolean to check whether to make objects or not
        String program; //string to hold textarea info
        String[] words; //words of the individual program line
        List<int> circleParameterList, rectangleParameterList, moveParameterList; //Parameter list of objects
        int moveX, moveY; //cursor moving direction points


        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //Shape creation and initialization
            AbstractFactory shapeFactory = FactoryProducer.getFactory("Shape");
            shape1 = shapeFactory.getShape("Circle");
            shape2 = shapeFactory.getShape("Rectangle");
        }

        /// <summary>
        /// Form load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            circle = new Circle();
            rectangle = new Rectangle();
            circleObjects = new List<Circle>();
            rectangleObjects = new List<Rectangle>();
            //List to hold parameter info
            circleParameterList = new List<int>();
            rectangleParameterList = new List<int>();
            moveParameterList = new List<int>();
        }

        /// <summary>
        /// button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_split_Click(object sender, EventArgs e)
        {

            try
            {

                //whole written program
                program = rtxt_code.Text;


                // ... Parts are separated by Windows line breaks.

                // Use a char array of 2 characters (\r and \n).
                // ... Break lines into separate strings.
                // ... Use RemoveEntryEntries so empty strings are not added.
                char[] delimiters = new char[] { '\r', '\n' };
                string[] parts = program.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); //holds invididuals code line

                //loop through the whole program code line
                for (int i = 0; i < parts.Length; i++)
                {
                    //single code line
                    String code_line = parts[i];

                    //individual words of the code line
                    words = code_line.Split(' ');


                    //condition to check if "draw" then
                    if (words[0] == "draw")
                    {
                        if (words[1] == "circle") // condition to check if "circle" then
                        {

                            

                            if (words.Length>4) //extending parameter values
                            {
                                MessageBox.Show("can't draw");
                            }
                            else
                            {
                                //for storing parameters value in int array
                                for (int j = 3; j < words.Length; j++)
                                {
                                    int parameter = Convert.ToInt32(words[j]); // parameter converted to int value

                                    if ((circleParameterList.Count < 2) || circleParameterList == null)
                                    {
                                        //MessageBox.Show("rectangle parameter empty........ adding");
                                        circleParameterList.Add(parameter); //initially added to parameter list
                                    }
                                    else
                                    {
                                        MessageBox.Show("Parameter passed exceeds its limitation");
                                    }


                                    if (circleParameterList.ElementAt(j - 3) == parameter)
                                    {
                                        MessageBox.Show("same parameter passed");
                                    }
                                    else
                                    {
                                        int value = circleParameterList[circleParameterList.FindIndex(ind => ind.Equals(circleParameterList.ElementAt(j - 3)))] = parameter;

                                        MessageBox.Show("Replace Element be like: " + value.ToString());
                                    }
                                }
                                MessageBox.Show("MoveX: " + moveX + "MoveY: " + moveY);
                                MessageBox.Show("Before drawing circle draw pointer is: " + movePointer);
                                if (movePointer == true || (moveX==0 && moveY==0))
                                {
                                    MessageBox.Show("Draw Circle: " + Convert.ToString(drawCircle));
                                    drawCircle = true; //draw circle
                                    circle = new Circle(moveX, moveY);
                                    circle.setRadius(Convert.ToInt32(circleParameterList[0])); //sets radius of the circle
                                    circleObjects.Add(circle);
                                }
                                else
                                {
                                    drawCircle = false;
                                    MessageBox.Show("No need to draw new circle!!");
                                }

                                
                                panel1.Refresh(); //refresh with every drawing equals to true
                                //rectangleParameterList.Clear();

                                //circleParameterList.Clear();
                            }

                        }

                        if (words[1] == "rectangle") //if words is to draw rectangle
                        {

                            if (words.Length > 5 || words.Length <5) //checks if parameter value exceeds required parameter values
                            {
                                MessageBox.Show("can't draw");
                            }
                            else
                            {
                                
                                //for storing parameters value in int array
                                for (int j = 3; j < words.Length; j++)
                                {
                                    int parameter = Convert.ToInt32(words[j]); //parameter converted to int value

                                    //MessageBox.Show("Parameter " + j.ToString() + parameter.ToString());

                                    if ((rectangleParameterList.Count<2) || rectangleParameterList==null)
                                    {
                                        //MessageBox.Show("rectangle parameter empty........ adding");
                                        rectangleParameterList.Add(parameter); //initially added to parameter list
                                    }
                                    else
                                    {
                                        MessageBox.Show("Parameter passed exceeds its limitation");
                                    }
                                    

                                    //MessageBox.Show("rectangle list count be like "+ rectangleParameterList.Count);


                                    if (rectangleParameterList.ElementAt(j - 3) == parameter) //if previous value of parameter list matched recent value
                                    {
                                        MessageBox.Show("same parameter passed");
                                    }
                                    else
                                    {
                                        int value = rectangleParameterList[rectangleParameterList.FindIndex(ind => ind.Equals(rectangleParameterList.ElementAt(j - 3)))] = parameter;

                                        //MessageBox.Show("Replace Element be like: " + value.ToString());
                                    }

                                }

                                
                                if (movePointer == true)
                                {
                                    drawRect = true; //draw rectangle
                                    MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
                                    rectangle = new Rectangle(moveX, moveY);
                                    //rectangle = new Rectangle();  //creates new rectangle
                                    rectangle.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
                                    rectangle.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height
                                    rectangleObjects.Add(rectangle);
                                }
                                else if ((moveX == 0 && moveY == 0) && movePointer == false)
                                {
                                    drawRect = true; //draw rectangle
                                    MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
                                    rectangle = new Rectangle();
                                    //rectangle = new Rectangle();  //creates new rectangle
                                    rectangle.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
                                    rectangle.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height
                                    rectangleObjects.Add(rectangle);
                                }
                                else
                                {
                                    drawRect = false;
                                    MessageBox.Show("No need to draw new rectangle!!");
                                }

                                panel1.Refresh(); //refresh panel1
                            }
                        }
                        
                        
                    }

                    if (words[0]=="move") //condition if to move cursor
                    {

                        moveX = Convert.ToInt32(words[1]); //move in x direction
                        moveY = Convert.ToInt32(words[2]); //move in y direction


                        if (words.Length>3) //if parameter exceeds required parameter values
                        {
                            MessageBox.Show("Please enter correrct parameters");
                        }
                        else
                        {
                            //for storing parameters value in int array
                            for (int j = 1; j < words.Length; j++)
                            {
                                int parameter = Convert.ToInt32(words[j]); //parameter converted to int value


                                if ((moveParameterList.Count < 2) || moveParameterList == null)
                                {
                                    moveParameterList.Add(parameter); //initially added to parameter list
                                }
                                else
                                {
                                    MessageBox.Show("Parameter passed exceeds its limitation");
                                }

                                if (moveParameterList.ElementAt(j - 1) == parameter) //if previous value of parameter list matched recent value
                                {
                                    movePointer = false;
                                    MessageBox.Show("same parameter passed index: " + (j - 1));
                                    MessageBox.Show("draw pointer: " + movePointer);
                                }
                                else
                                {
                                    movePointer = true;
                                    MessageBox.Show("same parameter passed index: " + (j - 1));
                                    MessageBox.Show("draw pointer: " + movePointer);
                                    int value = moveParameterList[moveParameterList.FindIndex(ind => ind.Equals(moveParameterList.ElementAt(j - 1)))] = parameter;

                                    //MessageBox.Show("Replace Element be like: " + value.ToString());
                                }

                            }


                            //MessageBox.Show("Moving...");
                            movePointer = true; //move pointer
                            panel1.Refresh(); //refresh panel
                        }
                        
                    }

                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("!!Please input correct code or syntax!!");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("!!Please input correct parameter!!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("!!Please input correct parameter!!");

            }

        }

        /// <summary>
        /// Panel paint method to paint to the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics to draw in panel
            Graphics g = e.Graphics;


            if (drawCircle==true)//draw circle condition
            {
                foreach (Circle circleObject in circleObjects)
                {
                    circleObject.draw(g); //draw circle with given graphics
                }

                //circle.setX(circle.getX()); //sets x position
                //circle.setY(circle.getY()); //sets y position



                //shapeObjects.draw(g); //draw circle with given graphics
            }

            if (drawRect == true) //draw rectangle condition
            {
                foreach (Rectangle rectangleObject in rectangleObjects)
                {
                    rectangleObject.draw(g); //draw circle with given graphics
                }

                rectangle.draw(g); //draw circle with given graphics
            }

            if (movePointer==true) //condition to move pointer
            {
                

                Point point = new Point(moveX,moveY); //creates new point direction
                pictureBox1.Location = point; //draws cursor to given point in panel
                //circle.setX(point.X);
                //MessageBox.Show(circle.getX().ToString());
                //circle.setY(point.Y);
                //-MessageBox.Show(circle.getY().ToString());
                //rectangle.setX(point.X);
                //MessageBox.Show(rectangle.getX().ToString());
                //rectangle.setY(point.Y);
                //MessageBox.Show(rectangle.getY().ToString());
            }
            
        }
    }
}
