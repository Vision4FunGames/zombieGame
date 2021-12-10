using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialObj : MonoBehaviour
{
    public GameObject tutorialObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.tutorial == true)
            {
                Time.timeScale = 0;
                tutorialObject.SetActive(true);
            }
        }
    }

    public void continueGame()
    {
        Time.timeScale = 1;
        tutorialObject.SetActive(false);
        Destroy(gameObject);
    }
}
