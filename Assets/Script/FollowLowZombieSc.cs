using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowLowZombieSc : MonoBehaviour
{
    public GameObject player;
    public GameObject[] zombiePrefab;
    public GameObject[] RagdollObj;
    public GameObject freezombie;
    public Vector3 offset;
    public float radius = 5.0F;
    public float power = 10.0F;


    public int zombiCount;
    public float addforceUp;


    public float islemTimer;
    public bool isokeyislem;
    void Start()
    {
        zombiCount = GameManager.Instance.zombiCount;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Instantiate(zombiePrefab[Random.Range(0, 3)], transform.GetChild(0).GetChild(i));
        }
        checkZombie();
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position - offset, 1f * Time.deltaTime);
        islemTimer = Time.deltaTime + islemTimer;

        if (islemTimer > 1)
        {
            isokeyislem = true;
        }
        else
            isokeyislem = false;
    }
    public void explosion() // patlama zombi eksiliyor.
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (transform.GetChild(0).GetChild(i).childCount > 0)
            {
                Destroy(transform.GetChild(0).GetChild(i).GetChild(0).transform.gameObject);
            }
            extraPeople(i);
        }
        AddforceRagdoll();
    }
    public void AddforceRagdoll() //ragdoll obj
    {
        for (int i = 0; i < 10; i++)
        {
            int rand = Random.Range(0, 3);
            GameObject temp = Instantiate(RagdollObj[rand]);
            Destroy(temp, 8);
            temp.transform.position = transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 3f), 20);
            StartCoroutine(usepower(temp));
        }
    }
    IEnumerator usepower(GameObject temp)
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 explosionPos = transform.forward;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 1.0F);
        }
    }

    public void extraPeople(int currentIndex)   //arkadan zombi ekleniyor.
    {
        if (zombiCount > 0)
        {
            zombiCount--;
            Invoke("checkZombie", 0.1f);
            GameObject temp = Instantiate(zombiePrefab[Random.Range(0, 2)], transform.GetChild(0).GetChild(currentIndex));
            temp.transform.position = temp.transform.position - new Vector3(0, 0, +40);
            temp.transform.DOLocalMove(temp.transform.localPosition + new Vector3(0, 0, +40), 2f);
        }
        Invoke("checkZombie", 0.1f);
    }
    public void extraPeople(GameObject obj)   //arkadan zombi ekleniyor.
    {
        if (zombiCount > 0)
        {
            zombiCount--;
            Invoke("checkZombie", 0.1f);
            GameObject temp = Instantiate(zombiePrefab[Random.Range(0, 2)], obj.transform);
            temp.transform.position = temp.transform.position - new Vector3(0, 0, +40);
            temp.transform.GetComponent<Collider>().enabled = false;
            temp.transform.DOLocalMove(temp.transform.localPosition + new Vector3(0, 0, +40), 2f).OnComplete(() => temp.transform.GetComponent<Collider>().enabled = true);
        }
    }
    public void checkZombie()
    {
        int count = 0;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (transform.GetChild(0).GetChild(i).childCount > 0)
            {
                count++;
            }
        }
        UiManager.Instance.ZombieText.text = (zombiCount + count).ToString();
    }
    public void carpmaislemi(int multpy)
    {
        if (isokeyislem)
        {
            int count = 0;
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                if (transform.GetChild(0).GetChild(i).childCount > 0)
                {
                    count++;
                }
            }
            zombiCount = ((count * multpy) - count) + (zombiCount * multpy);
            UiManager.Instance.ZombieText.text = (zombiCount + count).ToString();
            extraPeopleUpdate();
        }
    }
    public void toplamaislemi(int addcount)
    {
        int count = 0;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            if (transform.GetChild(0).GetChild(i).childCount > 0)
            {
                count++;
            }
        }
        zombiCount = addcount + zombiCount;
        UiManager.Instance.ZombieText.text = (zombiCount + count).ToString();
        extraPeopleUpdate();
    }
    public void extraPeopleUpdate()
    {
        for (int i = 0; i < freezombie.transform.childCount; i++)
        {
            if (freezombie.transform.GetChild(i).childCount <= 0)
            {
                if (zombiCount > 0)
                {
                    zombiCount--;
                    GameObject temp = Instantiate(zombiePrefab[Random.Range(0, 2)], transform.GetChild(0).GetChild(i));
                    temp.transform.position = temp.transform.position - new Vector3(0, 0, +40);
                    temp.transform.DOLocalMove(temp.transform.localPosition + new Vector3(0, 0, +40), 2f);
                }
                Invoke("checkZombie", 0.1f);
            }
        }
    }
}
