using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZombiAdd : MonoBehaviour
{
    GameObject parentObj;
    FollowLowZombieSc fl;
    void Start()
    {
        parentObj = transform.GetChild(0).gameObject;
        fl = FindObjectOfType<FollowLowZombieSc>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            VibrationManager.Instance.Vib();
            fl.toplamaislemi(parentObj.transform.childCount);
            for (int i = 0; i < parentObj.transform.childCount; i++)
            {
                parentObj.transform.GetChild(i).GetComponent<GoZombieGruoup>().starGo(fl.transform.GetChild(0).GetChild(1).gameObject);
            }
        }
        if(other.CompareTag("zombieChild"))
        {
            Destroy(gameObject, 1.5f);
        }
    }
}
