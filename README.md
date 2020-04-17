# Unity_MQTT
This is an edited version of [Unity3d_MQTT](https://github.com/vovacooper/Unity3d_MQTT) by vovacooper.  
  
I have made the variables more accessable to the user along with adding a routing script to keep the routing seperate from the main MQTT scripts.
  
![UI](ReadMe_Assets/MQTT_Image1.PNG "User Interface")


###IP Address
IP of the broker.

###Broker_Port
Port of the broker

###Topic Prefix
Prefix that is added to all topics. E.g. in the example above, the topics subscriped to are: OC/TrackingPeople/IDs/#

###Topics
This is a list of all the topics you wish to subscribe too. Use # as a wildcard

