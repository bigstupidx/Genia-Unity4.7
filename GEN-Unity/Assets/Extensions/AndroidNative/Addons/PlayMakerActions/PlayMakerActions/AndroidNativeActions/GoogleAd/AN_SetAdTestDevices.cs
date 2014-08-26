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
	public class AN_SetAdTestDevices : FsmStateAction {


		public FsmString[] devicesIds;


		public override void OnEnter() {
			foreach(FsmString id in devicesIds) {
				AndroidAdMobController.instance.AddTestDevice(id.Value);
			}

			Finish();
		}



		
	}
}
