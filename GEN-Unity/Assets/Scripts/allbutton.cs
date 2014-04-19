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

		if(GUI.Button(new Rect (0,0,100,50), "Bullet active"))
		{
			pbullets.pbulletactive = true;
		}
		if(GUI.Button(new Rect (100,0,100,50), "Freeze active"))
		{
			EnemyAI.freezer = true;
		}
		if(GUI.Button(new Rect (200,0,100,50), "Restart Demo"))
		{
			pbullets.pbulletactive =false;
			EnemyAI.freezer = false;
			Application.LoadLevel(Application.loadedLevel);
		}

			if (GUI.Button (new Rect (100,Screen.height -150,150,150), "Suck'em")) {
			if( !weaponchoice.activeSelf)
			{
				weaponchoice.SetActive(true);
			}
			}
		

	}
}
