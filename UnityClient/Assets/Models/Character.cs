using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace models
{
    public class Character : MonoBehaviour {
        public string name;

        // Use this for initialization
        void Start() {
            DontDestroyOnLoad(this);
        }

        // Update is called once per frame
        void Update() {

        }

        public void setName(string newName)
        {
            name = newName;
        }
    }
}