using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rocket : MonoBehaviour
{
    public float mainThrust = 1f;
     Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        InputProcess();

    }

    private static void InputProcess()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.
        }

        if (Input.GetKey(KeyCode.D))
        {
            print("right");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            print("left");
        }
    }
}
