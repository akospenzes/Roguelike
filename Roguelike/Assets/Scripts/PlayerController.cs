using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject firePoint;
    public TMPro.TMP_Text healthText;
    public TMPro.TMP_Text movementSpeedText;
    public TMPro.TMP_Text selectedWeaponText;
    public TMPro.TMP_Text weaponDamageText;
    public TMPro.TMP_Text weaponFireRateText;
    public TMPro.TMP_Text weaponMultiplierText;
    public TMPro.TMP_Text weaponProjectileSpeedText;

    [Header("Player stats")]
    public int maxHealth;
    public float movementSpeed;
    public int currentHealth;

    [Header("Weapons")]
    public Weapon pulseRifle;
    public Weapon shotgun;
    public Weapon pistols;

    private Rigidbody2D rb;
    private Rigidbody2D fp_rb;
    private Vector2 movementDir;
    private Vector2 mousePos;
    private Weapon selectedWeapon;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Color spriteColor;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selectedWeapon = pulseRifle;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        fp_rb = firePoint.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        UpdateFirePointPosition();
        UpdatePlayerUI();
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

        if (Mathf.Abs(mx) > 0.0f || Mathf.Abs(my) > 0.0f)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
            if (mx < 0.0f)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

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
        fp_rb.rotation = angle;
    }

    private void Shoot()
    {
        selectedWeapon.Shoot();
    }

    public void HitByEnemy(int damage)
    {
        currentHealth -= damage;
        Physics2D.IgnoreLayerCollision(6, 9, true);
        Color c = spriteColor;
        c.a = 0.5f;
        spriteRenderer.color = c;
        Invoke("EnableEnemyCollision", 3);
    }

    private void EnableEnemyCollision()
    {
        spriteRenderer.color = spriteColor;
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
    private void UpdateFirePointPosition()
    {
        fp_rb.position = rb.position;
    }

    private void UpdatePlayerUI()
    {
        healthText.text = "Health : " + currentHealth.ToString() + "/" + maxHealth.ToString();
        movementSpeedText.text = "Movement speed : " + movementSpeed.ToString();
        selectedWeaponText.text = "Selected weapon : " + selectedWeapon.weaponName;
        weaponDamageText.text = "Damage : " + selectedWeapon.damage.ToString();
        weaponFireRateText.text = "Fire rate : " + (1.0f / selectedWeapon.cooldown).ToString();
        weaponMultiplierText.text = "Multiplier : " + selectedWeapon.multiplier.ToString();
        weaponProjectileSpeedText.text = "Projectile speed : " + selectedWeapon.projectileSpeed_.ToString();
}
}
