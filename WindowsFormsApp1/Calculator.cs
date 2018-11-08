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

        public Calculator(IEnumerable<IOperator> operations) => this.Operations = new IOperator[] { new AdditionOperator(), new SubtractionOperator(), new MultiplicationOperator(), new DivisionOperator() };








        //private decimal val1;
        //private decimal val2;
        //private Oper? Operator;

        //public Calculator()
        //{

        //}

        //public void Clear()
        //{
        //    this.Operator = null;
        //    this.val1 = 0;
        //    this.val2 = 0;
        //}

        //public void GetOper(decimal currentValue, Oper _operator)
        //{
        //    this.val1 = currentValue;
        //    this.Operator = _operator;
        //}

        //public decimal GetResult(decimal value2)
        //{
        //    this.val2 = value2;
        //    decimal equals = 0;

        //    var x = val1;

        //    var y = val2;

        //    var oper = Operator;

        //    if (oper == Oper.add)
        //    {
        //        equals = x + y;
        //    }
        //    else if (oper == Oper.sub)
        //    {
        //        equals = x - y;
        //    }
        //    else if (oper == Oper.mult)
        //    {
        //        equals = x * y;
        //    }
        //    else if (oper == Oper.div)
        //    {
        //        equals = x / y;
        //    }

        //    return equals;
        //}

        //public decimal ConvertCurrency(decimal val1, decimal val2)
        //{
        //    return val1 * val2;
        //}
    }
}
