using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdmobBanner : MonoBehaviour {

	public string AndroidUnitID;
	public string IOSUnitID;

	private GoogleAdmobApp app;
	private string testDevice;

	private BannerView bannerView;

	void Awake() {
		app = GetComponent<GoogleAdmobApp> ();
		testDevice = app.TestDeviceID;
	}

	public void show () {
		RequestBanner ();
	}

	private void RequestBanner () {
		#if UNITY_ANDROID
		string adUnitId = AndroidUnitID;

		// admob test sample
		//string adUnitId = "ca-app-pub-3940256099942544/6300978111";
		#elif UNITY_IPHONE
		string adUnitId = IOSUnitID;
		#else
		string adUnitId = "unexpected_platform";
		#endif

		close ();
		bannerView = new BannerView (adUnitId, AdSize.Banner, AdPosition.Bottom);

		var adRqs = new AdRequest.Builder ()
		.AddTestDevice (AdRequest.TestDeviceSimulator)
		.AddTestDevice (testDevice)
		//.AddExtra ("color_bg", "9B30FF")
		.Build ();
		bannerView.LoadAd (adRqs);
	}

	public void close () {
		if (bannerView != null) {
			bannerView.Destroy ();
		}
	}
}
