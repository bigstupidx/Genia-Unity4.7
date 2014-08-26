using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_PlayServiceDisconnect : FsmStateAction {


		public override void OnEnter() {
			GooglePlayConnection.instance.disconnect();
			Finish();
		}



	}
}

