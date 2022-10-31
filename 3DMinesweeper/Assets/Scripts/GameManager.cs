using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FinalState
{
    Completed,
    Failed
}

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public event Action OnClear;
    public event Action OnSelect;

    public event Action OnGameStart;
    public event Action<FinalState> OnGameEnd;

    public event Action OnRedirectToMainMenu;

    public bool GameActive => gameActive;

    public int CubeSize { get => cubeSize; private set { cubeSize = value; } }
    public float MinePercentage { get => minePercentage; private set { minePercentage = value; } }

    private int cubeSize = 5;
    private float minePercentage = 0.01f;

    private InputControlls inputControlls;

    private bool gameActive = false;

    private new void Awake()
    {
        base.Awake();
        
        inputControlls = new InputControlls();
    }

    private void OnEnable()
    {
        inputControlls.Enable();

        inputControlls.Click.Clear.performed += (_) => Clear();
        inputControlls.Click.Select.performed += (_) => Select();
    }

    public void Clear()
    {
        OnClear?.Invoke();
    }

    public void Select()
    {
        OnSelect?.Invoke();
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
        gameActive = true;
    }

    public void GameEnd(FinalState finalState)
    {
        OnGameEnd?.Invoke(finalState);
        gameActive = false;
    }

    public void RedirectToMainMenu()
    {
        OnRedirectToMainMenu?.Invoke();
    }

    public void SetFieldData(int cubeSize, float minePercentage)
    {
        CubeSize = cubeSize;
        MinePercentage = minePercentage;
    }
}
