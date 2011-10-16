using System.Runtime.InteropServices;

namespace NME2.Domain.SimConnect
{
    // this is how you declare a data structure so that
    // simconnect knows how to fill it/read it.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct StructCoordinates
    {
        // this is how you declare a fixed size string
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public double latitude;
        public double longitude;
    };
}