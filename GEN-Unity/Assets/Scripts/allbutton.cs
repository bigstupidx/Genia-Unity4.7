using UnityEngine;
using System.Collections;

public class allbutton : MonoBehaviour {
	private GameObject weaponchoice;
	public float speed;
	public float hor;
	public float ver;

	// Use this for initialization
	void Start () {
		hor  = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");

		weaponchoice = GameObject.Find("sucker");
		weaponchoice.SetActive(false);
	 	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

		//	if(GUI.Button(new Rect(


			if (GUI.Button (new Rect (100,Screen.height -100,150,20), "Suck'em")) {
			if( !weaponchoice.activeSelf)
			{
				weaponchoice.SetActive(true);
			}
			}
		

	}
}
