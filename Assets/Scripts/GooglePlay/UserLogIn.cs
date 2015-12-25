﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UserLogIn : MonoBehaviour {

	void Start () {
		LogIn();
	}

	public void LogIn() {
		Social.localUser.Authenticate((bool success) => {
			if(success) {
				//Whoop whoop.
				Debug.Log("log");
			} else {
				//Whomp whomp.
			}
   	 	});
	}
}
