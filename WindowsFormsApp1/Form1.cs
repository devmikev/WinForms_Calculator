using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        string partialExpression;
        IEnumerable<IOperator> operations = new IOperator[] { new AdditionOperator(), new SubtractionOperator(), new MultiplicationOperator(), new DivisionOperator() };
        Calculator calc;

        public Form1()
        {
            InitializeComponent();
            InitializeButtons();

            calc = new Calculator(operations);
        }

        private void GetNumberButtonValue(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            textBox1.Text += btn.Text;   
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
        }

        private void equals_Click(object sender, EventArgs e)
        {
            decimal value2;
            //string partialExpression = textBox1.Text;
            //textBox1.Text = "";

            bool success = decimal.TryParse(textBox1.Text, out value2);
            if (success)
            {
                calc.InputNumber2(value2);
                textBox1.Text = partialExpression + " " + value2 + " = " + calc.ApplyOperator().ToString();

            }
            //textBox1.Text = calc.GetResult(value2).ToString();

            //plus.Enabled = true;
            //minus.Enabled = true;
            //multiply.Enabled = true;
            //divide.Enabled = true;
        }

        //Assumes number already present in textBox1
        private void GetOperator(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            decimal value1;
            bool success = decimal.TryParse(textBox1.Text, out value1);
            if (success)
            {
                var buttonOperator = btn.Text;
                if (buttonOperator == null)
                {
                    return;
                }

                //calc.GetOper(value1, opEnum.Value);
                calc.InputNumber1(value1); // Set val1, then add OperatorSymbol to textBox and set Operator

                foreach (var oper in operations)
                {
                    if (oper.Display == buttonOperator)
                    {
                        calc.Operator = oper;
                    }
                }

                //textBox1.Text += " " + calc.Operator.Display;
                partialExpression = textBox1.Text + " " + buttonOperator;
                textBox1.Text = "";

                plus.Enabled = false;
                minus.Enabled = false;
                multiply.Enabled = false;
                divide.Enabled = false;
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            
        }

        private void dot_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            textBox1.Text += btn.Text;
        }

        //https://stackoverflow.com/a/17248813/57883 found working solution for async blocking on winforms
        async private void currency_Click(object sender, EventArgs e)
        {
            //decimal value1;
            //decimal value2;

            //bool success = decimal.TryParse(textBox1.Text, out value1);

            //if (success)
            //{
            //    decimal? currency = await RequestCurrency.GetValue();
            //    if (currency != null)
            //    {
            //        value2 = currency.Value;
            //        var convertedValue = calc.ConvertCurrency(value1, value2).ToString("F");
            //        textBox1.Text = convertedValue;
            //    }
            //}
            throw new NotImplementedException();
        }
    }
}
