using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class CreepBehaviour : MonoBehaviour, IGetHealthSystem
{
    private HealthSystem healthSystem;

    public float health;

    private void Awake()
    {
        healthSystem = new HealthSystem(health);
    }

    public void Damage(float damage)
    {
        healthSystem.Damage(damage);
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
