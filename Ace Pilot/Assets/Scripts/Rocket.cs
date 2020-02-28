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
    AudioSource audiosource;
    [SerializeField] AudioClip engine;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip success;

    enum State { Alive, Dead, Transcending};
    State state = State.Alive;
     Rigidbody rigidBody;
     
    // Start is called before the first frame update
    void Start()
    {
         
        rigidBody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = success;

    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Alive)
        {
            Rotation();
            respondToThrustInput();
        }
       

    }

    //FUNCTION detect collisions, enemy collision trigers death, friendly collision trigers transcending
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "enemy":
                audiosource.Stop();
                audiosource.PlayOneShot(explosion);
                break;
            case "success":
                audiosource.Stop();
                audiosource.PlayOneShot(success);
                break;
            default:
                break;
        }
    }

    //FUNCTION respond to thrust input
    void respondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }
        else
        {
            audiosource.Stop();

        }

    }



    //FUNCTION thust
    //process the thrust make sure to make as frame rate independent
    void Thrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(engine);
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
