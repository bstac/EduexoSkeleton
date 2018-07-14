namespace Program
{

using System;
using System.IO;
using System.IO.Ports;

class Program
{
    //MSBuild.exe 
    static void Main()
    {
        SerialPort port = new SerialPort("COM4",9600, Parity.None, 8, StopBits.One);
	string inny = "start";
	Console.WriteLine("type x to exit");
	port.Open();
	while(!inny.Contains("x"))
	{
		inny = Console.ReadLine();
		if(port.BytesToRead > 0)
      		{   
          		byte[] inbyte = new byte[1];
          		port.Read(inbyte, 0, 1);
          		if (inbyte.Length > 0)
          		{
              			byte value = (byte)inbyte.GetValue(0);
              			//do other necessary processing you may want.
				Console.WriteLine(value);
          		}
      		}
	}
	port.Close();
    }
}
}