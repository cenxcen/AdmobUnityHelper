using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;



public class GoogleAdmobApp : MonoBehaviour {

	public string AppAndroidID;
	public string AppIosID;

	public string TestDeviceID;

	void Awake () {
		_bannerCtl = GetComponent<GoogleAdmobBanner> ();
		_interstitialCtl = GetComponent<GoogleAdmobInterstitial> ();
		_rewardCtl = GetComponent<GoogleAdmobReward> ();
	}

	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		string appId = AppAndroidID;
		#elif UNITY_IPHONE
		string appId = AppIosID;
		#else
		string appId = "unexpected_platform";
		#endif

		MobileAds.Initialize (appId);
	}

	public void showBanner () {
		if (haveBannerCtl) {
			_bannerCtl.show ();
		}
	}

	public void closeBanner () {
		if (haveBannerCtl) {
			_bannerCtl.close ();
		}
	}

	public void showReward () {
		if (haveRewardCtl) {
			_rewardCtl.show ();
		}
	}

	public void showInterstitial () {
		if (haveInterstitial) {
			_interstitialCtl.show ();
		}
	}

	public void closeInterstitial () {
		if (haveInterstitial) {
			_interstitialCtl.close ();
		}
	}

	private GoogleAdmobBanner _bannerCtl = null;

	public GoogleAdmobBanner ctlBanner {
		get {
			return _bannerCtl;
		}
	}

	public bool haveBannerCtl {
		get {
			return !object.ReferenceEquals (_bannerCtl, null);
		}
	}

	private GoogleAdmobReward _rewardCtl = null;

	public GoogleAdmobReward ctlReward {
		get {
			return _rewardCtl;
		}
	}

	public bool haveRewardCtl {
		get {
			return !object.ReferenceEquals (_rewardCtl, null);
		}
	}

	private GoogleAdmobInterstitial _interstitialCtl = null;

	public GoogleAdmobInterstitial ctlInterstitial {
		get {
			return _interstitialCtl;
		}
	}

	public bool haveInterstitial {
		get {
			return !object.ReferenceEquals (_interstitialCtl, null);
		}
	}
}
