using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_ShowLeaderboards : FsmStateAction {

		
		public override void Reset() {
			
		}


		public override void OnEnter() {
			GooglePlayManager.instance.showLeaderBoardsUI();
			Finish();
		}

	}
}

