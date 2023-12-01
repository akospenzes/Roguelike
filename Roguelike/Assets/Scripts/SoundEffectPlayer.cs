using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource projectile;
    public AudioSource healthPickUp;
    public AudioSource enemy;

    public void PlayProjectileSound()
    {
        projectile.volume = MenuManager.SFXValue;
        projectile.Play();
    }
    public void PlayHealthPickupSound()
    {
        healthPickUp.volume = MenuManager.SFXValue;
        healthPickUp.Play();
    }
    public void PlayEnemySound()
    {
        enemy.volume = MenuManager.SFXValue;
        enemy.Play();
    }
}
