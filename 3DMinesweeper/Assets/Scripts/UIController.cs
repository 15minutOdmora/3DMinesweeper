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
        gameManager.OnRedirectToMainMenu += GameManager_OnRedirectToMainMenu;
    }

    private void OnDisable()
    {
        gameManager.OnGameEnd -= GameManager_OnGameEnd;
        gameManager.OnGameStart -= GameManager_OnGameStart;
        gameManager.OnRedirectToMainMenu -= GameManager_OnRedirectToMainMenu;
    }

    private void GameManager_OnGameEnd(FinalState finalState)
    {
        endGameMenu.gameObject.SetActive(true);
        endGameMenu.Open();
        endGameMenu.SetFinalState(finalState);
    }

    private void GameManager_OnGameStart()
    {
        mainMenu.Close();
        endGameMenu.Close();
    }

    private void GameManager_OnRedirectToMainMenu()
    {
        endGameMenu.Close().setOnComplete(() => mainMenu.Open());
    }
}
