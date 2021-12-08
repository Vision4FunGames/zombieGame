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
            other.GetComponent<FollowLowZombieSc>().explosion();
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                transform.parent.transform.GetChild(i).GetComponent<TrapBomb>().particleBomb.SetActive(true);
                transform.parent.transform.GetChild(i).GetComponent<TrapBomb>().particleBomb.transform.parent = null;
                Destroy(transform.parent.transform.GetChild(i).gameObject,0.2f);
                Destroy(transform.parent.transform.GetChild(i).GetComponent<TrapBomb>().particleBomb,2f);
            }
        }
    }
}
