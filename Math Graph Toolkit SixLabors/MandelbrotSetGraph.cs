using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class MandelbrotSetGraph : Graph
    {
        public override Color Coloring(Complex z) =>
            DomainColoring.ColoringIterativeBounded(z);

        public override Complex Generate(Complex z, Point p)
        {
            var zx = z.Real;
            var zy = z.Imaginary;

            var c = zx + zy * new Complex(0, 1);

            int iter = 0;
            while (z.Magnitude <= 4 && iter < Global.iterMax)
            {
                z = z * z + c;
            }

            return iter;
        }

        public override string ToString() =>
            "Mandelbrot Set";
    }
}