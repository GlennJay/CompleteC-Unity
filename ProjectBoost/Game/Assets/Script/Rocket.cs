using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
     AudioSource audioSource;
     [SerializeField] float rcsThrust = 100f; //float for rotation thrust
     [SerializeField] float mainThrust = 50f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); //rigidbody of the rocket ship
        audioSource = GetComponent<AudioSource>(); //audio for thrust
        rigidBody.mass = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }

void OnCollisionEnter(Collision collision){
   switch(collision.gameObject.tag){
       case "Friendly":
       //do nothing
            break;

       default:
       //dead if hits walls
       print("dead");
            break;
   }
}

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //takes manual control of the rocket
        float rotationThisFrame = rcsThrust * Time.deltaTime; //frame rate independent
        
        if(Input.GetKey(KeyCode.A)){ //rotate right
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }else if(Input.GetKey(KeyCode.D)){ //rotate left
            transform.Rotate(Vector3.back * rotationThisFrame);
        }
        rigidBody.freezeRotation = false; //resume physics control on rotation
    }

    private void Thrust()
    {
        //relative force allows the changes to change on local scope in game
       if(Input.GetKey(KeyCode.Space)){ //can thrust while rotating
         rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if(!audioSource.isPlaying){
            audioSource.Play();
       }
        }else{
            audioSource.Stop(); //stop audio based of space key
        }


    }
}
