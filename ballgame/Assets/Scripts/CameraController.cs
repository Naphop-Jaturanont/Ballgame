using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // The target the camera will follow
    public Vector3 offset;  // The offset from the target position

    void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = transform.position.y;  // Lock the camera's Y position

        // Move the camera smoothly towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
    }
}

