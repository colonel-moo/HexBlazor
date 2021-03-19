using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HexBlazorLib.SvgHelpers
{
    public class SvgGrid
    {
        private SvgGrid() { }

        public SvgGrid(Dictionary<int, SvgHexagon> hexagons, Dictionary<int, SvgMegagon> megagons)
        {
            SvgHexagons = hexagons;
            SvgMegagons = megagons;
        }

        [JsonIgnore]
        public Dictionary<int, SvgHexagon> SvgHexagons { get; private set; }

        public List<KeyValuePair<int, SvgHexagon>> SvgHexList
        {
            get { return SvgHexagons.ToList(); }
            set { SvgHexagons = value.ToDictionary(x => x.Key, x => x.Value); }
        }

        [JsonIgnore]
        public Dictionary<int, SvgMegagon> SvgMegagons { get; private set; }

        public List<KeyValuePair<int, SvgMegagon>> SvgMegaList
        {
            get { return SvgMegagons.ToList(); }
            set { SvgMegagons = value.ToDictionary(x => x.Key, x => x.Value); }
        }

    }



}
