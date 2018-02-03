using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdmobInterstitial : MonoBehaviour {

	public string AndroidUnitID;
	public string IOSUnitID;

	private GoogleAdmobApp app;
	private string testDevice;

	private InterstitialAd interstitial;

	void Awake() {
		app = GetComponent<GoogleAdmobApp> ();
		testDevice = app.TestDeviceID;
	}

	public void show () {
		RequestInterstitial ();
		if (interstitial.IsLoaded ()) {
			interstitial.Show ();
		}
	}

	public void close() {
		if (interstitial != null) {
			interstitial.Destroy ();
		}
	}

	private void RequestInterstitial () {
		#if UNITY_ANDROID
		string adUnitId = AndroidUnitID;
		#elif UNITY_IPHONE
		string adUnitId = IOSUnitID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		close ();
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd (adUnitId);

		AdRequest request = new AdRequest.Builder ()
		.AddTestDevice (AdRequest.TestDeviceSimulator)
		.AddTestDevice (testDevice)
		.Build ();
		// Load the interstitial with the request.
		interstitial.LoadAd (request);
	}
	
}
