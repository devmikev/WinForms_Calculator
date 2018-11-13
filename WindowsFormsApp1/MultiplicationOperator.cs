using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MultiplicationOperator : IOperator
    {
        public string Name => "Multiplication";
        public string Display => "x";
        public decimal Apply(decimal x, decimal y) => x * y;
    }
}
