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
	//enemy objects
	private GameObject[] enemyobjs;
	//enemy object counter
	private int currentenemycount;


	public GameObject renemy2; //bouy2
	public GameObject renemy3; //bouy3
			
	public int randomenemyholder = 0;
	
	private int enemylevelcounter = 0;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
	

		Screen.SetResolution(1024,600,true,60);
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

	//	Creator();

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

	public void coustarter()

	{
		StartCoroutine(Needtime());
	}

	IEnumerator Needtime()
	{
		yield return new WaitForSeconds (5f);
		enemyobjs = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i = 0;i<4;i++){
			enemyobjs[i].transform.FindChild("Nose shooter").gameObject.SetActive(true);
			enemyobjs[i].GetComponent<EnemyAI>().enabled = true;
			if(enemyobjs[i].gameObject.name == "bouy2(Clone)")
			{
			enemyobjs[i].transform.FindChild("Nose shooter2").gameObject.SetActive(true);
			}
		}
		GUIability.freezer = false;
	}

	public void Creator()
	{
		//random enemy
		randomenemyholder = Random.Range(0,2);

		ranrespot = Random.Range(0,3);

		//increase enemy level counter
		enemylevelcounter++;
		
		if(enemylevelcounter<=15)	
		{
			Instantiate(Renemy, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);
		}
		
		if(enemylevelcounter>=16 && enemylevelcounter <= 30)
		{Instantiate(renemy2, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);
		}
		
		if(enemylevelcounter>=31 && enemylevelcounter <= 45)
		{
			Instantiate(renemy3, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);
		}

		if(enemylevelcounter>=46)
			
		{
			
			switch(randomenemyholder)
				
			{
			case 0:
				Instantiate(Renemy, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);
				break;
				
			case 1:
				Instantiate(renemy2, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);
				break;
				
			case 2:
				Instantiate(renemy3, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);
				break;
				
			}
			
		}



	//	Instantiate(Renemy, respots[ranrespot].transform.position, respots[ranrespot].transform.rotation);

	}
}
