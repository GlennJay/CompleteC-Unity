using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{


    Scene activeScene;
    // Start is called before the first frame update
    void Start()
    {
         activeScene = SceneManager.GetActiveScene();
        print(activeScene.buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("LoadMainScreen", 5.0f);
    }


     public void LoadMainScreen()
    {
        SceneManager.LoadScene(activeScene.buildIndex + 1);
        Debug.Log(activeScene.buildIndex);

    }
}
