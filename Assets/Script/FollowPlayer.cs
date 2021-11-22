using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject followmainObj;
    public Vector3 offset;

    void Start()
    {
        offset = followmainObj.transform.position - transform.position;
        offset = new Vector3(offset.x, offset.y+0.5f, offset.z - 40f);
    }

    void Update()
    {
        transform.position = offset + followmainObj.transform.position;
    }
}
