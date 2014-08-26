using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Utils")]
	public class AN_IsPackageInstalled : FsmStateAction {
				
		public FsmEvent packageFound;
		public FsmEvent packageNotFound;

		public FsmString package;

		public override void OnEnter() {
		
			AndroidNativeUtility.instance.addEventListener(AndroidNativeUtility.PACKAGE_FOUND, OnFound);
			AndroidNativeUtility.instance.addEventListener(AndroidNativeUtility.PACKAGE_NOT_FOUND, OnNotFound);

			AndroidNativeUtility.instance.CheckIsPackageInstalled(package.Value);

		}

		private void OnFound() {
			AndroidNativeUtility.instance.removeEventListener(AndroidNativeUtility.PACKAGE_FOUND, OnFound);
			AndroidNativeUtility.instance.removeEventListener(AndroidNativeUtility.PACKAGE_NOT_FOUND, OnNotFound);
			Fsm.Event(packageFound);
			Finish();
		}

		private void OnNotFound() {
			AndroidNativeUtility.instance.removeEventListener(AndroidNativeUtility.PACKAGE_FOUND, OnFound);
			AndroidNativeUtility.instance.removeEventListener(AndroidNativeUtility.PACKAGE_NOT_FOUND, OnNotFound);
			Fsm.Event(packageNotFound);
			Finish();
		}

	}
}


