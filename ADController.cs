using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;


public class ADController : MonoBehaviour {

	public static ADController ad;

	void Awake () {
		if (ad != this && ad != null) {
			if (ad.haveAdmobApp ) {
				ad.ctlAdmobApp.closeBanner ();
			}
		}

		ad = this;
		_admobAppCtl = GetComponent<GoogleAdmobApp> ();
	}
	
	private GoogleAdmobApp _admobAppCtl = null;
	public GoogleAdmobApp ctlAdmobApp {
		get {
			return _admobAppCtl;
		}
	}

	public bool haveAdmobApp {
		get {
			return !object.ReferenceEquals (_admobAppCtl, null);
		}
	}
	
}
