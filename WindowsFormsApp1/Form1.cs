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

        //RequestCurrency currency = new RequestCurrency();

        Calculator calc = new Calculator();

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

        private Oper? GetEnumOp(string op)
        {
            switch (op)
            {
                case "+":
                    return Oper.add;
                case "-":
                    return Oper.sub;
                case "x":
                    return Oper.mult;
                case "/":
                    return Oper.div;
                default:
                    return null;
            }
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
            calc.Clear();
        }

        private void equals_Click(object sender, EventArgs e)
        {
            decimal value2;
            bool success = decimal.TryParse(textBox1.Text, out value2);
            if (success)
                textBox1.Text = calc.GetResult(value2).ToString();
        }

        //Assumes number already present in textBox1
        private void GetOperator(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            decimal value1;
            bool success = decimal.TryParse(textBox1.Text, out value1);
            if (success)
            {
                var opEnum = (GetEnumOp(btn.Text));
                if (opEnum == null)
                {
                    return;
                }

                calc.GetOper(value1, opEnum.Value);
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
            decimal value1;
            bool success = decimal.TryParse(textBox1.Text, out value1);
            if (success)
            {
                var currency = await RequestCurrency.GetRequest("http://free.currencyconverterapi.com/api/v5/convert?q=USD_EUR&compact=y");
                JsonObject output = JsonConvert.DeserializeObject<JsonObject>(currency);
                decimal value2;
                bool success2 = decimal.TryParse(output.USD_EUR.val.ToString(), out value2);
                if (success2)
                {
                    textBox1.Text = (value1 * value2).ToString("F");
                }
                //textBox1.Text = output.USD_EUR.val.ToString();
            }
            


        }
    }
}
