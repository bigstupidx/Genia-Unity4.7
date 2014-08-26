using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Pop-ups")]
	public class AN_DialogPopup : FsmStateAction {
		
		public FsmString title; 	
		public FsmString message; 

		public FsmString yes; 
		public FsmString no;

		public FsmEvent yesEvent;
		public FsmEvent noEvent;

		[Tooltip("Result will be fired in unity Editor")]
		public AndroidDialogResult ResultInEditor = AndroidDialogResult.YES;

		
		
		public override void OnEnter() {

			bool IsInEdditorMode = false;
			
			#if UNITY_EDITOR
			IsInEdditorMode = true;
			#endif
			
			
			if(IsInEdditorMode) {
				ParseResult(ResultInEditor);
				return;
			}


			AndroidDialog popup = AndroidDialog.Create(title.Value, message.Value, yes.Value, no.Value);

			popup.addEventListener(BaseEvent.COMPLETE, OnComplete);
			
		}

		
		public override void Reset() {
			base.Reset();
			
			title =  "Dialog title";
			message   = "Dialog message";
			yes = "Okay";
			no = "No";
			
		}


		private void OnComplete(CEvent e) {
			
			//romoving listner
			(e.dispatcher as AndroidDialog).removeEventListener(BaseEvent.COMPLETE, OnComplete);
			
			//parsing result
			ParseResult((AndroidDialogResult)e.data);
		}


		private void ParseResult(AndroidDialogResult res) {
			switch(res) {
			case AndroidDialogResult.YES:
				Fsm.Event(yesEvent);
				break;
			case AndroidDialogResult.NO:
				Fsm.Event(noEvent);
				break;
				
			}
			
			Finish();
		}
		
	}
}


