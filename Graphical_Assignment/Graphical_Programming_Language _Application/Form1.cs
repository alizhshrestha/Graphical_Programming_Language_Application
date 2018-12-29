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

        Shape shape1, shape2;
        Boolean drawCircle, drawRect;
        String program;
        List<int> parameterList;



        public Form1()
        {
            InitializeComponent();
            AbstractFactory shapeFactory = FactoryProducer.getFactory("Shape");
            shape1 = shapeFactory.getShape("Circle");
            shape2 = shapeFactory.getShape("Rectangle");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btn_split_Click(object sender, EventArgs e)
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
                String[] words = code_line.Split(' ');
               

                MessageBox.Show("Whole words length: " + Convert.ToString(parts.Length));


                MessageBox.Show("code lengths: " + Convert.ToString(words.Length));
                Code_Attributes code_attributes = new Code_Attributes();
                code_attributes.setCommand(words[0]);
                code_attributes.setObj(words[1]);
                code_attributes.setVariableName(words[2]);

                parameterList = new List<int>();

                

                //for storing parameters value in int array
                for (int j = 3; j<words.Length;j++)
                {
                    int parameter = Convert.ToInt32(words[j]);

                    MessageBox.Show("Parameter " + j.ToString() + parameter.ToString());

                    parameterList.Add(parameter);
                }

                for (int z = 0; z < parameterList.Count; z++)
                {
                    MessageBox.Show("Count No: " + z);
                }



                foreach (int parameterLists in parameterList)
                {
                    
                    MessageBox.Show("Parameter list be like: " + parameterLists.ToString());
                }



                String param = words[3];
                MessageBox.Show("command: " + code_attributes.getCommand() + "\r\n" + "object: " + code_attributes.getObj() + "\r\n" + "variable_name: " + code_attributes.getVariableName() + "\r\n" + "parameter: " + " "
                    );
                if (words[0]=="draw")
                {
                    if (words[1] == "circle")
                    {

                        code_attributes.setParameter(new int[] { });
                        

                        if (parameterList.Count== 1)
                        {
                            drawCircle = true;
                            MessageBox.Show("Draw Circle: " + Convert.ToString(drawCircle));
                        }
                        else
                        {
                            MessageBox.Show("Parameter passed is incorrect");
                        }


                    }

                    if (words[1] == "rectangle")
                    {

                        if (parameterList.Count == 2)
                        {
                            drawRect = true;
                            MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
                        }
                        else
                        {
                            MessageBox.Show("Parameter passed is incorrect");
                        }
                    }
                    panel1.Refresh();
                }
                
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MessageBox.Show("Painting...");
            if (drawCircle==true)
            {
                Circle c = new Circle();
                c.setRadius(parameterList[0]);
                c.setX(200);
                c.setY(200);
                MessageBox.Show("Radius is: " + parameterList[0].ToString());
                c.draw(g);
            }

            if (drawRect == true)
            {
                Rectangle rect = new Rectangle();
                rect.setX(100);
                rect.setY(100);
                rect.setWidth(parameterList[0]);
                MessageBox.Show("Width is: " + parameterList[0].ToString());
                rect.setHeight(parameterList[1]);
                MessageBox.Show("Height is: " + parameterList[0].ToString());
                rect.draw(g);
            }
            
        }
    }
}
