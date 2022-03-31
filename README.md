## Call Center
This application simulates the operation of a telephone exchange, which receives calls at random intervals (every 5-10 seconds). </br>
Calls are queued, from where they are then picked up by the first free agent. Each call lasts a random amount of time (15-20 seconds).</br>

Application is responsive. Implemented logging (in this case output to the console, but can be easily changed to something else). 

Implemented command handler. Currently there are following commands: 
* to add a new operator type: </br>
``` add agent [name] ``` 

* to remove an existing operator type (note: the operator will be deleted after the existing call ends): </br>
``` remove agent [name] ```

* to add a new call type:</br>
``` add call```
