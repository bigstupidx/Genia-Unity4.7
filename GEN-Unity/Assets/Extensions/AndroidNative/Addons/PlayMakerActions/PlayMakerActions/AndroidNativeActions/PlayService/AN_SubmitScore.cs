using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_SubmitScore : FsmStateAction {

		public FsmString leaderboardId;
		public FsmInt score;


		public override void OnEnter() {
			GooglePlayManager.instance.submitScoreById(leaderboardId.Value, score.Value);
			Finish();
			
		}

	}
}

