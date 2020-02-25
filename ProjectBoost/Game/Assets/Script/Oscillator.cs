using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour //for moving platforms
{

[SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f); //where the object will move

//TODO remove from inspector
[Range(0,1)][SerializeField]float movementFactor; // 0 for not moved, 1 for fully moved

Vector3 startPos;
    [SerializeField] float period = 2f; //time it takes to complete one full cycles


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;//get starting position of the game object
    }

    // Update is called once per frame
    void Update()
    {
        //set movement factor
        float cycles = Time.time / period; //grows continually from zero
        const float tua = Mathf.PI * 2; //about 6.28
        float rawSinWave = Mathf.Sin(cycles * tua);
        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offSet = movementFactor * movementVector;
        transform.position = startPos + offSet;
        
    }
}
