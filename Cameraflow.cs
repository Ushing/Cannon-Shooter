using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraflow : MonoBehaviour
{
    public Transform targer;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 distance = targer.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, distance, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(targer);
    }
}
