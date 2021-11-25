using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAction : MonoBehaviour
{
    public Animator anim;
    public PlayerController plmovement;
    public GameObject _player;
    public GameObject finishPoint;
    FollowLowZombieSc followZombie;

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
            _player.transform.DOMove(finishPoint.transform.position, 2f).OnComplete(() =>
            {
                _player.GetComponent<ShootDetect>().enabled = true;
                coverWall();
                FreeZombie();
                other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            });
            _player.transform.parent = null;
            plmovement.enabled = false;
            Camera.main.GetComponent<CameraFollow>().Target2 = _player.transform.GetChild(2);
            Camera.main.GetComponent<CameraFollow>().Target = _player.transform;
            Camera.main.GetComponent<CameraFollow>().isfinish = true;
        }
    }
    public void FreeZombie()
    {
        for (int i = 0; i < followZombie.zombiePrefab.Length; i++)
        {
            followZombie.zombiePrefab[i].transform.parent = null;
            followZombie.zombiePrefab[i].GetComponent<FinishZombieSc>().enabled = true;
            followZombie.zombiePrefab[i].GetComponent<ZombiScript>().enabled = false;
        }
    }
    public void coverWall()
    {
        anim.SetBool("Shoot", true);
    }

}
