using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
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

    public override void Shoot(GameObject projectilePrefab, Transform projectileSpawnPoint, float projectileSpeed)
    {
        if (canShoot)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(projectileSpawnPoint.up * projectileSpeed, ForceMode2D.Impulse);
            canShoot = false;
            remainingCooldown = cooldown;
        }
    }
}
