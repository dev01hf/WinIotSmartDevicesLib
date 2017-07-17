using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public class MCP3208QueryBuffer : MCP3xxxQueryBuffer
    {
        public MCP3208QueryBuffer():base()
        {
        }

        public override int Convert2Int()
        {
            return -1;
        }

        public override bool SetChannel(MCP3xxxAdChannel newChannel)
        {
            bool result = false;

            if ((int)newChannel <= 7)
            {
                _Channel = newChannel;

                switch (newChannel)
                {
                    case MCP3xxxAdChannel.Ch0:
                        ChannelByte = 0b00000000;
                        ModeByte &= 0b00000110;
                        break;
                    case MCP3xxxAdChannel.Ch1:
                        ChannelByte = 0b01000000;
                        ModeByte &= 0b00000110;
                        break;
                    case MCP3xxxAdChannel.Ch2:
                        ChannelByte = 0b10000000;
                        ModeByte &= 0b00000110;
                        break;
                    case MCP3xxxAdChannel.Ch3:
                        ChannelByte = 0b11000000;
                        ModeByte &= 0b00000110;
                        break;
                    case MCP3xxxAdChannel.Ch4:
                        ChannelByte = 0b00000000;
                        ModeByte |= 0b00000001;
                        break;
                    case MCP3xxxAdChannel.Ch5:
                        ChannelByte = 0b01000000;
                        ModeByte |= 0b00000001;
                        break;
                    case MCP3xxxAdChannel.Ch6:
                        ChannelByte = 0b10000000;
                        ModeByte |= 0b00000001;
                        break;
                    case MCP3xxxAdChannel.Ch7:
                        ChannelByte = 0b11000000;
                        ModeByte |= 0b00000001;
                        break;
                }

                HasStartBit = true;
                result = true;
            }
            else
            {
                initValues();
            }

            return result;
        }
    }
}
