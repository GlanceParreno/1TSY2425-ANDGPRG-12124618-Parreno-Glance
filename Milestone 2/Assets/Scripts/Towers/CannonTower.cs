using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
    public float splashRadius = 2f; // Radius for splash damage

    public override void Shoot()
    {
        if (target != null)
        {
            Collider[] hits = Physics.OverlapSphere(target.position, splashRadius);
            foreach (var hit in hits)
            {
                Monster monsterScript = hit.GetComponent<Monster>();
                if (monsterScript != null)
                {
                    monsterScript.TakeDamage(damage);
                }
            }
        }
    }
}

