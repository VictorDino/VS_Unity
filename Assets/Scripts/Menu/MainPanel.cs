using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainPanel : MonoBehaviour
{
    private float lastVolume;
    private float lastFxVolume;

    [Header("Options")]
    public Slider volumeMaster;
    public Slider volumeFX;
    public Toggle mute;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;

    [Header("Audio")]
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;

    private void Awake()
    {
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
    }
    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("volMaster", v);
    }

    public void ChangeVolumeFX(float v)
    {
        mixer.SetFloat("volFX", v);
    }

    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }

    public void SetMute()
    {
        
        if (mute.isOn)
        {
            mixer.GetFloat("volMaster", out lastVolume);
            mixer.GetFloat("volFX", out lastFxVolume);

            mixer.SetFloat("volMaster", -80);
            mixer.SetFloat("volFX", -80);
        }
        else
        {
            mixer.SetFloat("volMaster", lastVolume);
            mixer.SetFloat("volFX", lastFxVolume);
        }
    }
}
