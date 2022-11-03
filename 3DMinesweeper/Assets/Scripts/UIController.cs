using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] MainMenu mainMenu;
    [SerializeField] EndGameMenu endGameMenu;

    [SerializeField] TMP_Text timerText;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;

        Timer.Instance.SetText(timerText);
        Timer.Instance.Restart();
        timerText.enabled = false;
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

    private void GameManager_OnGameEnd(FinalState finalState, float endTime)
    {
        endGameMenu.gameObject.SetActive(true);
        endGameMenu.Open();
        endGameMenu.SetFinalState(finalState, endTime);
        timerText.enabled = false;
    }

    private void GameManager_OnGameStart()
    {
        timerText.enabled = true;
        Timer.Instance.Restart();
        mainMenu.Close().setOnComplete(() => { Timer.Instance.Begin(); });
        endGameMenu.Close();
    }

    private void GameManager_OnRedirectToMainMenu()
    {
        endGameMenu.Close().setOnComplete(() => mainMenu.Open());
    }
}
