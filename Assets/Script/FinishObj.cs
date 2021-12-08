using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishObj : MonoBehaviour
{
    public GameObject[] friends;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void activeFriend()
    {
        for (int i = 0; i < friends.Length; i++)
        {
            friends[i].GetComponent<FriendSc>().enabled = true;
        }
    }
    public void stopFight()
    {
        for (int i = 0; i < friends.Length; i++)
        {
            friends[i].GetComponent<FriendSc>().enabled = false;
        }
    }
}
