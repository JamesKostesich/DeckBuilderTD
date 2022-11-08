using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep
{
    public CreepBase _base;
    int level;
    public GameObject creepObj;
    private float moveSpeed;
    private double creepSlow;
    public string moveDir;
    public Vector2 pos;
    public int currentPath;

    public Creep(CreepBase tBase, int tLevel = 1)
    {
        _base = tBase;
        level = tLevel;
        moveSpeed = _base.MoveSpeed;
        moveDir = "forward";
        currentPath = 0;
    }
    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
}
