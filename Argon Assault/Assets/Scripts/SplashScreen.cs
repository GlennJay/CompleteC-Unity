using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{


    Scene activeScene;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
         activeScene = SceneManager.GetActiveScene();
        Invoke("LoadMainScreen", 2.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public void LoadMainScreen()
    {
        SceneManager.LoadScene(activeScene.buildIndex + 1);
       

    }
}
