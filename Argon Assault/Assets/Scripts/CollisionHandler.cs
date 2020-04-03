using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("OnPlayerDeath");
    }
}
