﻿using System;
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
            
            program = rtxt_code.Text;

            //MessageBox.Show(program);

            // ... Parts are separated by Windows line breaks.

            // Use a char array of 2 characters (\r and \n).
            // ... Break lines into separate strings.
            // ... Use RemoveEntryEntries so empty strings are not added.
            char[] delimiters = new char[] { '\r', '\n' };
            string[] parts = program.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            String[] programLine = new string[5];

            Console.WriteLine(":::SPLIT, CHAR ARRAY:::");
            for (int i = 0; i < parts.Length; i++)
            {
                programLine[i] = parts[i];
                String code_line = programLine[i];
                string[] words = code_line.Split(' ');
                //MessageBox.Show(programLine[i]);
                MessageBox.Show("Whole words length: " + Convert.ToString(parts.Length));

                
                for (int j = 0; j < words.Length-3; j++)
                {

                    String command = words[0];
                    String obj = words[1];
                    String variable_name = words[2];
                    String param = words[3];
                    MessageBox.Show("command: " + words[0] + "\r\n" + "object: " + words[1] + "\r\n" + "variable_name: " + words[2] + "\r\n" + "parameter: " + words[3]);
                    if (words[0]=="draw")
                    {
                        if (words[1] == "circle")
                        {
                            drawCircle = true;
                            MessageBox.Show("Draw Circle: " + Convert.ToString(drawCircle));
                        }

                        if (words[1] == "rectangle")
                        {
                            drawRect = true;
                            MessageBox.Show("Draw Rectangle: " + Convert.ToString(drawRect));
                        }
                        panel1.Refresh();
                    }
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MessageBox.Show("Painting...");
            if (drawCircle==true)
            {
                shape1.draw(g);
            }

            if (drawRect == true)
            {
                shape2.draw(g);
            }
            
        }
    }
}
