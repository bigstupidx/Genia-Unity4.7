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
	public class AN_ShowInterstisialAd : FsmStateAction {

		[Tooltip("Event fired when Ad is started")]
		public FsmEvent successEvent;
		
		[Tooltip("Event fired when Ad is failed to load")]
		public FsmEvent failEvent;
		
		public override void OnEnter() {
			AndroidAdMobController.instance.ShowInterstitialAd();
			Finish();
		}

	}
}
