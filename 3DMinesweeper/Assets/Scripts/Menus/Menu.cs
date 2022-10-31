using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] float animationDuration;

    internal GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public LTDescr Open()
    {
        return ScaleAnimation.StartOpen(this.gameObject, animationDuration);
    }

    public LTDescr Close()
    {
        return ScaleAnimation.StartClose(this.gameObject, animationDuration);
    }
}
