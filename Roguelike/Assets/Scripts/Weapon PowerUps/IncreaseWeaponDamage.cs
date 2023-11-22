using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWeaponDamage : PowerUpEffect
{
    public override void ApplyPowerUp()
    {
        weapon.IncreaseDamage(damage);
    }
}
