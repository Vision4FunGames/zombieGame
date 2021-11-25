using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int zombiCount;

    void Start()
    {
         UiManager.Instance.ZombieText.text = zombiCount.ToString();
    }

    void Update()
    {
        
    }
}
