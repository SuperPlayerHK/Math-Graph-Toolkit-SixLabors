using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class CollatzConjectureFractalGraph : Graph
    {
        public override Color Coloring(Complex z)
        {
            return DomainColoring.ColoringIterativeBounded(z);
        }

        public override Complex Generate(Complex z, Point p)
        {
            int iter = 0;
            while (z.Magnitude < 16 && iter < Global.iterMax)
            {
                z = MathFunctions.CollatzConjecture(z);
                ++iter;
            }

            return iter;
        }

        public override string ToString() =>
            "Collatz Fractal";
    }
}
