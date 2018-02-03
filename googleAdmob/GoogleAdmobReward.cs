using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class GoogleAdmobReward : MonoBehaviour {

	public string AndroidUnitID;
	public string IOSUnitID;

	private GoogleAdmobApp app;
	private string testDevice;

	private RewardBasedVideoAd rewardBasedVideo;

	void Awake() {
		app = GetComponent<GoogleAdmobApp> ();
		testDevice = app.TestDeviceID;
	}

	// Use this for initialization
	void Start () {
		rewardBasedVideo = RewardBasedVideoAd.Instance;
		
		// Called when an ad request has successfully loaded.
		rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
		// Called when an ad request failed to load.
		rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		// Called when an ad is shown.
		rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
		// Called when the ad starts to play.
		rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
		// Called when the user should be rewarded for watching a video.
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
		// Called when the ad is closed.
		rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
		// Called when the ad click caused the user to leave the application.
		rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
		
		RequestRewardedVideo ();
	}

	public void show () {
		if (rewardBasedVideo.IsLoaded ()) {
			rewardBasedVideo.Show ();
		}
	}

	private void RequestRewardedVideo () {
		#if UNITY_ANDROID
		string adUnitId = AndroidUnitID;
		#elif UNITY_IPHONE
		string adUnitId = IOSRewardUnitID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ()
		.AddTestDevice (AdRequest.TestDeviceSimulator)
		.AddTestDevice (testDevice)
		.Build ();
		// Load the rewarded video ad with the request.
		this.rewardBasedVideo.LoadAd (request, adUnitId);
	}

	public void HandleRewardBasedVideoLoaded (object sender, EventArgs args) {
		MonoBehaviour.print ("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad (object sender, AdFailedToLoadEventArgs args) {
		MonoBehaviour.print (
			"HandleRewardBasedVideoFailedToLoad event received with message: "
			+ args.Message);
	}

	public void HandleRewardBasedVideoOpened (object sender, EventArgs args) {
		MonoBehaviour.print ("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted (object sender, EventArgs args) {
		MonoBehaviour.print ("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed (object sender, EventArgs args) {
		MonoBehaviour.print ("HandleRewardBasedVideoClosed event received");
	}

	public void HandleRewardBasedVideoRewarded (object sender, Reward args) {
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print (
			"HandleRewardBasedVideoRewarded event received for "
			+ amount.ToString () + " " + type);
	}

	public void HandleRewardBasedVideoLeftApplication (object sender, EventArgs args) {
		MonoBehaviour.print ("HandleRewardBasedVideoLeftApplication event received");
	}

}
