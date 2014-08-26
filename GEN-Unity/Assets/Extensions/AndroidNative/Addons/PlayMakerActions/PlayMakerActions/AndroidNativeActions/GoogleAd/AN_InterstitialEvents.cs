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
	public class AN_InterstitialEvents : FsmStateAction {

		 
		public FsmEvent OnLoadedEvent;
		public FsmEvent OnFailedToLoadEvent;

		public FsmEvent OnOpenEvent;
		public FsmEvent OnCloseEvent;
		public FsmEvent OnLeftApplicationEvent;

		
		public override void OnEnter() {
			AndroidAdMobController.instance.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LOADED, OnLoaded);
			AndroidAdMobController.instance.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_FAILED_LOADING, OnFailedToLoad);


			AndroidAdMobController.instance.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_OPENED, OnOpen);
			AndroidAdMobController.instance.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_CLOSED, OnClose);
			AndroidAdMobController.instance.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LEFT_APPLICATION, OnLeftApplication);

		}


		private void OnLoaded() {
			Fsm.Event(OnLoadedEvent);
		}

		private void OnFailedToLoad() {
			Fsm.Event(OnFailedToLoadEvent);
		}


		private void OnOpen() {
			Fsm.Event(OnOpenEvent);
		}

		private void OnClose() {
			Fsm.Event(OnCloseEvent);
		}

		private void OnLeftApplication() {
			Fsm.Event(OnLeftApplicationEvent);
		}
		

		
	}
}
