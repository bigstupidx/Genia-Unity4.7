using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Pop-ups")]
	public class AN_RatePopup : FsmStateAction {
		
		public FsmString title; 	
		public FsmString message;   
		public FsmString yes; 	
		public FsmString no;	
		public FsmString later; 
		public FsmString rateUrl; 

		public FsmEvent yesEvent;
		public FsmEvent noEvent;
		public FsmEvent laterEvent;

		[Tooltip("Result will be fired in unity Editor")]
		public AndroidDialogResult ResultInEditor = AndroidDialogResult.RATED;

		
		
		public override void OnEnter() {

			bool IsInEdditorMode = false;
			
			#if UNITY_EDITOR
			IsInEdditorMode = true;
			#endif
			
			
			if(IsInEdditorMode) {
				ParseResult(ResultInEditor);
				return;
			}


			AndroidRateUsPopUp rate = AndroidRateUsPopUp.Create(title.Value, message.Value, rateUrl.Value, yes.Value, later.Value, no.Value);

			rate.addEventListener(BaseEvent.COMPLETE, onRatePopUpClose);
			
		}

		public override void Reset() {
			base.Reset();

			title =  "Dialog title";
			message   = "Dialog message";
			yes = "Okay";
			no = "No";
			later  = "Later";
			rateUrl = "LINK_TO_YOUR_APP";
			
		}



		private void onRatePopUpClose(CEvent e) {
			
			//romoving listner
			(e.dispatcher as AndroidRateUsPopUp).removeEventListener(BaseEvent.COMPLETE, onRatePopUpClose);
			
			//parsing result
			ParseResult((AndroidDialogResult)e.data);
		}


		private void ParseResult(AndroidDialogResult res) {
			switch(res) {
			case AndroidDialogResult.RATED:
				Fsm.Event(yesEvent);
				break;
			case AndroidDialogResult.REMIND:
				Fsm.Event(laterEvent);
				break;
			case AndroidDialogResult.DECLINED:
				Fsm.Event(noEvent);
				break;
				
			}
			
			Finish();
		}
		
	}
}


