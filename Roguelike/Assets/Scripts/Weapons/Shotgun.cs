using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
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

    private static Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta), v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta));
    }

    private void CreateProjectiles()
    {
        Vector2 force1 = projectileSpawnPoint_.up * projectileSpeed_;
        Vector2 force2 = rotate(force1, 0.2f);
        Vector2 force3 = rotate(force1, -0.2f);

        GameObject projectile1 = Instantiate(projectilePrefab_, projectileSpawnPoint_.position, projectileSpawnPoint_.rotation);
        projectile1.GetComponent<ProjectileScript>().SetDamage(damage);
        Rigidbody2D projectileRb = projectile1.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(force1, ForceMode2D.Impulse);

        GameObject projectile2 = Instantiate(projectilePrefab_, projectileSpawnPoint_.position, projectileSpawnPoint_.rotation);
        projectile2.GetComponent<ProjectileScript>().SetDamage(damage);
        Rigidbody2D projectileRb2 = projectile2.GetComponent<Rigidbody2D>();
        projectileRb2.AddForce(force2, ForceMode2D.Impulse);

        GameObject projectile3 = Instantiate(projectilePrefab_, projectileSpawnPoint_.position, projectileSpawnPoint_.rotation);
        projectile3.GetComponent<ProjectileScript>().SetDamage(damage);
        Rigidbody2D projectileRb3 = projectile3.GetComponent<Rigidbody2D>();
        projectileRb3.AddForce(force3, ForceMode2D.Impulse);
    }

}
