using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Сamera")]
	public class AN_SaveScreenshotToGallery : FsmStateAction {
				




		public override void OnEnter() {
			AndroidCamera.instance.SaveScreenshotToGallery();
			Finish();
		}

	}
}


