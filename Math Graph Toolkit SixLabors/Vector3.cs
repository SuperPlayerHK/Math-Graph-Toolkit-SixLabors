using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public struct Vector3<T>
        where T : INumber<T>
    {
        public T x;
        public T y;
        public T z;

        public Vector3(T x, T y, T z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(T val)
        {
            this.x = val;
            this.y = val;
            this.z = val;
        }

        public static readonly Vector3<T> unitX = new Vector3<T>(T.One, T.Zero, T.Zero);
        public static readonly Vector3<T> unitY = new Vector3<T>(T.Zero, T.One, T.Zero);
        public static readonly Vector3<T> unitZ = new Vector3<T>(T.Zero, T.Zero, T.One);

        public override string ToString() =>
            $"<{x} {y} {z}>";
    }
}
