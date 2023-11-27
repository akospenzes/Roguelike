using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player stats")]
    public int maxHealth;
    public float movementSpeed;
    public int currentHealth;

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
        currentHealth = maxHealth;
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

        if (Input.GetKey("space"))
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
        selectedWeapon.Shoot();
    }

    public void HitByEnemy(int damage)
    {
        currentHealth -= damage;
        Physics2D.IgnoreLayerCollision(6, 9, true);
        Invoke("EnableEnemyCollision", 3);
    }

    private void EnableEnemyCollision()
    {
        Physics2D.IgnoreLayerCollision(6, 9, false);
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        IncreaseHealth(amount);
    }

    public void IncreaseMovementSpeed(float amount)
    {
        movementSpeed += amount;
    }
}
