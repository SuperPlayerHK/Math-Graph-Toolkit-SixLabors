using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class CustomFunctionGraph : Graph
    {
        public Func<Complex, Complex> customFunction;

        public CustomFunctionGraph(Func<Complex, Complex> customFunction)
        {
            this.customFunction = customFunction;
        }

        public override Complex Generate(Complex z, Point i)
        {
            return customFunction(z);
        }

        public override string ToString() =>
            "Custom Function";
    }
}
