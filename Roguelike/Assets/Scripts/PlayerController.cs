using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;

    [Header("Projectile")]
    public float projectileSpeed;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float weaponCooldown;

    [Header("Weapons")]
    public Weapon pulseRifle;
    public Weapon shotgun;
    public Weapon pistols;


    private Rigidbody2D rb;
    private Vector2 movementDir;
    private Vector2 mousePos;
    private Weapon selectedWeapon;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selectedWeapon = pulseRifle;
    }

    void Update()
    {
        GetInput();
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

        if (Input.GetKeyDown("1"))
        {
            selectedWeapon = pulseRifle;
        }
        if (Input.GetKeyDown("2"))
        {
            selectedWeapon = shotgun;
        }
        if (Input.GetKeyDown("3"))
        {
            selectedWeapon = pistols;
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
        selectedWeapon.Shoot(projectilePrefab, projectileSpawnPoint, projectileSpeed);
    }
}
