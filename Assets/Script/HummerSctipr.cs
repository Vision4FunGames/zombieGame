using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HummerSctipr : MonoBehaviour
{
    FollowLowZombieSc followZombie;
    void Start()
    {
        //HummerRotate();
        followZombie = FindObjectOfType<FollowLowZombieSc>();
    }

    void Update()
    {

    }

    public void HummerRotate()
    {
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 0.5f).SetEase(Ease.InQuart).OnComplete(() =>
        {
            followZombie.explosion();
            transform.DORotateQuaternion(Quaternion.Euler(0, 0, -90), 1).SetEase(Ease.Linear).OnComplete(() =>
            {
            
            });
        });
    }
}
