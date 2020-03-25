using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    Scene activeScene;
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
