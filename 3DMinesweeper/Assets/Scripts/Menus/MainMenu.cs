using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : Menu
{
    [SerializeField] TMP_InputField cubeSizeInputField;
    [SerializeField] TMP_InputField minePercentageInputField;

    public void Start()
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
    }

    private void SetInputValues(int cubeSize, float minePercentage)
    {
        cubeSizeInputField.text = cubeSize.ToString();
        minePercentageInputField.text = (minePercentage * 100f).ToString();
    }

    private (int, float) GetInputValues()
    {
        int cubeSize = int.Parse(cubeSizeInputField.text);
        float minePercentage = float.Parse(minePercentageInputField.text);
        return (cubeSize, minePercentage);
    }
}
