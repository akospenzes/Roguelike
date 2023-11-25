using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : PowerUpEffect
{
    public GameObject player;
    public int amount;
    public override void ApplyPowerUp()
    {
        player.GetComponent<PlayerController>().IncreaseHealth(amount);
    }
}
