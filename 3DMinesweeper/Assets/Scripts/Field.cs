using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Field : MonoBehaviour
{
    [SerializeField] GameObject cube;

    private Cube[,,] field;

    private Ray ray;
    private RaycastHit hit;

    private int CubeSize => GameManager.Instance.CubeSize;
    private float MinePercentage => GameManager.Instance.MinePercentage;

    private void Start()
    {
        // Generate();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStart += Generate;
        GameManager.Instance.OnClear += GameManager_OnClear;
        GameManager.Instance.OnMarked += GameManager_OnMarked;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStart -= Generate;
        GameManager.Instance.OnClear += GameManager_OnClear;
        GameManager.Instance.OnMarked += GameManager_OnMarked;
    }

    private void GameManager_OnMarked()
    {
        OnMouseClick(true);
    }

    private void GameManager_OnClear()
    {
        OnMouseClick();
    }

    public void Generate()
    {
        Renderer meshRenderer = cube.GetComponentInChildren<MeshRenderer>();
        Vector3 cubeSize = meshRenderer.bounds.size;

        field = new Cube[CubeSize, CubeSize, CubeSize];

        for (int i = 0; i < CubeSize; i++)
        {
            for (int j = 0; j < CubeSize; j++)
            {
                for (int k = 0; k < CubeSize; k++)
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
                CubeSize * cubeSize.x / 2,
                CubeSize * cubeSize.y / 2,
                CubeSize * cubeSize.z / 2
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
        cubeData.isMine = Random.value < MinePercentage;

        field[i, j, k] = cubeData;
    }

    private void OnMouseClick(bool markedAction = false)
    {
        if (!GameManager.Instance.GameActive)
        {
            return;
        }

        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Cube cube = hit.transform.gameObject.GetComponent<Cube>();

            if (markedAction)
            {
                MarkedAction(cube);
            }
            else
            {
                RevealAction(cube);
            }
        }
    }

    private void RevealAction(Cube cube)
    {
        if (cube.isMine)
        {
            cube.Reveal();
            ClearAll();
            GameManager.Instance.GameEnd(FinalState.Failed);
        }
        else
        {
            Vector3 pos = cube.positionInField;
            ClearSection((int)pos.x, (int)pos.y, (int)pos.z);
        }
    }

    private void MarkedAction(Cube cube)
    {
        if (cube.isMine)
        {
            cube.Mark();
        }
        else
        {
            ClearAll();
            GameManager.Instance.GameEnd(FinalState.Failed);
        }
    }

    private void SetNumbers()
    {
        for (int i = 0; i < CubeSize; i++)
        {
            for (int j = 0; j < CubeSize; j++)
            {
                for (int k = 0; k < CubeSize; k++)
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
        return (0 <= i) & (i < CubeSize) & (0 <= j) & (j < CubeSize) & (0 <= k) & (k < CubeSize);
    }

    private void ClearSection(int i, int j, int k, bool all = false)
    {
        if (!CheckBounds(i, j, k))
        {
            return;
        }

        Cube cube = field[i, j, k];

        if (cube.isRevealed)
        {
            return;
        }

        cube.Reveal();

        if (cube.isMine || cube.number > 0)
        {
            return;
        }

        ClearSection(i + 1, j, k, all);
        ClearSection(i - 1, j, k, all);
        ClearSection(i, j + 1, k, all);
        ClearSection(i, j - 1, k, all);
        ClearSection(i, j, k + 1, all);
        ClearSection(i, j, k - 1, all);
    }

    private void ClearAll()
    {
        for (int i = 0; i < CubeSize; i++)
        {
            for (int j = 0; j < CubeSize; j++)
            {
                for (int k = 0; k < CubeSize; k++)
                {
                    if (!field[i, j, k].isRevealed)
                    {
                        field[i, j, k].Reveal();
                    }
                }
            }
        }
    }
}
