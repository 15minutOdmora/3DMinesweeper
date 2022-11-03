using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class MainMenu : Menu
{
    [SerializeField] TMP_InputField cubeSizeInputField;
    [SerializeField] TMP_InputField minePercentageInputField;
    [SerializeField] TMP_Text difficultyText;

    [SerializeField] float easyLimit;
    [SerializeField] float mediumLimit;

    [SerializeField] Color easyColor;
    [SerializeField] Color mediumColor;
    [SerializeField] Color hardColor;

    private void Start()
    {
        SetInputValues(gameManager.CubeSize, gameManager.MinePercentage);
    }

    public void OnPlayButtonClick()
    {
        (int cubeSize, float minePercentage) = GetInputValues();
        gameManager.SetFieldData(cubeSize, minePercentage);
        Close().setOnComplete(() => gameManager.StartGame());
    }

    public void OnQuitButtonClicked()
    {
        Debug.Log("Quit clicked.");
        Application.Quit();
    }

    public void OnMinePercentageValueChanged(string value)
    {
        float parsedValue;
        try
        {
            parsedValue = float.Parse(minePercentageInputField.text) * 0.01f;
            UpdateDifficultyText(parsedValue);
        }
        catch (FormatException)
        {
            return;
        }
    }

    private void SetInputValues(int cubeSize, float minePercentage)
    {
        cubeSizeInputField.text = cubeSize.ToString();
        minePercentageInputField.text = (minePercentage * 100f).ToString();
    }

    private (int, float) GetInputValues()
    {
        int cubeSize = int.Parse(cubeSizeInputField.text);
        float minePercentage = float.Parse(minePercentageInputField.text) * 0.01f;
        return (cubeSize, minePercentage);
    }

    private void UpdateDifficultyText(float value)
    {
        if (value < easyLimit)
        {
            difficultyText.color = easyColor;
            difficultyText.text = "Easy";
        }
        else if (value < mediumLimit)
        {
            difficultyText.color = mediumColor;
            difficultyText.text = "Medium";
        }
        else
        {
            difficultyText.color = hardColor;
            difficultyText.text = "Hard";
        }
    }
}
