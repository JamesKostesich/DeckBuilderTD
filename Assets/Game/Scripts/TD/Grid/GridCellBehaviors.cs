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

            //Hide towerInfo when clicking on a cell with no tower.
            towerInfo.SetActive(false);
        }
    }

    private void PlaceTower()
    {
        //Test towerBase, will be passed in future
        towerBase = GameManager.Instance.Tower;

        //Placement location
        float x = this.transform.position.x;
        float y = this.transform.position.y + 0.5f;
        float z = this.transform.position.z;
        
        tower = new Tower(towerBase);
        tower.towerObj = Instantiate(tower._base.TowerModel, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        TowerBehaviour stats = tower.towerObj.GetComponent<TowerBehaviour>();

        //Set TowerBehaviour base stats from Tower class
        stats.title = tower.Title;
        stats.description = tower.Description;

        stats.targetsAllowed = tower.Targets;
        stats.turnSpeed = tower.TurnSpeed;
        stats.projectileSpeed = tower.ProjectileSpeed;
        stats.range = tower.Range;

        stats.damage = tower.Damage;
        stats.attackSpeed = tower.AttackSpeed;
        stats.critChance = tower.CritChance;
        stats.critDamage = tower.CritDamage;
        stats.magicDamage = tower.MagicDamage;
        stats.mana = tower.Mana;
    }
    private void PlaceTower(TowerBase towerBase)
    {
        float x = this.transform.position.x;
        float z = this.transform.position.z;
        tower = new Tower(towerBase);
        tower.towerObj = Instantiate(tower._base.TowerModel, new Vector3(x, 0f, z), Quaternion.identity) as GameObject;
    }
}
