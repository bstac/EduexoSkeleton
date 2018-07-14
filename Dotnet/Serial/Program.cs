namespace Program
{

using System;
using System.IO;
using System.IO.Ports;

class Program
{
    private const int max_buffer = 1024;
    private static string cumulative = string.Empty;
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
		while(port.BytesToRead > 0)
      		{   
          		byte[] inbyte = new byte[max_buffer];
          		port.Read(inbyte, 0, max_buffer);
          		if (inbyte.Length > 0)
          		{
				string result = System.Text.Encoding.UTF8.GetString(inbyte);
				cumulative += result;
          		}
      		}
		Console.WriteLine(cumulative );
		cumulative = string.Empty;
	}
	port.Close();
    }
}
}