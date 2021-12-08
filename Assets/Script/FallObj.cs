using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallObj : MonoBehaviour
{
    public GameObject rightWall, leftWall;
    FollowLowZombieSc followzombie;
    public GameObject zombiesPrefab;
    bool isOpen;
    int count;
    void Start()
    {
        followzombie = FindObjectOfType<FollowLowZombieSc>();
    }

    void Update()
    {

    }

    public void isOpenWalls()
    {
        isOpen = true;
        Invoke("ExtraPeople", 3f);
        rightWall.transform.DORotateQuaternion(Quaternion.Euler(0, 0, 65), 0.2f).SetEase(Ease.InQuart);
        leftWall.transform.DORotateQuaternion(Quaternion.Euler(0, 0, -115), 0.2f).SetEase(Ease.InQuart).OnComplete(() =>
        {
            //followzombie.fallZombies();
        });
    }
    public void ExtraPeople()
    {
        //followzombie.extraPeople();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            isOpenWalls();
        }
        if (other.CompareTag("zombieChild"))
        {
            StartCoroutine(waitforsecondnext(other.gameObject));
        }
    }
    IEnumerator waitforsecondnext(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        fallZombies(obj);
    }
    public void fallZombies(GameObject other)
    {
        if (zombiesPrefab.transform.childCount > count)
        {
            zombiesPrefab.transform.GetChild(count).gameObject.SetActive(true);
        }
        Destroy(other.gameObject);
        Destroy(other.gameObject);
        GameObject current = other.gameObject.transform.parent.gameObject;
        count++;
        followzombie.extraPeople(current);
        // UiManager.Instance.ZombieText.text = followzombie.zombiCount.ToString();
        //followzombie.extraPeople();
    }
}
