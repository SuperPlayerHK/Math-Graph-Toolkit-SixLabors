namespace Math_Graph_Toolkit_SixLabors
{
    public class GingerbreadmanMapGraph : ChaoticMap2DGraph
    {
        public GingerbreadmanMapGraph()
        {
            chaoticIterationMode = ChaoticIterationMode.Discrete;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return 1 - y + Math.Abs(x);
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return x;
        }

        public override string ToString() => "Gingerbreadman Map";
    }
}
