using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    // for testing - Buildable Towers
    [SerializeField] private TowerBase tower;
    [SerializeField] private CreepBase creep;

    // TD Stuff
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


