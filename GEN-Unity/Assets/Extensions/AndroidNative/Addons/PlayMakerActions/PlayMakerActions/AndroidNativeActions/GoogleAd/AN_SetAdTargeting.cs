////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav (Stan's Assets) 
// @support stans.assets@gmail.com 
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;



namespace HutongGames.PlayMaker.Actions {
	
	[ActionCategory("Android Native - Google Ad")]
	public class AN_SetAdTargeting : FsmStateAction {


		public FsmString[] keywords;
		public bool tagForChildDirectedTreatment = false;
		public GoogleGenger gender = GoogleGenger.Unknown;
		public bool setBirthday = false;
		public FsmInt day;
		public AndroidMonth month;
		public FsmInt year;


		public override void OnEnter() {

			foreach(FsmString k in keywords) {
				AndroidAdMobController.instance.AddKeyword(k.Value);
			}
			AndroidAdMobController.instance.SetGender(gender);
			AndroidAdMobController.instance.TagForChildDirectedTreatment(tagForChildDirectedTreatment);
			if(setBirthday) {
				AndroidAdMobController.instance.SetBirthday(year.Value, month, day.Value);
			}

			Finish();
		}



		
	}
}
