using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public string towerName;
    public string description;
    public string targetsAllowed = "Enemy";
    public float range;
    public float projectileSpeed;
    
    public float attackSpeed;
    public float damage;
    public float critChance;
    public float critDamage;
    public float magicDamage;
    public float mana;

    [Header("Setup Data")]
    public float turnSpeed;
    public GameObject bulletPrefab;

    private float fireCountdown = 0f;
    private Transform partToRotate;
    private Transform firePoint;

    private GameObject towerInfo;

    void Start()
    {
        partToRotate = this.transform.GetChild(0);
        firePoint = partToRotate.GetChild(0);

        towerInfo = GameManager.Instance.TowerInfo;

        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetsAllowed);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        //Target LOCKED ON!
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Shooting
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / attackSpeed;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletBehaviour bullet = bulletGO.GetComponent<BulletBehaviour>();

        if (bullet != null)
            bullet.Seek(target, projectileSpeed);
    }

    void OnMouseDown()
    {
        towerInfo.GetComponent<TowerInfo>().nameText.text = towerName;
        towerInfo.GetComponent<TowerInfo>().descText.text = description;

        towerInfo.GetComponent<TowerInfo>().damage.text = damage.ToString();
        towerInfo.GetComponent<TowerInfo>().speed.text = attackSpeed.ToString();
        towerInfo.GetComponent<TowerInfo>().critChance.text = new string(critChance.ToString() + "%");
        towerInfo.GetComponent<TowerInfo>().critDamage.text = new string("x" + critDamage.ToString());
        towerInfo.GetComponent<TowerInfo>().magicDamage.text = magicDamage.ToString();
        towerInfo.GetComponent<TowerInfo>().mana.text = mana.ToString();

        towerInfo.SetActive(true);
    }
}
