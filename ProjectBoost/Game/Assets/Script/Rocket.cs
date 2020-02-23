using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
     AudioSource audioSource;
     [SerializeField] float rcsThrust = 100f; //float for rotation thrust
     [SerializeField] float mainThrust = 50f;
     
     //current scene
     int currentScene;

     //state
     enum State {Alive, Dying, Transcending};
     State state = State.Alive;

     
    
    
    // Start is called before the first frame update
    void Start()
    {
        //active scene
        Scene scene = SceneManager.GetActiveScene();
        rigidBody = GetComponent<Rigidbody>(); //rigidbody of the rocket ship
        audioSource = GetComponent<AudioSource>(); //audio for thrust
        rigidBody.mass = 1f;
        currentScene = scene.buildIndex;
        print(scene.buildIndex);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Alive){
            Rotate();
            Thrust();
        }else if(state == State.Dying){ // TODO stop sound on death
            Dying();
        }
        
    }

void OnCollisionEnter(Collision collision){
    //retruns if the player is not alive and stops execution
    if(state != State.Alive){
        return;
    }
   switch(collision.gameObject.tag){
       case "Friendly":
       //do nothing since it is the starting point
            break;
            case "Obstacle":
                //dead if hits walls
                state = State.Dying;
                Invoke("LoadActiveLevel", 1f);
                break;
            case "Finished": //player wins ang goes to the next level
            state = State.Transcending;
                Invoke("LoadNextLevel", 1f);
                break;
            default:
        break;

   }
}

void Dying(){
    if(Input.GetKey(KeyCode.D)){ //rotate right
        transform.Rotate(Vector3.zero);
    }else if(Input.GetKey(KeyCode.A)){ //rotate left
        transform.Rotate(Vector3.zero);
    }

    if(Input.GetKey(KeyCode.Space)){ //can thrust while rotating
        rigidBody.AddRelativeForce(Vector3.zero);
        audioSource.Stop();
    }
    
         //stop audio based of space key
    
    
    
        
}
    private void LoadActiveLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //takes manual control of the rocket
        float rotationThisFrame = rcsThrust * Time.deltaTime; //frame rate independent
        if(Input.GetKey(KeyCode.D)){ //rotate right
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }else if(Input.GetKey(KeyCode.A)){ //rotate left
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
