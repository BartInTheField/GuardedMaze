using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endGameText;

    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.OnGameOver += GameOver;
        gameManager.OnGameFinish += GameFinish;
    }

    private void GameOver()
    {
        endGameText.text = "Game over";
    }

    private void GameFinish()
    {
        endGameText.text = "Good game";
    }
}