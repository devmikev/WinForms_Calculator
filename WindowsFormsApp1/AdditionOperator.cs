using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AdditionOperator : IOperator
    {
        public string Name => "Addition";
        public string Display => "+";
        public decimal Apply(decimal x, decimal y) => x + y;
    }
}
