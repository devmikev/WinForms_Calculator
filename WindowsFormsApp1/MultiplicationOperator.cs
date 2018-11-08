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
        public int Apply(int x, int y) => x * y;
    }
}
