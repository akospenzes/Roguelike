using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float damage;
    public float cooldown;
    public int multiplier;

    protected bool canShoot;
    protected float remainingCooldown;

    protected virtual void Start()
    {
        canShoot = true;
        remainingCooldown = 0f;
    }

    protected virtual void Update()
    {
        if (remainingCooldown > 0f)
        {
            remainingCooldown -= Time.deltaTime;
        }
        if (remainingCooldown <= 0f)
        {
            canShoot = true;
        }
    }

    public virtual void Shoot(GameObject projectilePrefab, Transform projectileSpawnPoint, float projectileSpeed){ }

    public void IncreaseFireRate(float fireRate) 
    {
        if (fireRate > 1.0f) 
        {
            cooldown /= fireRate;
        }
    }

    public void IncreaseDamage(float damage_)
    {
        damage += damage_;
    }

    public void IncreaseMultiplier(int multiplier_)
    {
        if (multiplier_ > 1)
        {
            multiplier *= multiplier_;
        }
    }
}
