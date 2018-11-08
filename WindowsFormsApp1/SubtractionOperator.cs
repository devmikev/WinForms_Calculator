using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SubtractionOperator : IOperator
    {
        public string Name => "Subtraction";
        public string Display => "-";
        public int Apply(int x, int y) => x - y;
    }
}
