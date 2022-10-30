using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnEnable()
    {
        GameManager.Instance.OnGameEnd += GameManager_OnGameEnd;
    }

    public void OnDisable()
    {
        
    }

    public void OnPlayButtonClick()
    {
        ScaleAnimation.StartClose(this.gameObject, 0.3f, () => GameManager.Instance.StartGame());
    }

    private void GameManager_OnGameEnd()
    {
        ScaleAnimation.StartOpen(this.gameObject, 0.3f);
    }
}
