using MathNet.Numerics;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{

    public class Program
    {
        static List<Graph> graphs = new List<Graph>()
        {
            
        };

        static long GetUnixTimeSeconds() =>
            DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        static void RenderAsImages()
        {
            long unixTime = GetUnixTimeSeconds();
            foreach (var graph in graphs)
            {
                var graphImage = new GraphRenderer(graph).RenderAll();

                graphImage.Save($"Out{++unixTime}.png");
                Process.Start("explorer.exe", $"Out{unixTime}.png");

                Console.Clear();
            }
        }

        static void RenderAsGif()
        {
            int width = Global.imageWidth;
            int height = Global.imageHeight;

            Image<Rgb24> gif = new(width, height, Color.Black);
            gif.Metadata.GetGifMetadata().RepeatCount = 0;
            gif.Frames.RootFrame.Metadata.GetGifMetadata().FrameDelay = 0;

            foreach(var graph in graphs)
            {
                gif.Frames.AddFrame(new GraphRenderer(graph).RenderAll().Frames.RootFrame);
                gif.Frames.RootFrame.Metadata.GetGifMetadata().FrameDelay = 500;

                Console.Clear();
            }

            long unixTime = GetUnixTimeSeconds();
            gif.SaveAsGif($"Out{unixTime}.gif");
            Process.Start("explorer.exe", $"Out{unixTime}.gif");
        }

        static void Main(string[] args)
        {
            new OptionMenu<string>("Output Types", new Dictionary<string, Action>()
            {
                { "Render as images", RenderAsImages },
                { "Render as GIF", RenderAsGif },
            }).Show();
        }
    }
}