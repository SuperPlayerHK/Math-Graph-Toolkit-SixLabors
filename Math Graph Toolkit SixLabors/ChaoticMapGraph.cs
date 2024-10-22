using System.Numerics;

namespace Math_Graph_Toolkit_SixLabors
{
    public abstract class ChaoticMapGraph : Graph
    {
        public enum ChaoticIterationMode
        {
            /// <summary>
            /// <code>x@n+1 = f(x@n)</code>
            /// </summary>
            Discrete,

            /// <summary>
            /// <code>x += dx</code>
            /// </summary>
            Continuous,

            /// <summary>
            /// The default iteration mode.
            /// <code>x += dx * dt</code>
            /// </summary>
            ContinuousDeltaTime
        }

        public abstract double GetDeltaX(double x, double y, double z);
        public abstract double GetDeltaY(double x, double y, double z);
        public abstract double GetDeltaZ(double x, double y, double z);

        public virtual double GetDeltaT(double t) => t + dt;

        public const double dt = .01d;
        public double t { get; private set; } = 0;

        public ChaoticIterationMode chaoticIterationMode = ChaoticIterationMode.ContinuousDeltaTime;

        public sealed override Complex Generate(Complex _z, Point p)
        {
            Vector3<double> vec0 = MathExt.MapComplexByAxisUsage<double>(_z, axisUsage);

            double x = vec0.x;
            double y = vec0.y;
            double z = vec0.z;

            for (int i = 0; i < Global.iterMax; ++i)
            {
                double xt = x, yt = y, zt = z;
                
                switch (chaoticIterationMode)
                {
                    case ChaoticIterationMode.Discrete:
                        x = GetDeltaX(xt, yt, zt);
                        y = GetDeltaY(xt, yt, zt);
                        z = GetDeltaZ(xt, yt, zt);
                        break;
                    case ChaoticIterationMode.Continuous:
                        x += GetDeltaX(xt, yt, zt);
                        y += GetDeltaY(xt, yt, zt);
                        z += GetDeltaZ(xt, yt, zt);
                        break;
                    case ChaoticIterationMode.ContinuousDeltaTime:
                        x += GetDeltaX(xt, yt, zt) * dt;
                        y += GetDeltaY(xt, yt, zt) * dt;
                        z += GetDeltaZ(xt, yt, zt) * dt;
                        break;
                }

                t = GetDeltaT(t);
            }

            return MathExt.MapVector3ByAxisUsage(new Vector3<double>(x, y, z), axisUsage);
        }

        public virtual MathExt.AxisUsage axisUsage { get; } = MathExt.AxisUsage.XZ;

        public abstract override string ToString();
    }
}
