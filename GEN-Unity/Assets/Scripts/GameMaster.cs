using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	private GameObject mainplayer;
	private GameObject sucker;
	public static int deadcount;
	public int suckedup;
	private GameObject rangen;

	// Use this for initialization
	void Start () {
		rangen = GameObject.Find("Randomer");

//		sucker = GameObject.Find("sucker");
		rangen.SetActive(false);
		deadcount =0;
	}
	
	// Update is called once per frame
	void Update () {
	

		bool startsucker = Input.GetKeyDown(KeyCode.Space);

		if((deadcount == suckedup)&& (!rangen.activeSelf))
		{
			rangen.SetActive(true);
			deadcount = 0;
		}
		/*
		if(startsucker){
			if(!sucker.activeSelf)
			{
				sucker.SetActive(true);
			}

}*/


	}
}
