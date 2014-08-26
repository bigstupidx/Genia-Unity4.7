using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_ShowAchivmentsUI : FsmStateAction {

		
		public override void Reset() {
			
		}


		public override void OnEnter() {
			GooglePlayManager.instance.showAchievementsUI();
			Finish();
			
		}

	}
}

