using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class HenonHeilesPotentialGraph : Graph
    {
        public double lambda;

        public HenonHeilesPotentialGraph(double lambda)
        {
            this.lambda = lambda;
        }

        public override Complex Generate(Complex z, Point i)
        {
            double x = z.Real;
            double y = z.Imaginary;

            return .5d * (x * x + y * y) +
                lambda * (x * x + y - (y * y * y / 3));
        }

        public override string ToString() =>
            "Hénon–Heiles Potential";
    }
}