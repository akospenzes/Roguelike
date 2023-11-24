using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PulseRifle : Weapon
{
    private GameObject projectilePrefab_;
    private Transform projectileSpawnPoint_;
    private float projectileSpeed_;
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

    public override void Shoot(GameObject projectilePrefab, Transform projectileSpawnPoint, float projectileSpeed)
    {
        projectilePrefab_ = projectilePrefab;
        projectileSpawnPoint_ = projectileSpawnPoint;
        projectileSpeed_ = projectileSpeed;

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
    {   //eltolás
        GameObject projectile1 = Instantiate(projectilePrefab_, projectileSpawnPoint_.position, projectileSpawnPoint_.rotation);
        Rigidbody2D projectileRb1 = projectile1.GetComponent<Rigidbody2D>();
        projectileRb1.AddForce(projectileSpawnPoint_.up * projectileSpeed_, ForceMode2D.Impulse);

        GameObject projectile2 = Instantiate(projectilePrefab_, projectileSpawnPoint_.position, projectileSpawnPoint_.rotation);
        Rigidbody2D projectileRb2 = projectile2.GetComponent<Rigidbody2D>();
        projectileRb2.AddForce(projectileSpawnPoint_.up * projectileSpeed_, ForceMode2D.Impulse);
    }
}
