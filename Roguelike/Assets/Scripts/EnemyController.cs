using JetBrains.Annotations;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject effectPrefab;
    public SoundEffectPlayer effectPlayer;

    [Header("Enemy stats")]
    public float maxHealth;
    public int damage;

    [Header("Healthbar")]
    public Image healthBarImage;

    private float currentHealth;
    private SpriteRenderer spriteRenderer;
    private AIDestinationSetter destinationSetter;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void Update()
    {
        float x = transform.position.x;
        float tx = destinationSetter.target.transform.position.x;

        if (x - tx > 0.0f)
        {
            spriteRenderer.flipX = true;
        }
        else 
        {
            spriteRenderer.flipX = false;
        }
    }

    public void ReduceHealth(float damage)
    {
        currentHealth -= damage;

        healthBarImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0.0f)
        {
            Despawn();
        }
    }

    private void Despawn()
    {
        effectPlayer.PlayEnemySound();
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 0.35f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().HitByEnemy(damage);

            gameObject.GetComponent<AIDestinationSetter>().target = collision.gameObject.transform;
        }
    }

    public void SetAIDestination(GameObject player)
    {
        gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
    }

    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
        currentHealth = maxHealth;
    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }
    public void SetEffectPlayer(GameObject sfx)
    {
        effectPlayer = sfx.GetComponent<SoundEffectPlayer>();
    }
}
