using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class PlayerAction : MonoBehaviour
{
    public Animator anim;
    public PlayerController plmovement;
    public GameObject _player;
    public GameObject finishPoint;
    FollowLowZombieSc followZombie;
    public GameObject[] freezombie;
    Vector3 xoffset;
    void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        plmovement = GetComponent<PlayerController>();
        _player = transform.GetChild(1).gameObject;
        finishPoint = GameObject.FindGameObjectWithTag("FinishPoint");
        followZombie = FindObjectOfType<FollowLowZombieSc>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            anim.SetBool("Run", true);
            _player.transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 1f);
            _player.transform.DOMove(finishPoint.transform.position, 2f).OnComplete(() =>
            {

                //followZombie.gameObject.SetActive(false);
                coverWall();
                FreeZombie();
                // other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                _player.GetComponent<ShootDetect>().enabled = true;
                Camera.main.GetComponent<CameraFollow>().Target2 = _player.transform.GetChild(2);
            });
            _player.transform.parent = null;
            plmovement.enabled = false;
            Camera.main.GetComponent<CameraFollow>().Target2 = _player.transform.GetChild(2);
            Camera.main.GetComponent<CameraFollow>().Target = _player.transform;
            Camera.main.GetComponent<CameraFollow>().isfinish = true;
            Camera.main.GetComponent<CameraFollow>().finishpos();
        }
    }
    public void FreeZombie()
    {
        int count = Convert.ToInt32(UiManager.Instance.ZombieText.text);
        int currentcount = 0;

        for (int i = 0; i < followZombie.freezombie.transform.childCount; i++)
        {
            if (followZombie.freezombie.transform.GetChild(i).childCount > 0)
            {
                currentcount++;
                followZombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<ZombiScript>().enabled = false;
                followZombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<FinishZombieSc>().enabled = true;
            }
        }
        count = count - currentcount;

        if (count > 0)
        {
            StartFreeZombie(count);
        }
    }
    public void StartFreeZombie(int count)
    {
        if(count > 10)
        {
            count = 10;
        }
        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate(freezombie[UnityEngine.Random.Range(0, 3)]);
            xoffset = xoffset - new Vector3(UnityEngine.Random.Range(-3f, 3f), 0, 1.5f);
            if (xoffset.x < -3)
                xoffset.x = -3;
            if (xoffset.x > 2)
                xoffset.x = 2;
            temp.transform.position = followZombie.transform.position + xoffset;
        }
    }
    public void coverWall()
    {
        anim.SetBool("Shoot", true);
    }
}
