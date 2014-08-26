using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_ReportAchievement : FsmStateAction {

		public FsmString achivmentId;



		public override void OnEnter() {
			GooglePlayManager.instance.reportAchievementById(achivmentId.Value);
			Finish();
		}

	}
}

