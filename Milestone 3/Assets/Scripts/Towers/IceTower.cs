using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IceTower : Tower
{
    public float slowAmount = 0.5f; // Slow effect (e.g., 50% speed reduction)
    public float slowDuration = 2f; // Duration of slow effect

    public override void Shoot()
    {
        if (target != null)
        {
            Monster monsterScript = target.GetComponent<Monster>();
            if (monsterScript != null)
            {
                StartCoroutine(ApplySlow(monsterScript));
                monsterScript.TakeDamage(damage);
            }
        }
    }

    private IEnumerator ApplySlow(Monster monster)
    {
        // Assuming the monster has a "speed" property that can be modified
        monster.speed *= slowAmount;
        yield return new WaitForSeconds(slowDuration);
        monster.speed /= slowAmount; // Reset speed after duration
    }
}


