
namespace HexBlazorInterfaces.Structs
{
    /// <summary>
    /// structure for storing X-Y floating-point coordinates
    /// </summary>
    public struct GridPoint
    {
        public readonly double X;
        public readonly double Y;

        public GridPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
