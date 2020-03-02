using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] float rotationSpeed;
    [SerializeField] bool vectBack;
    [SerializeField] bool vectForw;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
         rigidbody.freezeRotation = true;
        float frameRotation = rotationSpeed * Time.deltaTime;
        if(vectBack){
             transform.Rotate(Vector3.back * frameRotation, Space.World);
        }else if(vectForw){
            transform.Rotate(Vector3.forward * frameRotation, Space.World);
        }
        
           
        
      /*   else if (Input.GetKey(KeyCode.A))
        {
            
        } */
        rigidbody.freezeRotation = false;
    }
}
