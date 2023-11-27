using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpScript : MonoBehaviour
{
    public int healthAmount;

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
            collision.gameObject.GetComponent<PlayerController>().IncreaseHealth(healthAmount);
            //animacio
            Destroy(gameObject);
        }
    }

    public void SetHealthAmount(int amount)
    {
        healthAmount = amount;
    }
}
