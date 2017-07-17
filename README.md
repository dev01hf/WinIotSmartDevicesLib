# WinIotSmartDevicesLib
a smart device library for Windows IOT

Release 1.0
covers AD-Controller MCP3204. Your Raspberry should use lightning Provider: 
https://developer.microsoft.com/en-us/windows/iot/docs/lightningproviders

To communicate with MCP3204, it is necessary to connect your device by a SPI connection:

Raspi:3.3VDC Pin1  ->  MCP3004:VDD+VREF Pin13+14

Raspi:GND Pin6  ->  MCP3004:GND+DGND Pin7+12

Raspi:MOSI Pin19  ->  MCP3004:Din Pin9

Raspi:MISO Pin21  ->  MCP3004:Dout Pin10

Raspi:SCLK Pin23  ->  MCP3004:CLK Pin11

Raspi:CE0 or CE1 Pin24|26  ->  MCP3004:CS Pin8

Next step, reference WinIotSmartDevicesLib in your UWP project, min. version build 14393. Have a look at your project properties at application tab.

The library contains 3 building blocks(classes) to communicate with your MCP3204:
1. MCP3xxxConnector, responsible for a SPI connection. This class defines chip_enabled_Pin, clock frequency(speed), 
2. MCP3204QueryBuffer, a 3 byte buffer. This class maps your initial communication and tells the AD controller wich channel you want to read, in single or in differential mode.
3. MCP320xResultBuffer, a 3 byte buffer. A helper class to convert your buffer to an INT value.

Many options of MCP3204 are capsuled by enums and classes, so you it very comfortable to use this library.
To make initialization of these 3 classes comfortable as possible, there is Factoryclass, MCP3xxxFactory with static method CreateDeviceMCP3204().
If you want to read Channel0 with 1MHz Speed and use CE0, you can use the following Snipset:

using WinIotSmartLib.ADConverter;

...

MCP3xxxConnector _SpiConnector;

MCP3204QuerBuffer _QueryBuffer;

MCP320xResultBuffer _ResultBuffer;

// create objects async

Tuple<MCP3204QuerBuffer, MCP320xResultBuffer, MCP3xxxConnector> MCP3204 = await MCP3xxxFactory.CreateDeviceMCP3204(MCP3xxxAdChannel.Ch0, SpiCsLine.Cs0Pin24, SpiClockFrequency.f1Mhz);

_SpiConnector = MCP3204.Item3;

_QueryBuffer = MCP3204.Item1;

_ResultBuffer = MCP3204.Item2;

_SpiConnector.ReadADC(_QueryBuffer, _ResultBuffer); // send and receive data

int value = _ResultBuffer.Convert2Int(); // convert yout buffer to INT

_ResultBuffer.CreateBuffer(); // create a new buffer for another ReadADC operation

_SpiConnector.Dispose(); // if not, dispose all objects 

_QueryBuffer = null;

_ResultBuffer = null;

