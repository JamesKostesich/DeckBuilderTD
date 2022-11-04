using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridCell", menuName = "TowerDefense/Grid Cell")]
public class GridCellBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] CellType type;
    [SerializeField] GameObject cellPrefab;
    [SerializeField] int yRotation;

    public string Name {
        get { return name; }
    }

    public string Description {
        get { return description; }
    }

    public CellType Type { 
        get{ return type; } 
    }

    public GameObject CellPrefab {
        get { return cellPrefab; }
    }

    public int Rotation {
        get { return yRotation; }
    }

    public enum CellType { Path, Ground }
}
