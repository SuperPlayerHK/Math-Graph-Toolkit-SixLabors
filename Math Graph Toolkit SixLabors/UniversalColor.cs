using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public struct UniversalColor
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;

        public UniversalColor(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public UniversalColor(byte r, byte g, byte b) : this(r, g, b, 255) { }

        public static UniversalColor FromClamped<T>(T r, T g, T b, T a)
            where T : INumber<T>
        {
            byte _r = byte.CreateChecked(T.Clamp(r, T.Zero, T.CreateChecked(255)));
            byte _g = byte.CreateChecked(T.Clamp(g, T.Zero, T.CreateChecked(255)));
            byte _b = byte.CreateChecked(T.Clamp(b, T.Zero, T.CreateChecked(255)));
            byte _a = byte.CreateChecked(T.Clamp(a, T.Zero, T.CreateChecked(255)));

            return new UniversalColor(_r, _g, _b, _a);
        }

        // This -> Other
        public static implicit operator System.Drawing.Color(UniversalColor _this)
        {
            return System.Drawing.Color.FromArgb(_this.a, _this.r, _this.g, _this.b);
        }

        public static implicit operator SixLabors.ImageSharp.Color(UniversalColor _this)
        {
            return new Rgba32(_this.r, _this.g, _this.b, _this.a);
        }

        // Other -> This
        public static implicit operator UniversalColor(System.Drawing.Color _other)
        {
            return new UniversalColor(_other.R, _other.G, _other.B, _other.A);
        }

        public static implicit operator UniversalColor(SixLabors.ImageSharp.Color _other)
        {
            var rgba32 = (Rgba32)_other;
            return new UniversalColor(rgba32.R, rgba32.G, rgba32.B, rgba32.A);
        }
    }
}