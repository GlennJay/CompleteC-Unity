using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPLayer : MonoBehaviour
{
    
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPLayer>().Length;
        //if more than one music player
        if(numMusicPlayers > 1)
        {
            //destroy itself
            Destroy(gameObject);
        }
        else
        {
            //else keep music player
            DontDestroyOnLoad(gameObject);
        }
        
    }
   
   
}
