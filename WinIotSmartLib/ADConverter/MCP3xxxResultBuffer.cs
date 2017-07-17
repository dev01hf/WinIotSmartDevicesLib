using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public abstract class MCP3xxxResultBuffer : IMCP3xxxBuffer
    {
        protected int _Result;
        protected byte[] _Buffer;

        public MCP3xxxResultBuffer()
        {
            CreateBuffer();
        }

        public byte[] Buffer
        { get { return _Buffer; }
            private set { _Buffer = value; }
        }

        public byte[] CreateBuffer()
        {
            _Buffer = new byte[3];
            return _Buffer;
        }

        public int Value
        { get { return _Result; }
          set { _Result = value; }
        }

        public abstract int Convert2Int();
    }
}
