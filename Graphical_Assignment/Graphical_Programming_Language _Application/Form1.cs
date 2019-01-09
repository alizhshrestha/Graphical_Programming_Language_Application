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
        List<Variables> variableObjects;
        Circle circle; //declaration of circle
        Rectangle rectangle; //declaration of rectangle
        Line line;
        Boolean drawCircle, drawRect, movePointer; //boolean to check whether to make objects or not
        String program; //string to hold textarea info
        String[] words; //words of the individual program line
        List<int> circleParameterList, rectangleParameterList, moveParameterList, drawToParameterList; //Parameter list of objects
        int moveX, moveY; //cursor moving direction points
        private bool drawToLine;
        int counter;
        int loopCounter;
        float incrementVal;

        Variables v;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        int height, width, radius;

        Point point; //defines points in panel
        bool VariableAdd;



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
            variableObjects = new List<Variables>();
            
            
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

                    char[] code_delimiters = new char[] { ' ', '='};
                    words = code_line.Split(code_delimiters, StringSplitOptions.RemoveEmptyEntries); //holds invididuals code line
                    //MessageBox.Show("words Length:" + words.Count().ToString());
                    //foreach (string word in words)
                    //{
                    //    MessageBox.Show(word);
                    //}

                    if (words[1] == "+")
                    {
                        variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].setValue(variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].getValue() + Convert.ToInt32(words[2]));
                        MessageBox.Show(variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].getValue().ToString());
                    }

                    if ((Regex.IsMatch(words[0], @"^[a-zA-Z]+$") && words.Count()==2 && !words.Contains("end")))
                    {
                        if (variableObjects == null || variableObjects.Count == 0)
                        {
                            v = new Variables();
                            v.setVariable(words[0]);
                            v.setValue(Convert.ToInt32(words[1]));
                            MessageBox.Show("Adding variable: " +v.getVariable());
                            MessageBox.Show("Adding value: " + v.getValue().ToString());
                            variableObjects.Add(v);
                        }
                        else
                        {
                            if (variableObjects.Exists(x => x.variable == words[0])==true)
                            {
                                if (variableObjects.Exists(x => x.value == Convert.ToInt32(words[1])) == true)
                                {
                                    //if (words.Length == 3)
                                    //{
                                    //    incrementVal = Convert.ToInt64(words[2]);
                                    //    v.setVariable(words[0]);
                                    //    v.setValue(Convert.ToInt32(words[1]) + incrementVal);
                                    //    variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))] = v;
                                    //}

                                    //MessageBox.Show("New incremented variable: " + v.getVariable());
                                    //MessageBox.Show("New incremented value: " + v.getValue().ToString());
                                    MessageBox.Show("exists");
                                }
                                else
                                {
                                    v.setVariable(words[0]);
                                    v.setValue(Convert.ToInt32(words[1]));
                                    variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))] = v;
                                    //MessageBox.Show("Variable: " + variableObjects.Find(x => x.variable.Contains(words[0])).ToString());
                                    //MessageBox.Show("Value: " + variableObjects.Find(x => x.variable.Contains(words[1])).ToString());
                                }

                            }
                            else
                            {
                                v = new Variables();
                                v.setVariable(words[0]);
                                v.setValue(Convert.ToInt32(words[1]));
                                //MessageBox.Show("Adding variable: " + v.getVariable());
                                //MessageBox.Show("Adding value: " + v.getValue().ToString());
                                variableObjects.Add(v);        
                            }

                            //foreach (Variables v in variableObjects)
                            //{
                            //    String var_exists = v.getVariable();
                            //    float num_exists = v.getValue();
                            //    variableObjects.Exists(x => x.variable == var_exists);                                           
                            //    //if (words[0] == var_exists && Convert.ToInt32(words[1]) == num_exists)
                            //    //{
                            //    //    MessageBox.Show("Variable exists");
                            //    //    VariableAdd = false;

                            //    //}
                            //    //else if ()
                            //    //{

                            //    //}
                            //    //else
                            //    //{
                            //    //    VariableAdd = true;
                            //    //}
                            //}
                        }

                        //if (VariableAdd == true)
                        //{
                        
                        //}


                    }

                    if (words[0]=="show")
                    {
                        foreach (Variables v in variableObjects)
                        {
                            MessageBox.Show("Full variable: " + v.getVariable());
                            MessageBox.Show("Full value: " + Convert.ToString(v.getValue()));
                        }
                    }


                    //individual words of the code line
                    //words = code_line.Split(' ');
                    
                    //condition to check if "draw" then
                    if (words[0] == "draw")
                    {
                        counter += 1;

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
                                    //if (words[j].Contains("radius"))
                                    //{
                                    //    words[j] = radius.ToString();
                                    //    MessageBox.Show(words[j]);
                                    //}


                                    if (variableObjects.Exists(x => x.variable == words[j]) == true)
                                    {
                                        words[j] = Convert.ToString(variableObjects.ElementAt(variableObjects.FindIndex(x => x.variable.Contains(words[j]))).getValue());
                                    }
                                    


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

                                    if (variableObjects.Exists(x => x.variable == words[j]) == true)
                                    {
                                        words[j] = Convert.ToString(variableObjects.ElementAt(variableObjects.FindIndex(x => x.variable.Contains(words[j]))).getValue());
                                    }

                                    //if (words[j].Contains("height"))
                                    //{
                                    //    words[j] = height.ToString();
                                    //    MessageBox.Show(words[j]);
                                    //}
                                    //else if (words[j].Contains("width"))
                                    //{
                                    //    words[j] = width.ToString();
                                    //    MessageBox.Show(words[j]);
                                    //}
                                    int parameter = Convert.ToInt32(words[j]); // parameter converted to int value
                                    Boolean doDraw;
                                    doDraw = DrawController.checkParameterListVacancy(rectangleParameterList, parameter, 2, j, 3, movePointer);
                                    MessageBox.Show(doDraw.ToString());

                                    if (movePointer == true)
                                    {
                                        if (doDraw == true && j==4)
                                        {
                                            drawRect = true; //draw circle
                                            rectangle = new Rectangle(moveX, moveY);
                                            //rectangle = new Rectangle();  //creates new rectangle
                                            //if (words[j].Contains("height"))
                                            //{
                                            //    rectangle.setHeight(height);
                                            //}else if (words[j].Contains("width"))
                                            //{
                                            //    rectangle.setWidth(width);
                                            //}
                                            //else
                                            //{
                                            rectangle.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
                                            rectangle.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height
                                            //}
                                            rectangleObjects.Add(rectangle);
                                        }
                                    }
                                    else
                                    {
                                        if (doDraw == true && j==4)
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
                                if (doDraw == true && j == 2)
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


                    //if (words[0]=="height")
                    //{
                    //    height = Convert.ToInt32(words[1]);
                    //    //MessageBox.Show(height.ToString());
                    //}

                    //if (words[0]=="width")
                    //{
                    //    width = Convert.ToInt32(words[1]);
                    //    //MessageBox.Show(width.ToString());
                    //}

                    //if (words[0] == "radius")
                    //{
                    //    radius = Convert.ToInt32(words[1]);
                    //    MessageBox.Show("Radius is: "+ radius.ToString());
                    //}

                    

                    if (words[0] == "if")
                    {
                        string variable_name = words[1];
                        int value = Convert.ToInt32(words[2]);
                        MessageBox.Show("if is in " + i.ToString());
                        if (variableObjects.Exists(x => x.variable == words[1]) == true && variableObjects.Exists(x => x.value == Convert.ToInt32(words[2])) == true)
                        {
                            MessageBox.Show("!!Entered into if statement!!");

                        }
                        //if (height == value)
                        //{

                        //    //return;
                        //}
                        else
                        {
                            i = Array.IndexOf(parts, "end if");
                            MessageBox.Show("next step is in " + i.ToString());

                            //for (int j = i; j < parts.Length; j++)
                            //{
                            //    //MessageBox.Show("if is in" + i);
                            //    if (parts.Contains("end if"))
                            //    {

                            //        MessageBox.Show("end if is in: " + i.ToString());
                            //        return;
                            //    }
                            //}
                        }
                        

                        
                        //for (int j = 1; j < words.Count(); j++)
                        //{
                        //    ConditionController condition = new ConditionController();
                        //    condition.setVariable();
                        //}
                        
                    }

                    

                    if (words[0]=="loop")
                    {
                        loopCounter = Convert.ToInt32(words[1]);
                        MessageBox.Show("!!Entered into loop!!");
                    }

                    

                    if (parts[i]=="end loop")
                    {
                        //if (i < Array.IndexOf(parts, "end loop"))
                        //{
                        //    //i = Array.IndexOf(parts, "loop " + loopCounter);
                        //    //MessageBox.Show("looping!!");
                        //    MessageBox.Show("Continue!!");
                        //}
                        //else
                        //{
                            
                            if (counter < loopCounter)
                            {
                                i = Array.IndexOf(parts, "loop " + loopCounter);
                            }
                            else
                            {
                                i = Array.IndexOf(parts, "end loop");
                            }

                        //}
                    }
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                //MessageBox.Show("!!Please input correct code or syntax!!");
                MessageBox.Show("Message: " + ex.Message);
            }
            //catch (FormatException ex)
            //{
            //    MessageBox.Show("!!Please input correct parameter!!");
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    MessageBox.Show("!!Please input correct parameter!!");

            //}
            MessageBox.Show("if condition completed with width " + width);
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
