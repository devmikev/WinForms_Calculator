using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Calculator
    {
        public string val1;
        public string val2;
        public string Operator;
        public string result;
        public decimal equals;

        public Calculator()
        {

        }

        public void Clear()
        {
            this.Operator = "";
            this.val1 = "";
            this.val2 = "";
            this.result = "";
        }

        public void GetOper(string currentValue, string _operator)
        {
            this.val1 = currentValue;
            this.Operator += _operator;
        }

        public void GetResult(string value2)
        {
            this.val2 = value2;

            var x = Convert.ToDecimal(val1);
            
            var y = Convert.ToDecimal(val2);

            var oper = Operator;

            if (oper == "+")
            {
                equals = x + y;
            }
            else if (oper == "-")
            {
                equals = x - y;
            }
            else if (oper == "x")
            {
                equals = x * y;
            }
            else if (oper == "/")
            {
                equals = x / y;
            }
        }
    }
}
