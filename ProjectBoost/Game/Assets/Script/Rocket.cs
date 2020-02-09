using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); //rigidbody of the rocket ship
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)){ //can thrust while rotating
            print("thrust");
            Thrust();
        }

        if(Input.GetKey(KeyCode.A)){ //rotate right
            print("rotate right");
        }else if(Input.GetKey(KeyCode.D)){ //rotate left
            print("roate left");
        }
    }

    private void Thrust()
    {
        rigidBody.AddRelativeForce(Vector3.up); //relative force allows the changes to change on local scope in game
    }
}
