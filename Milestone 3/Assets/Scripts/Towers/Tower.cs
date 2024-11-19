using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Tower attributes
    public float damage = 10f; // Base damage
    public float fireRate = 1f; // Rate of fire (shots per second)
    public float range = 5f; // Attack range
    public int cost = 100; // Cost to build the tower

    // Upgrade-related attributes
    public int upgradeLevel = 0; // Current upgrade level
    public int maxUpgradeLevel = 3; // Maximum upgrade level
    public int baseUpgradeCost = 100; // Cost of the first upgrade
    public float upgradeCostMultiplier = 1.5f; // Multiplier for subsequent upgrade costs

    // Upgrade increments
    public float damageIncreasePerLevel = 5f; // Increase damage per upgrade
    public float rangeIncreasePerLevel = 1f; // Increase range per upgrade
    public float fireRateIncreasePerLevel = 0.2f; // Increase fire rate per upgrade

    // Visual feedback for upgrades
    public Renderer towerRenderer; // For applying materials
    public Material[] upgradeMaterials; // Materials for each upgrade level

    // Targeting logic
    protected float nextFireTime; // Time until the next shot
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

    // Upgrade logic

    // Calculate the cost of the next upgrade
    public int GetUpgradeCost()
    {
        return Mathf.CeilToInt(baseUpgradeCost * Mathf.Pow(upgradeCostMultiplier, upgradeLevel));
    }

    // Upgrade path 1: Increase damage
    public void UpgradePath1()
    {
        if (upgradeLevel < maxUpgradeLevel)
        {
            upgradeLevel++;
            damage += damageIncreasePerLevel;
            ApplyUpgradeVisuals();
        }
    }

    // Upgrade path 2: Increase range
    public void UpgradePath2()
    {
        if (upgradeLevel < maxUpgradeLevel)
        {
            upgradeLevel++;
            range += rangeIncreasePerLevel;
            ApplyUpgradeVisuals();
        }
    }

    // Upgrade path 3: Increase fire rate
    public void UpgradePath3()
    {
        if (upgradeLevel < maxUpgradeLevel)
        {
            upgradeLevel++;
            fireRate += fireRateIncreasePerLevel;
            ApplyUpgradeVisuals();
        }
    }

    // Apply visual feedback for upgrades
    private void ApplyUpgradeVisuals()
    {
        if (towerRenderer != null && upgradeLevel - 1 < upgradeMaterials.Length)
        {
            towerRenderer.material = upgradeMaterials[upgradeLevel - 1];
        }
    }
}
