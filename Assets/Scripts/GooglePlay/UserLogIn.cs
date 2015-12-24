using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UserLogIn : MonoBehaviour {

	public Text debugText;

	void Start () {
		LogIn();
	}

	public void LogIn() {
		Social.localUser.Authenticate((bool success) => {
       		if(success) {
       			debugText.text = "Login Success";
       		} else {
       			debugText.text = "Login Failure";
       		}
   	 	});
	}
}
