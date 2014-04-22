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

		Creator();
	
		if(deadcount == suckedup)
		{
			if(!rangen.activeSelf)
			{
				sucker.SetActive(false);
				deadcount = 0;
				rangen.SetActive(true);    
			}
		}
		else if(deadcount > suckedup)
			
		{
			deadcount = deadcount - suckedup;
			
			if(!rangen.activeSelf)
			{
				sucker.SetActive(false);
				deadcount = 0;
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
