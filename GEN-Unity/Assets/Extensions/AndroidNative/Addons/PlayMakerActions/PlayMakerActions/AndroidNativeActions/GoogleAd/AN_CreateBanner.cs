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
	public class AN_CreateBanner : FsmStateAction {


		public FsmInt bannerId;
		public bool ShowBannerOnLoad = true;
		public TextAnchor anchor;
		public GADBannerSize size;

		[Tooltip("Event fired when Ad is started")]
		public FsmEvent successEvent;
		
		[Tooltip("Event fired when Ad is failed to load")]
		public FsmEvent failEvent;


		private GoogleMobileAdBanner _banner ;

		public override void OnEnter() {
			_banner = AndroidAdMobController.instance.CreateAdBanner(anchor, size);
			_banner.ShowOnLoad = ShowBannerOnLoad;
			bannerId.Value = _banner.id;

			_banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_LOADED, OnReady);
			_banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_FAILED_LOADING, OnFail);

		}


		private void OnReady() {

			_banner.removeEventListener(GoogleMobileAdEvents.ON_BANNER_AD_LOADED, OnReady);
			_banner.removeEventListener(GoogleMobileAdEvents.ON_BANNER_AD_FAILED_LOADING, OnFail);

			Fsm.Event(successEvent);
			Finish();
		}

		private void OnFail() {

			_banner.removeEventListener(GoogleMobileAdEvents.ON_BANNER_AD_LOADED, OnReady);
			_banner.removeEventListener(GoogleMobileAdEvents.ON_BANNER_AD_FAILED_LOADING, OnFail);

			Fsm.Event(failEvent);
			Finish();
		}
		
	}
}
