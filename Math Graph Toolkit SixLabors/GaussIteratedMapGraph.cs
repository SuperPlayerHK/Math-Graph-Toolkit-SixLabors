namespace Math_Graph_Toolkit_SixLabors
{
    public class GaussIteratedMapGraph : ChaoticMap2DGraph
    {
        public double alpha;
        public double beta;

        public GaussIteratedMapGraph(double alpha, double beta)
        {
            this.alpha = alpha;
            this.beta = beta;

            chaoticIterationMode = ChaoticIterationMode.Discrete;
        }

        private double Iter(double v)
        {
            return Math.Exp(-alpha * v * v) + beta;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return Iter(x);
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return Iter(y);
        }

        public override string ToString() =>
            "Gauss Iterated Map";
    }
}