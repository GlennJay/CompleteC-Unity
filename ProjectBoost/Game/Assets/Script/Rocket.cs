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
     [SerializeField] AudioClip mainEngine;
     [SerializeField] AudioClip death;
     [SerializeField] AudioClip success;
     
     
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
        audioSource.clip = success;
       
         
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(state == State.Alive){            
            RespondToRotateInput();
            RespondToThrustInput();
        }else if(state == State.Dying){ // TODO stop sound on death
           
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
            Dying();
            break;
            case "Finished": //player wins ang goes to the next level
                StartSuccess();
                break;
            default:
            break;

   }
}

    private void StartSuccess()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", 1f);
    }

    void Dying(){
     state = State.Dying;
    audioSource.Stop();  
    audioSource.PlayOneShot(death);  
    Invoke("LoadActiveLevel", 1f);
}
    private void LoadActiveLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextLevel()
    {
        
        SceneManager.LoadScene(currentScene + 1);
    }

    private void RespondToRotateInput()
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

    private void RespondToThrustInput()
    {
        //relative force allows the changes to change on local scope in game
       if(Input.GetKey(KeyCode.Space))
        { //can thrust while rotating
            ApplyThrust();
        }
        else
        {
            audioSource.Stop(); //stop audio based of space key
        }


    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }
}
