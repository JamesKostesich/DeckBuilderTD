using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep
{
    public CreepBase _base;
    int level;
    public GameObject creepObj;
    public CreepBehaviour creepBehaviour;
    private double creepSlow;
    public string moveDir;
    public int currentPath;
    void Start()
    {
    }
    public Creep(CreepBase tBase, int tLevel = 1)
    {
        _base = tBase;
        level = tLevel;
        MoveSpeed = _base.MoveSpeed;
        moveDir = "forward";
        currentPath = 0;
    }
    public bool takeDamage(float damage, float crit)
    {
        //returns true if dead
        creepBehaviour.health -= damage*crit;
        if(creepBehaviour.health < 0)
        {
            return true;
        }
        return false;
    }
    public bool takeMDamage(float damage, float crit)
    {
        //returns true if dead
        creepBehaviour.health -= damage * crit;
        if (creepBehaviour.health < 0)
        {
            return true;
        }
        return false;
    }
    public float MoveSpeed { get; }
    public float Health { get; }
}
