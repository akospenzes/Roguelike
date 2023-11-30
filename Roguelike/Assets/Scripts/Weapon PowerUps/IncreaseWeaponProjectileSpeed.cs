using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWeaponProjectileSpeed : PowerUpEffect
{
    public override void ApplyPowerUp()
    {
        weapon.IncreaseProjectileSpeed(projectileSpeed);
    }
}
