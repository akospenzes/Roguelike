using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [Header("Weapon PowerUps")]
    public PowerUpEffect effect1;
    public PowerUpEffect effect2;
    public PowerUpEffect effect3;
    public PowerUpEffect effect4;
    public PowerUpEffect effect5;
    public PowerUpEffect effect6;
    public PowerUpEffect effect7;
    public PowerUpEffect effect8;
    public PowerUpEffect effect9;

    public List<PowerUpEffect> getThreePowerUps()
    {
        List<PowerUpEffect> all_effects = new List<PowerUpEffect>();
        all_effects.Add(effect1);
        all_effects.Add(effect2);
        all_effects.Add(effect3);
        all_effects.Add(effect4);
        all_effects.Add(effect5);
        all_effects.Add(effect6);
        all_effects.Add(effect7);
        all_effects.Add(effect8);
        all_effects.Add(effect9);

        List<PowerUpEffect> selected_effects = new List<PowerUpEffect>();

        for (int i = 0; i < 3; i++) 
        {
            int randomIndex = Random.Range(0, all_effects.Count);
            PowerUpEffect randomElement = all_effects[randomIndex];
            selected_effects.Add(randomElement);
            all_effects.RemoveAt(randomIndex);
        }

        return selected_effects;
    }

}