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
	public class AN_RefreshBanner : FsmStateAction {

		public FsmInt bannerId;

		public override void OnEnter() {
			GoogleMobileAdBanner banner =  AndroidAdMobController.instance.GetBanner(bannerId.Value);
			if(banner != null) {
				banner.Refresh();
			}
		}

	}
}
