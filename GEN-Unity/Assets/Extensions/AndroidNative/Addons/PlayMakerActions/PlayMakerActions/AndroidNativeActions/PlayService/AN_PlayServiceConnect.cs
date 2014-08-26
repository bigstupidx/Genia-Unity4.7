using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	[Tooltip("Init Play Service. Best practice to do this on appplicaton start")]
	public class AN_PlayServiceConnect : FsmStateAction {

		public FsmEvent successEvent;
		public FsmEvent failEvent;
		
		public override void Reset() {
			
		}

		public override void OnEnter() {
			
			bool IsInEdditorMode = false;
			
			#if UNITY_EDITOR
			IsInEdditorMode = true;
			#endif
			
			
			if(IsInEdditorMode) {
				Fsm.Event(successEvent);
				Finish();
				return;
			}
			
			
			GooglePlayConnection.instance.addEventListener (GooglePlayConnection.PLAYER_CONNECTED, OnPlayerConnected);
			GooglePlayConnection.instance.addEventListener (GooglePlayConnection.PLAYER_DISCONNECTED, OnPlayerDisconnected);

			if(GooglePlayConnection.state == GPConnectionState.STATE_CONNECTED) {
				//checking if player already connected
				OnPlayerConnected ();
			} 

			GooglePlayConnection.instance.connect();
			
		}

		private void OnPlayerDisconnected() {
			GooglePlayConnection.instance.removeEventListener (GooglePlayConnection.PLAYER_CONNECTED, OnPlayerConnected);
			GooglePlayConnection.instance.removeEventListener (GooglePlayConnection.PLAYER_DISCONNECTED, OnPlayerDisconnected);

			Fsm.Event(failEvent);
			Finish();
		}
		
		private void OnPlayerConnected() {
			GooglePlayConnection.instance.removeEventListener (GooglePlayConnection.PLAYER_CONNECTED, OnPlayerConnected);
			GooglePlayConnection.instance.removeEventListener (GooglePlayConnection.PLAYER_DISCONNECTED, OnPlayerDisconnected);

			Fsm.Event(successEvent);
			Finish();
		}



	}
}

