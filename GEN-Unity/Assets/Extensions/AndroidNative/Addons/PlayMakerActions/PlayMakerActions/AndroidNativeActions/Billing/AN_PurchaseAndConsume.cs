using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions {

	[ActionCategory("Android Native - Billing")]
	[Tooltip("Aaction will start purchase flow on device. In Editor mode Success event will fired immediately")]
	public class AN_PurchaseAndConsume : FsmStateAction {


		[Tooltip("Event fired when Store Kit initlization is complete")]
		public FsmEvent successEvent;

		[Tooltip("Event fired when Store Kit initlization is failed")]
		public FsmEvent failEvent;


		[Tooltip("Purhase product Id")]
		public string ProductID  = "";

	

		public override void OnEnter() {

			Debug.Log("AN: AN_PurchaseAndConsume action started");

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
			Debug.Log("AN: OnInvComplete");
			e.dispatcher.removeEventListener(BaseEvent.COMPLETE, OnInvComplete);
			e.dispatcher.removeEventListener(BaseEvent.FAILED, OnInvFailed);


			if(AndroidInAppPurchaseManager.instance.inventory.IsProductPurchased(ProductID)) {
				Debug.Log("AN: " + ProductID+ " already purchased");

				AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_CONSUMED,  OnProductConsumed);
				AndroidInAppPurchaseManager.instance.consume (ProductID);

			} else {
				Debug.Log("AN: " + ProductID+ " not yet purchased");

				AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_PURCHASED, OnProductPurchased);
				AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_CONSUMED,  OnProductConsumed);
				
				AndroidInAppPurchaseManager.instance.purchase(ProductID);
			}

		}
		
		private void OnInvFailed(CEvent e) {
			e.dispatcher.removeEventListener(BaseEvent.COMPLETE, OnInvComplete);
			e.dispatcher.removeEventListener(BaseEvent.FAILED, OnInvFailed);
			OnFailed();
		}




		private void OnProductPurchased(CEvent e) {

			BillingResult result = e.data as BillingResult;

			Debug.Log ("AN: Cousume Responce: " + result.response.ToString() + " " + result.message);

			if(result.isSuccess) {
				AndroidInAppPurchaseManager.instance.consume (ProductID);
			} else {
				OnFailed();
			}




		}

		private void OnProductConsumed(CEvent e) {
			BillingResult result = e.data as BillingResult;
			Debug.Log ("AN: Cousume Responce: " + result.response.ToString() + " " + result.message);

			if(result.isSuccess) {
				OnPurchase();
			} else {
				OnFailed();
			}
			

		}


		private void OnPurchase() {
			Debug.Log("AN: AN_PurchaseAndConsume action Finsihed");
			Debug.Log("AN: OnPurchase Finsihed successEvent");
			AndroidInAppPurchaseManager.instance.removeEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_PURCHASED, OnProductPurchased);
			AndroidInAppPurchaseManager.instance.removeEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_CONSUMED,  OnProductConsumed);

			Fsm.Event(successEvent);
			Finish();

		}

		private void OnFailed() {
			Debug.Log("AN: AN_PurchaseAndConsume action Finsihed");
			Debug.Log("AN: OnFailed Finsihed failEvent");

			AndroidInAppPurchaseManager.instance.removeEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_PURCHASED, OnProductPurchased);
			AndroidInAppPurchaseManager.instance.removeEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_CONSUMED,  OnProductConsumed);

			Fsm.Event(failEvent);
			Finish();

		}
		
	}
}
