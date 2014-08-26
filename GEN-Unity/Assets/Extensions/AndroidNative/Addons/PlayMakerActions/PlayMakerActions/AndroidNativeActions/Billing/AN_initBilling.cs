using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {

	[ActionCategory("Android Native - Billing")]
	[Tooltip("Init billing. Best practice to do this on appplicaton start")]
	public class AN_initBilling : FsmStateAction {


		[Tooltip("Event fired when billing initlization is complete")]
		public FsmEvent successEvent;

		public override void Reset() {
		
		}


		public override void OnEnter() {

			bool IsInEdditorMode = false;

			#if UNITY_EDITOR_OSX || UNITY_EDITOR
			IsInEdditorMode = true;
			#endif


			if(IsInEdditorMode) {
				Fsm.Event(successEvent);
				Finish();
				return;
			}


			AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_BILLING_SETUP_FINISHED, OnInit);
			AndroidInAppPurchaseManager.instance.loadStore();

		}


		private void OnInit() {
			AndroidInAppPurchaseManager.instance.removeEventListener (AndroidInAppPurchaseManager.ON_BILLING_SETUP_FINISHED, OnInit);

			Fsm.Event(successEvent);
			Finish();
		}

	}
}

