using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistols : Weapon
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Shoot()
    {
        if (canShoot)
        {
            base.Shoot();
            for (int i = 0; i < multiplier; i++)
            {
                if (i == 0)
                    CreateProjectiles();
                else
                    Invoke("CreateProjectiles", i * 0.05f);
            }
            canShoot = false;
            remainingCooldown = cooldown;
        }
    }

    private void CreateProjectiles()
    {
        Vector2 force1 = projectileSpawnPoint_.up * projectileSpeed_;

        GameObject projectile1 = Instantiate(projectilePrefab_, projectileSpawnPoint_.position, projectileSpawnPoint_.rotation);
        projectile1.GetComponent<ProjectileScript>().SetDamage(damage);
        Rigidbody2D projectileRb = projectile1.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(force1, ForceMode2D.Impulse);
    }
}
