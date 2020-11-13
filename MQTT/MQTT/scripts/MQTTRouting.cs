

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt.Messages;
using UnityEngine.UI;

public class MQTTRouting : MonoBehaviour
{
    //Text box to add notes for future me who has forgotten everything
    [Multiline]
    public string explainWhatIAm = "Describe how this script is used";


    //Test text output from received input
    private Text objectLabel;
    public TMPro.TextMeshPro myText;
    public int charactersFromtheLeft = 26;
    public string Topic1 = "DRL/ProjectionMap/Control/";
    public string ListenForMe1;
    public string Incoming1 = "FirstMessageTopic";
    public bool Messagebool1;

    void Update()
    {
        //updateReceivedMessage();
        myText.text = " Incoming Message is: " + Incoming1;
    }

    public void routeMessage(MqttMsgPublishEventArgs MqttMessage)
   {
      try
      {
         //Route infomation about cords and active tracking to the correct ID track object;

         // OC/TrackingPeople/IDs/{ID}/X, y, active
         if (MqttMessage.Topic.Contains(Topic1))
         {
                Debug.Log("Topic1 Detected");
            //Get the ID out of the topic
            string substring = MqttMessage.Topic.Substring(charactersFromtheLeft);
              //  Debug.Log("The location of the substring is " +substring);
                //int ID = Parse(substring.Substring(0, substring.IndexOf('/')));
                int lastSlashToCheck = Topic1.LastIndexOf("/") + 1;
              //  Debug.Log("The value of lastSlashToCheck is " + Topic1.Substring(lastSlashToCheck, Topic1.Length - lastSlashToCheck));
                //If position then store the position into the vector2 position for the trackobject
               // if (Topic1.Substring(lastSlashToCheck, Topic1.Length - lastSlashToCheck) == ListenForMe1)
                    string Messagestring = System.Text.Encoding.UTF8.GetString(MqttMessage.Message);

               if (Messagestring == ListenForMe1) //if using this as a trigger.remove to print whatever comes in on the topic.
               {
                    Debug.Log("ListenForMe1 Detected");
                    //string Messagestring = System.Text.Encoding.UTF8.GetString(MqttMessage.Message);
                    Incoming1 = Messagestring;
                    Messagebool1 = true;
                  //  myText.text = " Incoming Message is: " + Incoming1;
                 //   updateReceivedMessage();

            }
         }
      }
      catch (System.Exception e)
      {
         Debug.LogError("Error Routing Of MQTT: " + e);
      }
       
    }
    
 
    
    public void updateReceivedMessage()
    {
       // Debug.Log("Inside updateReceivedMessage Now");
        myText.text = " Incoming Message is: " + Incoming1;
    }
}
