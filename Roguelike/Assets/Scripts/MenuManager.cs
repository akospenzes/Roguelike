using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button StartButton;
    public Button OptionsButton;
    public Button QuitButton;

    public Button ApplyButton;
    public Button BackButton;
    public TMPro.TMP_InputField WaveTimeInput;
    public TMPro.TMP_InputField EnemiesPerWaveInput;

    public static float WaveTime = 60.0f;
    public static int EnemiesPerWave = 10;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void OpenOptions()
    {
        StartButton.gameObject.SetActive(false);
        OptionsButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);

        ApplyButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
        WaveTimeInput.gameObject.SetActive(true);
        EnemiesPerWaveInput.gameObject.SetActive(true);

        WaveTimeInput.text = WaveTime.ToString();
        EnemiesPerWaveInput.text = EnemiesPerWave.ToString();
    }

    public void ApplyOptions()
    {
        WaveTime = float.Parse(WaveTimeInput.text);
        EnemiesPerWave = int.Parse(EnemiesPerWaveInput.text);

        WaveTimeInput.gameObject.SetActive(false);
        EnemiesPerWaveInput.gameObject.SetActive(false);

        ApplyButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

        StartButton.gameObject.SetActive(true);
        OptionsButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
    }

    public void BackWithoutApply()
    {
        WaveTimeInput.gameObject.SetActive(false);
        EnemiesPerWaveInput.gameObject.SetActive(false);

        ApplyButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

        StartButton.gameObject.SetActive(true);
        OptionsButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
    }
}
