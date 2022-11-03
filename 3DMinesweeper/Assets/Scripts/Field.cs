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
    private List<Cube> mines;

    private Ray ray;
    private RaycastHit hit;

    private int CubeSize => GameManager.Instance.CubeSize;
    private float MinePercentage => GameManager.Instance.MinePercentage;

    private int mineTotal = 0;
    private int mineCount = 0;

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
        Reset();

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

        // If no mine added -> add one at a random position
        if (mineTotal == 0)
        {
            int i = Random.Range(0, CubeSize - 1);
            int j = Random.Range(0, CubeSize - 1);
            int k = Random.Range(0, CubeSize - 1);
            MakeMine(i, j, k);
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
        field[i, j, k] = cubeData;

        if (Random.value < MinePercentage)
        {
            MakeMine(i, j, k);
        }
    }

    private void MakeMine(int i, int j, int k)
    {
        field[i, j, k].isMine = true;
        mineTotal++;
        mines.Add(field[i, j, k]);
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
            mineCount++;
            Debug.Log(mineCount);
            Debug.Log(mineTotal);
            if (mineCount == mineTotal)
            {
                ClearAll();
                GameManager.Instance.GameEnd(FinalState.Completed);
            }
        }
        else
        {
            ClearAll();
            GameManager.Instance.GameEnd(FinalState.Failed);
        }
    }

    private void SetNumbers()
    {
        foreach (Cube cube in mines)
        {
            AddSurroundingMineCount(
                (int)cube.positionInField.x,
                (int)cube.positionInField.y,
                (int)cube.positionInField.z
            );
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

    private void Reset()
    {
        mineTotal = 0;
        mineCount = 0;

        mines = new List<Cube>();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
