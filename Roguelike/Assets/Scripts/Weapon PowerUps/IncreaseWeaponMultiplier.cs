using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWeaponMultiplier : PowerUpEffect
{
    public override void ApplyPowerUp()
    {
        weapon.IncreaseMultiplier(multiplier);
    }
}
