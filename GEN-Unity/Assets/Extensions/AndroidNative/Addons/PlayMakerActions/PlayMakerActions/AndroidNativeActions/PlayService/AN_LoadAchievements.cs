using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {

	[ActionCategory("Android Native - PlayService")]
	public class AN_LoadAchievements : FsmStateAction {
		
		public FsmEvent successEvent;
		
		public override void OnEnter() {
			
			bool IsInEdditorMode = false;
			
			#if UNITY_EDITOR
			IsInEdditorMode = true;
			#endif
			
			
			if (IsInEdditorMode) {
				Fsm.Event (successEvent);
				Finish ();
				return;
			}
						
			GooglePlayManager.instance.addEventListener (GooglePlayManager.ACHIEVEMENTS_LOADED, OnAchivmentsLoaded);
			GooglePlayManager.instance.loadAchievements ();
		}
		
		private void OnAchivmentsLoaded() {
			GooglePlayManager.instance.removeEventListener (GooglePlayManager.ACHIEVEMENTS_LOADED, OnAchivmentsLoaded);
			
			Fsm.Event(successEvent);
			Finish();
		}		
	}
}
