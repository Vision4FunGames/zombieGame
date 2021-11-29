using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FreeZombie : MonoBehaviour
{
    public GameObject[] freezombie;
    FollowLowZombieSc followzombie;
    Vector3 xoffset;
    void Start()
    {
        followzombie = FindObjectOfType<FollowLowZombieSc>();

        StartFreeZombie();
    }

    public void StartFreeZombie()
    {
        int count = Convert.ToInt32(UiManager.Instance.ZombieText.text);
        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate(freezombie[UnityEngine.Random.Range(0, 3)]);
            xoffset = xoffset + new Vector3(UnityEngine.Random.Range(-3f, 3f), 0, 1.5f);
            if (xoffset.x < -3)
                xoffset.x = -3;
            if (xoffset.x > 2)
                xoffset.x = 2;
                temp.transform.position = transform.position + xoffset;
        }
    }
}
