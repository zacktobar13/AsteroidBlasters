using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour 
{

    public GameObject[] settingsMenuText;
    public GameObject creditsMenu, confirmPage, dataDeletedText, scoreInfoText;
    public Image soundToggleImage, settingsButton;
    public Sprite soundOn, soundOff, settingsButtonUnpressed;
    public ScoreManager scoreManager;
    SoundManager soundManager;
    GeneralSounds generalSounds;
    bool soundEnabled;
    public GameObject mainMenu;

    void OnEnable() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        generalSounds = GetComponent<GeneralSounds>();

        if (PlayerPrefs.GetString("Sound") == "True") {
            soundToggleImage.sprite = soundOn;
            soundEnabled = true;
        } else {
            soundToggleImage.sprite = soundOff;
            soundEnabled = false;
        }
    }
    
    void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            ShowMainMenu();
        }
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowCredits() 
    {
        creditsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ToggleSound() 
    {
        soundEnabled = !soundEnabled;

        if(soundEnabled == true) 
        {
            soundManager.DisableSound();
            soundToggleImage.sprite = soundOff;
            PlayerPrefs.SetString("Sound", "False");
        } 
        else 
        {
            soundManager.EnableSound();
            soundToggleImage.sprite = soundOn;
            PlayerPrefs.SetString("Sound", "True");
        }
    }

    public void ShowConfirmPage() 
    {
        gameObject.SetActive(false);
        confirmPage.SetActive(true);
    }
}