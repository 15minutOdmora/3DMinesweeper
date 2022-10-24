using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] int onHoverSizeIncreasePercentage;
    [SerializeField] bool locked;

    public TMP_Text textComponent;

    private float initialFontSize;

    private void Awake()
    {
        initialFontSize = textComponent.fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (locked) return;
        textComponent.fontSize = GetHoverFontSize();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (locked) return;
        textComponent.fontSize = initialFontSize;
    }

    /// <summary>
    /// Calculate on hover size of font, based on percentage increase.
    /// </summary>
    /// <returns>On hover font size</returns>
    private float GetHoverFontSize()
    {
        return initialFontSize * (1f + onHoverSizeIncreasePercentage / 100f);
    }
}
