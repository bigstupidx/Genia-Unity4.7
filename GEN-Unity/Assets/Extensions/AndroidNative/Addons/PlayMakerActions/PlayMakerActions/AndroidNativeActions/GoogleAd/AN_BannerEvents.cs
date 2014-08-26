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
	public class AN_BannerEvents : FsmStateAction {

		public FsmInt bannerId;
		 
		public FsmEvent OnLoadedEvent;
		public FsmEvent OnFailedToLoadEvent;

		public FsmEvent OnOpenEvent;
		public FsmEvent OnCloseEvent;
		public FsmEvent OnLeftApplicationEvent;

		
		public override void OnEnter() {
			GoogleMobileAdBanner banner = AndroidAdMobController.instance.GetBanner(bannerId.Value);
			if(banner == null) {
				return;
			}

			banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_LOADED, OnLoaded);
			banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_FAILED_LOADING, OnFailedToLoad);


			banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_OPENED, OnOpen);
			banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_CLOSED, OnClose);
			banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_LEFT_APPLICATION, OnLeftApplication);

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
