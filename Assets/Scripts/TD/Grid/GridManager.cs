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

    public GridCellObj[] pathCellObjects;
    public GridCellObj[] sceneryCellObjects;
    public TowerObj[] TowerObjs;

    private PathGenerator path;
    Vector3 worldPosition;

    void Start()
    {
        path = new PathGenerator(gridWidth, gridHeight);

        List<Vector2Int> pathCells = path.GeneratePath();
        int pathSize = pathCells.Count;

        while (pathSize < minPathLength)
        {
            pathCells = path.GeneratePath();
            pathSize = pathCells.Count;
        }

        StartCoroutine(CreateGrid(pathCells));
        buildTower(TowerObjs[0],new Vector2Int(2,2));
    }

    private Vector2Int getMousePos()
    {
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        int x = (int)Mathf.Floor(worldPosition.x);
        int y = (int)Mathf.Floor(worldPosition.y);

        return new Vector2Int(x, y);
    }
    public void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            buildTower(TowerObjs[0], getMousePos());
            print(getMousePos());
            print("hello");
        }
    }
   

    IEnumerator CreateGrid(List<Vector2Int> pathCells)
    {
        yield return LayPathCells(pathCells);
        yield return LaySceneryCells();
        
    }

    private IEnumerator LayPathCells(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int pathCell in pathCells)
        {
            int neighbourValue = path.getCellNeighbourValue(pathCell.x, pathCell.y);
            Debug.Log("Tile " + pathCell.x + ", " + pathCell.y + " neighbour value = " + neighbourValue);
            GameObject pathTile = pathCellObjects[neighbourValue].cellPrefab;
            GameObject pathTileCell = Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            pathTileCell.transform.Rotate(0f, pathCellObjects[neighbourValue].yRotation, 0f, Space.Self);

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
                    int randomSceneryCellIndex = Random.Range(0, sceneryCellObjects.Length);
                    Instantiate(sceneryCellObjects[randomSceneryCellIndex].cellPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                    yield return new WaitForSeconds(groundDelay);
                }
            }
        }

        yield return null;
    }
    public void buildTower(TowerObj tower, Vector2Int location)
    {
        GameObject towerObj = tower.towerPrefab;
        Instantiate(towerObj, new Vector3(location.x, 0f, location.y), Quaternion.identity);
    }
}
