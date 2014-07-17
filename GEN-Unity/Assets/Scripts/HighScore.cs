using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	public UILabel highscore;



	public string Highscore
		
	{
		get
		{
			return highscore.text;
		}
		set
		{
			highscore.text = value;
		}
	}

 
	
	// Update is called once per frame
	void Update () {
	
		highscore.text = PlayerPrefs.GetInt("HScore").ToString();
	}
}
