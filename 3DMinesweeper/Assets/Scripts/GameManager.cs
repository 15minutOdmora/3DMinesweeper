using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public event Action OnClear;
    public event Action OnSelect;

    public event Action OnGameRestart;
    public event Action OnGameEnd;

    private InputControlls inputControlls;

    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        inputControlls = new InputControlls();    
    }

    private void OnEnable()
    {
        inputControlls.Enable();

        inputControlls.Click.Clear.performed += (_) => Clear();
        inputControlls.Click.Select.performed += (_) => Select();
    }

    private void OnDisable()
    {
        inputControlls.Disable();
    }

    public void Clear()
    {
        OnClear?.Invoke();
    }

    public void Select()
    {
        OnSelect?.Invoke();
    }

    public void RestartGame()
    {
        OnGameRestart?.Invoke();
    }

    public void GameEnd()
    {
        OnGameEnd?.Invoke();
    }
}
