using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("In ms^-1")][SerializeField] float Speed = 4f;
    [Tooltip("In meter")][SerializeField] float xRange = 7f;

    //[Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In meter")] [SerializeField] float yMinRange = -3.73f;
    [Tooltip("In meter")] [SerializeField] float yMaxRange = 3.8f;

    [SerializeField] float positionPitchFactor = -0.44f;
    [SerializeField] float controlPitchFactor = 1.28f;

    [SerializeField] float positionYawFactor = 0.13f;
    //[SerializeField] float controlYawFactor = -3f;

    //[SerializeField] float positionRollFactor = -3f;
    [SerializeField] float controlRollFactor = -25.85f;

    float yThrow, xThrow;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

        //moving the ship based off the xoffset and leaving the y and z to their local position of the parent camera object
        

    }
    private void ProcessRotation()
    {
        //combining the input of y to go with the rotation
        float positionDueToPitchFactor = transform.localPosition.y * positionPitchFactor;
        float positionDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = positionDueToPitchFactor  + positionDueToControlThrow;

        //float positionDueToYawFactor = transform.localPosition.x * positionYawFactor;
        //float positionDueToXControlThrow = xThrow * controlYawFactor;
        float yaw = transform.localPosition.x * positionYawFactor;

        //float positionDueToRollFactor = transform.localPosition.x * positionRollFactor;
        //float positionDueToZControlThrow = xThrow * controlRollFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessTranslation()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffSet = yThrow * Speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffSet;

        float yClampRnage = Mathf.Clamp(rawYPos, yMinRange, yMaxRange);
        float XClampRange = Mathf.Clamp(rawXPos, -xRange, xRange);



        //taking the local position of the ship and adding the offset to move the ship



        transform.localPosition = new Vector3(XClampRange, yClampRnage, transform.localPosition.z);

    }

    
}
