using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridCell", menuName = "TowerDefense/Grid Cell")]
public class GridCellObj : ScriptableObject
{
    public enum CellType { Path, Ground }

    public CellType cellType;
    public GameObject cellPrefab;
    public int yRotation;
    public bool built = false;
    public bool buildable()
    {
        if(!built && cellType == CellType.Ground)
        {
            return true;
        }
        return false;
    }

}
