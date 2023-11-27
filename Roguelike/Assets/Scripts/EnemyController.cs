using JetBrains.Annotations;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy stats")]
    public float maxHealth;
    public int damage;

    [Header("Healthbar")]
    public Image healthBarImage;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
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
        //play animation
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
    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }
}
