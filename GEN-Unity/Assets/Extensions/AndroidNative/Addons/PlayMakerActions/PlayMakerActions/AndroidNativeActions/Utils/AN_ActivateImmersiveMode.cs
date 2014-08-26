using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Others")]
	public class AN_ActivateImmersiveMode : FsmStateAction {
				
		public override void OnEnter() {
			ImmersiveMode.instance.EnableImmersiveMode();
			Finish();
		}
	}
}


