using MathNet.Numerics;
using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class NewtonFractalGraph : Graph
    {
        public override Color Coloring(Complex z)
        {
            return DomainColoring.ColoringIndexBounded(z, rootCount);
        }

        public Func<Complex, Complex> f;
        public Func<Complex, Complex> fPrime;

        public Complex[] roots;
        public int rootCount => roots.Length;

        public NewtonFractalGraph(Func<Complex, Complex> f, Func<Complex, Complex> fPrime, Complex[] roots)
        {
            this.f = f;
            this.fPrime = fPrime;
            this.roots = roots;
        }

        public override Complex Generate(Complex z, Point p)
        {
            for (int iter = 0; iter < Global.iterMax; ++iter)
            {
                z -= f(z) / fPrime(z);

                for (int i = 0; i < roots.Length; ++i)
                {
                    Complex diff = z - roots[i];

                    if (Math.Abs(diff.Real) < tolerance &&
                        Math.Abs(diff.Imaginary) < tolerance)
                        return i + 1;
                }
            }

            return 0;
        }

        private const double tolerance = .000001d;

        public override string ToString() =>
            "Newton Fractal";
    }
}
