using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	private GameObject mainplayer;
	public GameObject Renemy;
	private GameObject sucker;
	public static int deadcount;
	public static int respawncounter = 0;
	public int suckedup;

	public Randomselect rangen;
	private GameObject randomer;

	private GameObject[] respots;
	private int respotsamount;
	private int ranrespot;
	public GUIText sucked;
	private Rect pausebutton;
	private bool firstime = true;
	public int resetcount;



//	void OnGUI()
//	{
//		GUI.Label(new Rect(100, Screen.height/2, 100, 100),"Test");
//	}

	// Use this for initialization
	void Start () {
		//rangen = GameObject.Find("Randomer");


		deadcount =0;
	//	deadcount = suckedup;
		randomer = GameObject.Find ("Randomer");
		randomer.SetActive(false);
		respots = GameObject.FindGameObjectsWithTag("Respawner");
		respotsamount = respots.Length;
//		print (respotsamount);
		ranrespot = Random.Range(0,respotsamount-1);

		sucker = GameObject.Find("sucker");
	}
	
	// Update is called once per frame
	void Update () {

		//exit android
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit();

		Screen.SetResolution(1024,600,true,60);

		Creator();
	
		//sucked.text = deadcount.ToString();

	 

		if(deadcount == suckedup)
		{

			if(firstime)
			{
				randomer.SetActive(true);  
				firstime = false;
			}

			rangen.randomgo();
			sucker.SetActive(false);
			deadcount = 0;
		}

		if(deadcount > suckedup)	
		{
			rangen.randomgo();
			deadcount = deadcount - suckedup;
			sucker.SetActive(false);		
		}
	}

	void Creator()
	{
		if(respawncounter >0)
		{
			Instantiate(Renemy, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);
			respawncounter = respawncounter -1;	
		}
		else
		{

		}
	
	
	}
}
