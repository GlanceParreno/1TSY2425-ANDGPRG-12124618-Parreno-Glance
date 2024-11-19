using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireTower : Tower
{
    public float burnDamage = 5f; // Damage per second for burn effect
    public float burnDuration = 3f; // Duration of burn effect

    public override void Shoot()
    {
        if (target != null)
        {
            Monster monsterScript = target.GetComponent<Monster>();
            if (monsterScript != null)
            {
                StartCoroutine(ApplyBurn(monsterScript));
                monsterScript.TakeDamage(damage);
            }
        }
    }

    private IEnumerator ApplyBurn(Monster monster)
    {
        float burnTime = 0;
        while (burnTime < burnDuration)
        {
            monster.TakeDamage(burnDamage);
            burnTime += 1f;
            yield return new WaitForSeconds(1f);
        }
    }
}
