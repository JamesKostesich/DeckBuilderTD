using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreepWave", menuName = "TowerDefense/CreepWave")]
public class CreepWaveBase : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] List<CreepBase> creepBases;

    public string Title
    {
        get { return title; }
    }
    public List<CreepBase> CreepBases
    {
        get { return creepBases; }
    }
}
