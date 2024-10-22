using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math_Graph_Toolkit_SixLabors
{
    public class SumGraph : Graph
    {
        public override Complex Generate(Complex z, Point i)
        {
            return (z * (z + 1)) / 2;
        }

        public override string ToString()
        {
            return "Sum";
        }
    }
}
