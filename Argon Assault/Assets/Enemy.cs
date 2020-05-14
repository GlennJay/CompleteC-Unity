using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffects;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        
        AddNonTriggerBoxCollider();

    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider enemyNonTriggerBoxCollider = gameObject.AddComponent<BoxCollider>() as BoxCollider;
        enemyNonTriggerBoxCollider.isTrigger = false;

    }

    void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathEffects, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
