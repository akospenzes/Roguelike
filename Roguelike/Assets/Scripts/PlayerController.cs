using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementDir;
    Vector2 mousePos;
    float remainingCooldown;
    bool canShoot;

    [Header("Movement")]
    public float movementSpeed;

    [Header("Projectile")]
    public float projectileSpeed;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float weaponCooldown;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = false;
        remainingCooldown = weaponCooldown;
    }

    void Update()
    {
        GetInput();

        if (remainingCooldown > 0f)
        {
            remainingCooldown -= Time.deltaTime;            
        }
        if (remainingCooldown <= 0f)
        {
            canShoot = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void GetInput()
    {
        float mx = Input.GetAxis("Horizontal");
        float my = Input.GetAxis("Vertical");

        movementDir = new Vector2(mx, my);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(movementDir.x * movementSpeed, movementDir.y * movementSpeed);
    }

    private void Rotate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Shoot()
    {
        if (canShoot)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(projectileSpawnPoint.up * projectileSpeed, ForceMode2D.Impulse);
            canShoot = false;
            remainingCooldown = weaponCooldown;
        }
    }
}
