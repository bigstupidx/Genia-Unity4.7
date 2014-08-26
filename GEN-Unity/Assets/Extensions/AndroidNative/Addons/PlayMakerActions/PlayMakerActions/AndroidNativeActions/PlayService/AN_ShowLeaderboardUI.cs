using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_ShowLeaderboardUI : FsmStateAction {

		public FsmString leaderboardId;


		public override void OnEnter() {
			GooglePlayManager.instance.showLeaderBoardById(leaderboardId.Value);
			Finish();
			
		}

	}
}

