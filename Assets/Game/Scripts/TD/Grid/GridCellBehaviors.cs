using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCellBehaviors : MonoBehaviour
{
    public bool buildable;
    public TowerBase towerBase { get; set; }
    public Tower tower;

    private GameObject towerInfo;
    
    void Start()
    {
        towerInfo = GameManager.Instance.TowerInfo;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buildable)
            {
                PlaceTower();
                this.buildable = true;
            }

            towerInfo.SetActive(false);
        }
    }

    private void PlaceTower()
    {
        towerBase = GameManager.Instance.Tower;

        float x = this.transform.position.x;
        float z = this.transform.position.z;
        tower = new Tower(towerBase);
        tower.towerObj = Instantiate(tower._base.TowerModel, new Vector3(x, 0.5f, z), Quaternion.identity) as GameObject;
    }
    private void PlaceTower(TowerBase towerBase)
    {
        float x = this.transform.position.x;
        float z = this.transform.position.z;
        tower = new Tower(towerBase);
        tower.towerObj = Instantiate(tower._base.TowerModel, new Vector3(x, 0f, z), Quaternion.identity) as GameObject;
    }
}
