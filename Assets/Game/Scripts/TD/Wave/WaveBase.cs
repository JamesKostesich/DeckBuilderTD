using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "TowerDefense/Wave")]
public class WaveBase : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] List<CreepBase> creepBases;
    [SerializeField] float delay;

    public string Title
    {
        get { return title; }
    }
    public List<CreepBase> CreepBases
    {
        get { return creepBases; }
    }
    public float Delay
    {
        get { return delay; }
    }
}
