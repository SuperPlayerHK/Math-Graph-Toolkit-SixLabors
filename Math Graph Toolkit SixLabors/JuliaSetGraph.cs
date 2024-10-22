using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class JuliaSetGraph : Graph
    {
        public override Color Coloring(Complex z) =>
            DomainColoring.ColoringIterativeBounded(z);

        public Complex c;
        public JuliaSetGraph(Complex c)
        {
            this.c = c;
        }

        public override Complex Generate(Complex z, Point p)
        {
            int iter = 0;

            while (z.Magnitude <= 4 && iter < Global.iterMax)
            {
                z = z * z + c;

                ++iter;
            }

            return iter;
        }

        public override string ToString() =>
            "Julia Set";
    }
}
