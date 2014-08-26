using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - PlayService")]
	public class AN_SubscribeToGiftsActions : FsmStateAction {
		
		public FsmEvent giftResultReceived;
		public FsmEvent pendingGameRequestDetected;

		public FsmBool showInboxRequestDetected;
		public FsmString code;
		public FsmString[] receivedGiftsPlayload;

		public FsmString reseivedgiftPlayLoad;


		public override void OnEnter() {				
			GooglePlayManager.instance.addEventListener (GooglePlayManager.SEND_GIFT_RESULT_RECEIVED, OnGiftResult);
			GooglePlayManager.instance.addEventListener (GooglePlayManager.PENDING_GAME_REQUESTS_DETECTED, OnPendingGiftsDetected);
			GooglePlayManager.instance.addEventListener (GooglePlayManager.GAME_REQUESTS_ACCEPTED, OnGameRequestAccepted);
		}
	
		private void OnGiftResult(CEvent e) {
			GooglePlayManager.instance.removeEventListener (GooglePlayManager.SEND_GIFT_RESULT_RECEIVED, OnGiftResult);

			GooglePlayGiftRequestResult result = e.data as GooglePlayGiftRequestResult;
			this.code.Value = result.code.ToString();

			Fsm.Event(giftResultReceived);
		}

		private void OnPendingGiftsDetected(CEvent e) {
			GooglePlayManager.instance.removeEventListener (GooglePlayManager.PENDING_GAME_REQUESTS_DETECTED, OnPendingGiftsDetected);

			if (showInboxRequestDetected.Value) {
				GooglePlayManager.instance.ShowRequestsAccepDialog();
			}

			Fsm.Event(pendingGameRequestDetected);
		}

		private void OnGameRequestAccepted(CEvent e) {
			List<GPGameRequest> gifts = e.data as List<GPGameRequest>;
			receivedGiftsPlayload = new FsmString[]{};
			for(int i = 0; i < gifts.Count; i++) {
				receivedGiftsPlayload[i] = gifts[i].playload;
			}
		}
	}
}