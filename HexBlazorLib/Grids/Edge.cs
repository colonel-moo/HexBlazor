﻿using HexBlazorInterfaces.Structs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HexBlazorLib.Grids
{
    public class Edge
    {
        private Edge() { }

        internal Edge(GridPoint gpa, GridPoint gpb)
        {
            // get the midpoint of gpa and gpb 
            GridPoint midPoint = new GridPoint ((gpa.X + gpb.X) / 2, (gpa.Y + gpb.Y) / 2);
            ID = HashCode.Combine(midPoint.X, midPoint.Y);
            Hexagons = new Dictionary<int, Hexagon>() { };
            PointA = gpa;
            PointB = gpb;
            PathD = string.Format("M{0},{1} L{2},{3} ", PointA.X, PointA.Y, PointB.X, PointB.Y);
        }

        public int ID { get; private set; }

        public Dictionary<int, Hexagon> Hexagons { get; }

        public GridPoint PointA { get; }

        public GridPoint PointB { get; }

        public string PathD { get; private set; }

        /// <summary>
        /// determines if the given edge should be displayed as part of a megagon
        /// </summary>
        /// <returns>Boolean, true if the edge should be represented by a megagon</returns>
        public bool GetIsMegaLine()
        {
            bool isMegaLine = false;

            if (Hexagons != null && Hexagons.Count == 2)
            {
                Hexagon[] hexagons = Hexagons.Values.ToArray();
                isMegaLine = hexagons[0].MegaLocation == MegaLocation.A && hexagons[1].MegaLocation == MegaLocation.D
                          || hexagons[0].MegaLocation == MegaLocation.A && hexagons[1].MegaLocation == MegaLocation.C
                          || hexagons[0].MegaLocation == MegaLocation.A && hexagons[1].MegaLocation == MegaLocation.E

                          || hexagons[0].MegaLocation == MegaLocation.B && hexagons[1].MegaLocation == MegaLocation.E
                          || hexagons[0].MegaLocation == MegaLocation.B && hexagons[1].MegaLocation == MegaLocation.D
                          || hexagons[0].MegaLocation == MegaLocation.B && hexagons[1].MegaLocation == MegaLocation.F

                          || hexagons[0].MegaLocation == MegaLocation.C && hexagons[1].MegaLocation == MegaLocation.F
                          || hexagons[0].MegaLocation == MegaLocation.C && hexagons[1].MegaLocation == MegaLocation.E
                          || hexagons[0].MegaLocation == MegaLocation.C && hexagons[1].MegaLocation == MegaLocation.A

                          || hexagons[0].MegaLocation == MegaLocation.D && hexagons[1].MegaLocation == MegaLocation.A
                          || hexagons[0].MegaLocation == MegaLocation.D && hexagons[1].MegaLocation == MegaLocation.F
                          || hexagons[0].MegaLocation == MegaLocation.D && hexagons[1].MegaLocation == MegaLocation.B

                          || hexagons[0].MegaLocation == MegaLocation.E && hexagons[1].MegaLocation == MegaLocation.B
                          || hexagons[0].MegaLocation == MegaLocation.E && hexagons[1].MegaLocation == MegaLocation.A
                          || hexagons[0].MegaLocation == MegaLocation.E && hexagons[1].MegaLocation == MegaLocation.C

                          || hexagons[0].MegaLocation == MegaLocation.F && hexagons[1].MegaLocation == MegaLocation.C
                          || hexagons[0].MegaLocation == MegaLocation.F && hexagons[1].MegaLocation == MegaLocation.B
                          || hexagons[0].MegaLocation == MegaLocation.F && hexagons[1].MegaLocation == MegaLocation.D;
            }

            return isMegaLine;
        }

    }

}