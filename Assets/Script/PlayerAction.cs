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
    public GameObject bombprefab;
    Vector3 xoffset;
    int slowobscount;

    GameObject parentObj;
    float timer;
    float timerAction;
    public float delaybomb;
    bool completeBomb;
    int bombCount;

    float delayAction;
    void Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        plmovement = GetComponent<PlayerController>();
        _player = transform.GetChild(1).gameObject;
        finishPoint = GameObject.FindGameObjectWithTag("FinishPoint");
        followZombie = FindObjectOfType<FollowLowZombieSc>();
        delayAction = delaybomb;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timerAction > delayAction)
        {
            timerAction = 0;
            if (other.CompareTag("Finish"))
            {
                anim.SetBool("Run", true);
                _player.transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 1f);
                _player.transform.DOMove(finishPoint.transform.position, 2f).OnComplete(() =>
                {
                    coverWall();
                    FreeZombie();
                    _player.GetComponent<ShootDetect>().enabled = true;
                    other.GetComponent<FinishObj>().activeFriend();
                    Camera.main.GetComponent<CameraFollow>().Target2 = _player.transform.GetChild(2);
                });
                _player.transform.parent = null;
                plmovement.enabled = false;
                Camera.main.GetComponent<CameraFollow>().Target2 = _player.transform.GetChild(2);
                Camera.main.GetComponent<CameraFollow>().Target = _player.transform;
                Camera.main.GetComponent<CameraFollow>().isfinish = true;
                Camera.main.GetComponent<CameraFollow>().finishpos();
            }
            if (other.CompareTag("slowobs"))
            {
                other.GetComponent<SlowObs>().ActiveSlowTypeAction(gameObject);
                if (slowobscount == 0)
                    followZombie.offset.z = 30;
                else if (slowobscount == 1)
                    followZombie.offset.z = 20;
                else if (slowobscount == 2)
                {
                    followZombie.offset.z = 15;
                    plmovement.speed = 0;
                    plmovement.forwardSpeed = 0;
                    GameManager.Instance.hardfailGame();
                }
                slowobscount++;
            }
            if (other.CompareTag("Bomb"))
            {
                parentObj = other.gameObject;
                completeBomb = true;
                timer = 0;
            }
            if (other.CompareTag("Guns"))
            {
                GameManager.Instance.gunsSet›mage();
                Destroy(other.gameObject);
            }
        }
    }
    public void spawnBomb()
    {
        if (bombCount < 3)
        {
            GameObject tempBomb = Instantiate(bombprefab);
            tempBomb.transform.position = new Vector3(transform.position.x, 1, transform.position.z - 28f);
            tempBomb.transform.parent = parentObj.transform.GetChild(0).transform;
            if (bombCount == 2)
            {
                tempBomb.GetComponent<Collider>().enabled = true;
            }
            bombCount++;
        }
        else
        {
            completeBomb = false;
        }

    }
    private void Update()
    {

        timerAction = timerAction + Time.deltaTime;

        if (completeBomb)
        {
            timer = timer + Time.deltaTime;
            if (timer > delaybomb)
            {
                timer = 0;
                spawnBomb();
            }
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
        if (count > 10)
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
