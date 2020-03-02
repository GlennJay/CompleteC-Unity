using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
[DisallowMultipleComponent]
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
    [SerializeField] ParticleSystem rightEngine;
    [SerializeField] ParticleSystem leftEngine;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;

    //Debug bool keys
    public bool collisionEnabled;
    

    //active scene
    public int activeScene;
    //scenes in build
    public int sceneCount;
    
    

    enum State { Alive, Dead, Transcending};
    State state = State.Alive;
     Rigidbody rigidBody;
     
    // Start is called before the first frame update
    void Start()
    {
         collisionEnabled = true;
        rigidBody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = success;
         sceneCount = SceneManager.sceneCountInBuildSettings;
         activeScene = SceneManager.GetActiveScene().buildIndex;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            Rotation();
            respondToThrustInput();

        }
        if(Debug.isDebugBuild){
            RespondToDebugKeys();
        }
        

    }

     void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextScene();
        }

        if (Input.GetKey(KeyCode.C))
        {
            collisionEnabled = !collisionEnabled;
        }
        
    }

    //FUNCTION detect collisions, enemy collision trigers death, friendly collision trigers transcending
    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || !collisionEnabled) { return; }

        if(collisionEnabled){
            switch (collision.gameObject.tag)
            {
                case "enemy":
                    Dying();
                    
                    break;
                case "success":
                    Transcending();
                    
                    break;
                default:
                    break;
            }
        }
        
    }

    private void LoadNextScene() //TODO add validation if there is no more scenes
    {   
        
        
         int nextScene = activeScene + 1;
        
        if( activeScene < sceneCount -1){
            SceneManager.LoadScene(nextScene);
        }else{
             SceneManager.LoadScene(0);
        }
       
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(activeScene);
    }

    private void Transcending()
    {
        state = State.Transcending;
        audiosource.Stop();
        audiosource.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextScene",2f);
    }

    private void Dying()
    {
        state = State.Dead;
        audiosource.Stop();
        rightEngine.Stop();
        leftEngine.Stop();
        audiosource.PlayOneShot(explosion);
        deathParticles.Play();
        Invoke("ReloadScene", 2f);
    }

    //FUNCTION respond to thrust input
    void respondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
            //leftEngine.Play();
        }
        else
        {
            audiosource.Stop();
            rightEngine.Stop();
            leftEngine.Stop();

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

        if (!rightEngine.isPlaying && !leftEngine.isPlaying)
        {
            rightEngine.Play();
            leftEngine.Play();
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
