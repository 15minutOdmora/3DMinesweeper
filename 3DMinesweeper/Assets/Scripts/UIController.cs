using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] MainMenu mainMenu;
    [SerializeField] EndGameMenu endGameMenu;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void OnEnable()
    {
        gameManager.OnGameEnd += GameManager_OnGameEnd;
        gameManager.OnGameStart += GameManager_OnGameStart;
    }

    private void OnDisable()
    {
        gameManager.OnGameEnd -= GameManager_OnGameEnd;
        gameManager.OnGameStart -= GameManager_OnGameStart;
    }

    private void GameManager_OnGameEnd(FinalState finalState)
    {
        endGameMenu.Open();
    }

    private void GameManager_OnGameStart()
    {
        mainMenu.Close();
        endGameMenu.Close();
    }
}
