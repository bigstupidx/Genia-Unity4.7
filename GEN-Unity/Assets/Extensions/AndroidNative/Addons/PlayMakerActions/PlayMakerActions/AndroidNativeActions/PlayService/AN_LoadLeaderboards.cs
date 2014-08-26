using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {

	[ActionCategory("Android Native - PlayService")]
	public class AN_LoadLeaderboards : FsmStateAction {

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


			GooglePlayManager.instance.addEventListener (GooglePlayManager.LEADERBOARDS_LOEADED, OnLeaderBoardsLoaded);
			GooglePlayManager.instance.loadLeaderBoards ();
		}

		private void OnLeaderBoardsLoaded() {
			GooglePlayManager.instance.removeEventListener (GooglePlayManager.LEADERBOARDS_LOEADED, OnLeaderBoardsLoaded);
			
			Fsm.Event(successEvent);
			Finish();
		}
	}
}
