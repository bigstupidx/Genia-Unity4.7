using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Pop-ups")]
	public class AN_ShowPreloader : FsmStateAction {
		
		public FsmString title; 	
		public FsmString message;  
		
		
		public override void OnEnter() {
			AndroidNativeUtility.ShowPreloader(title.Value, message.Value);
			Finish();
			
		}
		
		public override void Reset() {
			base.Reset();
			
			title =  "Preloader title";
			message   = "Preloader text";
			
		}


		
	}
}


