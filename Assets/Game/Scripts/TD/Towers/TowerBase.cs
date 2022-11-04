using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "TowerDefense/Tower")]
public class TowerBase : ScriptableObject
{
    [SerializeField] string title;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] GameObject towerModel;

    [SerializeField] int attackDamage;
    [SerializeField] int attackSpeed;

    [SerializeField] Element elementType;

    public enum Element { Fire, Water }

    public string Title
    {
        get { return title; }
    }
    public string Description
    {
        get { return description; }
    }
    public GameObject TowerModel
    {
        get { return towerModel; }
    }
    public int AttackDamage
    {
        get { return attackDamage; }
    }
    public int AttackSpeed
    {
        get { return attackSpeed; }
    }
    public Element ElementType
    {
        get { return elementType; }
    }
}
