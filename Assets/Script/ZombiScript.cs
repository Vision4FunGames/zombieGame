using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiScript : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    public GameObject ragdollobj;
    void Start()
    {
        Invoke("startAnim", Random.Range(0, 1.5f));
    }
    public void startAnim()
    {
        anim = GetComponent<Animator>();
        int randomanimation = Random.Range(0, 2);
        switch (randomanimation)
        {
            case 0:
                anim.SetBool("run1", true);
                break;
            case 1:
                anim.SetBool("run2", true);
                break;
            default:
                break;
        }
    }

    void Update()
    {
        
    }
}
