using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
     AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); //rigidbody of the rocket ship
        audioSource = GetComponent<AudioSource>(); //audio for thrust
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)){ //can thrust while rotating
        
            Thrust();
        }else{
            audioSource.Stop(); //stop audio based of space key
        }

        if(Input.GetKey(KeyCode.A)){ //rotate right
            transform.Rotate(Vector3.forward);
        }else if(Input.GetKey(KeyCode.D)){ //rotate left
            transform.Rotate(Vector3.back);
        }
    }

    private void Thrust()
    {
        rigidBody.AddRelativeForce(Vector3.up); //relative force allows the changes to change on local scope in game
      
         if(!audioSource.isPlaying){
            audioSource.Play();
       }

    }
}
