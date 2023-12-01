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
    public TMPro.TMP_Text WaveTimeInputText;
    public TMPro.TMP_Text EnemiesPerWaveInputText;
    public TMPro.TMP_Text MusicSliderText;
    public TMPro.TMP_Text SFXSliderText;
    public Slider MusicSlider;
    public Slider SFXSlider;
    public GameObject QuitUICanvas;
    public GameObject PlayerUICanvas;

    public static float WaveTime = 45.0f;
    public static int EnemiesPerWave = 10;
    public static float MusicValue = 1.0f;
    public static float SFXValue = 1.0f;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ContinueGame()
    {
        PlayerUICanvas.SetActive(true);
        QuitUICanvas.SetActive(false);
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
        WaveTimeInputText.gameObject.SetActive(true);
        EnemiesPerWaveInputText.gameObject.SetActive(true);
        MusicSliderText.gameObject.SetActive(true);
        SFXSliderText.gameObject.SetActive(true);
        MusicSlider.gameObject.SetActive(true);
        SFXSlider.gameObject.SetActive(true);

        WaveTimeInput.text = WaveTime.ToString();
        EnemiesPerWaveInput.text = EnemiesPerWave.ToString();

    }

    public void ApplyOptions()
    {
        WaveTime = float.Parse(WaveTimeInput.text);
        EnemiesPerWave = int.Parse(EnemiesPerWaveInput.text);
        MusicValue = MusicSlider.value;
        SFXValue = SFXSlider.value;

        WaveTimeInput.gameObject.SetActive(false);
        EnemiesPerWaveInput.gameObject.SetActive(false);

        ApplyButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);

        StartButton.gameObject.SetActive(true);
        OptionsButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
        WaveTimeInputText.gameObject.SetActive(false);
        EnemiesPerWaveInputText.gameObject.SetActive(false);
        MusicSliderText.gameObject.SetActive(false);
        SFXSliderText.gameObject.SetActive(false);
        MusicSlider.gameObject.SetActive(false);
        SFXSlider.gameObject.SetActive(false);
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
        WaveTimeInputText.gameObject.SetActive(false);
        EnemiesPerWaveInputText.gameObject.SetActive(false);
        MusicSliderText.gameObject.SetActive(false);
        SFXSliderText.gameObject.SetActive(false);
        MusicSlider.gameObject.SetActive(false);
        SFXSlider.gameObject.SetActive(false);
    }
}
