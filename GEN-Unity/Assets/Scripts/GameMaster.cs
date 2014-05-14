using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	private GameObject mainplayer;
	public GameObject Renemy;
	private GameObject sucker;
	public static int deadcount;
	public static int respawncounter = 0;
	public int suckedup;
	private GameObject rangen;
	private GameObject[] respots;
	private int respotsamount;
	private int ranrespot;
	public GUIText sucked;
	private Rect pausebutton;



	void OnGUI()
	{
		GUI.Label(new Rect(100, Screen.height/2, 100, 100),"");
	}

	// Use this for initialization
	void Start () {
		rangen = GameObject.Find("Randomer");

		rangen.SetActive(false);
		deadcount =0;

		respots = GameObject.FindGameObjectsWithTag("Respawner");
		respotsamount = respots.Length;
		print (respotsamount);
		ranrespot = Random.Range(0,respotsamount-1);

		sucker = GameObject.Find("sucker");
	}
	
	// Update is called once per frame
	void Update () {

		//exit android
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit();

		Creator();
	
		sucked.text = deadcount.ToString();

		if(deadcount == suckedup)
		{
			if(!rangen.activeSelf)
			{
				sucker.SetActive(false);
				deadcount = 0;
				rangen.SetActive(true);    
			}
		}

		if(deadcount > suckedup)	
		{
			if(!rangen.activeSelf)
			{
				sucker.SetActive(false);
				deadcount = deadcount - suckedup;
				rangen.SetActive(true);    
			}
		
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
