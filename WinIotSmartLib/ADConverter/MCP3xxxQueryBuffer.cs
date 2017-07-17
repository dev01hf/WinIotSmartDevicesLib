using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public abstract class MCP3xxxQueryBuffer : IMCP3xxxBuffer
    {
        protected byte[] _Buffer;

        protected MCP3xxxAdChannel _Channel;

        public MCP3xxxQueryBuffer()
        {
            initValues();
        }

        protected void initValues()
        {
            CreateBuffer();
            _Channel = MCP3xxxAdChannel.InvalidCh;
        }

        protected byte[] CreateBuffer()
        {
            _Buffer = new byte[3] { 0x0, 0x0, 0x0 };
            return _Buffer;
        }

        public byte[] Buffer
        { get { return _Buffer; }
          protected set { _Buffer = value; }
        }

        public byte ModeByte
        { get { return _Buffer[0]; }
          protected set { _Buffer[0] = value; }
        }

        public byte ChannelByte
        { get { return _Buffer[1]; }
          protected set { _Buffer[1] = value; }
        }

        public byte NullByte
        { get { return _Buffer[2]; }
          protected set { _Buffer[2] = value; }
        }

        public MCP3xxxAdChannel Channel
        {
            get { return _Channel; }
            set
            {
                SetChannel(value);
            }
        }

        public abstract bool SetChannel(MCP3xxxAdChannel newChannel);

        public abstract int Convert2Int();

        public bool DifferentialMode
        {
            get { return (ModeByte & 0b00000010)!=0; } 
            set
            {
                if (!value)
                {
                    ModeByte |= 0b00000010;
                }
                else
                {
                    ModeByte &= 0b00000010;
                }
            }
        }

        protected bool HasStartBit
        {
            get { return (ModeByte & 0b00000100) != 0; }
            set
            {
                if (value)
                {
                    ModeByte |= 0b00000100;
                }
                else
                {
                    ModeByte &= 0b00000100;
                }
            }
        }
    }
}
