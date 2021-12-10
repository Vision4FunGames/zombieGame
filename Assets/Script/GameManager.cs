using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] levels;
    public int zombiCount;
    PlayerController plController;
    FollowLowZombieSc flzombie;
    PlayerAction plaction;
    ShootDetect sh;
    FinishObj fsObj;
    public GameObject puffparticle;
    public GameObject[] guns›tem;
    float currentFillValue;
    public bool tutorial;
    public int levelvalue;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
            tutorial = true;
        }
        plController = FindObjectOfType<PlayerController>();
        levels[PlayerPrefs.GetInt("Level")%4].SetActive(true);
        guns›tem = GameObject.FindGameObjectsWithTag("Guns");
        Application.targetFrameRate = 60;
        UiManager.Instance.ZombieText.text = zombiCount.ToString();
        fsObj = FindObjectOfType<FinishObj>();
        plaction = FindObjectOfType<PlayerAction>();
    }
    public void GameStart()
    {
        plController.speed = 20;
        plController.forwardSpeed = 26;
    }
    public void hardfailGame()
    {
        StartCoroutine(waitforsecondanim());
        //Camera.main.GetComponent<CameraFollow>().lose = true;
    }
    IEnumerator waitforsecondanim()
    {
        yield return new WaitForSeconds(1.5f);
        flzombie = FindObjectOfType<FollowLowZombieSc>();
        for (int i = 0; i < flzombie.freezombie.transform.childCount; i++)
        {
            if (flzombie.freezombie.transform.GetChild(i).childCount > 0)
            {
                flzombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<ZombiScript>().anim.SetBool("run1", false);
                flzombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<ZombiScript>().anim.SetBool("run2", false);
                flzombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<ZombiScript>().anim.SetBool("idle", true);
            }
        }
        plaction.anim.SetBool("dead", true);
        UiManager.Instance.loseP.SetActive(true);
    }
    public void failGame()
    {
        fsObj.stopFight();
        sh = FindObjectOfType<ShootDetect>();
        sh.enabled = false;
        flzombie = FindObjectOfType<FollowLowZombieSc>();
        for (int i = 0; i < flzombie.freezombie.transform.childCount; i++)
        {
            if (flzombie.freezombie.transform.GetChild(i).childCount > 0)
            {
                flzombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<FinishZombieSc>().isDead = true;
                flzombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<FinishZombieSc>().anim.SetBool("run1", false);
                flzombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<FinishZombieSc>().anim.SetBool("run2", false);
                flzombie.freezombie.transform.GetChild(i).GetChild(0).GetComponent<FinishZombieSc>().anim.SetBool("idle", true);
            }
        }
        plaction.anim.SetBool("dead", true);
        UiManager.Instance.loseP.SetActive(true);
        Camera.main.GetComponent<CameraFollow>().lose = true;
    }
    public void winGame()
    {
        UiManager.Instance.winP.SetActive(true);
        fsObj.stopFight();
    }
    private void Update()
    {
        UiManager.Instance.gunImage.GetComponent<Image>().fillAmount = Mathf.Lerp(UiManager.Instance.gunImage.GetComponent<Image>().fillAmount, currentFillValue, 0.055f);
    }
    public void gunsSet›mage()
    {
        currentFillValue = currentFillValue + (1 / (float)guns›tem.Length);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene("MainGame");
    }
}
