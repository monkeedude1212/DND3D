using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

namespace DND3D.Net
{
    public class Host : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            //IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8000);
            //Socket newsock = new Socket(AddressFamily.InterNetwork,
            //                   SocketType.Stream, ProtocolType.Tcp);
            //newsock.Bind(localEndPoint);
            //newsock.Listen(10);
            //Socket client = newsock.Accept();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("Still running");
        }
    }
}
