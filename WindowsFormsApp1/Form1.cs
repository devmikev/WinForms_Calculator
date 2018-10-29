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
        public Form1()
        {
            InitializeComponent();
            InitializeNumberButtons();
        }

        private void GetNumberButtonValue(object sender, EventArgs e)
        {
            //textBox1.Text += this.buttonPanel.Controls.Owner.Text;
            var btn = (Button)sender;
            textBox1.Text += btn.Text;   
            

        }

        private void InitializeNumberButtons()
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
                }
            }
        }


    }
}
