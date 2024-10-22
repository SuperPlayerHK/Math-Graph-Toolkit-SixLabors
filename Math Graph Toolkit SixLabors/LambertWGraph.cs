using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class LambertWGraph : Graph
    {
        public override Complex Generate(Complex z, Point i)
        {
            return MathFunctions.LambertW(z);
        }

        public override string ToString() =>
            "f(z) -> LambertW(z)";
    }
}