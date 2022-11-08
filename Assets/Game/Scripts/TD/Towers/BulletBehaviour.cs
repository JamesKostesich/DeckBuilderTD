using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform target;
    private float speed;

    public GameObject impactEffect;

    public void Seek(Transform _target, float _speed)
    {
        //Can pass other information to bullet here
        target = _target;
        speed = _speed;
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
        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }
}
