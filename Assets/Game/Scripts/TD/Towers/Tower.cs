using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    TowerBase _base;
    int level;

    public Tower(TowerBase tBase, int tLevel)
    {
        _base = tBase;
        level = tLevel;
    }

    public int AttackDamage
    {
        get { return 10 * _base.AttackDamage; }
    }
}
