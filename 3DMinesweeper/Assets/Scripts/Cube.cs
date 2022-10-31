using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    public Field field;
    public Vector3 positionInField;
    public bool isMine;
    public int number;
    public bool isRevealed;

    [SerializeField] GameObject textContainer;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject mine;

    private List<TMP_Text> textObjects;

    private void Start()
    {
        textObjects = new List<TMP_Text>();

        for (int i = 0; i < textContainer.transform.childCount; i++)
        {
            GameObject textObject = textContainer.transform.GetChild(i).gameObject;
            textObjects.Add(textObject.GetComponent<TMP_Text>());
        }

        textContainer.SetActive(false);
    }

    public void Reveal()
    {
        if (isMine)
        {
            DisplayMine();
        }
        else if (number > 0)
        {
            DisplayValue();
        }
        else
        {
            Clear();
        }

        isRevealed = true;
    }

    private void DisplayMine()
    {
        cube.SetActive(false);
        mine.SetActive(true);
    }

    private void DisplayValue()
    {
        SetNumber();
        textContainer.SetActive(true);
        Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
        LeanTween.scale(gameObject, targetScale, 0.3f).setEase(LeanTweenType.easeOutCubic);
    }

    private void Clear()
    {
        gameObject.SetActive(false);
    }

    private void SetNumber()
    {
        string textValue = number == 0 ? "" : $"{number}";

        foreach (TMP_Text textItem in textObjects)
        {
            textItem.text = textValue;
        }
    }
}
