using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPickUpScript : MonoBehaviour
{
    public int healthAmount;
    public SoundEffectPlayer effectPlayer;
    private void Start()
    {
        Invoke("DestroyHealthPickUp", 150.0f);
    }

    public void DestroyHealthPickUp() 
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            effectPlayer.PlayHealthPickupSound();
            collision.gameObject.GetComponent<PlayerController>().IncreaseHealth(healthAmount);
            Destroy(gameObject);
        }
    }

    public void SetHealthAmount(int amount)
    {
        healthAmount = amount;
    }

    public void SetEffectPlayer(GameObject sfx)
    {
        effectPlayer = sfx.GetComponent<SoundEffectPlayer>();
    }
}
