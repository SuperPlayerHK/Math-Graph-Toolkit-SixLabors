namespace Math_Graph_Toolkit_SixLabors
{

    public class HindmarshRoseModelGraph : ChaoticMapGraph
    {
        public double a, b, c, d;
        public double r, s, xr, I;

        public HindmarshRoseModelGraph(double a, double b, double c, double d, double r, double s, double xr, double I)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.r = r;
            this.s = s;
            this.xr = xr;
            this.I = I;
        }

        static double Phi(double x, double a, double b)
        {
            return -a * x * x * x +
                b * x * x;
        }

        static double Psi(double x, double c, double d)
        {
            return c - d * x * x;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return y + Phi(x, a, b) - z + I;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return Psi(x, c, d) - y;
        }

        public override double GetDeltaZ(double x, double y, double z)
        {
            return r * (s * (x - xr) - z);
        }

        public override MathExt.AxisUsage axisUsage => MathExt.AxisUsage.XY;
        public override string ToString() => "Gingerbreadman Map";
    }
}
