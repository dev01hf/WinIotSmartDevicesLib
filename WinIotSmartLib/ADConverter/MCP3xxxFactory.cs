using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIotSmartLib.ADConverter
{
    public class MCP3xxxFactory
    {
        public static async Task<Tuple<MCP3204QuerBuffer, MCP320xResultBuffer, MCP3xxxConnector>> CreateDeviceMCP3204(MCP3xxxAdChannel channel, SpiCsLine csLine, SpiClockFrequency frequency)
        {
            MCP3xxxConnector Connector = new MCP3xxxConnector();
            Task init = Connector.InitSPIAsync(csLine, frequency);

            MCP3204QuerBuffer QuerBuffer = new MCP3204QuerBuffer();
            QuerBuffer.DifferentialMode = false;
            QuerBuffer.SetChannel(channel);

            MCP320xResultBuffer ResultBuffer = new MCP320xResultBuffer();

            Tuple<MCP3204QuerBuffer, MCP320xResultBuffer, MCP3xxxConnector> result = new Tuple<MCP3204QuerBuffer, MCP320xResultBuffer, MCP3xxxConnector>(QuerBuffer, ResultBuffer, Connector);

            await init;           

            return result;
        }
    }
}
