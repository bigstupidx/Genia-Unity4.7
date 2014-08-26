using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Сamera")]
	public class AN_SaveImageToGalalry : FsmStateAction {
				

		public FsmTexture texture;


		public override void OnEnter() {
			AndroidCamera.instance.SaveImageToGalalry( (Texture2D) texture.Value);
			Finish();
		}

	}
}


