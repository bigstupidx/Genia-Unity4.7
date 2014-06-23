using UnityEngine;
using System.Collections;

public class startcounter : MonoBehaviour {
	//Label text
	public UILabel countertext;
	//playermovement
	public GameObject playermovement;
	//enemymovement
	public GameObject[] enemymovement;
	//ref to tween
	private TweenScale scaler;
	//timerobj
	public GameObject timerobject;


	public string Countertext
	{
		get
		{
			return countertext.text;
		}
		set
		{
			countertext.text = value;
		}

	}

	// Use this for initialization
	void Start () {
		scaler = gameObject.GetComponent<TweenScale>();
		StartCoroutine(startgame());

		enemymovement = GameObject.FindGameObjectsWithTag("Enemy");
		playermovement.GetComponent<Playercontrol>().enabled = false;
		playermovement.GetComponent<pbullets>().enabled = false;

		timerobject.GetComponent<Timer>().enabled = false;

		for(int i = 0;i<4;i++){
			enemymovement[i].transform.FindChild("Nose shooter").gameObject.SetActive(false);
			enemymovement[i].GetComponent<EnemyAI>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator startgame()
	{
		for(int i =3; i>0;i--){
			countertext.text = i.ToString();
			yield return new WaitForSeconds(1f);
		
		}
		countertext.text = "GO!";
		yield return new WaitForSeconds(.5f);
		countertext.text = "";

		playermovement.GetComponent<Playercontrol>().enabled = true;
		playermovement.GetComponent<pbullets>().enabled = true;

		for(int i = 0;i<4;i++){
			enemymovement[i].transform.FindChild("Nose shooter").gameObject.SetActive(true);
			enemymovement[i].GetComponent<EnemyAI>().enabled = true;
		}

		timerobject.GetComponent<Timer>().enabled = true;
	
	}

	public void enabletween()

	{
		//scaler.enabled = true;
	}

}
