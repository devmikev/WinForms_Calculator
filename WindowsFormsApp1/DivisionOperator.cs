using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DivisionOperator : IOperator
    {
        public string Name => "Division";
        public string Display => "/";
        public int Apply(int x, int y) => x / y;
    }
}
