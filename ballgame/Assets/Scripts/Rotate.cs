using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of rotation in degrees per second

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}