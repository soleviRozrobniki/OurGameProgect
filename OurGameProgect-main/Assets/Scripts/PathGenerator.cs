using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PathGenerator : MonoBehaviour
{
    [Header("Stats")]
    int lastColumn;
    int lastRow;
    [Header("Path")]
    public GameObject pathPrefab,wallPrefab,doorWallPrefab;
    private GameObject curPath;
    [SerializeField] private Transform paths;
    [SerializeField] private Vector2 offset;
    [Header("Grid")]
    public int rows;
    public int columns;
    public float cellSize;
    private bool[,] grid;
    private void Start()
    {
        grid = new bool[rows, columns];
        GameObject path = Instantiate(pathPrefab, paths);
        Vector3 position = new Vector3(0f, Random.Range(0, rows) * cellSize);
        path.transform.position = position;
        lastColumn = 0;
        lastRow = Mathf.FloorToInt(position.y / cellSize);
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
                if (curPath)
                {
                    Instantiate(doorWallPrefab, new Vector2(curPath.transform.position.x + offset.x, curPath.transform.position.y), Quaternion.identity, curPath.transform).transform.Rotate(0, 0, 90);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x - offset.x, curPath.transform.position.y), Quaternion.identity, curPath.transform).transform.Rotate(0, 0, 90);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x, curPath.transform.position.y + offset.y), Quaternion.identity, curPath.transform);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x, curPath.transform.position.y - offset.y), Quaternion.identity, curPath.transform);
                }
                break;
            case 1:
                row--;
                if (curPath)
                {
                    Instantiate(doorWallPrefab, new Vector2(curPath.transform.position.x, curPath.transform.position.y - offset.y), Quaternion.identity, curPath.transform);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x - offset.x, curPath.transform.position.y), Quaternion.identity, curPath.transform).transform.Rotate(0, 0, 90);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x, curPath.transform.position.y + offset.y), Quaternion.identity, curPath.transform);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x + offset.x, curPath.transform.position.y), Quaternion.identity, curPath.transform).transform.Rotate(0, 0, 90);
                }
                break;
            case 2:
                row++;
                if (curPath)
                {
                    Instantiate(doorWallPrefab, new Vector2(curPath.transform.position.x, curPath.transform.position.y + offset.y), Quaternion.identity, curPath.transform);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x - offset.x, curPath.transform.position.y), Quaternion.identity, curPath.transform).transform.Rotate(0, 0, 90);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x, curPath.transform.position.y - offset.y), Quaternion.identity, curPath.transform);
                    Instantiate(wallPrefab, new Vector2(curPath.transform.position.x + offset.x, curPath.transform.position.y), Quaternion.identity, curPath.transform).transform.Rotate(0, 0, 90);
                }
                break;
            default:
                Debug.LogError("Direction out of bounds");
                break;
        }

        if (!(column >= columns || row < 0 || row >= rows || grid[row, column]))
        {
            curPath = Instantiate(pathPrefab, paths);
            Vector3 position = new Vector3(column * cellSize, row * cellSize, 0f);
            curPath.transform.position = position;
            lastColumn = column;
            lastRow = row;
            grid[lastRow, lastColumn] = true;
            
        }
        if (lastColumn < columns - 1) Generate();
    }
}