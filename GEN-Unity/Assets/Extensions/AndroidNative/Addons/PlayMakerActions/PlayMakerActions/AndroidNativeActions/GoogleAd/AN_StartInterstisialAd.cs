////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav (Stan's Assets) 
// @support stans.assets@gmail.com 
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;



namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Google Ad")]
	public class AN_StartInterstisialAd : FsmStateAction {

		[Tooltip("Event fired when Ad is started")]
		public FsmEvent successEvent;
		
		[Tooltip("Event fired when Ad is failed to load")]
		public FsmEvent failEvent;
		
		public override void OnEnter() {
			AndroidAdMobController.instance.StartInterstitialAd();
			AndroidAdMobController.instance.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LOADED, OnReady);
			AndroidAdMobController.instance.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_FAILED_LOADING, OnFail);
			
		}
		
		
		private void OnReady() {
			
			AndroidAdMobController.instance.removeEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LOADED, OnReady);
			AndroidAdMobController.instance.removeEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_FAILED_LOADING, OnFail);
			
			Fsm.Event(successEvent);
			Finish();
		}
		
		private void OnFail() {
			
			AndroidAdMobController.instance.removeEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LOADED, OnReady);
			AndroidAdMobController.instance.removeEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_FAILED_LOADING, OnFail);
			
			Fsm.Event(failEvent);
			Finish();
		}
		
	}
}
