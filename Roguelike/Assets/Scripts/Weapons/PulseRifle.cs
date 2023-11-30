using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PulseRifle : Weapon
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
        Vector3 spawnPoint = projectileSpawnPoint_.position;
        Vector3 spawnPointUp = projectileSpawnPoint_.up;

        GameObject projectile1 = Instantiate(projectilePrefab_, spawnPoint, projectileSpawnPoint_.rotation);
        projectile1.GetComponent<ProjectileScript>().SetDamage(damage);
        Rigidbody2D projectileRb1 = projectile1.GetComponent<Rigidbody2D>();
        projectileRb1.AddForce(projectileSpawnPoint_.up * projectileSpeed_, ForceMode2D.Impulse);

        GameObject projectile2 = Instantiate(projectilePrefab_, spawnPoint + spawnPointUp * 1.1f, projectileSpawnPoint_.rotation);
        projectile2.GetComponent<ProjectileScript>().SetDamage(damage);
        Rigidbody2D projectileRb2 = projectile2.GetComponent<Rigidbody2D>();
        projectileRb2.AddForce(projectileSpawnPoint_.up * projectileSpeed_, ForceMode2D.Impulse);
    }
}
