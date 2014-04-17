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
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {

			if (GUI.Button (new Rect (100,Screen.height -100,150,50), "Suck'em")) {
			if( !weaponchoice.activeSelf)
			{
				weaponchoice.SetActive(true);
			}
			}
		

	}
}
