using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Creep", menuName = "TowerDefense/Creep")]
public class CreepBase : ScriptableObject
{
    [SerializeField] string title;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] GameObject creepModel;

    [SerializeField] int health;
    [SerializeField] int moveSpeed;

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
    public GameObject CreepModel
    {
        get { return creepModel; }
    }
    public int Health
    {
        get { return health; }
    }
    public int MoveSpeed
    {
        get { return moveSpeed; }
    }
    public Element ElementType
    {
        get { return elementType; }
    }
}
