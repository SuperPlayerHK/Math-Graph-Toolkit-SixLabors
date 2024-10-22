namespace Math_Graph_Toolkit_SixLabors
{
    public class BogdanovMapGraph : ChaoticMap2DGraph
    {
        public double epsilon;
        public double k;
        public double mu;

        public BogdanovMapGraph(double epsilon, double k, double mu)
        {
            this.epsilon = epsilon;
            this.k = k;
            this.mu = mu;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return x + GetDeltaY(x, y, z);
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return y + epsilon * y +
                k * x * (x - 1) +
                mu * x * y;
        }

        public override string ToString() =>
            "Bogdanov Map";
    }
}