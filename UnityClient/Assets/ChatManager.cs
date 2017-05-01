using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using models;

public class ChatManager : NetworkBehaviour
{
    Character currentCharacter;

    List<string> chatLog;

    public Text chatTextBox;
    // Use this for initialization
    void Start()
    {
        chatLog = new List<string>();
        RpcReceiveChat("Initializing Chat");

        GameObject obj = GameObject.FindGameObjectWithTag("CurrentCharacter");
        if (!ReferenceEquals(obj, null))
        {
            currentCharacter = obj.GetComponent<Character>();
        }
        if (!ReferenceEquals(currentCharacter, null))
        {
            RpcReceiveChat("Welcome " + currentCharacter.name);
        }
        else
        {
            Debug.Log("No Character!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    [ClientRpc]
    public void RpcReceiveChat(string message)
    {
        // Only called on one of the clients
        Debug.Log("Got chat message: " + message);
        chatLog.Add(message);
        chatTextBox.text += '\n';
        chatTextBox.text += message;
    }
}
