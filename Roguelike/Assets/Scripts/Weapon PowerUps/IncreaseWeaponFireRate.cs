using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseWeaponFireRate : PowerUpEffect
{
    private void Start()
    {
        text = weaponName + " : " + text;
    }

    public override void ApplyPowerUp()
    {
        weapon.IncreaseFireRate(fireRate);
    }
}
