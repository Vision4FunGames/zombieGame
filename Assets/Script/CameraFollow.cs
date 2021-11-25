using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // camera will follow this object

    public float finisposx , finishposy , finishposz;
    public Transform Target;
    public Transform Target2;
    //camera transform
    // offset between camera and target
    public Vector3 Offset;
    public Vector3 posTransform;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    public bool isfinish;
    private void Start()
    {
        Offset = transform.position - Target.position;
        Target2 = Target;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = Target2.position + Offset;
        targetPosition.x = transform.position.x;
        posTransform = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        transform.position = posTransform;
        if (isfinish)
        {
            transform.LookAt(Target);
            //transform.position = Vector3.Lerp(transform.position,Target.position-new Vector3(+finisposx, -finishposy, -finishposz),0.0055f);
        }
    }
}
