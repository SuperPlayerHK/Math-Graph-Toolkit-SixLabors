using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{

    public class IkedaMapGraph : ChaoticMap2DGraph
    {
        public double u;

        public IkedaMapGraph(double u)
        {
            this.u = u;

            chaoticIterationMode = ChaoticIterationMode.Discrete;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            double _t = .4 - (6 / (1 + x * x + y * y));
            return 1 + u * (x * Math.Cos(_t) - y * Math.Sin(_t));
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            double _t = .4 - (6 / (1 + x * x + y * y));
            return u * (x * Math.Sin(_t) + y * Math.Cos(_t));
        }

        public override string ToString() => "Ikeda Map";
    }
}
