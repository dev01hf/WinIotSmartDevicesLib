using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public class MCP320xResultBuffer : MCP3xxxResultBuffer
    {
        public MCP320xResultBuffer():base()
        {
        }

        public override int Convert2Int()
        {
            _Result = _Buffer[1] & 0x0F;
            _Result <<= 8;
            _Result += _Buffer[2];

            _Buffer = null;

            return _Result;
        }
    }
}
