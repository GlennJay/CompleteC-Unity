
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Player object to follow
    public Transform targetPlayer;

    //camera speed
    public float cameraSpeed = 0.125f;

    //offset of the camera
    public Vector3 offset;

     void FixedUpdate()
    {
        Vector3 desiredPosition = targetPlayer.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(targetPlayer);
    }



}
