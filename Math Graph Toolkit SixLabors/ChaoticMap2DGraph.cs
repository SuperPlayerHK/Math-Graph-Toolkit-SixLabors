namespace Math_Graph_Toolkit_SixLabors
{
    public abstract class ChaoticMap2DGraph : ChaoticMapGraph
    {
        public override MathExt.AxisUsage axisUsage => MathExt.AxisUsage.XY;

        public abstract override double GetDeltaX(double x, double y, double z);
        public abstract override double GetDeltaY(double x, double y, double z);

        public sealed override double GetDeltaZ(double x, double y, double z) => 0;

        public abstract override string ToString();
    }
}
