using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In meter")][SerializeField] float xRange = 7f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In meter")] [SerializeField] float yMinRange = -2;
    [Tooltip("In meter")] [SerializeField] float yMaxRange = 3;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //how far the stick moves
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        //taking the local position of the ship and adding the offset to move the ship
        float rawXPos = transform.localPosition.x + xOffset;
        float XClampRange = Mathf.Clamp(rawXPos, -xRange, xRange);

        //Implementing the y axis controlls
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffSet = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffSet;
        float yClampRnage = Mathf.Clamp(rawYPos, yMinRange, yMaxRange);




        //moving the ship based off the xoffset and leaving the y and z to their local position of the parent camera object
        transform.localPosition = new Vector3(XClampRange, yClampRnage,transform.localPosition.z) ;

       
        
        
        
    }
}
