using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "TowerDefense/Tower")]
public class TowerBase : ScriptableObject
{
    [SerializeField] string title;
    [TextArea]
    [SerializeField] string description;

    [SerializeField] string targetsAllowed = "Enemy";
    [SerializeField] float range;
    [SerializeField] float projectileSpeed;
    [SerializeField] float turnSpeed;

    [SerializeField] float damage;
    [SerializeField] float attackSpeed;
    [SerializeField] float critChance;
    [SerializeField] float critDamage;
    [SerializeField] float magicDamage;
    [SerializeField] float mana;

    [SerializeField] Element elementType;
    [SerializeField] GameObject towerModel;

    public enum Element { Fire, Water }

    public string Title
    {
        get { return title; }
    }
    public string Description
    {
        get { return description; }
    }
    public string TargetsAllowed
    {
        get { return targetsAllowed; }
    }
    public float Range
    {
        get { return range; }
    }
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
    }
    public float Damage
    {
        get { return damage; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
    }
    public float CritChance
    {
        get { return critChance; }
    }
    public float CritDamage
    {
        get { return critDamage; }
    }
    public float MagicDamage
    {
        get { return magicDamage; }
    }
    public float Mana
    {
        get { return mana; }
    }
    public float TurnSpeed
    {
        get { return turnSpeed; }
    }
    public Element ElementType
    {
        get { return elementType; }
    }
    public GameObject TowerModel
    {
        get { return towerModel; }
    }
}
