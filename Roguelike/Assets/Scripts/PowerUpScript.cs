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

    [Header("PowerUp UI")]
    public GameObject UICanvas;
    public Button effect1Button;
    public Button effect2Button;
    public Button effect3Button;
    public TextMeshProUGUI effect1Text;
    public TextMeshProUGUI effect2Text;
    public TextMeshProUGUI effect3Text;

    private void Start()
    {
        CreatePowerUpWindow();
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
        List<PowerUpEffect> random_powerups = GetThreePowerUps();
        effect1Text.text = random_powerups[0].weaponName + " : " + random_powerups[0].text;
        effect2Text.text = random_powerups[1].weaponName + " : " + random_powerups[1].text;
        effect3Text.text = random_powerups[2].weaponName + " : " + random_powerups[2].text;
        effect1Button.onClick.AddListener(delegate {ButtonPressed(random_powerups[0]);});
        effect2Button.onClick.AddListener(delegate {ButtonPressed(random_powerups[1]);});
        effect3Button.onClick.AddListener(delegate {ButtonPressed(random_powerups[2]);});
        UICanvas.SetActive(true);
    }

    public void ButtonPressed(PowerUpEffect p)
    {
        p.ApplyPowerUp();
        UICanvas.SetActive(false);
    }

}