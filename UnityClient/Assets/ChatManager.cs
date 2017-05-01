using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using models;

public class ChatManager : MonoBehaviour
{
    Character currentCharacter;

    List<string> chatLog;

    public Text chatTextBox;
    // Use this for initialization
    void Start()
    {
        chatLog = new List<string>();
        AddToChat("Initializing Chat");

        GameObject obj = GameObject.FindGameObjectWithTag("CurrentCharacter");
        if (!ReferenceEquals(obj, null))
        {
            currentCharacter = obj.GetComponent<Character>();
        }
        if (!ReferenceEquals(currentCharacter, null))
        {
            AddToChat("Welcome " + currentCharacter.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToChat(string message)
    {
        chatLog.Add(message);
        chatTextBox.text += '\n';
        chatTextBox.text += message;
    }
}
