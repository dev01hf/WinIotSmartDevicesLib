using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public interface IMCP3xxxBuffer
    {
        byte[] Buffer { get; }
        int Convert2Int();
    }
}
