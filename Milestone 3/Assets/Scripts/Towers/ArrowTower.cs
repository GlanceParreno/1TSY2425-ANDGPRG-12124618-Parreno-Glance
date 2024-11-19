using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower
{
    public override void Shoot()
    {
        if (target != null)
        {
            Monster monsterScript = target.GetComponent<Monster>();
            if (monsterScript != null)
            {
                monsterScript.TakeDamage(damage);
            }
        }
    }
}