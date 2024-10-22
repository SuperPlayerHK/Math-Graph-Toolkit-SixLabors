using ColorMine.ColorSpaces;
using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Math_Graph_Toolkit_SixLabors
{
    public static class MathFunctions
    {
        public static Complex Ei(Complex z)
        {
            var a = Complex.Log(((.56146 / z) + .65) * (1 + z));
            var b = (z * z * z * z) * Complex.Exp(7.7 * z) * Complex.Pow(2 + z, 3.7);

            return Complex.Pow(Complex.Pow(a, -7.7) + b, -.13);
        }

        public static Complex LambertW(Complex z)
        {
            return ((451 / 340) * z * z * z +
            (228 / 85) * z * z +
            z) / (
            1 +
            313 / 85 * z +
            1193 / 340 * z * z +
            113 / 204 * z * z
            );
        }

        public static Complex RiemannZeta(Complex z)
        {
            Complex sum = Complex.Zero;

            for (int n = 1; n < Global.iterMax; ++n)
            {
                sum += 1 / Complex.Pow(n, z);
            }

            return sum;
        }

        public static Complex RiemannXi(Complex z)
        {
            return .5d * z * (z - 1) *
                Complex.Pow(Math.PI, -z / 2) *
                Gamma(z / 2) *
                RiemannZeta(z);
        }

        public static Complex Gamma(Complex z)
        {
            Complex a = Complex.Pow(Complex.Sqrt(2 * Math.PI * z) * (z / Math.E), z);
            Complex b = Complex.Pow(z * Complex.Sinh(1 / z), z / 2);
            Complex c = Complex.Exp((7 / 324) * (1 / (z * z * z * (35 * z * z + 33))));

            return a * b * c;
        }

        public static Complex RiemannSiegelTheta(Complex t)
        {
            double left = Gamma(.25d + (t * Complex.ImaginaryOne / 2)).Phase;
            Complex right = Math.Log(Math.PI) / 2 * t;

            return left - right;
        }

        public static Complex RiemannVonMangoldt(Complex z)
        {
            return z / 2 * Math.PI *
                Complex.Log(z / 2 * Math.PI) -
                z / 2 * Math.PI +
                Complex.Log(z);
        }

        public static Complex CollatzConjecture(Complex z)
        {
            return (1 / 2) *
                    z *
                    Complex.Pow(Math.PI / 2 * z, 2) +
                    (3 * z + 1) / 2 *
                    Complex.Pow(Math.PI / 2 * z, 2);
        }
    }

    public static class MathExt
    {
        public static double Cycle(double x, double cycle, double fade = 2000)
        {
            var cycleVal = Math.Cos(Math.PI * x / cycle);

            var cyclePowBase = Math.Pow(fade, .5 * cycle) * (1 + Math.Log10(cycle));
            var cyclePow = fade * Math.Log(fade, cyclePowBase);

            // Console.WriteLine(Math.Pow(Math.Abs(cycleVal), cyclePow));
            return Math.Pow(Math.Abs(cycleVal), cyclePow);
        }

        public static T Map<T>(this T value, T fromMin, T fromMax, T toMin, T toMax)
            where T : INumber<T>
        {
            return toMin + (value - fromMin) / (fromMax - fromMin) * (toMax - toMin);
        }

        public static TOut MapAs<TIn, TOut>(this TIn value, TIn fromMin, TIn fromMax, TIn toMin, TIn toMax)
            where TIn : INumber<TIn>, IConvertible
            where TOut : INumber<TOut>, IConvertible
        {
            TIn result = Map(value, fromMin, fromMax, toMin, toMax);

            // return (TOut)Convert.ChangeType(result, typeof(TOut))!;
            return TOut.CreateChecked(result);
        }

        public static T Mesh<T>(this T left, T right)
            where T : INumber<T>
        {
            return T.Clamp(left * right, T.Zero, T.One);
        }

        public static T Weaken<T>(this T value, T strength)
            where T : INumber<T>
        {
            return Map(value, T.Zero, T.One, strength, T.One);
        }

        public static Color AsSixLaborColor(this ColorSpace colorSpace)
        {
            var rgb = colorSpace.ToRgb();
            return Color.FromRgb((byte)rgb.R, (byte)rgb.G, (byte)rgb.B);
        }

        public static Vector3<T> MapComplexByAxisUsage<T>(this Complex _z, AxisUsage axis)
            where T : INumber<T>, IFormattable
        {
            T x = T.Zero;
            T y = T.Zero;
            T z = T.Zero;

            T re = T.CreateChecked(_z.Real);
            T im = T.CreateChecked(_z.Imaginary);

            switch (axis)
            {
                case AxisUsage.XZ:
                    x = re;
                    z = im;
                    break;
                case AxisUsage.ZX:
                    z = re;
                    x = im;
                    break;
                case AxisUsage.XY:
                    x = re;
                    y = im;
                    break;
                case AxisUsage.YX:
                    y = re;
                    x = im;
                    break;
                case AxisUsage.YZ:
                    y = re;
                    z = im;
                    break;
                case AxisUsage.ZY:
                    z = re;
                    y = im;
                    break;
            }

            return new Vector3<T>(x, y, z);
        }

        public static Complex MapVector3ByAxisUsage<T>(this Vector3<T> vec, AxisUsage axis)
            where T : INumber<T>, IFormattable
        {
            T re = T.Zero, im = T.Zero;

            switch (axis)
            {
                case AxisUsage.XZ:
                    re = vec.x;
                    im = vec.z;
                    break;
                case AxisUsage.ZX:
                    re = vec.z;
                    im = vec.x;
                    break;
                case AxisUsage.XY:
                    re = vec.x;
                    im = vec.y;
                    break;
                case AxisUsage.YX:
                    re = vec.y;
                    im = vec.z;
                    break;
                case AxisUsage.YZ:
                    re = vec.y;
                    im = vec.z;
                    break;
                case AxisUsage.ZY:
                    re = vec.z;
                    im = vec.y;
                    break;
            }

            return new Complex(Convert.ToDouble(re), Convert.ToDouble(im));
        }

        public enum AxisUsage
        {
            XZ, ZX,
            XY, YX,
            YZ, ZY
        }

        public enum Direction
        {
            Up, Right, Down, Left
        }

        public static Point MoveDirection(this Point pt, Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    pt.Offset(0, -1);
                    break;

                case Direction.Right:
                    pt.Offset(1, 0);
                    break;

                case Direction.Down:
                    pt.Offset(0, 1);
                    break;

                case Direction.Left:
                    pt.Offset(-1, 0);
                    break;
            }

            return pt;
        }

        public static Direction RotateDirection(this Direction dir, bool counterClockwise = false)
        {
            if (counterClockwise)
                return (Direction)((int)(dir - 1) % 4);

            return (Direction)((int)(dir + 1) % 4);
        }

        public const double GOLDEN_RATIO = 1.618033989d;
        public const double SILVER_RATIO = 2.414213562d;
        public const double BRONZE_RATIO = 3.302775638d;

        /// <summary>
        /// The value of <see cref="MathFunctions.LambertW(Complex)"/> where value is 1.
        /// </summary>
        public const double OMEGA_CONSTANT = 0.5671432904d;
    }
}
