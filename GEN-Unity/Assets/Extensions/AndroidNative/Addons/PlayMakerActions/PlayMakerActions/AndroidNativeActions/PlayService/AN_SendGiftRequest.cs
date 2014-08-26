using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
		
	[ActionCategory("Android Native - PlayService")]
	public class AN_SendGiftRequest : FsmStateAction {
		
		public GPGameRequestType type_gift = GPGameRequestType.TYPE_GIFT;	
		public FsmInt requestLifeTimeDays;
		public FsmTexture tx;
		public FsmString description;
		public FsmString playLoadID;
		
		public override void OnEnter() {
			GooglePlayManager.instance.SendGiftRequest(type_gift, requestLifeTimeDays.Value, tx.Value as Texture2D, description.Value, playLoadID.Value);
			Finish();
		}		
	}
}

