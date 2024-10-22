using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class ArnoldsCatMapGraph : Graph
    {
        public override Complex Generate(Complex z, Point i)
        {
            double re = z.Real;
            double im = z.Imaginary;

            double x = 2 * re + im;
            double y = re + im;

            return new Complex(x % 1, y % 1);
        }

        public override string ToString() =>
            "Arnold's Cat Map";
    }
}