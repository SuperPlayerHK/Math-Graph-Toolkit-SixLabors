using ColorMine.ColorSpaces;
using SixLabors.ImageSharp.ColorSpaces;
using SixLabors.ImageSharp.ColorSpaces.Conversion;
using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public static class DomainColoring
    {
        public enum GridType
        {
            Rectangular, Circular
        }

        public static Color ColoringInvalidPurpleTexture(Point i)
        {
            return (i.X % 2 == 0 || i.Y % 2 == 0) ? Color.Black : Color.Purple;
        }

        public static Color ColoringGridStrong(Complex z, GridType gridType = GridType.Rectangular)
        {
            return new ColorMine.ColorSpaces.Hsv
            {
                H = EffectRainbow(z),
                S = EffectRingLine(z),
                V = gridType == GridType.Circular ? EffectCircularGrid(z) : EffectRectangularGrid(z)
            }.AsSixLaborColor();
        }

        public static Color ColoringGridSoft(Complex z, GridType gridType = GridType.Rectangular)
        {
            return new ColorMine.ColorSpaces.Hsv
            {
                H = EffectRainbow(z),
                S = MathExt.Weaken(EffectRingLine(z), .95f),
                V = MathExt.Weaken(gridType == GridType.Circular ? EffectCircularGrid(z) : EffectRectangularGrid(z), .95d)
            }.AsSixLaborColor();
        }

        public enum ColorScheme
        {
            Dark, Light
        }

        public static Color ColoringAero(Complex z, ColorScheme colorScheme = ColorScheme.Light)
        {
            if (colorScheme == ColorScheme.Dark)
            {
                return new ColorMine.ColorSpaces.Hsv
                {
                    H = EffectRainbow(z),
                    S = 1d,
                    V = MathExt.Weaken(EffectRingRegionLogarithmic(z), .75d),
                }.AsSixLaborColor();
            }
            else
            {
                return new ColorMine.ColorSpaces.Hsv
                {
                    H = EffectRainbow(z),
                    S = MathExt.Weaken(EffectRingRegionLogarithmic(z), .75d),
                    V = 1d
                }.AsSixLaborColor();
            }
        }

        /// <summary>
        /// A ring region that is calculated based on <see cref="Complex.Magnitude"/>.
        /// </summary>
        public static double EffectRingRegion(Complex z)
        {
            return z.Magnitude % 1d;
        }

        /// <summary>
        /// A ring region that is calculated based on <see cref="Complex.Magnitude"/>, logarithmically.
        /// </summary>
        public static double EffectRingRegionLogarithmic(Complex z)
        {
            return Math.Log10(z.Magnitude) % 1d;
        }

        /// <summary>
        /// A ring line that is calculated based on <see cref="Complex.Magnitude"/>.
        /// </summary>
        public static double EffectRingLine(Complex z)
        {
            return 1 - MathExt.Cycle(z.Magnitude, 1);
        }

        /// <summary>
        /// A ring line that is calculated based on <see cref="Complex.Magnitude"/>, logarithmically.
        /// </summary>
        public static double EffectRingLineLogarithmic(Complex z)
        {
            return 1 - MathExt.Cycle(z.Magnitude, Math.Log10(z.Magnitude));
        }

        /// <summary>
        /// A beam line that is calculated based on <see cref="Complex.Phase"/>, one line cycle is every 45 degree.
        /// </summary>
        public static double EffectBeamLine(Complex z)
        {
            return 1 - MathExt.Cycle(MathExt.Map(z.Phase, -Math.PI, Math.PI, 0, 360), 45);
        }

        /// <summary>
        /// A circular grid that is calculated based on <see cref="Complex.Magnitude"/> and <see cref="Complex.Phase"/> using <see cref="MathExt.Mesh{T}(T, T)"/>.
        /// </summary>
        public static double EffectCircularGrid(Complex z)
        {
            return MathExt.Mesh(EffectBeamLine(z), EffectRingLine(z));
        }

        /// <summary>
        /// A rectangular grid that is calculated based on <see cref="Complex.Magnitude"/> and <see cref="Complex.Phase"/> using <see cref="MathExt.Mesh{T}(T, T)"/>.
        /// </summary>
        public static double EffectRectangularGrid(Complex z)
        {
            return MathExt.Mesh(EffectGridReal(z), EffectGridImag(z));
        }

        public static double EffectGridReal(Complex z)
        {
            return 1 - MathExt.Cycle(z.Real, 1, 10000);
        }

        public static double EffectGridImag(Complex z)
        {
            return 1 - MathExt.Cycle(z.Imaginary, 1, 10000);
        }

        /// <summary>
        /// A rainbow that is calculated based on <see cref="Complex.Phase"/>.
        /// </summary>
        public static double EffectRainbow(Complex z)
        {
            return MathExt.Map(z.Phase, -Math.PI, Math.PI, 0d, 360d);
        }

        public static Color ColoringIndexBounded(Complex z, int max)
        {
            int i = (int)z.Real;

            double h = i / max * 360d;
            double s = 1.0d;

            return new ColorMine.ColorSpaces.Hsv
            {
                H = h,
                S = s,
                V = max == 0 ? 0 : 1
            }.AsSixLaborColor();
        }

        public static Color ColoringIterativeBounded(Complex z)
        {
            double iter = z.Real;

            double h = Math.Pow(iter / Global.iterMax * 360, 1.5) % 360;
            double s = 1.0d;
            double v = iter / Global.iterMax;

            return new ColorMine.ColorSpaces.Hsv
            {
                H = h,
                S = s,
                V = 1 - v
            }.AsSixLaborColor();
        }
    }
}