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
        HummerRotate();
    }

    void Update()
    {

    }

    public void HummerRotate()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 90), 0.5f).SetEase(Ease.InQuart).OnComplete(() =>
        {
            transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), 1).SetEase(Ease.Linear).OnComplete(() =>
            {
                HummerRotate();
            });
        });
    }
}
