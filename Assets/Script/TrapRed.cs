using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapRed : MonoBehaviour
{
    public DOTweenPath dppat;
    public GameObject parentObj;
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
            ActiveTraps();
        }
    }
    public void ActiveTraps()
    {
        for (int i = 0; i < parentObj.transform.childCount; i++)
        {
            parentObj.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            parentObj.transform.GetChild(i).GetComponent<SlowobsChild>().isGo = true;
        }
        Destroy(parentObj, 6f);
        //dppat.DOPlay();
    }
}
