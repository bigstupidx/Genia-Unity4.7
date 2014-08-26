using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {

	[ActionCategory("Android Native - Billing")]
	public class AN_RetriveProductInfo : FsmStateAction {



		public FsmString ProductSKU  = "";




		public FsmString price;	
		public FsmString title;
		public FsmString description;
		public FsmString priceAmountMicros;
		public FsmString priceCurrencyCode;



		public FsmEvent successEvent;
		public FsmEvent failEvent;
	

		public override void OnEnter() {

			#if UNITY_EDITOR
				Fsm.Event(successEvent);
				Finish();
			#endif

	   		#if !UNITY_EDITOR
				InitAndroidInventoryTask iTask = InitAndroidInventoryTask.Create();
				iTask.addEventListener(BaseEvent.COMPLETE, OnInvComplete);
				iTask.addEventListener(BaseEvent.FAILED, OnInvFailed);
				iTask.Run();
			#endif

			
		}

		private void OnInvComplete(CEvent e) {
			e.dispatcher.removeEventListener(BaseEvent.COMPLETE, OnInvComplete);
			e.dispatcher.removeEventListener(BaseEvent.FAILED, OnInvFailed);


			if(AndroidInAppPurchaseManager.instance.inventory.GetProductDetails(ProductSKU.Value) != null) {
				OnSuccess();
			} else {
				OnFailed();
			}

		}

		private void OnInvFailed(CEvent e) {
			e.dispatcher.removeEventListener(BaseEvent.COMPLETE, OnInvComplete);
			e.dispatcher.removeEventListener(BaseEvent.FAILED, OnInvFailed);
			OnFailed();
		}





		private void OnSuccess() {

			GoogleProductTemplate tpl =  AndroidInAppPurchaseManager.instance.inventory.GetProductDetails(ProductSKU.Value);

			price = tpl.price;	
			title = tpl.title;
			description = tpl.description;
			priceAmountMicros = tpl.priceAmountMicros;
			priceCurrencyCode = tpl.priceCurrencyCode;

			Fsm.Event(successEvent);
			Finish();
		}



		private void OnFailed() {
			Fsm.Event(failEvent);
			Finish();
		}
		
	}
}
