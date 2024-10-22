namespace Math_Graph_Toolkit_SixLabors
{
    public class LotkaVolterraEquationsGraph : ChaoticMap2DGraph
    {
        public double alpha;
        public double beta;
        public double gamma;
        public double delta;

        public LotkaVolterraEquationsGraph(double alpha, double beta, double gamma, double delta)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.gamma = gamma;
            this.delta = delta;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return alpha * x - beta * x * y;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return delta * x * y - gamma * y;
        }

        public override string ToString() => "Lotka-Volterra Equations";
    }
}
