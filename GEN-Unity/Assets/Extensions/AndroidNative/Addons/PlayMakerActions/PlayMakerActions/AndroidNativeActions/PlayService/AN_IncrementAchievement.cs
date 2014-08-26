using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_IncrementAchievement : FsmStateAction {
		
		public FsmString achievementName;	
		public FsmInt numsteps;		
		
		public override void OnEnter() {
			GooglePlayManager.instance.incrementAchievement (achievementName.Value, numsteps.Value);
			Finish();
		}		
	}
}
