using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed; // Movement speed
    public float health; // Health points
    public int goldReward = 10; // Gold rewarded on death

    public virtual void Move() {}

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();

        }
    }
    private void Die()
    {
        TowerManager.Instance.AddGold(goldReward); // Reward player on death
        Destroy(gameObject);
    }
}

