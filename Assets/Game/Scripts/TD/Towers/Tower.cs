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

    //In the getters we can apply formulas to modify a stat for all future towers, for easier testing.
    //Also can be used to create card effects which buff towers that haven't been built yet.

    public string Title
    {
        get { return _base.Title; }
    }
    public string Description
    {
        get { return _base.Description; }
    }
    public string Targets
    {
        get { return _base.TargetsAllowed; }
    }
    public float Range
    {
        get { return 1 * _base.Range; }
    }
    public float ProjectileSpeed
    {
        get { return 1 * _base.ProjectileSpeed; }
    }
    public float Damage
    {
        get { return 1 * _base.Damage; }
    }
    public float AttackSpeed
    {
        get { return 1 * _base.AttackSpeed; }
    }
    public float CritChance
    {
        get { return 1 * _base.CritChance; }
    }
    public float CritDamage
    {
        get { return 1 * _base.CritDamage; }
    }
    public float MagicDamage
    {
        get { return 1 * _base.MagicDamage; }
    }
    public float Mana
    {
        get { return 1 * _base.Mana; }
    }
    public float TurnSpeed
    {
        get { return 1 * _base.TurnSpeed; }
    }
}
