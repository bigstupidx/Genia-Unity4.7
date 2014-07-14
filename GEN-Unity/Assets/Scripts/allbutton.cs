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

	//	sucker = new Rect (100,Screen.height -200,300,300);

	 	}

	public void ActiveSucker()

	{
		weaponchoice.SetActive(true);
	}

	void Update()
	{
	if(Input.GetKeyDown(KeyCode.Space))
		{
			weaponchoice.SetActive(true);
		}

	}
  
}
