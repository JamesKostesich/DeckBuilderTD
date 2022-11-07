using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{   
    public int gridWidth = 16;
    public int gridHeight = 8;

    public int minPathLength = 30;
    public float pathDelay = 0.05f;
    public float groundDelay = 0.025f;

    public GridCellBase[] basePath;
    public GridCellBase[] baseGround;
    public GameObject[,] grid;
    public GameObject startCell;
    public GameObject endCell;

    private PathGenerator path;
    Vector3 worldPosition;

    void Start()
    {
        path = new PathGenerator(gridWidth, gridHeight);

        List<Vector2Int> pathCells = path.GeneratePath();
        int pathSize = pathCells.Count;
        grid = new GameObject[gridWidth, gridHeight];

        while (pathSize < minPathLength)
        {
            pathCells = path.GeneratePath();
            pathSize = pathCells.Count;
        }

        StartCoroutine(CreateGrid(pathCells));
    }


    IEnumerator CreateGrid(List<Vector2Int> pathCells)
    {
        yield return LayPathCells(pathCells);
        yield return LaySceneryCells();
    }

    private bool IsBuildable(int i)
    {
        if (basePath[i].Type == GridCellBase.CellType.Path)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private IEnumerator LayPathCells(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int pathCell in pathCells)
        {
            int neighbourValue = path.getCellNeighbourValue(pathCell.x, pathCell.y);
            GameObject cell = Instantiate(basePath[neighbourValue].CellPrefab, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            cell.transform.Rotate(0f, basePath[neighbourValue].Rotation, 0f, Space.Self);
            grid[pathCell.x , pathCell.y] = cell;
            cell.tag = "path";
            if (neighbourValue == 4)
            {
                startCell = cell;
            }
            if(neighbourValue == 8)
            {
                endCell = cell;
            }

            yield return new WaitForSeconds(pathDelay);
        }

        yield return null;
    }

    IEnumerator LaySceneryCells()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (path.CellIsEmpty(x, y))
                {
                    int rand = Random.Range(0, baseGround.Length);
                    GameObject cell = Instantiate(baseGround[rand].CellPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                    grid[x, y] = cell;
                    //cell.tag = "not path";
                    yield return new WaitForSeconds(groundDelay);
                }
            }
        }

        yield return null;
    }
}
