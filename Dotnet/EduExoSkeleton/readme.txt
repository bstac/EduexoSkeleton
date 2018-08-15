//c# code for json requests, to be sent to mono exe and forwarded to Arduino
//look for other readmes which contain rough spec

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


