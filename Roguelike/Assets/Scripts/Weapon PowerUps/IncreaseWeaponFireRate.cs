using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWeaponFireRate : PowerUpEffect
{
    public override void ApplyPowerUp()
    {
        weapon.IncreaseFireRate(fireRate);
    }
}
