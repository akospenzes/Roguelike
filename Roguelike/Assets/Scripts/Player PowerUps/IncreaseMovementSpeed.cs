using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMovementSpeed : PowerUpEffect
{
    public GameObject player;
    public float amount;
    public override void ApplyPowerUp()
    {
        player.GetComponent<PlayerController>().IncreaseMovementSpeed(amount);
    }
}
