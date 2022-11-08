using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform target;
    private float speed;
    private Creep creep;
    private TowerBehaviour tower;

    public GameObject impactEffect;

    public void Seek(Transform _target, float _speed, Creep _creep, TowerBehaviour _tower)
    {
        //Can pass other information to bullet here
        target = _target;
        speed = _speed;
        creep = _creep;
        tower = _tower;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //dir.magnitude = distance to target
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);
        //Damage Math
        float crit = 1;
        if(Random.Range(0,101) <= tower.critChance)
        {
            crit = tower.critDamage;
        }
        if (creep.takeDamage(tower.damage, crit) || creep.takeMDamage(tower.magicDamage, crit))
        {
            GameManager.Instance.GetComponent<WaveManager>().killCreep(creep);
        }
        Destroy(gameObject);
    }
}
