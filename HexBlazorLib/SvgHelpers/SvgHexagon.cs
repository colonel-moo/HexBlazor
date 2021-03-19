using System.Linq;
using HexBlazorLib.Coordinates;

namespace HexBlazorLib.SvgHelpers
{
    /// <summary>
    /// encapsulate information useful for drawing a hexagon as SVG
    /// </summary>
    public class SvgHexagon
    {
        public readonly int ID;
        public readonly string Points;
        public readonly string StarD;

        public readonly int Row;
        public readonly int Col;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id">Supply a unique ID for SvgHexagon</param>
        /// <param name="points">The points from which to derive the SVG</param>
        /// <param name="isSelected">Flag indicating how the client might fill the polygon</param>
        public SvgHexagon(int id, int row, int col, string points, bool isSelected, string starD)
        {
            ID = id;
            Row = row;
            Col = col;
            Points = points;
            IsSelected = isSelected;
            StarD = starD;
        }

        public bool IsSelected { get; set; }

    }
}