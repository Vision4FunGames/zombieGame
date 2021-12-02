using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapRed : MonoBehaviour
{
    public GameObject[] traps;
    // Start is called before the first frame update
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
            ActiveTraps();
        }
    }
    public void ActiveTraps()
    {
        for (int i = 0; i < traps.Length; i++)
        {
            traps[i].transform.DOLocalMove(new Vector3(traps[i].transform.localPosition.x + 1.3f, traps[i].transform.localPosition.y - 1.7f, traps[i].transform.localPosition.z), 0.5f).OnComplete(() =>
            {
                traps[i].transform.DOLocalMove(new Vector3(traps[i].transform.localPosition.x + 1.3f, traps[i].transform.localPosition.y, traps[i].transform.localPosition.z), 0.5f);
            });
        }
    }
}
