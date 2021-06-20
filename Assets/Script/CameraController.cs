using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.125f;
    private Vector3 smoothedPosition { get; set; }
    

    private void FixedUpdate()
    {
        smoothedPosition = Vector3.Lerp(transform.position, target.position, smoothTime);
        transform.position = smoothedPosition;
    }
}
