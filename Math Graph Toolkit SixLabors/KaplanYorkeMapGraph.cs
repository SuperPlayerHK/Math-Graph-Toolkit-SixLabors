namespace Math_Graph_Toolkit_SixLabors
{

    public class KaplanYorkeMapGraph : ChaoticMap2DGraph
    {
        public double alpha;

        public KaplanYorkeMapGraph(double alpha)
        {
            this.alpha = alpha;

            chaoticIterationMode = ChaoticIterationMode.Discrete;
        }

        public override double GetDeltaX(double x, double y, double z)
        {
            return (2 * x) % .99995d;
        }

        public override double GetDeltaY(double x, double y, double z)
        {
            return alpha * y + Math.Cos(4 * Math.PI * x);
        }

        public override string ToString() =>
            "Kaplan-Yorke Map";
    }
}