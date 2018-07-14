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
		try
		{
			var x = int.Parse(inny);
			if(x>80 && x< 350)
			{
				port.Write(new byte[] { (byte) x}, 0, 1);	
			}
			else
			{
				Console.WriteLine(inny + " not good");
			}
		}
		catch
		{
			Console.WriteLine(inny + " not good");
		}
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