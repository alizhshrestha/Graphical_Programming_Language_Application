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
        Boolean drawCircle, drawRect, movePointer; //boolean to check whether to make objects or not
        String program; //string to hold textarea info
        String[] words; //words of the individual program line
        List<int> circleParameterList, rectangleParameterList; //Parameter list of objects
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
            //List to hold parameter info
            circleParameterList = new List<int>();
            rectangleParameterList = new List<int>();
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


                    //MessageBox.Show("Whole words length: " + Convert.ToString(parts.Length));


                    //MessageBox.Show("code lengths: " + Convert.ToString(words.Length));

                    //Code attribute class initialization to hold code line information
                    /*
                    Code_Attributes code_attributes = new Code_Attributes();
                    code_attributes.setCommand(words[0]);
                    code_attributes.setObj(words[1]);
                    code_attributes.setVariableName(words[2]);
                    */

                    /*
                    for (int z = 0; z < parameterList.Count; z++)
                    {
                        MessageBox.Show("Count No: " + z);
                    }




                    foreach (int parameterLists in parameterList)
                    {
                        MessageBox.Show("Parameter no: " + parameterLists.ToString());
                    }
                    */
                    



                    //MessageBox.Show("command: " + code_attributes.getCommand() + "\r\n" + "object: " + code_attributes.getObj() + "\r\n" + "variable_name: " + code_attributes.getVariableName() + "\r\n" + "parameter: " + " "
                    //    );

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

                                    //MessageBox.Show("Parameter " + j.ToString() + parameter.ToString());

                                    if ((circleParameterList.Count < 2) || circleParameterList == null)
                                    {
                                        MessageBox.Show("rectangle parameter empty........ adding");
                                        circleParameterList.Add(parameter); //initially added to parameter list
                                    }
                                    else
                                    {
                                        MessageBox.Show("Parameter passed exceeds its limitation");
                                    }


                                    if (circleParameterList.ElementAt(j - 3) == parameter)
                                    {
                                        MessageBox.Show("Parameter no: " + "  " + "same parameter passed");
                                    }
                                    else
                                    {
                                        //cleared parameter list to renew value
                                        /*
                                        circleParameterList.RemoveAt(j - 3);

                                        foreach (int parameterLists in circleParameterList)
                                        {
                                            MessageBox.Show("Parameter no: " + (j-3)+"  " + parameterLists.ToString());
                                        }

                                        MessageBox.Show("replacing circle parameter");
                                        circleParameterList.Add(parameter); //parameter added to circleParameterList
                                        */

                                        int value = circleParameterList[circleParameterList.FindIndex(ind => ind.Equals(circleParameterList.ElementAt(j - 3)))] = parameter;

                                        MessageBox.Show("Replace Element be like: " + value.ToString());
                                    }
                                }

                                drawCircle = true; //draw circle
                                MessageBox.Show("Draw Circle: " + Convert.ToString(drawCircle));
                                panel1.Refresh(); //refresh with every drawing equals to true
                                //rectangleParameterList.Clear();

                                //circleParameterList.Clear();
                            }




                        }

                        if (words[1] == "rectangle") //if words is to draw rectangle
                        {

                            if (words.Length > 5) //checks if parameter value exceeds required parameter values
                            {
                                MessageBox.Show("can't draw");
                            }
                            else
                            {
                                //List to hold parameter info


                                //for storing parameters value in int array
                                for (int j = 3; j < words.Length; j++)
                                {
                                    int parameter = Convert.ToInt32(words[j]); //parameter converted to int value

                                    MessageBox.Show("Parameter " + j.ToString() + parameter.ToString());

                                    if ((rectangleParameterList.Count<2) || rectangleParameterList==null)
                                    {
                                        MessageBox.Show("rectangle parameter empty........ adding");
                                        rectangleParameterList.Add(parameter); //initially added to parameter list
                                    }
                                    else
                                    {
                                        MessageBox.Show("Parameter passed exceeds its limitation");
                                    }
                                    

                                    MessageBox.Show("rectangle list count be like "+ rectangleParameterList.Count);


                                    if (rectangleParameterList.ElementAt(j - 3) == parameter) //if previous value of parameter list matched recent value
                                    {
                                        MessageBox.Show("same parameter passed");
                                    }
                                    else
                                    {
                                        int value = rectangleParameterList[rectangleParameterList.FindIndex(ind => ind.Equals(rectangleParameterList.ElementAt(j - 3)))] = parameter;

                                        MessageBox.Show("Replace Element be like: " + value.ToString());
                                    }


                                    //MessageBox.Show("Rectangle parameter list be like: " + (j-3) + rectangleParameterList.ElementAt(j-3));

                                }


                                drawRect = true; //draw rectangle
                                MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
                                panel1.Refresh(); //refresh panel1
                                //rectangleParameterList.Clear();
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
                            MessageBox.Show("Moving...");
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

            //MessageBox.Show("Painting...");


            if (drawCircle==true)//draw circle condition
            {
                Circle c = new Circle(); //creates new circle
                //c.setRadius(parameterList[0]);

                c.setRadius(Convert.ToInt32(circleParameterList[0])); //sets radius of the circle
                /*
                 * parameterList.Clear();

                foreach (int parameterLists in parameterList)
                {
                    MessageBox.Show("Parameter list be like: " + parameterLists.ToString());
                }
                */

                c.setX(moveX); //sets x position
                c.setY(moveY); //sets y position
                //MessageBox.Show("Radius is: " + parameterList[0].ToString());

                c.draw(g); //draw circle with given graphics
            }

            if (drawRect == true) //draw rectangle condition
            {
                Rectangle rect = new Rectangle();  //creates new rectangle
                rect.setX(moveX); //sets x position
                rect.setY(moveY); //sets y position
                //rect.setWidth(parameterList[0]);
                //rect.setHeight(parameterList[1]);
                //MessageBox.Show("Rectangle param1: " + words[3]+ "Rectangle param2: " + words[4]);
                rect.setWidth(Convert.ToInt32(rectangleParameterList[0])); //sets width
                rect.setHeight(Convert.ToInt32(rectangleParameterList[1])); //sets height

                /*
                 * parameterList.Clear();

                foreach (int parameterLists in parameterList)
                {
                    MessageBox.Show("Parameter list be like: " + parameterLists.ToString());
                }
                */

                //MessageBox.Show("Width is: " + parameterList[0].ToString());
                //MessageBox.Show("Height is: " + parameterList[0].ToString());
                rect.draw(g); //draw circle with given graphics
            }

            if (movePointer==true) //condition to move pointer
            {
                Point point = new Point(moveX,moveY); //creates new point direction
                pictureBox1.Location = point; //draws cursor to given point in panel
            }
            
        }
    }
}
