using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Others")]
	public class AN_LoadAddressBook : FsmStateAction {
				
		public override void OnEnter() {
			ImmersiveMode.instance.EnableImmersiveMode();
			if(AddressBookController.isLoaded)
				OnAddressBookLoaded();
			else {
				AddressBookController.instance.addEventListener(AddressBookController.ON_CONTACTS_LOADED, OnAddressBookLoaded);
			}

		}

		public void OnAddressBookLoaded() {
			AddressBookController.instance.removeEventListener(AddressBookController.ON_CONTACTS_LOADED, OnAddressBookLoaded);
			Finish();
		}
	}
}


