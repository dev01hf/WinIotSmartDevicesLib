using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public enum SpiClockFrequency
    {
        f488khz = 488280
         , f1Mhz = 976562
         , f2Mhz = 1953125
         , f3P6Mhz = 3472222
    }

    public enum SpiCsLine
    {
        Cs0Pin24 = 0
        , Cs1Pin26 = 1
    }

    public enum MCP3xxxAdChannel
    {
        Ch0 = 0
        , Ch1 = 1
        , Ch2 = 2
        , Ch3 = 3
        , Ch4 = 4
        , Ch5 = 5
        , Ch6 = 6
        , Ch7 = 7
        , InvalidCh = 99
    }

}
