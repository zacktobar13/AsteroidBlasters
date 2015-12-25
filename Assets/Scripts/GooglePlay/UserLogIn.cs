using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UserLogIn : MonoBehaviour {
	public MainMenu mainMenu;

	void Start () {
		LogIn();
	}

	public void LogIn() {
		Social.localUser.Authenticate((bool success) => {
			if(success) {
				mainMenu.SendMessage("LogInSuccess");
			} else {
				mainMenu.SendMessage("FailedLogIn");
			}
   	 	});
	}
}
