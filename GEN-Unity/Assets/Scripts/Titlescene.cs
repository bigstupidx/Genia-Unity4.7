using UnityEngine;
using System.Collections;

public class Titlescene : MonoBehaviour {


	private Rect arrowbutton;
	public Texture arrowtext;
	private bool goarrow;
	private GUIStyle inputstyle;
	public UIPanel helper;



	// Use this for initialization
	void Start () {

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

}
