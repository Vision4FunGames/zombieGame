using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UiManager : Singleton<UiManager>
{
    public TextMeshProUGUI ZombieText;
    public GameObject loseP;
    public GameObject winP;
    public Image gunImage;
    public Text leveltxt;
    public Text scoreText;

    public int scoreValue;
    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
    }
}
