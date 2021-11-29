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
            _player.transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 1f);
            _player.transform.DOMove(finishPoint.transform.position, 2f).OnComplete(() =>
            {
              
                //followZombie.gameObject.SetActive(false);
                coverWall();
                FreeZombie();
               // other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                _player.GetComponent<ShootDetect>().enabled = true;
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
        for (int i = 0; i < followZombie.freezombie.transform.childCount; i++)
        {
            followZombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<ZombiScript>().enabled = false;
            followZombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<FinishZombieSc>().enabled = true;
        }
    }
    public void coverWall()
    {
        anim.SetBool("Shoot", true);
    }
}
