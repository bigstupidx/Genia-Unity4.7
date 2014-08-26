using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Social")]
	public class AN_SendMail : FsmStateAction {
				
		public FsmString title;
		public FsmString subject;
		public FsmString message;

		public FsmTexture texture;

		public override void OnEnter() {
		
			AndroidSocialGate.StartShareIntentWithSubject(title.Value, message.Value, subject.Value, texture.Value as Texture2D,  "mail");
			Finish();
		}

	}
}


