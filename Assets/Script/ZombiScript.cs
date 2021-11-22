using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiScript : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        int randomanimation = Random.Range(0, 3);
        switch (randomanimation)
        {
            case 0:
                anim.SetBool("run1", true);
                break;
            case 1:
                anim.SetBool("run2", true);
                break;
            case 2:
                anim.SetBool("run3", true);
                //anim.speed = 3;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        
    }
}
