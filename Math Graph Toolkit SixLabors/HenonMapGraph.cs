namespace Math_Graph_Toolkit_SixLabors
{
    public class HenonMapGraph : ChaoticMap2DGraph
    {
        public double a;
        public double b;
        
        public HenonMapGraph(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return 1 - a * x * x + y;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return b * x;
        }

        public override string ToString() =>
            "Hénon Map";
    }
}
