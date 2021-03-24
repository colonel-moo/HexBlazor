using HexBlazorInterfaces.Structs;
using HexBlazorInterfaces.SvgHelpers;
using System.Collections.Generic;

namespace HexBlazorLib.SvgHelpers
{
    public class SvgGrid : ISvgGrid
    {
        private SvgGrid() { }

        public SvgGrid(IEnumerable<KeyValuePair<int, ISvgHexagon>> hexagons
                     , IEnumerable<KeyValuePair<int, SvgMegagon>> megagons
                     , SvgViewBox viewBox)
        {
            SvgHexagons = hexagons;
            SvgMegagons = megagons;
            SvgViewBox = viewBox;
        }

        public IEnumerable<KeyValuePair<int, ISvgHexagon>> SvgHexagons { get; private set; }

        public IEnumerable<KeyValuePair<int, SvgMegagon>> SvgMegagons { get; private set; }

        public SvgViewBox SvgViewBox { get; private set; }

    }



}
