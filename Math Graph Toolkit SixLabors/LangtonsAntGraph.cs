using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public sealed class LangtonsAntGraph : Graph
    {
        public struct LangtonsAntSettings
        {
            public bool worldPersistence;
            public WorldBorderBehaviour worldBorderBehaviour;

            public int? iterMaxOverwrite;

            public enum WorldBorderBehaviour
            {
                Clamp, Wrap, Destroy
            }

            public LangtonsAntSettings(bool worldPersistence, WorldBorderBehaviour worldBorderBehaviour)
            {
                this.worldPersistence = worldPersistence;
                this.worldBorderBehaviour = worldBorderBehaviour;
                this.iterMaxOverwrite = null;
            }

            public LangtonsAntSettings(bool worldPersistence, WorldBorderBehaviour worldBorderBehaviour, int iterMaxOverwrite)
            {
                this.worldPersistence = worldPersistence;
                this.worldBorderBehaviour = worldBorderBehaviour;
                this.iterMaxOverwrite = iterMaxOverwrite;
            }
        }

        public bool[,] worldMap;
        public LangtonsAntSettings langtonsAntSettings;

        int iterSelected;

        public LangtonsAntGraph(LangtonsAntSettings langtonsAntSettings)
        {
            this.langtonsAntSettings = langtonsAntSettings;
            this.worldMap = new bool[Global.imageWidth, Global.imageHeight];

            iterSelected = (langtonsAntSettings.iterMaxOverwrite ?? Global.iterMax);
        }

        public override Color Coloring(Complex z)
        {
            if (z.Real == 1)
                return Color.Black;

            return Color.White;
        }

        public override Complex Generate(Complex z, Point i)
        {
            if (!langtonsAntSettings.worldPersistence)
                Array.Clear(worldMap);

            MathExt.Direction direction = MathExt.Direction.Right;

            for (int iter = 0; iter < iterSelected; ++iter)
            {
                direction = direction.RotateDirection(worldMap[i.X, i.Y]);

                worldMap[i.X, i.Y] ^= true;
                i = i.MoveDirection(direction);

                switch (langtonsAntSettings.worldBorderBehaviour)
                {
                    case LangtonsAntSettings.WorldBorderBehaviour.Clamp:
                        i.X = Math.Clamp(i.X, 0, Global.imageWidth - 1);
                        i.Y = Math.Clamp(i.Y, 0, Global.imageHeight - 1);
                        break;
                    case LangtonsAntSettings.WorldBorderBehaviour.Wrap:
                        if (i.X < 0) i.X = Global.imageWidth - 1;
                        if (i.X >= Global.imageWidth) i.X = 0;
                        if (i.Y < 0) i.Y = Global.imageHeight - 1;
                        if (i.Y >= Global.imageHeight) i.Y = 0;
                        break;
                    case LangtonsAntSettings.WorldBorderBehaviour.Destroy:
                        if (i.X < 0 || i.X >= Global.imageWidth || i.Y < 0 || i.Y >= Global.imageHeight)
                        {
                            i.X = Math.Clamp(i.X, 0, Global.imageWidth - 1);
                            i.Y = Math.Clamp(i.Y, 0, Global.imageHeight - 1);
                            goto BreakFromLoop;
                        }
                        break;
                }
            }

        BreakFromLoop:
            return new Complex(worldMap[i.X, i.Y] ? 1 : 0, 0);
        }

        public override string ToString() =>
            "Langton's Ant";
    }
}