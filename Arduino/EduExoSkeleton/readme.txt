This program should really just accept a configuration,
toggle working and stoppped, when queried report status 
and data for all configured inputs,
and while working, accept output commands.

command overview
 * status <-
 * query ->
 * start ->
 * stop ->
 * send ->
 * config ->
commands from arduino to pc

Transmission
 * Transamission should follow the following format
 [stx][json_message][etx][lrc]
this is for both 'to' and 'from' transmissions
lrc should be checked from position 1, that is skipping the stx...


just one...
status - response to query
{
        "status" : "0"
	"working" : "0"
        "description" : "a little bit about the state, could be printed to the console..."
	"pins_in" : 
	{
		"A0" : "value"
		...
	}
}

status == 0 ? good : not good
working == 0 ? started : stopped

commands from pc to arduino

*general format - a little bit like json rpc2.0
{
        "command" : "command_name"
} //additional things as well

query - get status
{
        "command" : "query"
}

start - start working * ignore if working
{
        "command" : "start"
}

stop - stop working * ignore while stopped
{
        "command" : "stop"
}

send - pin and data, repeast message to persist sending
  command==send ? look for pins_out : something else or nothing at all
  * only accept while started, error response
{
        "command" : "send"
        "pins_out" :
        {
                "A1" : "value"
                ...
        }
}


config - if command==config, look for config
 * only accept while stopped, error resposne

Analog pins can be used a digital, but not vice versa

{
        "command" : "config"
        "config" :
        {
		"pins" : 
		[{
			"pin" : "A0"
			"type" : "a"
			"direction" : "in"
		},{
			...
		}]
	}
}
config pin entry specs
 - pin  -  the pin name, will match string and coorespond to a constant
 - type - a=analog (must be like 'A*'), d=digital, can be any...? (I think)
 - direction - in or out

