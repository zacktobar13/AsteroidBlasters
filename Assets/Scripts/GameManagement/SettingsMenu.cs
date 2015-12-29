﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class SettingsMenu : MonoBehaviour {

    public GameObject[] settingsMenuText;
    public GameObject creditsMenu, backButton, confirmPage, dataDeletedText, scoreInfoText;
    public Image soundToggleImage, settingsButton;
    public Sprite soundOn, soundOff, settingsButtonUnpressed;
    public ScoreManager scoreManager;
    SoundManager soundManager;
    GeneralSounds generalSounds;
    bool soundEnabled, canTouch;
    bool creditsEnabled, confirmPageEnabled = false;
    public MainMenu mainMenu;
    string filePath;

    void OnEnable() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        generalSounds = GetComponent<GeneralSounds>();
        soundManager.PlaySound(generalSounds.Sounds[0]);
        canTouch = true;
        foreach(GameObject text in settingsMenuText) {
            text.SetActive(true);
        }
        if (PlayerPrefs.GetString("Sound") == "True") {
            soundToggleImage.sprite = soundOn;
            soundEnabled = true;
        } else {
            soundToggleImage.sprite = soundOff;
            soundEnabled = false;
        }
    }
    
    void Update () {
        foreach(Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                if (OnSoundToggler(touch.position)) {
                    ToggleSound();
                } else if (OnEraseHighScore(touch.position)) {
                    ShowConfirmPage();
                } else if (OnSettingsButton(touch.position)) {
                    ToggleSettingsMenu();
                } else if (OnYesButton(touch.position)) {
                    StartCoroutine("EraseHighScore");
                } else if (OnNoButton(touch.position)) {
                    NoButtonBackOut();
                } else if (OnCreditsButton(touch.position)) {
                    ShowCredits();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(creditsEnabled) {
                ShowCredits();
            } else if(confirmPageEnabled) {
                NoButtonBackOut();
            } else {
                ToggleSettingsMenu();
            }
        }
    }
    
    void ToggleSettingsMenu() {
        soundManager.PlaySound(generalSounds.Sounds[0]);
        foreach(GameObject text in settingsMenuText) {
            text.SetActive(false);
        }
        mainMenu.enabled = true;
        this.enabled = false;
        settingsButton.sprite = settingsButtonUnpressed;
    }

    bool OnSoundToggler(Vector2 touchPos) {
        if (!creditsEnabled && !confirmPageEnabled && touchPos.x > Screen.width * .72 &&  touchPos.x < Screen.width * .86 && 
            touchPos.y > Screen.height * .4 && touchPos.y < Screen.height * .57) {
            return true;
        }
        return false;
    }

    bool OnEraseHighScore(Vector2 touchPos) {
        if (!creditsEnabled && !confirmPageEnabled && touchPos.x > Screen.width * .2 && touchPos.x < Screen.width * .83 
             && touchPos.y > Screen.height * .17 && touchPos.y < Screen.height * .31) {
                return true;
        }
        return false;
    }

    bool OnSettingsButton(Vector2 touchPos) {
        if (!creditsEnabled && !confirmPageEnabled && touchPos.x < Screen.width * .15 && touchPos.y > Screen.height * .85) {
            return true;
        }
        return false;
    }

    bool OnCreditsButton(Vector2 touchPos) {
        if (!confirmPageEnabled && touchPos.x > Screen.width * .8
             && touchPos.y < Screen.height * .08) {
                return true;
        }
        return false;
    }

    bool OnYesButton(Vector2 touchPos) {
        if (confirmPageEnabled && canTouch && touchPos.x < Screen.width * .4 && touchPos.x > Screen.width * .15
             && touchPos.y < Screen.height * .26 && touchPos.y > Screen.height * .13) {
                return true;
        }
        return false;
    }

    bool OnNoButton(Vector2 touchPos) {
        if (confirmPageEnabled && canTouch && touchPos.x < Screen.width * .84 && touchPos.x > Screen.width * .6
             && touchPos.y < Screen.height * .3 && touchPos.y > Screen.height * .17) {
                return true;
        }
        return false;
    }

    void ShowCredits() {
        creditsEnabled = !creditsEnabled;
        scoreInfoText.SetActive(false);
        if(creditsEnabled) {
            soundManager.PlaySound(generalSounds.Sounds[0]);

            foreach(GameObject text in settingsMenuText) {
                text.SetActive(false);
            }
            backButton.SetActive(true);
            creditsMenu.SetActive(true);
        } else {
            soundManager.PlaySound(generalSounds.Sounds[0]);
            scoreInfoText.SetActive(true);
            foreach(GameObject text in settingsMenuText) {
                text.SetActive(true);
            }
            backButton.SetActive(false);
            creditsMenu.SetActive(false);
        }
    }

    void ToggleSound() {
        soundEnabled = !soundEnabled;

        if(soundEnabled == true) {
            soundManager.DisableSound();
            soundToggleImage.sprite = soundOff;
            PlayerPrefs.SetString("Sound", "False");
        } else {
            soundManager.EnableSound();
            soundToggleImage.sprite = soundOn;
            PlayerPrefs.SetString("Sound", "True");
        }
    }

    IEnumerator EraseHighScore(){
        canTouch = false;
        confirmPage.SetActive(false);
        dataDeletedText.SetActive(true);
        soundManager.PlaySound(generalSounds.Sounds[0]);
        yield return new WaitForSeconds(1f);
        dataDeletedText.SetActive(false);
        
        foreach(GameObject text in settingsMenuText) {
                text.SetActive(true);
        }
        scoreManager.resetHighScore();
        confirmPageEnabled = false;
        canTouch = true;
    }

    void ShowConfirmPage() {
        confirmPageEnabled = !confirmPageEnabled;

        if(confirmPageEnabled) {
            confirmPage.SetActive(true);
            soundManager.PlaySound(generalSounds.Sounds[0]);

            foreach(GameObject text in settingsMenuText) {
                text.SetActive(false);
            }
        } else {
            confirmPage.SetActive(false);
            soundManager.PlaySound(generalSounds.Sounds[0]);

            foreach(GameObject text in settingsMenuText) {
                text.SetActive(true);
            }
        }
    }

    void NoButtonBackOut() {
        confirmPageEnabled = false;
        confirmPage.SetActive(false);
        soundManager.PlaySound(generalSounds.Sounds[0]);

        foreach(GameObject text in settingsMenuText) {
                text.SetActive(true);
            }
    }
        
}


