using UnityEngine;
using System.Collections;

public class allbutton : MonoBehaviour {
	private GameObject weaponchoice;

	private GameObject theplayer;


	// Use this for initialization
	void Start () {
		weaponchoice = GameObject.Find("sucker");
		weaponchoice.SetActive(false);

	 	}


	void OnGUI () {
//
//		if(GUI.Button(new Rect (0,10,100,50), "Bullet active"))
//		{
//			pbullets.pbulletactive = true;
//		}
//		if(GUI.Button(new Rect (100,10,100,50), "Freeze active"))
//		{
//			EnemyAI.freezer = true;
//		}
		if(GUI.Button(new Rect (200,10,100,50), "Restart Demo"))
		{
			pbullets.pbulletactive =false;
			EnemyAI.freezer = false;
			Application.LoadLevel(Application.loadedLevel);
		}

//		if(GUI.Button(new Rect (300,10,110,50), "Increase Health"))
//		{
//			Playerhealth.uphealth =true;
//
//		}

			if (GUI.Button (new Rect (100,Screen.height -200,150,150), "Suck them UP!")) {
			if( !weaponchoice.activeSelf)
			{
				weaponchoice.SetActive(true);
			}
			}
		

	}
}
