using MathNet.Numerics;
using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{

    public class SineGraph : Graph
    {
        public override Color Coloring(Complex z)
        {
            return DomainColoring.ColoringAero(z);
        }

        public override Complex Generate(Complex z, Point p)
        {
            return z.Sin();
        }

        public override string ToString()
        {
            return "f(z) -> sin(z)";
        }
    }
}