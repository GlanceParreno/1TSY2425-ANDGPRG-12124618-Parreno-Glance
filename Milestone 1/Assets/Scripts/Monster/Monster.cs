using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed; // Movement speed
    public float health; // Health points

    public virtual void Move() {}

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject); // Removes the monster from the scene
    }
}

