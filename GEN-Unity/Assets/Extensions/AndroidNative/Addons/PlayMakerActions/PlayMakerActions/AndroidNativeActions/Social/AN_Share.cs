using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Social")]
	public class AN_Share : FsmStateAction {
				
		public FsmString title;
		public FsmString message;


		public override void OnEnter() {
		
			AndroidSocialGate.StartShareIntent(title.Value, message.Value);
			Finish();
		}

	}
}


