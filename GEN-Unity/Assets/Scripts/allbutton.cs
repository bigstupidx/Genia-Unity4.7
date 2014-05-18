using UnityEngine;
using System.Collections;

public class allbutton : MonoBehaviour {
	private GameObject weaponchoice;
	private GameObject theplayer;
	private Rect sucker;
	private bool startsucker = false;
	public GUIStyle suckup;
	public Texture suckertext;


	// Use this for initialization
	void Start () {
		weaponchoice = GameObject.Find("sucker");
		weaponchoice.SetActive(false);

		sucker = new Rect (100,Screen.height -200,150,150);

	 	}

	void Update()
	{
	
		
		for(int i =0; i<Input.touchCount;i++)
		{
			startsucker = sucker.Contains(Input.touches[i].position);
		}

		if(Input.GetMouseButton(0))
		{
			Vector2 mousePosition = Input.mousePosition;
			mousePosition.y = Screen.height - mousePosition.y;
			startsucker = sucker.Contains(mousePosition);
		}


		if(startsucker)
		{
			weaponchoice.SetActive(true);
		}
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
		if(GUI.Button(new Rect (200,10,100,50), "Restart Level"))
		{
			pbullets.pbulletactive =false;
			EnemyAI.freezer = false;
			Application.LoadLevel("Demo");
		}

//		if(GUI.Button(new Rect (300,10,110,50), "Make Wave"))
//		{
//			Playercontrol.bigwave = true;
//
//		}

		if(suckup ==null)
		{
			suckup = new GUIStyle("button");
		}

		GUI.Box(sucker,"",suckup);

	}
}
