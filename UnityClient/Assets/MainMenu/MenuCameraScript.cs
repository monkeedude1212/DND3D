using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour {
    public float desiredRotation;    
    public float rotationTimer = 0f;
    public float timeToRotate = 5f;

    public Vector3 desiredPosition;
    public float movingTimer = 0f;
    public float timetoMove = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs((desiredRotation - transform.rotation.eulerAngles.y)) > 0.05f)
        {
            rotationTimer += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, desiredRotation, 0), (rotationTimer / timeToRotate));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, desiredRotation, 0));
            rotationTimer = 0f;
        }

        if (Mathf.Abs((desiredPosition.x - transform.position.x)) + Mathf.Abs((desiredPosition.y - transform.position.y)) + Mathf.Abs((desiredPosition.z - transform.position.z)) > 0.05f)
        {
            movingTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, (movingTimer / timeToRotate));
        }
        else
        {
            transform.position = desiredPosition;
            movingTimer = 0f;
        }
    }
}