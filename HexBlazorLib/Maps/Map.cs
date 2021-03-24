﻿//using System.Collections.Generic;
//using HexBlazorLib.Grids;
//using HexBlazorLib.SvgHelpers;

//namespace HexBlazorLib.Maps
//{
//    public class Map
//    {
//        private Map() { }

//        internal Map(Grid grid)
//        {
//            GridHexagons = grid.Hexagons;
//            MapHexagons = new HexDictionary<int, Hexagon>();
//            Edges = new Dictionary<int, GridEdge>(grid.Edges);

//            MapHexagons.OnDictionaryAddItem += AddingHexagon;
//            MapHexagons.OnDictionaryRemoveItem += RemovingHexagon;
//            MapHexagons.OnDictionaryClear += ClearingHexagons;

//            SvgHexagons = new Dictionary<int, SvgHexagon>();
//            SvgMegagons = new Dictionary<int, SvgMegagon>();

//            foreach (Hexagon h in grid.Hexagons.Values)
//            {
//                MapHexagons.Add(h.ID, h);
//            }

//            //// get the SVG data for hexagons
//            //foreach (Hexagon h in MapHexagons.Values)
//            //{
//            //    SvgHexagons.Add(h.ID, new SvgHexagon(h.ID, h.OffsetLocation.Row, h.OffsetLocation.Col, h.Points));
//            //}


//            //// build the SvgMegagons
//            //foreach (GridEdge edge in Edges.Values)
//            //{
//            //    if (SvgMegagonsFactory.GetEdgeIsMegaLine(edge))
//            //    {
//            //        // add a new SvgMegagon
//            //        SvgMegagons.Add(edge.ID, new SvgMegagon(edge.ID, SvgMegagonsFactory.GetPathD(edge)));
//            //    }
//            //}
//        }

//        public Dictionary<int, SvgHexagon> SvgHexagons { get; }
//        public Dictionary<int, SvgMegagon> SvgMegagons { get; }

//        public void AddHexagon(int ID)
//        {
//            if (MapHexagons.ContainsKey(ID) == false)
//                MapHexagons.Add(ID, GridHexagons[ID]);
//        }

//        public void RemoveHexagon(int ID)
//        {
//            if (MapHexagons.ContainsKey(ID))
//                MapHexagons.Remove(ID);
//        }

//        #region Manage Hexagons

//        private Dictionary<int, GridEdge> Edges { get; }

//        private HexDictionary<int, Hexagon> MapHexagons { get; set; }

//        private Dictionary<int, Hexagon> GridHexagons { get; set; }

//        private void AddingHexagon(object sender, DictionaryChangingEventArgs<int, Hexagon> e)
//        {
//            var hex = e.Value;
//            SvgHexagons.Add(e.Key, new SvgHexagon(e.Key, hex.OffsetLocation.Row, hex.OffsetLocation.Col, hex.GetSvgPoints(), true, hex.GetStarD()));

//            // update the map's edges and revise the SvgMegagons as necessary
//            foreach (GridEdge edge in hex.Edges)
//            {
//                if (Edges.ContainsKey(edge.ID))
//                {
//                    if (Edges[edge.ID].Hexagons.ContainsKey(e.Key) == false)
//                        Edges[edge.ID].Hexagons.Add(e.Key, hex);

//                    if (SvgMegagonsFactory.GetEdgeIsMegaLine(Edges[edge.ID]) &&
//                        SvgMegagons.ContainsKey(edge.ID) == false)
//                        SvgMegagons.Add(edge.ID, new SvgMegagon(edge.ID, SvgMegagonsFactory.GetPathD(edge)));
//                }
//            }
//        }

//        private void RemovingHexagon(object sender, DictionaryChangingEventArgs<int, Hexagon> e)
//        {
//            var hex = e.Value;
//            SvgHexagons.Remove(e.Key);

//            // update the map's edges and revise the SvgMegagons as necessary
//            foreach (GridEdge edge in hex.Edges)
//            {
//                if (Edges.ContainsKey(edge.ID))
//                {
//                    if (Edges[edge.ID].Hexagons.ContainsKey(e.Key))
//                        Edges[edge.ID].Hexagons.Remove(e.Key);

//                    if (SvgMegagonsFactory.GetEdgeIsMegaLine(Edges[edge.ID]) == false
//                        && SvgMegagons.ContainsKey(edge.ID))
//                        SvgMegagons.Remove(edge.ID);
//                }
//            }
//        }

//        private void ClearingHexagons(object sender, DictionaryChangingEventArgs<int, Hexagon> e)
//        {
//            SvgHexagons.Clear();
//            SvgMegagons.Clear();
//        }

//        #endregion

//    }

//}