using UnityEngine;
using System.Collections;

public class Titlescene : MonoBehaviour {


	private Rect arrowbutton;
	public Texture arrowtext;
	private bool goarrow;
	private GUIStyle inputstyle;
	public UIPanel helper;
	public UIPanel setthings;



	// Use this for initialization
	void Start () {
		Screen.SetResolution(1024,600,true,60);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit();
	}

	public void startgame()
	{
		Application.LoadLevel("Demo");
	}

	public void helppanel()
	{
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
