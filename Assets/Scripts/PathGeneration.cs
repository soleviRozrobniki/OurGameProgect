using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGeneration : MonoBehaviour
{
    [Header("Stats")]
    int lastColumn;
    int lastRow;
    [Header("Path")]
    public GameObject pathPrefab;
    [SerializeField] private Transform paths;
    [Header("Grid")]
    public int rows;
    public int columns;
    public float cellSize;
    private bool[,] grid;

    private void Start()
    {
        grid = new bool[rows, columns];
        GameObject path = Instantiate(pathPrefab, paths);
        Vector3 position = new Vector3(0f, Random.Range(0, rows) * cellSize, 0f);
        path.transform.position = position;
        lastColumn = 0;
        lastRow = Mathf.FloorToInt(position.z / cellSize);
        grid[lastRow, lastColumn] = true;
        Generate();
    }

    private void Generate()
    {
        int column = lastColumn;
        int row = lastRow;

        int direction = Random.Range(0, 3);
        switch (direction)
        {
            case 0:
                column++;
                break;
            case 1:
                row--;
                break;
            case 2:
                row++;
                break;
            default:
                Debug.LogError("Direction out of bounds");
                break;
        }

        if (!(column >= columns || row < 0 || row >= rows || grid[row, column]))
        {
            GameObject path = Instantiate(pathPrefab, paths);
            Vector3 position = new Vector3(column * cellSize, row * cellSize, 0f);
            path.transform.position = position;
            lastColumn = column;
            lastRow = row;
            grid[lastRow, lastColumn] = true;
        }
        if (lastColumn < columns - 1) Generate();
    }
}

