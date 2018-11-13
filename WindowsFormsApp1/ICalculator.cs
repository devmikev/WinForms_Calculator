using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface ICalculator
    {
        IOperator Operator { get; set; }
        // store the input for applying operators
        void InputNumber1(decimal value);
        void InputNumber2(decimal value);
        IEnumerable<IOperator> Operations { get; }
        // there may not be two numbers input yet
        decimal? ApplyOperator();
        decimal Display { get; }

    }
}
