using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Pop-ups")]
	public class AN_HidePreloader : FsmStateAction {
		

		
		public override void OnEnter() {
			AndroidNativeUtility.HidePreloader();
			Finish();
			
		}

	}
}


