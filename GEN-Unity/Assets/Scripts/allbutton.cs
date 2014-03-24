using UnityEngine;
using System.Collections;

public class allbutton : MonoBehaviour {
	private GameObject weaponchoice;
	public float speed;
	public float hor;
	public float ver;
	private GameObject theplayer;
	public float playerspeed = 0;

	// Use this for initialization
	void Start () {
		hor  = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");

		weaponchoice = GameObject.Find("sucker");
		weaponchoice.SetActive(false);

		theplayer = GameObject.Find("Player");

	 	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

			if(GUI.Button(new Rect(Screen.width-200,Screen.height -300,50,50),"^"))
		              {
			theplayer.transform.Translate(Vector3.forward *speed*Time.deltaTime *ver);

			print("go up");
			}
			if(GUI.Button(new Rect(Screen.width-200,Screen.height -225,50,50),"v"))
			{
			theplayer.transform.Translate(Vector3.back *speed*Time.deltaTime*ver);
			print("go down");
			}



			if (GUI.Button (new Rect (100,Screen.height -100,150,20), "Suck'em")) {
			if( !weaponchoice.activeSelf)
			{
				weaponchoice.SetActive(true);
			}
			}
		

	}
}
