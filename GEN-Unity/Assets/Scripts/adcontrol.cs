using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class adcontrol : MonoBehaviour {

	//bool to check if new level loaded
	public static bool sceneclosed;

	//playmaker parts.
	public FsmBool gameplaycheck;
	//ad fsm
	public PlayMakerFSM adgameplayfsm;


	void OnEnable()
	{
		StartCoroutine(StartPlaymaker());
	}

	void Start()
	{
		sceneclosed = false;
	}
	
	void Update()
	{
		//the idea for this script is to connect with playmaker and disable the ad when the scene reloads.
		if(sceneclosed)
		{ 
			print("scene is closing, destroy ad");
			gameplaycheck = true;
		}
	}

	IEnumerator StartPlaymaker()
	{
		yield return new WaitForSeconds(5f);
		print("connect with FSM");
		gameplaycheck = adgameplayfsm.FsmVariables.GetFsmBool("sceneover");
		gameplaycheck.Value = false;
		gameplaycheck.ShowInInspector = true;
	}
}

