﻿using HexBlazorInterfaces.Structs;

namespace HexBlazorInterfaces.SvgHelpers
{
    public interface ISvgPathDFactory
    {
        enum Style
        {
            Star
        }

        string GetPathD(Style style, GridPoint origin, double size);

    }

    /// <summary>
    /// interface for Path Getter helper classes
    /// </summary>
    public interface ISvgPathDGetter
    {
        string GetPathD(GridPoint origin, double size);
    }

}
