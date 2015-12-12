using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public GameObject[] settingsMenuText;
    public GameObject creditsMenu, backButton, confirmPage, dataDeletedText;
    public Image soundToggleImage;
    public Sprite settingsPressed, settingsUnpressed, soundOn, soundOff;
    public ScoreManager scoreManager;
    SoundManager soundManager;
    GeneralSounds generalSounds;
    bool soundEnabled = true;
    bool creditsEnabled, confirmPageEnabled = false;
    public MainMenu mainMenu;

    void OnEnable() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        generalSounds = GetComponent<GeneralSounds>();
        foreach(GameObject text in settingsMenuText) {
            text.SetActive(true);
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
    }
    
    void ToggleSettingsMenu() {
        soundManager.PlaySound(generalSounds.Sounds[0], .15f);
        foreach(GameObject text in settingsMenuText) {
            text.SetActive(false);
        }
        mainMenu.enabled = true;
        this.enabled = false;
    }

    bool OnSoundToggler(Vector2 touchPos) {
        if (!creditsEnabled && !confirmPageEnabled && touchPos.x > Screen.width * .72 &&  touchPos.x < Screen.width * .86 && 
            touchPos.y > Screen.height * .37 && touchPos.y < Screen.height * .57) {
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
        if (!creditsEnabled && !confirmPageEnabled && touchPos.x < Screen.width * .15 && touchPos.y > Screen.height * .5) {
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
        if (confirmPageEnabled && touchPos.x < Screen.width * .4 && touchPos.x > Screen.width * .15
             && touchPos.y < Screen.height * .26 && touchPos.y > Screen.height * .13) {
                return true;
        }
        return false;
    }

    bool OnNoButton(Vector2 touchPos) {
        if (confirmPageEnabled && touchPos.x < Screen.width * .84 && touchPos.x > Screen.width * .6
             && touchPos.y < Screen.height * .3 && touchPos.y > Screen.height * .17) {
                return true;
        }
        return false;
    }

    void ShowCredits() {
        creditsEnabled = !creditsEnabled;

        if(creditsEnabled) {
            soundManager.PlaySound(generalSounds.Sounds[0], 1f);

            foreach(GameObject text in settingsMenuText) {
                text.SetActive(false);
            }
            backButton.SetActive(true);
            creditsMenu.SetActive(true);
        } else {
            soundManager.PlaySound(generalSounds.Sounds[0], 1f);

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
        } else {
            soundManager.EnableSound();
            soundToggleImage.sprite = soundOn;
        }
    }

    IEnumerator EraseHighScore(){
        confirmPageEnabled = false;
        confirmPage.SetActive(false);
        dataDeletedText.SetActive(true);
        yield return new WaitForSeconds(1f);
        dataDeletedText.SetActive(false);
        
        foreach(GameObject text in settingsMenuText) {
                text.SetActive(true);
        }
        scoreManager.resetHighScore();
    }

    void ShowConfirmPage() {
        confirmPageEnabled = !confirmPageEnabled;

        if(confirmPageEnabled) {
            confirmPage.SetActive(true);

            foreach(GameObject text in settingsMenuText) {
                text.SetActive(false);
            }
        } else {
            confirmPage.SetActive(false);

            foreach(GameObject text in settingsMenuText) {
                text.SetActive(true);
            }
        }
    }

    void NoButtonBackOut() {
        confirmPageEnabled = false;
        confirmPage.SetActive(false);

        foreach(GameObject text in settingsMenuText) {
                text.SetActive(true);
            }
    }
        
}


