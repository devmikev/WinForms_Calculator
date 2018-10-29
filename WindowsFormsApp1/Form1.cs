using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string val1;
        string val2;
        string Operator;

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();
          
        }

        private void GetNumberButtonValue(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            textBox1.Text += btn.Text;   

        }

        //Assumes number already present in textBox1
        private void GetOperator(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            var currentTextBoxValue = textBox1.Text;

            val1 = currentTextBoxValue;

            textBox1.Text = "";

            plus.Enabled = false;
            minus.Enabled = false;
            multiply.Enabled = false;
            divide.Enabled = false;

            Operator += btn.Text;
        }


        private void InitializeButtons()
        {
            foreach (var control in buttonPanel.Controls)
            {
                var b = control as Button;
                if (b != null)
                {
                    int num;
                    bool success = Int32.TryParse(b.Text, out num);
                    if (success)
                        b.Click += new System.EventHandler(GetNumberButtonValue);
                    else
                    {
                        if (b.Text != "c" && b.Text != "=")
                            b.Click += new System.EventHandler(GetOperator);
                    }
                }

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            plus.Enabled = true;
            minus.Enabled = true;
            multiply.Enabled = true;
            divide.Enabled = true;
            Operator = "";
            val1 = "";
            val2 = "";
        }

        private void equals_Click(object sender, EventArgs e)
        {
            var x = Convert.ToDecimal(val1);
            val2 = textBox1.Text;
            var y = Convert.ToDecimal(val2);
            decimal result;
            
            var oper = Operator;

            if (oper == "+")
            {
                result = x + y;
                textBox1.Text = result.ToString();
            }
            else if (oper == "-")
            {
                result = x - y;
                textBox1.Text = result.ToString();
            }
            else if (oper == "x")
            {
                result = x * y;
                textBox1.Text = result.ToString();
            }
            else if (oper == "/")
            {
                result = x / y;
                textBox1.Text = result.ToString();
            }
        }
    }
}
