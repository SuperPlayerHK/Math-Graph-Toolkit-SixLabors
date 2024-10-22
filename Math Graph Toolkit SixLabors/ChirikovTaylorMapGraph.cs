namespace Math_Graph_Toolkit_SixLabors
{
    public class ChirikovTaylorMapGraph : ChaoticMap2DGraph
    {
        public double k;

        public ChirikovTaylorMapGraph(double k)
        {
            this.k = k;
        }

        public override double GetDeltaX(double x, double y, double z)
        {   
            return (x + GetDeltaY(x, y, z)) % (2 * Math.PI);
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return (y + k * Math.Sin(x)) % (2 * Math.PI);
        }

        public override string ToString() => "Chirikov-Taylor Map";
    }
}