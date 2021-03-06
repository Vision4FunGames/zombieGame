using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FriendSc : MonoBehaviour
{
    public List<FinishZombieSc> finishZombies;
    public GameObject bullet;
    public GameObject cross;

    public int count;

    public float timer;
    public float delay;
    void Start()
    {
        foreach (FinishZombieSc fooObj in FindObjectsOfType<FinishZombieSc>())
        {
            finishZombies.Add(fooObj);
        }
    }
    void Update()
    {
            timer = timer + Time.deltaTime;
            if (timer > delay)
            {
                timer = 0;
                shoot();
            }
    }
    public void shoot()
    {
        if (finishZombies.Count > 0)
        {
            float DistanceFloat = Vector3.Distance(finishZombies[0].transform.position, transform.position);
            for (int i = 0; i < finishZombies.Count; i++)
            {
                if (Vector3.Distance(finishZombies[i].transform.position, transform.position) <= DistanceFloat)
                {
                    DistanceFloat = Vector3.Distance(finishZombies[i].transform.position, transform.position);
                    count = i; 
                }
            }
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.transform.parent = null;
            tempBullet.transform.position = cross.transform.position;
            tempBullet.transform.DOMove(finishZombies[count].transform.position, 0.5f).OnComplete(() =>
            {
                tempBullet.SetActive(false);
                finishZombies[count].GetComponent<Animator>().SetBool("death", true);
                finishZombies[count].GetComponent<Animator>().speed = 1;
                finishZombies[count].isDead = true;
                finishZombies.Remove(finishZombies[count]);
            });
        }
        else
        {
            GameManager.Instance.winGame();
        }
    }
}
