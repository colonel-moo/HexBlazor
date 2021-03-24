using HexBlazorInterfaces.Structs;
using HexBlazorInterfaces.SvgHelpers;
using HexBlazorLib.Grids;
using System.Collections.Generic;
using System.Linq;

namespace HexBlazorLib.SvgHelpers
{
    public sealed class SvgGridBuilder
    {

        public static SvgGrid Build(Grid grid, SvgViewBox viewBox)
        {
            Dictionary<int, ISvgHexagon> svgHexagons = GetSvgHexagons(grid.Hexagons.Values.ToArray());
            Dictionary<int, SvgMegagon> svgMegagons = GetSvgMegagons(grid.Edges.Values.ToArray());

            return new SvgGrid(svgHexagons, svgMegagons, viewBox);
        }

        private static Dictionary<int, ISvgHexagon> GetSvgHexagons(Hexagon[] hexagons)
        {
            Dictionary<int, ISvgHexagon> svgHexagons = new Dictionary<int, ISvgHexagon>();

            // get the SVG data for each hexagon
            foreach (Hexagon h in hexagons)
            {
                string points = string.Join(" ", h.Points.Select(p => string.Format("{0},{1}", p.X, p.Y)));
                svgHexagons.Add(h.ID, new SvgHexagon(h.ID, h.Row, h.Col, points, true, string.Empty));
            }

            return svgHexagons;
        }

        private static Dictionary<int, SvgMegagon> GetSvgMegagons(Edge[] edges)
        {
            Dictionary<int, SvgMegagon> svgMegagons = new Dictionary<int, SvgMegagon>();

            // build the SvgMegagons
            foreach (Edge edge in edges)
            {
                if (edge.GetIsMegaLine())
                {
                    // add a new SvgMegagon
                    svgMegagons.Add(edge.ID, new SvgMegagon(edge.ID, edge.PathD));
                }
            }

            return svgMegagons;
        }

    }
}