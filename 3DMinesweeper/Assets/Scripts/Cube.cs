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
    public bool isCleared;

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

        DisplayText(false);
    }

    public void Clear()
    {
        cube.SetActive(false);
        mine.SetActive(false);
        isCleared = true;
    }

    public void DisplayMine()
    {
        cube.SetActive(false);
        mine.SetActive(true);
    }

    public void DisplayText(bool display)
    {
        textContainer.SetActive(display);
    }

    public void SetNumber()
    {
        string textValue = number == 0 ? "" : $"{number}"; 

        foreach (TMP_Text textItem in textObjects)
        {
            textItem.text = textValue;
        }
    }
}
