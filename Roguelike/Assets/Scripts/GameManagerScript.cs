using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public PowerUpScript powerUpManager;
    void Start()
    {
        powerUpManager.CreatePowerUpWindow();
    }

}
