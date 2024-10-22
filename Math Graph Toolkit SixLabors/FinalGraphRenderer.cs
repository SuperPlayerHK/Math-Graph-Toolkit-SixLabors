using MathNet.Numerics.LinearAlgebra;
using ShellProgressBar;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public sealed class GraphRenderer
    {
        public List<GraphRendererRegion> graphRenderers;
        public Graph graph;

        public ProgressBar graphProgressBar;
        public Image<Rgb24> graphImage;

        public GraphRenderer(Graph graph)
        {
            this.graph = graph;

            // graphRegionRenderers = new List<GraphStripeRenderer>();
            graphRenderers = new List<GraphRendererRegion>();
            graphImage = new Image<Rgb24>(Global.imageWidth, Global.imageHeight);
            graphProgressBar = new ProgressBar(Global.renderRegionRows * Global.renderRegionColumns, $"Graphing {graph}");
            
            for (int x = 0; x < Global.imageWidth; x += Global.renderRegionWidth)
            {
                for (int y = 0; y < Global.imageHeight; y += Global.renderRegionHeight)
                {
                    graphRenderers.Add(new GraphRendererRegion(this, new Rectangle(
                        x,
                        y,
                        Global.renderRegionWidth,
                        Global.renderRegionHeight)));
                }
            }
        }

        public Image<Rgb24> RenderAll()
        {
            // Parallel.Invoke(graphRenderers.Select<GraphRendererRegion, Action>(renderer => renderer.Render).ToArray());
            Parallel.ForEach(graphRenderers, (graphRegion) =>
            {
                graphRegion.Render();
            });
            return graphImage;
        }
    }
}