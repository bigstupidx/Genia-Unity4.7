using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	private GameObject mainplayer;
	private GameObject sucker;

	// Use this for initialization
	void Start () {
		sucker = GameObject.Find("sucker");
		sucker.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		bool startsucker = Input.GetKeyDown(KeyCode.Space);

		if(startsucker){
			if(!sucker.activeSelf)
			{
				sucker.SetActive(true);
			}
		}


	}
}
