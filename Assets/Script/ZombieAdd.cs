using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeAdd { carpma , toplama}
public class ZombieAdd : MonoBehaviour
{
    public typeAdd mytype;
    public int multply;
    FollowLowZombieSc fl;
    void Start()
    {
        fl = FindObjectOfType<FollowLowZombieSc>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(mytype == typeAdd.carpma)
            {
                fl.carpmaislemi(multply);
            }
        }
    }
}
