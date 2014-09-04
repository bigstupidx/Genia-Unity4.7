using UnityEngine;
using System.Collections;

public class ademperor : MonoBehaviour {

	public GameObject startadobj;
	public static int deathcounter = 0;
	public bool adinuse;

	void Update()
	{
		if(adinuse){
		if(deathcounter ==3)
		{
			startadobj.gameObject.SetActive(true);
			deathcounter =0;
			StartCoroutine(Quickcount());
		}
		}
	}

	IEnumerator Quickcount()
	{
		yield return new WaitForSeconds(5f);
		startadobj.gameObject.SetActive(false);
	}

}
