using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum typeAdd { carpma , toplama}
public class ZombieAdd : MonoBehaviour
{
    public typeAdd mytype;
    public int multply;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            if(mytype == typeAdd.carpma)
            {
                other.GetComponent<FollowLowZombieSc>().carpmaislemi(multply);
            }
        }
    }
}
