using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCellBehaviors : MonoBehaviour
{
    public bool Path;
    public TowerBase tower { get; set; }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!Path)
            {
                PlaceTower();
                this.Path = true;
            }
        }
    }

    private void PlaceTower()
    {
        tower = GameManager.Instance.Tower;

        float x = this.transform.position.x;
        float z = this.transform.position.z;

       Instantiate(tower.TowerModel, new Vector3(x, 0f, z), Quaternion.identity);
    }
}
