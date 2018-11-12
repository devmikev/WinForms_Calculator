using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Calculator : ICalculator
    {
        decimal val1 = 0;
        decimal val2 = 0;

        public IOperator Operator { get; set; }

        public IEnumerable<IOperator> Operations { get; }

        public decimal Display => val1;

        public decimal? ApplyOperator() => this.Operator?.Apply(val1, val2);

        public void InputNumber1(decimal value)
        {
            //int.TryParse(value, out val1);
            this.val1 = value;
        }


        public void InputNumber2(decimal value)
        {
            //int.TryParse(value, out val1);
            this.val2 = value;
        }

        public Calculator(IEnumerable<IOperator> operations)
        {
            this.Operations = new IOperator[] { new AdditionOperator(), new SubtractionOperator(), new MultiplicationOperator(), new DivisionOperator() };
        }
    }
}
