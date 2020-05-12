using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("in Seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("Particle effects on player")] [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        
    }

    private void StartDeathSequence()
    {

        gameObject.SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        //loop back if at the end of the scenes
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }


        SceneManager.LoadScene(nextSceneIndex);

    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
