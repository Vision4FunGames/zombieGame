using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummerDetect : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("zombie"))
        {
            transform.GetComponentInParent<HummerSctipr>().HummerRotate();
        }
    }
}
