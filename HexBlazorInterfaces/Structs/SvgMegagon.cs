﻿
namespace HexBlazorInterfaces.Structs
{
    public struct SvgMegagon
    {
        public readonly int Id;
        public readonly string D; //e.g. <path d = "M20,230 Q40,205 50,230 T90,230" />

        public SvgMegagon(int id, string d)
        {
            Id = id;
            D = d;
        }

    }
}
