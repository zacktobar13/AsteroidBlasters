using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ActivateGooglePlay : MonoBehaviour {

	void Start () {
		PlayGamesPlatform.Activate();
	}
}
