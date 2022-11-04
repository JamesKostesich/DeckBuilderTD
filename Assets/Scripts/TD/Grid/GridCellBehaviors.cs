using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCellBehaviors : MonoBehaviour
{
    public bool Path;

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
        GameObject tower = GameManager.Instance.TowerPrefab;

        float x = this.transform.position.x;
        float z = this.transform.position.z;

        Instantiate(tower, new Vector3(x, 0f, z), Quaternion.identity);
    }
}
