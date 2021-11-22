using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowLowZombieSc : MonoBehaviour
{
    public GameObject player;
    public GameObject zombiePrefab;
    public GameObject RagdollObj;
    public Vector3 offset;


    public float addforceUp;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(zombiePrefab, transform.GetChild(i));
        }
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position - offset, 0.025f);
    }


    public void explosion()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).GetChild(0).transform.gameObject);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(RagdollObj);
            temp.transform.position = transform.position + new Vector3(0, 0, 20);
            temp.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(Vector3.up * addforceUp, ForceMode.Impulse);
            int rand = Random.Range(0, 3);
            print(rand);
            if (rand == 0)
                temp.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(Vector3.left * addforceUp, ForceMode.Impulse);
            else if (rand == 1)
                temp.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(Vector3.right * addforceUp, ForceMode.Impulse);
            else if (rand == 2)
                temp.transform.GetChild(1).GetComponent<Rigidbody>().AddForce(Vector3.forward * addforceUp, ForceMode.Impulse);
        }
        extraPeople();
    }
    public void extraPeople()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject temp = Instantiate(zombiePrefab, transform.GetChild(i));
            temp.transform.position = temp.transform.position - new Vector3(0, 0, +40);
            temp.transform.DOLocalMove(temp.transform.localPosition + new Vector3(0, 0, +40), 5f);
        }
    }
}
