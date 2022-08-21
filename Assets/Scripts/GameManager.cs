using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI secondsSurvivedUI;
    private bool _isGameOver;

    private void Start()
    {
        FindObjectOfType<PlayerTriggerManager>().OnPlayerDeath += OnGameOver;
    }

    private void Update()
    {
        if (_isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Space basildi");
                SceneManager.LoadScene(0);
            }
            
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
                Application.Quit();
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        _isGameOver = true;
    }
}
