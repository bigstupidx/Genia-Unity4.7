using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour {


	private float finaltime;
	private int finaldead;
	//UI labels
	public UILabel deadtext;
	public UILabel timetext;
	public GameObject highscoretext;



	void OnEnable(){

		finaldead  = DeadEnemyCounter.enemyend;
		finaltime = Timer.gametime;

		deadtext.text = finaldead.ToString();
		timetext.text = finaltime.ToString();

		print (PlayerPrefs.GetInt("HScore")+ " current high score");
		print (finaldead + "final dead");

		if(PlayerPrefs.GetInt("HScore")<finaldead)
		{
			StartCoroutine(Blinking());

			PlayerPrefs.SetInt("HScore",finaldead);
			PlayerPrefs.Save();
		}


	}
	
	public string Deadtext

	{
		get
		{
			return deadtext.text;
		}
		set
		{
			deadtext.text = value;
		}
	}

	public string Timetext
		
	{
		get
		{
			return timetext.text;
		}
		set
		{
			timetext.text = value;
		}
	}

	IEnumerator Blinking()

	{
		for(int i =0 ;i<10;i++)
		{
			print ("blinking");
			highscoretext.SetActive(true);
			yield return new WaitForSeconds(.5f);
			highscoretext.SetActive(false);
			yield return new WaitForSeconds(.5f);
		}

		highscoretext.SetActive(true);
	
	}

	public void gotomain()

	{
		adcontrol.sceneclosed = true;
		Application.LoadLevel("Title");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
