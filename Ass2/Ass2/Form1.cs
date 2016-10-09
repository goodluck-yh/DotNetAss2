using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2
{
    public partial class Form1 : Form
    {
        bool isCalcResult = false;
        public Form1()
        {
            InitializeComponent();
            this.result.Text = "0";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("0", true);
        }

        private void dot_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation(".", false);
        }

        private void one_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("1", true);
        }

        private void two_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("2", true);
        }

        private void three_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("3", true);
        }

        private void four_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("4", true);
        }

        private void five_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("5", true);
        }

        private void six_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("6", true);
        }

        private void seven_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("7", true);
        }

        private void eight_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("8", true);
        }

        private void nine_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("9", true);
        }

        private void add_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("+", false);
        }

        private void mutiple_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("*", false);
        }

        private void minus_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("-",false);
        }

        private void divide_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("/",false);
        }

        private void modulo_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("%", false);
        }

        private void power_Click(object sender, EventArgs e)
        {
            pressNumberOrOperation("^", false);
        }

        private void ce_Click(object sender, EventArgs e)
        {
            clearEmement();
        }

        private void cl_Click(object sender, EventArgs e)
        {
            clearLine();
        }

        private void equal_Click(object sender, EventArgs e)
        {
            Calculate calculate = new Calculate();
            this.result.Text = calculate.Calc(this.result.Text);
            this.isCalcResult = true;
            /*string result = calculate.Calc("1+2+3");
            Console.WriteLine(result);
            result = calculate.Calc("-6-+5+4*3^2");
            Console.WriteLine(result);
            result = calculate.Calc("-6.0*2+");
            Console.WriteLine(result);
            result = calculate.Calc("3/0^2");  //should be 00
            Console.WriteLine(result);
            result = calculate.Calc("3.5.5");
            Console.WriteLine(result);
            result = calculate.Calc("7/*-3");
            Console.WriteLine(result);
            result = calculate.Calc("1+2-4");
            Console.WriteLine(result);
            result = calculate.Calc("1*2/4");
            Console.WriteLine(result);
            result = calculate.Calc("4^-0.5");
            Console.WriteLine(result);
            result = calculate.Calc("1.2-5.6*0.1+2.2/1.1");   //2.64
            Console.WriteLine(result);
            result = calculate.Calc("1.2+2.3%1.67^2.5");  //3.5
            Console.WriteLine(result);*/


        }

        private void clearEmement()
        {
            if (this.isCalcResult == false)
            {
                if (this.result.Text.Length == 1)
                {
                    this.result.Text = "0";
                }
                else
                {
                    this.result.Text = this.result.Text.Remove(this.result.Text.Length - 1);
                }
            }else
            {
                double currentNum;
                if (Double.TryParse(this.result.Text, out currentNum) == false || this.result.Text == "∞")
                {
                    this.result.Text = "0";
                }
                this.isCalcResult = false;
            }
            
        }

        private void clearLine()
        {
            this.result.Text = "0";
            if(this.isCalcResult == true)
            {
                this.isCalcResult = false;
            }
        }

        private void pressNumberOrOperation(string input, bool isNum)
        {
            double currentNum;

            if(this.isCalcResult == false)
            {
                if(isNum == true && this.result.Text == "0")
                {
                    this.result.Text = input;
                }else
                {
                    this.result.Text += input;
                }
                
            }else
            {
                if(isNum == true)
                {
                    this.result.Text = input;
                }else if (Double.TryParse(this.result.Text, out currentNum) == false || this.result.Text == "∞")
                {
                    this.result.Text = "0" + input;
                }
                else
                {
                    this.result.Text += input;
                }
                this.isCalcResult = false;
            }
            
        }
    }
}
