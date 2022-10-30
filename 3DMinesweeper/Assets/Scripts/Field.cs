using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Field : MonoBehaviour
{
    [SerializeField] private int size;
    [SerializeField] private float minePercentage;

    [SerializeField] GameObject cube;

    private Cube[,,] field;

    private Ray ray;
    private RaycastHit hit;

    private void Start()
    {
        Generate();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnClear += OnMouseClick;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnClear -= OnMouseClick;
    }

    public void Generate()
    {
        Renderer meshRenderer = cube.GetComponentInChildren<MeshRenderer>();
        Vector3 cubeSize = meshRenderer.bounds.size;

        field = new Cube[size, size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    Vector3 position = new Vector3(
                            i * cubeSize.x,
                            j * cubeSize.y,
                            k * cubeSize.z
                        );
                    SpawnCube(position, i, j, k);
                }
            }
        }

        SetNumbers();

        transform.position -= new Vector3(
                size * cubeSize.x / 2,
                size * cubeSize.y / 2,
                size * cubeSize.z / 2
            );
    }

    public void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private void SpawnCube(Vector3 position, int i, int j, int k)
    {
        GameObject instantiatedCube = Instantiate(cube);

        instantiatedCube.transform.parent = this.transform;
        instantiatedCube.transform.position = position;

        Cube cubeData = instantiatedCube.GetComponent<Cube>();
        cubeData.field = this;
        cubeData.positionInField = new Vector3(i, j, k);
        cubeData.isMine = Random.value < minePercentage;

        field[i, j, k] = cubeData;
    }

    private void OnMouseClick()
    {
        if (!GameManager.Instance.GameActive)
        {
            return;
        }

        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white, 10f);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Cube cubeData = hit.transform.gameObject.GetComponent<Cube>();

            if (cubeData.isMine)
            {
                cubeData.DisplayMine();
                GameManager.Instance.GameEnd();
            }
            else
            {
                Vector3 pos = cubeData.positionInField;
                ClearSection((int)pos.x, (int)pos.y, (int)pos.z);
            }
        }
    }

    private void SetNumbers()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    if (field[i, j, k].isMine)
                    {
                        AddSurroundingMineCount(i, j, k);
                    }
                }
            }
        }
    }

    private void AddSurroundingMineCount(int i, int j, int k)
    {
        for (int ii = i - 1; ii <= i + 1; ii++)
        {
            for (int jj = j - 1; jj <= j + 1; jj++)
            {
                for (int kk = k - 1; kk <= k + 1; kk++)
                {
                    if (CheckBounds(ii, jj, kk))
                    {
                        if (!field[ii, jj, kk].isMine)
                        {
                            field[ii, jj, kk].number += 1;
                        }
                    }
                }
            }
        }
    }

    private bool CheckBounds(int i, int j, int k)
    {
        return (0 <= i) & (i < size) & (0 <= j) & (j < size) & (0 <= k) & (k < size);
    }

    private void ClearSection(int i, int j, int k)
    {
        if (!CheckBounds(i, j, k))
        {
            return;
        }
        if (field[i, j, k].isCleared)
        {
            return;
        }
        if (field[i, j, k].isMine)
        {
            return;
        }
        if (field[i, j, k].number > 0)
        {
            field[i, j, k].DisplayText(true);
            field[i, j, k].SetNumber();
            return;
        }

        field[i, j, k].Clear();
        
        ClearSection(i + 1, j, k);
        ClearSection(i - 1, j, k);
        ClearSection(i, j + 1, k);
        ClearSection(i, j - 1, k);
        ClearSection(i, j, k + 1);
        ClearSection(i, j, k - 1);
    }
}
