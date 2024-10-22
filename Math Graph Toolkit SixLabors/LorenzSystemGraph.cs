namespace Math_Graph_Toolkit_SixLabors
{
    public class LorenzSystemGraph : ChaoticMapGraph
    {
        public double rho;
        public double sigma;
        public double beta;

        public LorenzSystemGraph(double rho, double sigma, double beta)
        {
            this.rho = rho;
            this.sigma = sigma;
            this.beta = beta;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return sigma * (y - x);
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return x * (rho - z) - y;
        }

        public override double GetDeltaZ(double x, double y, double z)
        {
            return x * y - beta * z;
        }

        public override string ToString() => "Lorenz System";
    }
}
