using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    public TowerBase _base;
    int level;
    public GameObject towerObj;

    public Tower(TowerBase tBase, int tLevel = 1)
    {
        _base = tBase;
        level = tLevel;
    }

    public int AttackDamage
    {
        get { return 10 * _base.AttackDamage; }
    }
}
