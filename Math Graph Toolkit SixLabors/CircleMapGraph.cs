namespace Math_Graph_Toolkit_SixLabors
{
    public class CircleMapGraph : ChaoticMap2DGraph
    {
        public float k;

        public CircleMapGraph(float k)
        {
            this.k = k;

            chaoticIterationMode = ChaoticIterationMode.Discrete;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return GetDeltaY(x, y, z) - y;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return y + MathExt.OMEGA_CONSTANT - k * Math.Sin(y);
        }

        public override string ToString() =>
            "Circle Map";
    }
}