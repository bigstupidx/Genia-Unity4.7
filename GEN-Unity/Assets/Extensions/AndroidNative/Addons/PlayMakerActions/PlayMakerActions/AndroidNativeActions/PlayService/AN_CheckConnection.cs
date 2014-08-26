using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {

	public class AN_CheckConnection : FsmStateAction {

		public FsmBool connection;

		public FsmEvent serviceConnected;
		public FsmEvent serviceDisconnected;
		
		public override void OnEnter() {
			
			bool IsInEdditorMode = false;

			#if UNITY_EDITOR
			IsInEdditorMode = true;
			#endif

			connection.Value = GooglePlayConnection.state == GPConnectionState.STATE_CONNECTED || IsInEdditorMode ? true : false;								

			Fsm.Event (connection.Value ? serviceConnected : serviceDisconnected);

			Finish ();
		}
	}
}
