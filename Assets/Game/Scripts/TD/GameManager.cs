using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    // for testing - Buildable Towers
    [SerializeField] private TowerBase tower;
    [SerializeField] private CreepBase creep;

    [SerializeField] private GameObject towerInfo;

    public GameObject[,] grid;

    public TowerBase Tower
    {
        get
        {
            return tower;
        }
    }
    public CreepBase Creep
    {
        get
        {
            return creep;
        }
    }
    public GameObject TowerInfo
    {
        get
        {
            return towerInfo;
        }
    }
}
