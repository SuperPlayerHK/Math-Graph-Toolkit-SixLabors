using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public class BakersMapGraph : Graph
    {
        public enum MapsDefinitions
        {
            Folded, Unfolded, Tent
        }

        public MapsDefinitions bakerAlternatives;

        public BakersMapGraph(MapsDefinitions bakerAlternatives)
        {
            this.bakerAlternatives = bakerAlternatives;
        }

        public override Complex Generate(Complex z, Point i)
        {
            double x = z.Real;
            double y = z.Imaginary;

            switch (bakerAlternatives)
            {
                case MapsDefinitions.Folded:
                    if (0 <= x && x < .5d)
                        return new Complex(2 * x, y / 2);
                    else
                        return new Complex(2 - 2 * x, 1 - y / 2);
                case MapsDefinitions.Unfolded:
                    return new Complex(2 * x - Math.Floor(2 * x), (y + Math.Floor(2 * x)) / 2);
                case MapsDefinitions.Tent:
                    if (0 <= x && x < .5d)
                        return 2 * x;
                    else
                        return 2 * (1 - x);
            }

            return Complex.NaN;
        }

        public override string ToString() =>
            "Baker's Map";
    }
}