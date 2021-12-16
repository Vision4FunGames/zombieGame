using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    // camera will follow this object

    public float finisposx, finishposy, finishposz;
    public Transform Target;
    public Transform Target2;
    //camera transform
    // offset between camera and target
    public Vector3 Offset;
    public Vector3 posTransform;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;
    public bool lose;
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    public bool isfinish;
    float newpos;
    private void Start()
    {
        Offset = transform.position - Target.position;
        Target2 = Target;
    }
    public void finishpos()
    {
        transform.DOMove(Target2.position - new Vector3(+finisposx, -finishposy, -finishposz),1f).OnComplete(()=> { transform.DOMoveX(14, 1); });
      
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = Target2.position + Offset;
        //targetPosition.x = transform.position.x;
        float xpos = targetPosition.x;
        newpos = Mathf.Lerp(newpos, (Mathf.Clamp(xpos, 20, 40)), 0.065f);
        targetPosition.x = newpos;
        posTransform = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
        //posTransform.x = transform.position.x;
        if (!isfinish)
            transform.position = posTransform;
        if (isfinish)
        {
            transform.LookAt(Target2);
        }
        if (lose)
        {
            Offset = Vector3.Lerp(Offset, new Vector3(Offset.x, finishposy, -finishposz), 0.025f);
        }
    }
}
