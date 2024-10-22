using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public abstract class Graph
    {
        public virtual Color Coloring(Complex z)
        {
            return DomainColoring.ColoringGridStrong(z);
        }

        public virtual Color ColoringInvalid(Point i)
        {
            return DomainColoring.ColoringInvalidPurpleTexture(i);
        }

        public abstract Complex Generate(Complex z, Point i);
        public override abstract string ToString();
    }
}