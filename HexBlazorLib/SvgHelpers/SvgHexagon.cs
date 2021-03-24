using HexBlazorInterfaces.SvgHelpers;

namespace HexBlazorLib.SvgHelpers
{
    /// <summary>
    /// encapsulate information useful for drawing a hexagon as SVG
    /// </summary>
    public class SvgHexagon : ISvgHexagon
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id">Supply a unique ID for SvgHexagon</param>
        /// <param name="row">The row where this hexagon resides within a grid</param>
        /// <param name="col">The column where this hexagon resides within a grid</param>
        /// <param name="points">The points for the SVG polygon element that renders the hexagon</param>
        /// <param name="isSelected">Flag indicating how the client might fill the polygon</param>
        /// <param name="centerD">the D for the SVG path element that renders the center point of the hexagon</param>
        public SvgHexagon(int id, int row, int col, string points, bool isSelected, string centerD)
        {
            ID = id;
            Row = row;
            Col = col;
            Points = points;
            IsSelected = isSelected;
            CenterD = centerD;
        }

        public int ID { get; }
        public string Points { get; }
        public string CenterD { get; }
        public int Row { get; }
        public int Col { get; }
        public bool IsSelected { get; set; }

    }
}