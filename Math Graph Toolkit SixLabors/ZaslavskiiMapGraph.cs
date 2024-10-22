namespace Math_Graph_Toolkit_SixLabors
{
    public class ZaslavskiiMapGraph : ChaoticMap2DGraph
    {
        public double vu;
        public double eplison;
        public double r;

        public double mu => (1 - Math.Exp(-r)) / r;

        public ZaslavskiiMapGraph(double vu, double eplison, double r)
        {
            this.vu = vu;
            this.eplison = eplison;
            this.r = r;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return (x +
                vu * (1 + mu * y) +
                eplison * vu * mu * Math.Cos(2 * Math.PI * x))
                % 1;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return Math.Exp(-r) *
                (y + eplison * Math.Cos(2 * Math.PI * x));
        }

        public override string ToString() =>
            "Zaslavskii Map";
    }
}