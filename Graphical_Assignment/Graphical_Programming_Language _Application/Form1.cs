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
        List<Circle> circleObjects; //list to hold circle objects
        List<Rectangle> rectangleObjects; //list to hold rectangle objects
        List<Line> lineObjects;
        Circle circle; //declaration of circle
        Rectangle rectangle; //declaration of rectangle
        Line line;
        Boolean drawCircle, drawRect, movePointer; //boolean to check whether to make objects or not
        String program; //string to hold textarea info
        String[] words; //words of the individual program line
        List<int> circleParameterList, rectangleParameterList, moveParameterList, drawToParameterList; //Parameter list of objects
        int moveX, moveY; //cursor moving direction points
        private bool drawToLine;

        Point point; //defines points in panel


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
            circle = new Circle(); //creates new circle
            rectangle = new Rectangle(); //creates new rectangle
            line = new Line();
            circleObjects = new List<Circle>(); //creates array of new circle objects
            rectangleObjects = new List<Rectangle>(); //creates array of new rectangle objects
            lineObjects = new List<Line>();
            
            
            //List to hold parameter info
            circleParameterList = new List<int>();
            rectangleParameterList = new List<int>();
            moveParameterList = new List<int>();
            drawToParameterList = new List<int>();
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
                            if (!(words.Length == 4)) //extending parameter values
                            {
                                MessageBox.Show("can't draw");
                            }
                            else
                            {
                                //for storing parameters value in int array
                                for (int j = 3; j < words.Length; j++)
                                {
                                    int parameter = Convert.ToInt32(words[j]); // parameter converted to int value
                                    Boolean doDraw;
                                    doDraw = DrawController.checkParameterListVacancy(circleParameterList, parameter, 1, j, 3, movePointer);
                                    MessageBox.Show(doDraw.ToString());
                                    if (movePointer == true)
                                    {
                                        if (doDraw == true && circleParameterList.Count == 1)
                                        {
                                            drawCircle = true; //draw circle
                                            circle = new Circle(moveX, moveY);
                                            circle.setRadius(Convert.ToInt32(circleParameterList[0])); //sets radius of the circle
                                            circleObjects.Add(circle);
                                        }
                                    }
                                    else
                                    {
                                        if (doDraw == true && circleParameterList.Count == 1)
                                        {
                                            drawCircle = true; //draw circle
                                            circle = new Circle();
                                            circle.setRadius(Convert.ToInt32(circleParameterList[0])); //sets radius of the circle
                                            circleObjects.Add(circle);
                                        }
                                    }
                                }
                            }
                        }


                        if (words[1] == "rectangle") // condition to check if "circle" then
                        {
                            if (!(words.Length == 5)) //extending parameter values
                            {
                                MessageBox.Show("can't draw");
                            }
                            else
                            {
                                //for storing parameters value in int array
                                for (int j = 3; j < words.Length; j++)
                                {
                                    int parameter = Convert.ToInt32(words[j]); // parameter converted to int value
                                    Boolean doDraw;
                                    doDraw = DrawController.checkParameterListVacancy(rectangleParameterList, parameter, 2, j, 3, movePointer);
                                    MessageBox.Show(doDraw.ToString());

                                    if (movePointer == true)
                                    {
                                        if (doDraw == true && rectangleParameterList.Count == 2)
                                        {
                                            drawRect = true; //draw circle
                                            rectangle = new Rectangle(moveX, moveY);
                                            //rectangle = new Rectangle();  //creates new rectangle
                                            rectangle.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
                                            rectangle.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height
                                            rectangleObjects.Add(rectangle);
                                        }
                                    }
                                    else
                                    {
                                        if (doDraw == true && rectangleParameterList.Count == 2)
                                        {
                                            drawRect = true; //draw circle
                                            rectangle = new Rectangle();
                                            //rectangle = new Rectangle();  //creates new rectangle
                                            rectangle.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
                                            rectangle.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height
                                            rectangleObjects.Add(rectangle);
                                        }


                                    }
                                }
                            }
                        }
                    }

                    if (words[0] == "move") // condition to check if "circle" then
                    {
                        moveX = Convert.ToInt32(words[1]); //move in x direction
                        moveY = Convert.ToInt32(words[2]); //move in y direction

                        if (!(words.Length == 3)) //extending parameter values
                        {
                            MessageBox.Show("can't draw");
                        }
                        else
                        {
                            //for storing parameters value in int array
                            for (int j = 1; j < words.Length; j++)
                            {
                                int parameter = Convert.ToInt32(words[j]); // parameter converted to int value
                                Boolean doDraw;
                                doDraw = DrawController.checkParameterListVacancy(moveParameterList, parameter, 2, j, 1, movePointer);
                                if (doDraw == true && moveParameterList.Count == 2)
                                {
                                    if (pictureBox1.Location.X == moveParameterList[0] && pictureBox1.Location.Y == moveParameterList[1])
                                    {
                                        movePointer = false; //move pointer
                                        MessageBox.Show(movePointer.ToString());
                                    }
                                    else
                                    {
                                        movePointer = true; //move pointer
                                        MessageBox.Show(movePointer.ToString());
                                        //drawToLine = false;
                                    }

                                    //line = new Line(moveX, moveY);
                                    ////rectangle = new Rectangle();  //creates new rectangle
                                    //lineObjects.Add(line);
                                }
                            }
                        }
                    }
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("!!Please input correct code or syntax!!");
            }
            //catch (FormatException ex)
            //{
            //    MessageBox.Show("!!Please input correct parameter!!");
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    MessageBox.Show("!!Please input correct parameter!!");

            //}

            panel1.Refresh(); //refresh with every drawing equals to true

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

            if (drawCircle == true)//draw circle condition
            {
                foreach (Circle circleObject in circleObjects)
                {
                    MessageBox.Show("Drawing Circle");
                    circleObject.draw(g); //draw circle with given graphics
                }
            }

            if (drawRect == true) //draw rectangle condition
            {
                foreach (Rectangle rectangleObject in rectangleObjects)
                {
                    MessageBox.Show("Drawing Rectangle");
                    rectangleObject.draw(g); //draw circle with given graphics
                }

                //rectangle.draw(g); //draw circle with given graphics
            }

            if (movePointer == true) //condition to move pointer
            {
                MessageBox.Show("moving");
                point = new Point();
                point.X = moveParameterList[0];
                point.Y = moveParameterList[1];
                pictureBox1.Location = point;
            }
        }
    }
}
