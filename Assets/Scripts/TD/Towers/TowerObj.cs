using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "TowerDefense/Tower")]
public class TowerObj : ScriptableObject
{
    public enum Element { Path, Ground }
    public int AttackDamage;
    public int AttackSpeed;
    public GameObject towerPrefab;
    public int turretRotationCenter;
    private GameObject turret;

}
