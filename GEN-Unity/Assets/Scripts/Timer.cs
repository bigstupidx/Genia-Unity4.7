using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public GUIText leveltimer;
	private float timercount = 0;
	public float beattime = 0;

	// Use this for initialization
	void Start () {
		leveltimer.text = timercount.ToString();
		StartCoroutine(Countdown());
	}

	// Update is called once per frame
	void Update () {

		if(timercount == beattime)
		{
			leveltimer.text = "You Survived";
		}
	 
	}

	IEnumerator Countdown()
	{

		while(timercount<beattime+1){
		timercount = timercount+1;
		yield return new WaitForSeconds(1f);
		leveltimer.text = timercount.ToString();
		}
	
		yield return 0;
	}
}
