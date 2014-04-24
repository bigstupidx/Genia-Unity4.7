using UnityEngine;
using System.Collections;

public class Playercontrol : MonoBehaviour {

	public float playerspeed;
	private bool goup;
	private bool godown;
	private bool goleft;
	private bool goright;

	private Vector3 playerscale;
	//public vector3 largerscale;
	public float scalesize;
	public static bool makelarger = false;
	
	//make larger scale 15
	
//	void Update()
//		
//	{
//		playerscale = transform.lossyscale;
//		
//		if(makelarger){
//			
//			transform.localScale(15,0,15);
//		}    
//		
//		do{
//			transform.localeScale(scalesize -.01f,0,scalesize - .01f);
//		}
//		
//		while(transform.lossyscale != playerscale);
//	}



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
			this.rigidbody.AddForce(Vector3.forward * playerspeed,ForceMode.Acceleration);
		//	transform.Translate(0,0,playerspeed*Time.deltaTime);
		}
			

		if(godown)
		{
		//	rigidbody.velocity  = Vector3.back *playerspeed;
			this.rigidbody.AddForce(Vector3.back * playerspeed,ForceMode.Acceleration);
			//transform.Translate(0,0,-1*playerspeed*Time.deltaTime);
		}

		if(goleft)
		{
			this.rigidbody.AddForce(Vector3.left * playerspeed,ForceMode.Acceleration);
		}

		if(goright)
		{
			this.rigidbody.AddForce(Vector3.right * playerspeed,ForceMode.Acceleration);
		}
	}

	void OnGUI()
	{
		if(GUI.RepeatButton(new Rect(Screen.width-200,Screen.height -350,100,100),"^"))
		{
			goup = true;
		//	print("goup is true");
		}else{
		//	print("goup is false");
			goup =false;
		}
	
		if(GUI.RepeatButton(new Rect(Screen.width-200,Screen.height -150,100,100),"v"))
		{
			godown =true;
		//	print("godown is true");
		}else{
		//	print("godown is false");
			godown =false;
		}

		if(GUI.RepeatButton(new Rect(Screen.width-300,Screen.height -250,100,100),"<"))
		{
			goleft =true;
		//	print("godown is true");
		}else{
		//	print("godown is false");
			goleft =false;
		}

		if(GUI.RepeatButton(new Rect(Screen.width-100,Screen.height -250,100,100),">"))
		{
			goright =true;
		//	print("godown is true");
		}else{
		//	print("godown is false");
			goright =false;
		}

	}
}
