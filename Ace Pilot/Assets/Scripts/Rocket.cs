using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rocket : MonoBehaviour
{
    //main thrust make serialized
    [SerializeField] float mainThrust;
    //rotation thrust make serialized
    [SerializeField] float rotationThrust;
    




     Rigidbody rigidBody;
     
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Thrust();

    }

    //FUNCTION thust
    //process the thrust make sure to make as frame rate independent
    void Thrust()
    {
        float frameThrust = mainThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * frameThrust);
            
        }
    }


    //FUNCTION rotation
    //process rotation make sure to make frame rate independent
    //freeze the rigidbody rotation before and after the rotation to enable and disable the physics engine

     void Rotation()
    {
        rigidBody.freezeRotation = true;
        float frameRotation = rotationThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * frameRotation);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * frameRotation);
        }
        rigidBody.freezeRotation = false;
    }
}
