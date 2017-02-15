using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laskin
{
    public partial class Form1 : Form
    {
        List<Control> buttons = new List<Control>();
 
        double currentInput = 0;
        double savedInput = 0; 
        string type = ""; 

        public Form1()
        {         
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            textBox1.Text = "0";
            buttons = GetButtons(this);

            foreach (var button in buttons)
            {              
                button.Click += new EventHandler(buttonClick);
            }
        }

        /// <summary>
        /// Is called when any button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttonClick(object sender, EventArgs e)
        {
            try
            {
                Button pressedButton = (Button)sender;
            
                if (isNumeric(pressedButton.Text))
                {
                    if (currentInput == 0) { textBox1.Text = ""; };

                    textBox1.Text += pressedButton.Text;
                    currentInput = double.Parse(textBox1.Text);
                }
                else if (pressedButton.Name == "buttonDot")
                {
                    textBox1.Text += ",";                   
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }
      
        // Equals button click.
        private void input_Click(object sender, EventArgs e)
        {
            textBox1.Text = calculateArgumentsBasedOnType(type, savedInput, currentInput).ToString();
        }

        /// <summary>
        /// Returns a double calculated from given type and arguments.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private double calculateArgumentsBasedOnType(string type, double arg1, double arg2)
        {
            double result = 0;

            switch (type)
            {
                case "+":
                    result = (arg1 + arg2);
                    break;
                case "-":
                    result = (arg1 - arg2);
                    break;
                case "/":
                    if (arg2 != 0)
                    {
                        result = (arg1 / arg2);
                    }
                    else
                    {
                        Console.WriteLine("Dividing with zero!");
                    }
                    break;
                case "*":
                    result = (arg1 * arg2);
                    break;
                default:
                    break;
            }

            return result;
        }

        // Divide button click.
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out currentInput)) { return; }

            if (savedInput == 0)
            {
                savedInput = currentInput;
                textBox1.Text = "";
            }
            else
            {
                savedInput = calculateArgumentsBasedOnType(type, savedInput, currentInput);
                currentInput = 0;
                textBox1.Text = savedInput.ToString();
            }
            type = "/";
        }

        // Multiply button click.
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out currentInput)) { return; }

            if (savedInput == 0)
            {
                savedInput = currentInput;
                textBox1.Text = "";
            }
            else
            {
                savedInput = calculateArgumentsBasedOnType(type, savedInput, currentInput);
                currentInput = 0;
                textBox1.Text = savedInput.ToString();
            }
            type = "*";
        }

        // Subtraction button click.
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out currentInput)) { return; }

            if (savedInput == 0)
            {
                savedInput = currentInput;
                textBox1.Text = "";
            }
            else
            {
                savedInput = calculateArgumentsBasedOnType(type, savedInput, currentInput);
                currentInput = 0;
                textBox1.Text = savedInput.ToString();
            }
            type = "-";
        }

        // Sum button click.
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out currentInput)) { return; }

            if (savedInput == 0)
            {
                savedInput = currentInput;
                textBox1.Text = "";
            }
            else
            {
                savedInput = calculateArgumentsBasedOnType(type, savedInput, currentInput);
                currentInput = 0;
                textBox1.Text = savedInput.ToString();
            }
            type = "+";
        }

        // Square root button click.
        private void buttonSquareRt_Click(object sender, EventArgs e)
        {
            double.TryParse(textBox1.Text, out currentInput);
            if (currentInput != 0)
            {
                textBox1.Text = (Math.Sqrt(currentInput)).ToString();
            }
        }

        /// <summary>
        /// Clears saved user inputs and textfields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            currentInput = 0;
            savedInput = 0;
            type = "";
        }
      
        /// <summary>
        /// Gets all Buttons from given Control.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private List<Control> GetButtons(Control control)
        {
            List<Control> tempList = new List<Control>();

            foreach (Control item in control.Controls)
            {
                // Katsotaan onko listan tuote painike
                if (item.GetType() == typeof(Button))
                {
                    // Jos on niin lisätään se väliaikaiseen painikkeiden listaan
                    tempList.Add(item);
                }                
            }

            //Palautetaan lista
            return tempList;
        }

        /// <summary>
        /// Checks if given string is a number.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool isNumeric(string s)
        {
            int temp;
            bool isNumeric = int.TryParse(s, out temp);
            return isNumeric;
        }
        
    }
}
