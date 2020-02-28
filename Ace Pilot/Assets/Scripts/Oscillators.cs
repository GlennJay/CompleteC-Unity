using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class Oscillators : MonoBehaviour
{
    //range for oscillation
    [SerializeField] [Range(0, 1)] float movementFactor;

    //starting position of the oscilator
    Vector3 startingPos;

    //movement factor
    [SerializeField] Vector3 movementVector;

    //time for each period
    [SerializeField] float period = 2f;

    


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }
        //time for each circle based on the time of the game
        float cycle = Time.time / period;
        const float tau = Mathf.PI * 2;

        float sinWave = Mathf.Sin(tau * cycle);
        movementFactor = sinWave / 2f + 0.5f;

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
