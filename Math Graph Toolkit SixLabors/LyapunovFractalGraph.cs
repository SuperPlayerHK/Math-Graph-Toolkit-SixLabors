using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{

    public sealed class LyapunovFractalGraph : Graph
    {
        public enum AB
        {
            A, B
        }

        public AB[] seq;

        public override Color Coloring(Complex z)
        {
            double exponent = z.Imaginary;

            if (-5 <= exponent && exponent < 0)
            {
                byte c1 = MathExt.MapAs<double, byte>(exponent, -5, 0, 0, 255);
                return Color.FromRgb(c1, (byte)(c1 * .9f), 0);
            }

            if (0 <= exponent && exponent < 5)
            {
                byte c2 = MathExt.MapAs<double, byte>(exponent, 0, 5, 128, 255);
                return Color.FromRgb(0, 0, c2);
            }

            return Color.Blue;
        }

        public LyapunovFractalGraph(params AB[] seq)
        {
            this.seq = seq;
        }

        public LyapunovFractalGraph(string seq)
        {
            seq = seq.ToLower();

            List<AB> seqAB = new List<AB>();

            foreach (var _char in seq)
            {
                if (_char == 'a')
                    seqAB.Add(AB.A);
                else if (_char == 'b')
                    seqAB.Add(AB.B);
                else
                    throw new ArgumentOutOfRangeException(nameof(seq), "must only contains A or B");
            }

            this.seq = seqAB.ToArray();
        }

        public override Complex Generate(Complex z, Point p)
        {
            double exponent = 0;

            for (int i = 1; i < N; ++i)
            {
                double r = seq[i % seq.Length] == AB.A ? z.Real : z.Imaginary;
                xN = xN * r * (1 - xN);

                double v = Math.Log(Math.Abs(r * (1 - 2 * xN)));
                if (!double.IsInfinity(v))
                    exponent += v;
            }

            return new Complex(0, exponent / N);
        }

        public override string ToString()
        {
            return $"Lyapunov Fractal where seq={string.Join(", ", seq)}";
        }

        double xN = .5f;
        const double N = 10000;
    }
}