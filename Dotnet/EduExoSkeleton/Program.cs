namespace EduExoSkeleton
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Microsoft.Extensions.Logging;
    //using System.IO.Ports;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
	    
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
		.UseUrls("http://0.0.0.0:5000")
                .UseStartup<Startup>()
                .Build();
    }

    public class ArduinoJsonRequest
    {
	[JsonProperty("command")]
        public string Command {get; set;}
	[JsonProperty("pins", NullValueHandling=NullValueHandling.Ignore)]
        public List<Pin> Pins {get; set;}
    }

    public class ArduinoResponse
    {
	[JsonProperty("status", NullValueHandling=NullValueHandling.Ignore)]
        public string Status {get; set;} //0 good, else bad
	[JsonProperty("working", NullValueHandling=NullValueHandling.Ignore)]
        public string Working {get; set;} //yes/no , started/stopped
	[JsonProperty("description", NullValueHandling=NullValueHandling.Ignore)]
        public string Description {get; set;} // little blip to print
	[JsonProperty("pins", NullValueHandling=NullValueHandling.Ignore)]
        public List<Pin> Pins {get; set;}  // in pins with states
    }

    public class Pin
    {
	[JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
        public string Name {get; set;}      //ex ... A0
	[JsonProperty("direction", NullValueHandling=NullValueHandling.Ignore)]
        public string Direction {get; set;} // in/out
	[JsonProperty("type", NullValueHandling=NullValueHandling.Ignore)]
        public string Type {get; set;}      // a/d -> analog or digital
	[JsonProperty("value", NullValueHandling=NullValueHandling.Ignore)]
        public string Value {get; set;}     //in send, all 
    }


    public enum ArduinoCommands
    {
        status, //<-  //never used, expected for response
        query,  //->
        start,  //->
        stop,   //->
        send,   //->
        config, //->
    }

}
