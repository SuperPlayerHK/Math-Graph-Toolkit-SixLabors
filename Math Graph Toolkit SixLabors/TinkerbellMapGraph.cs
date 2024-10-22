namespace Math_Graph_Toolkit_SixLabors
{
    public class TinkerbellMapGraph : ChaoticMap2DGraph
    {
        public double a;
        public double b;
        public double c;
        public double d;

        public TinkerbellMapGraph(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;

            chaoticIterationMode = ChaoticIterationMode.Discrete;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return x * x - y * y +
                a * x + b * y;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return 2 * x * y + c * x + d * y;
        }

        public override string ToString() => "Tinkerbell Map";
    }
}
