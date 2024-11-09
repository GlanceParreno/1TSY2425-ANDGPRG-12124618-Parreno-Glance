using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float damage = 10f; // Base damage of the tower
    public float fireRate = 1f; // Rate of fire (shots per second)
    public float range = 5f; // Attack range
    public int cost = 100; // Cost to build the tower

    protected float nextFireTime;
    protected Transform target; // Currently targeted enemy

    private void Update()
    {
        // Find target if no target is set
        if (target == null || Vector3.Distance(transform.position, target.position) > range)
        {
            FindTarget();
        }

        // Check if it's time to shoot
        if (target != null && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Set the next fire time based on fire rate
        }
    }

    // Finds the nearest enemy within range
    public virtual void FindTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range); // Detects enemies in range
        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, hit.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = hit.transform;
                }
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy; // Set the nearest enemy as target
        }
        else
        {
            target = null; // No enemy in range
        }
    }

    // Basic attack logic
    public virtual void Shoot()
    {
        if (target != null)
        {
            Monster enemyScript = target.GetComponent<Monster>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
            }
        }
    }
}

