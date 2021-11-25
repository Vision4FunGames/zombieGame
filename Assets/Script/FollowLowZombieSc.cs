using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowLowZombieSc : MonoBehaviour
{
    public GameObject player;
    public GameObject[] zombiePrefab;
    public GameObject RagdollObj;
    public Vector3 offset;
    public float radius = 5.0F;
    public float power = 10.0F;


    public int zombiCount;
    public float addforceUp;
    void Start()
    {
        zombiCount = GameManager.Instance.zombiCount;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Instantiate(zombiePrefab[Random.Range(0, 2)], transform.GetChild(0).GetChild(i));
        }
        checkZombie();
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position - offset, 1f * Time.deltaTime);
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
            GameObject temp = Instantiate(RagdollObj);
            Destroy(temp, 8);
            temp.transform.position = transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 3f), 20);
            StartCoroutine(usepower(temp));
        }
    }
    IEnumerator usepower(GameObject temp)
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
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
}
