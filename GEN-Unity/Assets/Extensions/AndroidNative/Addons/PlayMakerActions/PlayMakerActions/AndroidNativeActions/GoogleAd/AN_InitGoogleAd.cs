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
	public class AN_InitGoogleAd : FsmStateAction {


		public FsmString bannersAdunityId;
		public FsmString interstisialsAdunityId;


		public override void OnEnter() {
			AndroidAdMobController.instance.Init(bannersAdunityId.Value);
			AndroidAdMobController.instance.SetInterstisialsUnitID(interstisialsAdunityId.Value);
			Finish();
		}



		
	}
}
