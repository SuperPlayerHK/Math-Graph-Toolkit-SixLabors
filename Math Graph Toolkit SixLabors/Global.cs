using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math_Graph_Toolkit_SixLabors
{
    public class Global
    {
        public const int imageWidth = 512;
        public const int imageHeight = 512;

        public const int imageWidthHalf = imageWidth / 2;
        public const int imageHeightHalf = imageHeight / 2;

        public const int renderRegionWidth = 64;
        public const int renderRegionHeight = 64;

        public const int renderRegionColumns = imageWidth / renderRegionWidth;
        public const int renderRegionRows = imageHeight / renderRegionHeight;

        public const int iterMax = 512;

        public const double xCenter = 3;
        public const double yCenter = 3;

        public const double xWidth = 2;
        public const double yHeight = 2;

        public const double xMin = xCenter - xWidth;
        public const double xMax = xCenter + xWidth;

        public const double yMin = yCenter - yHeight;
        public const double yMax = yCenter + yHeight;

        public static Complex MapPixelToComplex(int x, int y)
        {
            return new Complex(
                MathExt.Map(x, 0, imageWidth, xMin, xMax),
                MathExt.Map(y, 0, imageHeight, yMin, yMax));
        }

        public static Complex MapPixelToComplex(Point point)
        {
            return MapPixelToComplex(point.X, point.Y);
        }

        public static Point MapComplexToPixel(Complex z)
        {
            return new Point(
                MathExt.MapAs<double, int>(z.Real, xMin, xMax, 0, imageWidth),
                MathExt.MapAs<double, int>(z.Imaginary, yMin, yMax, 0, imageHeight));
        }
    }
}
