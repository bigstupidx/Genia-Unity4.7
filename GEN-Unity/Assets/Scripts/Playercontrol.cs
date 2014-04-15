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
		goup = false;
		godown = false;
		goleft =false;
		goright =false;
	}

	// Update is called once per frame
	void FixedUpdate() {
	
		if(goup)
		{
			this.rigidbody.AddForce(Vector3.forward * playerspeed,ForceMode.Impulse);
		//	transform.Translate(0,0,playerspeed*Time.deltaTime);
		}
			

		if(godown)
		{
		//	rigidbody.velocity  = Vector3.back *playerspeed;
			this.rigidbody.AddForce(Vector3.back * playerspeed,ForceMode.Impulse);
			//transform.Translate(0,0,-1*playerspeed*Time.deltaTime);
		}

		if(goleft)
		{
			this.rigidbody.AddForce(Vector3.left * playerspeed,ForceMode.Impulse);
		}

		if(goright)
		{
			this.rigidbody.AddForce(Vector3.right * playerspeed,ForceMode.Impulse);
		}
	}

	void OnGUI()
	{
		if(GUI.RepeatButton(new Rect(Screen.width-200,Screen.height -300,50,50),"^"))
		{
			goup = true;
			print("goup is true");
		}else{
			print("goup is false");
			goup =false;
		}
	
		if(GUI.RepeatButton(new Rect(Screen.width-200,Screen.height -225,50,50),"v"))
		{
			godown =true;
			print("godown is true");
		}else{
			print("godown is false");
			godown =false;
		}

		if(GUI.RepeatButton(new Rect(Screen.width-250,Screen.height -260,50,50),"<"))
		{
			goleft =true;
			print("godown is true");
		}else{
			print("godown is false");
			goleft =false;
		}

		if(GUI.RepeatButton(new Rect(Screen.width-150,Screen.height -260,50,50),">"))
		{
			goright =true;
			print("godown is true");
		}else{
			print("godown is false");
			goright =false;
		}

	}
}
