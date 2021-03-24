﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace HexBlazorInterfaces.Structs
{
    /// <summary>
    /// structure to store the cubic coordinates for a Hexagon, provide math operations, calculate distances, etc. within an arbitrary grid
    /// </summary>
    public struct CubicCoordinate : IEquatable<CubicCoordinate>
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        public CubicCoordinate(int x, int y, int z)
        {
            if (x + y + z != 0) throw new ArgumentException("Sum of x + y + z must be 0");

            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// all the cubes that touch this one
        /// </summary>
        public static CubicCoordinate[] GetAdjacents(CubicCoordinate center)
        {
            CubicCoordinate[] offsets = new CubicCoordinate[]
                {
                    new CubicCoordinate(1, -1, 0),
                    new CubicCoordinate(1, 0, -1),
                    new CubicCoordinate(0, 1, -1),
                    new CubicCoordinate(-1, 1, 0),
                    new CubicCoordinate(-1, 0, 1),
                    new CubicCoordinate(0, -1, 1)
                };

            var adjacents = new CubicCoordinate[6];
            for (int i = 0; i < 6; i++)
            {
                adjacents[i] = center + offsets[i];
            }

            return adjacents;
        }

        /// <summary>
        /// returns the distance from this cube to a target
        /// </summary>
        /// <param name="target">the distant cube to check</param>
        /// <returns>Int32</returns>
        public int GetDistanceTo(CubicCoordinate target)
        {
            return GetDistance(this, target);
        }

        /// <summary>
        /// returns distance between two cubes
        /// </summary>
        /// <param name="source">starting cube</param>
        /// <param name="target">ending cube</param>
        /// <returns>Int32</returns>
        public static int GetDistance(CubicCoordinate source, CubicCoordinate target)
        {
            // for each dimension get the absolute value of the difference between this cube and the target
            // the maximum of these values is the distance to the target cube
            return Math.Max(Math.Abs(source.X - target.X), Math.Max(Math.Abs(source.Y - target.Y), Math.Abs(source.Z - target.Z)));
        }

        // other useful algorithms:
        // cubes within distance?
        // cubes at an exact distance (ring)?
        // path to distant cube?
        // all cubes on a line between this and distant cube?

        #region Cube Arithmetic

        public static CubicCoordinate operator +(CubicCoordinate a) => a;

        public static CubicCoordinate operator -(CubicCoordinate a) => new CubicCoordinate(-a.X, -a.Y, -a.Z);

        public static CubicCoordinate operator +(CubicCoordinate a, CubicCoordinate b)
            => new CubicCoordinate(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static CubicCoordinate operator -(CubicCoordinate a, CubicCoordinate b)
            => new CubicCoordinate(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static CubicCoordinate operator *(CubicCoordinate a, int k)
        => new CubicCoordinate(a.X * k, a.Y * k, a.Z * k);

        #endregion

        #region Equality and Hashcode overrides

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override bool Equals(object obj)
        {
            return Equals((CubicCoordinate)obj);
        }

        public bool Equals([AllowNull] CubicCoordinate other)
        {
            return other.X == X &&
                   other.Y == Y &&
                   other.Z == Z;
        }

        public static bool operator ==(CubicCoordinate left, CubicCoordinate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CubicCoordinate left, CubicCoordinate right)
        {
            return !(left == right);
        }

        #endregion

    }

    /// <summary>
    /// floating point value cubic coordinates, useful for rounding and linear interpolation
    /// </summary>
    public struct CubeF
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;

        public CubeF(double x, double y, double z)
        {
            if (Math.Round(x + y + z) != 0) throw new ArgumentException("x + y + z must == 0");

            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// use this to figure out which (integer) cube an arbitrary set of floating point cubic coordinates belongs to
        /// </summary>
        /// <returns>Cube</returns>
        public CubicCoordinate Round()
        {
            int x = (int)Math.Round(X);
            int y = (int)Math.Round(Y);
            int z = (int)Math.Round(Z);

            double x_diff = Math.Abs(x - X);
            double y_diff = Math.Abs(y - Y);
            double z_diff = Math.Abs(z - Z);

            if (x_diff > y_diff && x_diff > z_diff)
            {
                x = -y - z;
            }
            else if (y_diff > z_diff)
            {
                y = -x - z;
            }
            else
            {
                z = -x - y;
            }

            return new CubicCoordinate(x, y, z);
        }
    }

}
