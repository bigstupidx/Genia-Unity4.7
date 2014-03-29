using UnityEngine;
using System.Collections;

public class Playercontrol : MonoBehaviour {

	public float playerspeed;
	private bool goup;
	private bool godown;
	private bool goleft;
	private bool goright;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(GUI.RepeatButton(new Rect(Screen.width-200,Screen.height -300,50,50),"^"))
		{
			transform.Translate(Vector3.forward *playerspeed*Time.deltaTime);
			goup = true;
			print("go up");
		}
	
		if(GUI.RepeatButton(new Rect(Screen.width-200,Screen.height -225,50,50),"v"))
		{
			transform.Translate(Vector3.back *playerspeed*Time.deltaTime);
			print("go down");
		}

	}
}
