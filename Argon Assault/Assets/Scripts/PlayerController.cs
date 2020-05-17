﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    //to-do find out why the first reload loads slow

    // Start is called before the first frame update
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 4f;
    [Tooltip("In meter")][SerializeField] float xRange = 7f;
    [SerializeField] GameObject[] guns;

    //[Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In meter")] [SerializeField] float yMinRange = -3.73f;
    [Tooltip("In meter")] [SerializeField] float yMaxRange = 3.8f;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -0.44f;
    [SerializeField] float positionYawFactor = 0.13f;


    [Header("Screen-Control Based")]
    [SerializeField] float controlPitchFactor = 1.28f;
    [SerializeField] float controlRollFactor = -25.85f;

    
   
    float yThrow, xThrow;
    bool IsControlsEnabled = true;
    



    void Start()
    {
        
        
    }
    void OnPlayerDeath() //called by string reference
    {
        //disable controls and start death sequence
        IsControlsEnabled = false;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(IsControlsEnabled)
        {
           ProcessTranslation();
           ProcessRotation();
            ProcessFiring();
        }
        
    }

     void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
        
    }
    private void ActivateGuns()
    {
       foreach(GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }
    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
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
        //getting input from player
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //getting the offset based on the speed and framerate
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffSet = yThrow * controlSpeed * Time.deltaTime;

        //raw position that may or may not be inside screen
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffSet;

        //keeping a range to stay in screen
        float yClampRnage = Mathf.Clamp(rawYPos, yMinRange, yMaxRange);
        float XClampRange = Mathf.Clamp(rawXPos, -xRange, xRange);



        //taking the local position of the ship and adding the offset to move the ship


        //setting the local position off the clamped ranged
        transform.localPosition = new Vector3(XClampRange, yClampRnage, transform.localPosition.z);

    }

    
}
