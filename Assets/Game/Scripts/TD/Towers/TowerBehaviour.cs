using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public string title;
    public string description;
    
    //Targeting and Shooting
    public string targetsAllowed = "Enemy";
    public float range;
    public float projectileSpeed;
    public float turnSpeed;
    public GameObject bulletPrefab;

    //Stats
    public float damage;
    public float attackSpeed;
    public float critChance;
    public float critDamage;
    public float magicDamage;
    public float mana;

    //References
    private Transform target;
    private Transform partToRotate;
    private Transform firePoint;
    private GameObject towerInfo;
    private TowerInfo stats;

    //Constants
    private float fireCountdown = 0f;

    void Start()
    {
        //Ref to Children
        partToRotate = this.transform.GetChild(0);
        firePoint = partToRotate.GetChild(0);

        //Ref to UI
        towerInfo = GameManager.Instance.TowerInfo;
        stats = towerInfo.GetComponent<TowerInfo>();

        //Frequency of update target
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget()
    {
        //Create list of objects with targetable tags
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetsAllowed);
        
        //Default values
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //Find nearest enemy
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //If nearest enemy in range set it to target
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
        stats.nameText.text = title;
        stats.descText.text = description;

        stats.damage.text = damage.ToString();
        stats.speed.text = attackSpeed.ToString();
        stats.critChance.text = new string(critChance.ToString() + "%");
        stats.critDamage.text = new string("x" + critDamage.ToString());
        stats.magicDamage.text = magicDamage.ToString();
        stats.mana.text = mana.ToString();

        towerInfo.SetActive(true);
    }
}
