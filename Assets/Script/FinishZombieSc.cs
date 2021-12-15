using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZombieSc : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    ShootDetect shootdetect;
    public bool isDead;
    void Start()
    {
        anim = GetComponent<Animator>();
        shootdetect = FindObjectOfType<ShootDetect>();
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
        anim.speed = 0.5f;
    }

    void FixedUpdate()
    {
        if(!isDead)
        {
            Vector3 dir = shootdetect.transform.position - transform.position;
            transform.Translate(Vector3.forward * 0.6f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishPoint"))
        {
            GameManager.Instance.failGame();
        }
    }
}
