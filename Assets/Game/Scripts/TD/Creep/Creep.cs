using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep
{
    public CreepBase _base;
    int level;
    public GameObject creepObj;
    private double creepMoveDelay;
    private double creepSlow;
    public string moveDir;
    public Vector2 pos;

    public Creep(CreepBase tBase, int tLevel = 1)
    {
        _base = tBase;
        level = tLevel;
        creepMoveDelay = _base.MoveSpeed;
        moveDir = "forward";
    }
    public bool shouldMove()
    {
        creepMoveDelay--;
        if (creepMoveDelay <= 0)
        {
            creepMoveDelay = _base.MoveSpeed;
            return true;
        }
        return false;
    }
    public void move()
    {

    }
}
