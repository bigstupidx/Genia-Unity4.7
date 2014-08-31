using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class Titlescene : MonoBehaviour {


	private Rect arrowbutton;
	private bool goarrow;
	private GUIStyle inputstyle;
	public UIPanel helper;
	public UIPanel setthings;

	public bool adenable = false;

	//FSM part
	public FsmBool adcheck = false;
	//reference
	public PlayMakerFSM adFSM;
	//ad game object
	public GameObject adsplaymaker;


	// Use this for initialization
	void Start() {
		Screen.SetResolution(1024,600,true,60);

	
	
		}

	void Awake()
	{

	}

	IEnumerator Showads()

	{
		yield return new WaitForSeconds(1F);
		adsplaymaker.gameObject.SetActive(true);
		adcheck = adFSM.FsmVariables.GetFsmBool("adsoff");
		adcheck.Value = false;

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit();

		if(adenable){
			StartCoroutine(Showads());
		}
	}

	public void startgame()
	{
		adcheck.Value = true;
		Application.LoadLevel("Demo");
	}

	public void helppanel()
	{
		//adcheck.Value = true;
		helper.gameObject.SetActive(true);
	}

	public void exithelppanel()
	{
		helper.gameObject.SetActive(false);
	}

	public void settingspanel()
	{
		setthings.gameObject.SetActive(true);
	}
	public void exitsettingspanel()
	{
		setthings.gameObject.SetActive(false);
	}

	public void clearhighscore()

	{
		print(PlayerPrefs.GetInt("HScore"));
		PlayerPrefs.SetInt("HScore",0);
		PlayerPrefs.Save();
	}

}
