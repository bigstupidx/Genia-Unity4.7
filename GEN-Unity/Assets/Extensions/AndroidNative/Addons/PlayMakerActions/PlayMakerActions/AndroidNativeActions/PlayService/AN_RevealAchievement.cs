using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_RevealAchievement : FsmStateAction {
		
		public FsmString achievementName;		
		
		public override void OnEnter() {
			GooglePlayManager.instance.revealAchievement (achievementName.Value);
			Finish();
		}		
	}
}
