using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math_Graph_Toolkit_SixLabors
{

    public class MandelbrotSetOptimizedGraph : Graph
    {
        public override Color Coloring(Complex z) =>
            DomainColoring.ColoringIterativeBounded(z);

        public override Complex Generate(Complex z, Point p)
        {
            double x = 0;
            double y = 0;

            double x0 = z.Real;
            double y0 = z.Imaginary; 

            double x2 = 0;
            double y2 = 0;

            int iter = 0;
            while (x2 + y2 <= 4 && iter < Global.iterMax)
            {
                y = 2 * x * y + y0;
                x = x2 - y2 + x0;

                x2 = x * x;
                y2 = y * y;

                ++iter;
            }

            return iter;
        }

        public override string ToString() =>
            "Mandelbrot Set (Optimized)";
    }
}
