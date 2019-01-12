using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        //list to hold individuals objects
        List<Circle> circleObjects;
        List<Rectangle> rectangleObjects;
        List<Variables> variableObjects;
        List<MoveDirection> moveObjects;

        Circle circle; //declaration of circle
        Rectangle rectangle; //declaration of rectangle
        Boolean drawCircle, drawRect, movePointer; //boolean to check whether to make objects or not
        String program; //string to hold textarea info
        String[] words; //words of the individual program 
        int moveX, moveY; //cursor moving direction points
        int counter; // counter to loop code
        int loopCounter; //loopcounter to hold loop value in loop code

        Color c;

        Variables v;

        string console_text;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        Point point; //defines points in panel


        /// <summary>
        /// load button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //opens diaglog box when button click
            if (openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                lbl_path.Text = openFileDialog1.FileName;
                rtxt_code.Text = File.ReadAllText(lbl_path.Text);
            }

        }


        /// <summary>
        /// save button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, rtxt_code.Text);

            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            circleObjects.Clear();
            rectangleObjects.Clear();
            moveObjects.Clear();
            variableObjects.Clear();
            this.drawCircle = false;
            this.drawRect = false;
            this.movePointer = false;
            this.rtxt_code.Clear();
            panel1.Refresh();
            //form1.Load;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



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
            circleObjects = new List<Circle>(); //creates array of new circle objects
            rectangleObjects = new List<Rectangle>(); //creates array of new rectangle objects
            variableObjects = new List<Variables>(); //creates array of new variable objects
            moveObjects = new List<MoveDirection>(); //creates array of new move objects

            c = Color.DarkGreen;

            txt_hint.ForeColor = Color.Blue;
            txt_hint.ReadOnly = true;
            txt_hint.Text = "Hints:\n \n" +
                            "For drawing without parameter: \n draw circle 100 \n draw rectangle 100 100 \n \n" +
                            "For drawing with parameter: \n r = 100 \n draw circle r \n h = 100 \n w = 100 \n draw rectangle h w \n \n" +
                            "For moving cursor: \n move 100 100 \n \n" +
                            "For choosing color: \n color = red \n \n" +
                            "For declaring variable: \n counter = 100 \n \n" +
                            "For looping: \n r = 100 \n loop 4 \n r + 100 \n draw circle r \n end loop \n \n " +
                            "For if statement: \n counter = 5 \n if counter = 5 then \n draw circle 100 \n end if \n \n";

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
                console_text = "Program code: \n";
                foreach (string part in parts)
                {
                    console_text += part + "\n";
                }
                console_text += "\n\n";
                

                //loop through the whole program code line
                for (int i = 0; i < parts.Length; i++)
                {

                    //single code line
                    String code_line = parts[i];

                    char[] code_delimiters = new char[] { ' '};
                    words = code_line.Split(code_delimiters, StringSplitOptions.RemoveEmptyEntries); //holds invididuals code line

                    //calculation to add value to variable
                    if (Regex.IsMatch(words[0], @"^[a-zA-Z]+$") && words[1] == "+")
                    {

                        //sets new incremented value to the defined variable and puts it in vaiableObjects class
                        variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].setValue(variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].getValue() + Convert.ToInt32(words[2]));
                        //MessageBox.Show(variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].getValue().ToString());
                        console_text += "Adding:  \n" + words[0] + " + " + words[2] + " = " + variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].getValue().ToString() + "\n\n";
                        
                    }


                    //assigns value to defined variables
                    if ((Regex.IsMatch(words[0], @"^[a-zA-Z]+$") && words[1]== "="))
                    {
                        //add new variableObjects if variableObject is empty
                        if (variableObjects == null || variableObjects.Count == 0)
                        {
                            v = new Variables();
                            v.setVariable(words[0]);
                            v.setValue(Convert.ToInt32(words[2]));
                            console_text += "Adding variable: \n" + v.getVariable() + " = "  + v.getValue().ToString() + "\n\n";
                            variableObjects.Add(v);
                        }
                        else
                        {
                            //checks if variable and it's value exists in variableObjects or not 
                            if (variableObjects.Exists(x => x.variable == words[0] && x.value == Convert.ToInt32(words[2])) ==true)
                            {
                                console_text +=  "variable exists: \n" + words[0] + " = " +variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].getValue().ToString() + "\n\n";

                            }//else checks if variable exists or not
                            else if (!variableObjects.Exists(x => x.variable == words[0]))
                            {
                                v = new Variables();
                                v.setVariable(words[0]);
                                v.setValue(Convert.ToInt32(words[2]));
                                console_text += "Adding variable: \n" + v.getVariable() + " = " + v.getValue().ToString() + "\n\n";
                                variableObjects.Add(v);
                            }
                            //else add new variable value to variableObjects
                            else
                            {
                                v = new Variables();
                                v.setVariable(words[0]);
                                v.setValue(Convert.ToInt32(words[2]));
                                variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))] = v;
                                console_text += "Replacing variable value: \n" + words[0] + " = " + variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].getValue().ToString() + "\n\n";

                            }
                        }
                    }

                    //shows variableObjects lists
                    if (words[0]=="show")
                    {
                        foreach (Variables v in variableObjects)
                        {
                            MessageBox.Show("Full variable: " + v.getVariable());
                            MessageBox.Show("Full value: " + Convert.ToString(v.getValue()));
                        }
                    }
                    
                    //condition to check if "draw" then
                    if (words[0] == "draw")
                    {
                        counter += 1;//value to increment draw circle method

                        if (words[1] == "circle") // condition to check if "circle" then
                        {
                            if (!(words.Length == 3)) //checks if written code is correct or not
                            {
                                MessageBox.Show("!!Please enter correct command!!");
                                console_text += "Correct code be like: \n e.g. draw circle 100 or draw circle r \n\n";
                            }
                            else
                            {
                                if (variableObjects.Exists(x => x.variable == words[2]) == true) //assigns variable value to draw code parameter value
                                {
                                    words[2] = Convert.ToString(variableObjects.ElementAt(variableObjects.FindIndex(x => x.variable.Contains(words[2]))).getValue()); //variable value to radius parameter
                                }
                                if (circleObjects.Exists(x => x.getX() == moveX && x.getY() == moveY && x.getRadius() == Convert.ToInt32(words[2])) == true) //checks if circle with x,y,radius parameter exists or not
                                {
                                    console_text += "!!circle object exists with given parameters!!\n\n";

                                }
                                else
                                {//if not exists then creates new circle and add to circleObjects and draws circle
                                    Circle circle = new Circle();
                                    circle.setX(moveX);
                                    circle.setY(moveY);
                                    circle.setRadius(Convert.ToInt32(words[2]));
                                    circleObjects.Add(circle);
                                    drawCircle = true;
                                    console_text += "Adding new circle\n\n";
                                }
                            }
                        }



                        if (words[1] == "rectangle") // condition to check if "rectangle" then
                        {
                            MessageBox.Show(moveX.ToString());
                            if (!(words.Length == 4)) //extending parameter values
                            {
                                MessageBox.Show("!!Please enter correct command!!");
                                console_text += "Correct code be like: \n e.g. draw rectangle 100 100 or draw circle h w \n\n";
                            }
                            else
                            {

                                //assigns variable value to draw code parameter value
                                if (variableObjects.Exists(x => x.variable == words[2] == true))
                                {
                                    words[2] = Convert.ToString(variableObjects.ElementAt(variableObjects.FindIndex(x => x.variable.Contains(words[2]))).getValue()); //variable value to height parameter
                                }
                                if (variableObjects.Exists(x => x.variable == words[3]) == true)
                                {
                                    words[3] = Convert.ToString(variableObjects.ElementAt(variableObjects.FindIndex(x => x.variable.Contains(words[3]))).getValue()); //variable value to width parameter
                                }


                                if (rectangleObjects.Exists(x => x.getX() == moveX && x.getY() == moveY && x.getHeight() == Convert.ToInt32(words[2]) && x.getWidth() == Convert.ToInt32(words[3])) == true)//checks if rectangle with x,y,height,width parameter exists or not
                                {
                                    console_text += "!!rectangle object exists with given parameters!!\n\n";
                                }
                                else
                                {//if not exists then creates new rectangle and add to rectangleObjects and draws rectangle
                                    Rectangle rect = new Rectangle();
                                    rect.setX(moveX);
                                    rect.setY(moveY);
                                    rect.setHeight(Convert.ToInt32(words[2]));
                                    rect.setWidth(Convert.ToInt32(words[3]));
                                    rectangleObjects.Add(rect);
                                    drawRect = true;
                                    console_text += "Adding new rectangle\n\n";
                                }
                            }
                        }
                    }

                    if (words[0] == "move") // condition to check if "move" then
                    {

                        if (Convert.ToInt32(words[1])==pictureBox1.Location.X && Convert.ToInt32(words[2])==pictureBox1.Location.Y)//checks if cursor is in different position
                        {
                            //MessageBox.Show("don't move");
                            console_text += "Its in requested position\n\n";
                        }
                        else
                        {
                            moveX = Convert.ToInt32(words[1]);
                            moveY = Convert.ToInt32(words[2]);
                            movePointer = true;
                            console_text += "X="+ moveX+ "\n" + "Y=" + moveY +"\n\n";
                        }
                    }

                    if (words[0]=="color")
                    {
                        if (words[1]=="red")
                        {
                            c = Color.Red;
                            console_text += "Pen is of red color\n\n";
                        }
                        else if (words[1]=="blue")
                        {
                            c = Color.Blue;
                            console_text += "Pen is of blue color\n\n";
                        }
                        else if (words[1]=="yellow")
                        {
                            c = Color.Yellow;
                            console_text += "Pen is of yellow color\n\n";
                        }
                        else
                        {
                            c = Color.Green;
                            console_text += "Pen is of green color\n\n";
                        }
                    }


                    if (words[0] == "if") //code for if statement
                    {
                        string variable_name = words[1];
                        int value = Convert.ToInt32(words[3]);
                        if (variableObjects.Exists(x => x.variable == words[1]) == true && variableObjects.Exists(x => x.value == Convert.ToInt32(words[3])) == true) //checks if condition defined in if condition matches with variable objects list
                        {
                            console_text += "Entered into if statement\n\n";

                        }
                        else
                        {//directed to end if line
                            i = Array.IndexOf(parts, "end if");
                        }
                        
                    }

                    

                    if (words[0]=="loop") //code for loop statement
                    {
                        loopCounter = Convert.ToInt32(words[1]); //defines loop counter variable
                        console_text += "Entered into loop statement\n\n";
                    }

                    

                    if (parts[i]=="end loop") // code for end loop statement
                    {
                        if (counter < loopCounter) //if counter to draw is not less than loop counter
                        {
                            i = Array.IndexOf(parts, "loop " + loopCounter);
                        }
                        else // keep drawing
                        {
                            i = Array.IndexOf(parts, "end loop");
                        }
                    }
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                console_text += "Error: " + ex.Message +"\n\n";
            }
            catch (FormatException ex)
            {
                console_text += "!!Please input correct parameter!!\n\n";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                console_text += "!!Please input correct parameter!!\n\n";

            }
            rtxt_console.Text = console_text;
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
                    console_text += "Drawing Circle\n\n";
                    circleObject.draw(g, c); //draw circle with given graphics
                }
            }

            if (drawRect == true) //draw rectangle condition
            {
                foreach (Rectangle rectangleObject in rectangleObjects)
                {
                    console_text += "Drawing Rectangle\n\n";
                    rectangleObject.draw(g, c); //draw circle with given graphics
                }
            }

            if (movePointer == true) //condition to move pointer
            {
                console_text += "moving\n\n";
                point = new Point();
                point.X = moveX;
                point.Y = moveY;
                pictureBox1.Location = point;
            }
            rtxt_console.Text = console_text;
        }
    }
}
