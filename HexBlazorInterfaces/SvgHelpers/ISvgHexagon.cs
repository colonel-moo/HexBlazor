﻿
namespace HexBlazorInterfaces.SvgHelpers
{
    public interface ISvgHexagon
    {
        int ID { get; }
        string Points { get; }
        string CenterD { get; }
        int Row { get; }
        int Col { get; }

        bool IsSelected { get; set; }

    }
}
