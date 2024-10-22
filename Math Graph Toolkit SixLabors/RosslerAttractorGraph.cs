namespace Math_Graph_Toolkit_SixLabors
{
    public class RosslerAttractorGraph : ChaoticMapGraph
    {
        public double a;
        public double b;
        public double c;

        public RosslerAttractorGraph(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return -y - z;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return x + a * y;
        }

        public override double GetDeltaZ(double x, double y, double z)
        {
            return b + z * (x - c);
        }

        public override string ToString() => "Rössler Attractor";
        public override MathExt.AxisUsage axisUsage => MathExt.AxisUsage.XY;
    }
}
