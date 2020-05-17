using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffects;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int scoreForDeath = 10;
    [SerializeField] int hits = 11;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider enemyNonTriggerBoxCollider = gameObject.AddComponent<BoxCollider>() as BoxCollider;
        enemyNonTriggerBoxCollider.isTrigger = false;

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits -= 1;
    }

    private void KillEnemy()
    {
        scoreBoard.ScoreHit(scoreForDeath);
        GameObject fx = Instantiate(deathEffects, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        
        Destroy(gameObject);
    }
}
