using ShellProgressBar;
using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public sealed class GraphRendererRegion
    {
        public GraphRenderer graphRenderer;
        public Rectangle region;

        public Graph graph => graphRenderer.graph;
        public ProgressBar graphProgressBar => graphRenderer.graphProgressBar;
        public Image<Rgb24> graphImage => graphRenderer.graphImage;

        public int regionLeft => region.Left;
        public int regionTop => region.Top;

        public int regionWidth => region.Width;
        public int regionHeight => region.Height;

        public int regionRight => regionWidth + regionLeft;
        public int regionBottom => regionHeight + regionTop;

        public GraphRendererRegion(GraphRenderer graphRenderer, Rectangle region)
        {
            this.graphRenderer = graphRenderer;
            this.region = region;
        }

        public void Render()
        {
            for (int regionY = regionTop; regionY < regionBottom; ++regionY)
            {
                for (int regionX = regionLeft; regionX < regionRight; ++regionX)
                {
                    Point regionPoint = new Point(regionX, regionY);
                    Complex mappedZ = Global.MapPixelToComplex(regionPoint);
                    Complex generatedZ = graph.Generate(mappedZ, regionPoint);

                    if (Complex.IsNaN(generatedZ))
                        graphImage[regionX, regionY] = graph.ColoringInvalid(regionPoint);
                    else
                        graphImage[regionX, regionY] = graph.Coloring(generatedZ);
                }

            }
            graphProgressBar.Tick();
        }
    }
}