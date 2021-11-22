using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // camera will follow this object
    public Transform Target;
    //camera transform
    // offset between camera and target
    public Vector3 Offset;
    public Vector3 posTransform;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = Target.position + Offset;
        targetPosition.x = transform.position.x;
        posTransform = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        transform.position = posTransform;
    }
}
