using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    public string weaponName;
    public float damage;
    public float cooldown;
    public int multiplier;

    protected bool canShoot;
    protected float remainingCooldown;

    public GameObject projectilePrefab_;
    public Transform projectileSpawnPoint_;
    public float projectileSpeed_;

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

    public virtual void Shoot(){ }

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
        multiplier += multiplier_;
    }

    public void IncreaseProjectileSpeed(float amount)
    {
        projectileSpeed_ += amount;
    }
}
