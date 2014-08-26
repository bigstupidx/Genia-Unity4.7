using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {

	[ActionCategory("Android Native - Billing")]
	public class AN_RetriveInventory : FsmStateAction {

		public FsmEvent successEvent;
		public FsmEvent failEvent;


		public FsmString[] purchases;
		public FsmString[] products;


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

			InitAndroidInventoryTask iTask = InitAndroidInventoryTask.Create();
			iTask.addEventListener(BaseEvent.COMPLETE, OnInvComplete);
			iTask.addEventListener(BaseEvent.FAILED, OnInvFailed);
			iTask.Run();


			
		}

		private void OnInvComplete(CEvent e) {
			e.dispatcher.removeEventListener(BaseEvent.COMPLETE, OnInvComplete);
			e.dispatcher.removeEventListener(BaseEvent.FAILED, OnInvFailed);

			purchases = new FsmString[AndroidInAppPurchaseManager.instance.inventory.purchases.Count];

			int i = 0;
			foreach(GooglePurchaseTemplate purch in AndroidInAppPurchaseManager.instance.inventory.purchases) {
				purchases[i] = purch.SKU;
				i++;
			}	

			products = new FsmString[AndroidInAppPurchaseManager.instance.inventory.products.Count];

			i = 0;
			foreach(GoogleProductTemplate prod in AndroidInAppPurchaseManager.instance.inventory.products) {
				products[i] = prod.SKU;
				i++;
			}	


			Fsm.Event(successEvent);
			Finish();

		}

		private void OnInvFailed(CEvent e) {
			e.dispatcher.removeEventListener(BaseEvent.COMPLETE, OnInvComplete);
			e.dispatcher.removeEventListener(BaseEvent.FAILED, OnInvFailed);
			Fsm.Event(failEvent);
			Finish();

		}

	
		
	}
}
