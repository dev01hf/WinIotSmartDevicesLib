using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IoT.Lightning.Providers;
using Windows.Devices;
using Windows.Devices.Spi;

namespace WinIotSmartLib.ADConverter
{
     public class MCP3xxxConnector
    {
        protected SpiDevice SpiCtr;
        protected bool _InitComplete;

        public MCP3xxxConnector()
        {
        }

        public async Task InitSPIAsync(SpiCsLine spi_CsLine, SpiClockFrequency spi_ClockFrq)
        {
            try
            {
                _InitComplete = false;

                var settings = new SpiConnectionSettings((int)spi_CsLine);
                settings.ClockFrequency = (int)spi_ClockFrq;   
                settings.Mode = SpiMode.Mode0;      /* The ADC expects idle-low clock polarity so we use Mode0  */

                if (LightningProvider.IsLightningEnabled)
                {
                    LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
                }

                var controller = await SpiController.GetDefaultAsync();
                SpiCtr = controller.GetDevice(settings);

                _InitComplete = true;
            }

            /* If initialization fails, display the exception and stop running */
            catch (Exception ex)
            {
                throw new Exception("cannot initialize SPI", ex);
            }
        }

        public void ReadADC(IMCP3xxxBuffer Qbuffer, IMCP3xxxBuffer Rbuffer)
        {
            SpiCtr.TransferFullDuplex(Qbuffer.Buffer, Rbuffer.Buffer);                            
        }

        public int ReadAdcValue(IMCP3xxxBuffer Qbuffer, IMCP3xxxBuffer Rbuffer)
        {
            SpiCtr.TransferFullDuplex(Qbuffer.Buffer, Rbuffer.Buffer);

            return Rbuffer.Convert2Int();
        }

        public void Dispose()
        {
            if (SpiCtr != null)
            {
                SpiCtr.Dispose();
            }
        }
 }

 
}
