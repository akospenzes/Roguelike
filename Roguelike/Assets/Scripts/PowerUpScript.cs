using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public PowerUpEffect effect10;
    public PowerUpEffect effect11;
    public PowerUpEffect effect12;
    public PowerUpEffect effect13;
    public PowerUpEffect effect14;

    [Header("PowerUp UI")]
    public GameObject UICanvas;
    public Button effect1Button;
    public Button effect2Button;
    public Button effect3Button;
    public TextMeshProUGUI effect1Text;
    public TextMeshProUGUI effect2Text;
    public TextMeshProUGUI effect3Text;

    public bool windowActive = false;

    private void Start()
    {
    }

    public List<PowerUpEffect> GetThreePowerUps()
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
        all_effects.Add(effect10);
        all_effects.Add(effect11);
        all_effects.Add(effect12);
        all_effects.Add(effect13);
        all_effects.Add(effect14);

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

    public void CreatePowerUpWindow()
    {
        windowActive = true;
        List<PowerUpEffect> random_powerups = GetThreePowerUps();
        effect1Text.text = random_powerups[0].text + random_powerups[0].weaponName;
        effect2Text.text = random_powerups[1].text + random_powerups[1].weaponName;
        effect3Text.text = random_powerups[2].text + random_powerups[2].weaponName;
        effect1Button.onClick.AddListener(delegate {ButtonPressed(random_powerups[0]);});
        effect2Button.onClick.AddListener(delegate {ButtonPressed(random_powerups[1]);});
        effect3Button.onClick.AddListener(delegate {ButtonPressed(random_powerups[2]);});
        UICanvas.SetActive(true);
    }

    public void ButtonPressed(PowerUpEffect p)
    {
        windowActive = false;
        p.ApplyPowerUp();
        effect1Button.onClick.RemoveAllListeners();
        effect2Button.onClick.RemoveAllListeners();
        effect3Button.onClick.RemoveAllListeners();
        UICanvas.SetActive(false);
    }

}