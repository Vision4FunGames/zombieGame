using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBomb : MonoBehaviour
{
    public GameObject particleBomb;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            particleBomb.SetActive(true);
            other.GetComponent<FollowLowZombieSc>().explosion();
        }
    }
}
