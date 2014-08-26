using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Сamera")]
	public class AN_GetImageFromCamera : FsmStateAction {
				
		public FsmTexture LoadedTexture;

		public FsmEvent loaded;
		public FsmEvent failed;


		public override void OnEnter() {
			AndroidCamera.instance.OnImagePicked += OnImagePicked;
			AndroidCamera.instance.GetImageFromCamera();

			#if UNITY_EDITOR
				Fsm.Event(failed);
				Finish();
			#endif
		}


		private void OnImagePicked(AndroidImagePickResult result) {
			AndroidCamera.instance.OnImagePicked -= OnImagePicked;

			if(result.IsSucceeded) {
				Fsm.Event(loaded);
				LoadedTexture.Value = result.image;
			} else {
				Fsm.Event(failed);
			}

			Finish();
		}

	}
}


