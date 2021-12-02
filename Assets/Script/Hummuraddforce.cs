using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummuraddforce : MonoBehaviour
{
    FollowLowZombieSc followZombie;
    bool isOnce;
    // Start is called before the first frame update
    void Start()
    {
        followZombie = FindObjectOfType<FollowLowZombieSc>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombieChild"))
        {
            if (!isOnce)
            {
                isOnce = true;
                followZombie.explosion();
            }
        }
    }
}
