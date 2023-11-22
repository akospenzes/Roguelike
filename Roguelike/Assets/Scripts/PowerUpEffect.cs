using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    [Header("Effect stats")]
    public Weapon weapon;
    public float damage;
    public float fireRate;
    public int multiplier;
    public string weaponName;
    public string text;
    public virtual void ApplyPowerUp() { }
}
