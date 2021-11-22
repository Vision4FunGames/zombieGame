using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiStack : MonoBehaviour
{
    public GameObject zombiePrefab;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(zombiePrefab, transform.GetChild(i));
        }
    }

    void Update()
    {
        
    }
}
