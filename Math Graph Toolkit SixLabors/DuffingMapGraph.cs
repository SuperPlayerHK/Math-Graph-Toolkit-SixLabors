namespace Math_Graph_Toolkit_SixLabors
{
    public class DuffingMapGraph : ChaoticMap2DGraph
    {
        public double a;
        public double b;

        public DuffingMapGraph(double a, double b)
        {
            this.a = a;
            this.b = b;

            chaoticIterationMode = ChaoticIterationMode.Discrete;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return y;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return -b * x + a * y - y * y * y;
        }

        public override string ToString() =>
            "Duffing Map";
    }
}
