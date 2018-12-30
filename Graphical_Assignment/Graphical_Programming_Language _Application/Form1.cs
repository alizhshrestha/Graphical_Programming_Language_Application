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
        //Declaration
        Shape shape1, shape2;
        Boolean drawCircle, drawRect, movePointer;
        String program;
        String[] words;
        List<int> circleParameterList, rectangleParameterList;
        int moveX, moveY;


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
                string[] parts = program.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                //loop through the whole program code line
                for (int i = 0; i < parts.Length; i++)
                {
                    //single code line
                    String code_line = parts[i];

                    //words of the code line
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

                    if (words[0] == "draw")
                    {
                        if (words[1] == "circle")
                        {

                            //List to hold parameter info
                            circleParameterList = new List<int>();



                            //for storing parameters value in int array
                            for (int j = 3; j < words.Length; j++)
                            {
                                int parameter = Convert.ToInt32(words[j]);

                                //MessageBox.Show("Parameter " + j.ToString() + parameter.ToString());
                                if (circleParameterList.Count == 0)
                                {
                                    MessageBox.Show("circle parameter empty........ adding");
                                    circleParameterList.Add(parameter);

                                }
                                else
                                {
                                    MessageBox.Show("circle parameter clearing");
                                    circleParameterList.Clear();
                                }
                                
                                
                            }

                            

                            if (words.Length>4)
                            {
                                MessageBox.Show("can't draw");
                            }
                            else
                            {
                                drawCircle = true;
                                MessageBox.Show("Draw Circle: " + Convert.ToString(drawCircle));
                                panel1.Refresh();
                                //rectangleParameterList.Clear();

                                //circleParameterList.Clear();
                            }




                        }

                        if (words[1] == "rectangle")
                        {
                            
                            //List to hold parameter info
                            rectangleParameterList = new List<int>();
                           


                            //for storing parameters value in int array
                            for (int j = 3; j < words.Length; j++)
                            {
                                int parameter = Convert.ToInt32(words[j]);

                                //MessageBox.Show("Parameter " + j.ToString() + parameter.ToString());
                                

                                MessageBox.Show("rectangle parameter empty........ adding");
                                 rectangleParameterList.Add(parameter);
                                MessageBox.Show("Rectangle parameter list be like: " + rectangleParameterList.ElementAt(j-3));

                            }


                            if (words.Length > 5)
                            {
                                MessageBox.Show("can't draw");
                            }
                            else
                            {
                                drawRect = true;
                                MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
                                panel1.Refresh();

                                //rectangleParameterList.Clear();
                            }
                        }
                        
                        
                    }

                    if (words[0]=="move")
                    {

                        moveX = Convert.ToInt32(words[1]);
                        moveY = Convert.ToInt32(words[2]);

                        if (words.Length>3)
                        {
                            MessageBox.Show("Please enter correrct parameters");
                        }
                        else
                        {
                            movePointer = true;
                            panel1.Refresh();
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
            
            Graphics g = e.Graphics;
            //MessageBox.Show("Painting...");
            if (drawCircle==true)
            {
                Circle c = new Circle();
                //c.setRadius(parameterList[0]);
                c.setRadius(Convert.ToInt32(circleParameterList[0]));
                /*
                 * parameterList.Clear();

                foreach (int parameterLists in parameterList)
                {
                    MessageBox.Show("Parameter list be like: " + parameterLists.ToString());
                }
                */

                c.setX(200);
                c.setY(200);
                //MessageBox.Show("Radius is: " + parameterList[0].ToString());
                c.draw(g);
            }

            if (drawRect == true)
            {
                Rectangle rect = new Rectangle();
                rect.setX(100);
                rect.setY(100);
                //rect.setWidth(parameterList[0]);
                //rect.setHeight(parameterList[1]);
                //MessageBox.Show("Rectangle param1: " + words[3]+ "Rectangle param2: " + words[4]);
                rect.setWidth(Convert.ToInt32(rectangleParameterList[0]));
                rect.setHeight(Convert.ToInt32(rectangleParameterList[1]));

                /*
                 * parameterList.Clear();

                foreach (int parameterLists in parameterList)
                {
                    MessageBox.Show("Parameter list be like: " + parameterLists.ToString());
                }
                */

                //MessageBox.Show("Width is: " + parameterList[0].ToString());
                //MessageBox.Show("Height is: " + parameterList[0].ToString());
                rect.draw(g);
            }
            if (movePointer==true)
            {
                Point point = new Point(moveX,moveY);
                pictureBox1.Location = point;
            }
            
        }
    }
}
