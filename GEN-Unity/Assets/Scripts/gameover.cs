using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour {


	private float finaltime;
	private int finaldead;


	void OnEnable(){
		
		finaldead  = DeadEnemyCounter.enemyend;
		finaltime = Timer.gametime;
		//docs.unity3d.com/ScriptReference/PlayerPrefs.html

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
