using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameMenu : Menu
{
    [SerializeField] TMP_Text headerText;
    [SerializeField] TMP_Text timeResultText;

    [SerializeField] Color completedColor;
    [SerializeField] Color failedColor;

    private float bestTime = Mathf.Infinity;

    public void OnPlayClicked()
    {
        gameManager.StartGame();
    }

    public void OnBackClicked()
    {
        gameManager.RedirectToMainMenu();
    }

    public void SetFinalState(FinalState state, float finalTime = 0f)
    {
        headerText.text = state.ToString();

        if (state == FinalState.Completed)
        {
            headerText.color = completedColor;
        }
        else
        {
            headerText.color = failedColor;
        }
    }
}
