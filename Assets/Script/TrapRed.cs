using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapRed : MonoBehaviour
{
    public DOTweenPath dppat;
    public GameObject parentObj;
    public GameObject gate;
    // Start is called before the first frame update
    void Start()
    {
        dppat.DOPause();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VibrationManager.Instance.Vib();
            Invoke("ActiveTraps",1f);
        }
    }
    public void ActiveTraps()
    {
        gate.transform.DORotateQuaternion(Quaternion.Euler(0,0,-110f),1);
        for (int i = 0; i < parentObj.transform.childCount; i++)
        {
            parentObj.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            parentObj.transform.GetChild(i).GetComponent<SlowobsChild>().isGo = true;
        }
        Destroy(parentObj, 6f);
        //dppat.DOPlay();
    }
}
