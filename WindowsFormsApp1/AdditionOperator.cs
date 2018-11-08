using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class AdditionOperator : IOperator
    {
        public string Name => "Addition";
        public string Display => "+";
        public int Apply(int x, int y) => x + y;
    }
}
