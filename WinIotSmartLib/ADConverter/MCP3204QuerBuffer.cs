using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public class MCP3204QuerBuffer : MCP3xxxQueryBuffer
    {
        public MCP3204QuerBuffer():base()
        {
        }

        public override int Convert2Int()
        {
            return -1;
        }

        public override bool SetChannel(MCP3xxxAdChannel newChannel)
        {
            bool result = false;

            if ((int)newChannel<=3)
            {
                _Channel = newChannel;

                switch (newChannel)
                {
                    case MCP3xxxAdChannel.Ch0:
                        ChannelByte = 0b00000000;
                        break;
                    case MCP3xxxAdChannel.Ch1:
                        ChannelByte = 0b01000000;
                        break;
                    case MCP3xxxAdChannel.Ch2:
                        ChannelByte = 0b10000000;
                        break;
                    case MCP3xxxAdChannel.Ch3:
                        ChannelByte = 0b11000000;
                        break;
                }

                HasStartBit = true;
                result = true;
            }
            else
            {
                initValues();
                throw new System.ArgumentException("MCP3204 allows only channel Ch0 - Ch3, Requested: " + newChannel.ToString() , "newChannel");
            }

            return result;
        }
    }
}
