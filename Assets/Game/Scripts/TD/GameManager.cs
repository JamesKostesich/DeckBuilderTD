using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    // for testing - Buildable Towers
    [SerializeField] private TowerBase tower;

    public TowerBase Tower
    {
        get
        {
            return tower;
        }
    }
}
