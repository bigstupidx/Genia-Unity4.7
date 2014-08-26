using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Pop-ups")]
	public class AN_MessagePopup : FsmStateAction {
		
		public FsmString title; 	
		public FsmString message;  




		
		
		public override void OnEnter() {

			bool IsInEdditorMode = false;
			
			#if UNITY_EDITOR
			IsInEdditorMode = true;
			#endif
			
			
			if(IsInEdditorMode) {
				Finish();
				return;
			}

			AndroidMessage msg = AndroidMessage.Create(title.Value, message.Value);
			msg.addEventListener(BaseEvent.COMPLETE, OnComplete);
			
		}

		public override void Reset() {
			base.Reset();
			
			title =  "Messahe title";
			message   = "Messahe text";

			
		}



		private void OnComplete(CEvent e) {
			Finish();
		}



		
	}
}


