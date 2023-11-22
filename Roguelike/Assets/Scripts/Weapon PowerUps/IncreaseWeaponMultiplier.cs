using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWeaponMultiplier : PowerUpEffect
{
    private void Start()
    {
        text = weaponName + " : " + text;
    }

    public override void ApplyPowerUp()
    {
        weapon.IncreaseMultiplier(multiplier);
    }
}
