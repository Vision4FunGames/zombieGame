using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootDetect : MonoBehaviour
{
    public List<FinishZombieSc> finishZombies;
    public GameObject spawnBullet;
    public GameObject bullet;
    public int count;
    void Start()
    {
        foreach (FinishZombieSc fooObj in FindObjectsOfType<FinishZombieSc>())
        {
            finishZombies.Add(fooObj);
        }
    }

    public void shoot()
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
        tempBullet.transform.position = spawnBullet.transform.position;
        tempBullet.transform.DOMove(finishZombies[count].transform.position, 0.5f).OnComplete(() =>
        {
            tempBullet.SetActive(false);
            finishZombies[count].GetComponent<Animator>().SetBool("death", true);
            finishZombies[count].GetComponent<Animator>().speed = 1;
            finishZombies[count].isDead = true;
            finishZombies.Remove(finishZombies[count]);
        });
    }
}
