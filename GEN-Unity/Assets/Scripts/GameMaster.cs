using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	private GameObject mainplayer;
	private GameObject sucker;
	public static int deadcount;

	// Use this for initialization
	void Start () {
		sucker = GameObject.Find("sucker");
		sucker.SetActive(false);
		deadcount =0;
	}
	
	// Update is called once per frame
	void Update () {
	
		print (deadcount);
		bool startsucker = Input.GetKeyDown(KeyCode.Space);

		if(startsucker){
			if(!sucker.activeSelf)
			{
				sucker.SetActive(true);
			}
		}


	}
}
