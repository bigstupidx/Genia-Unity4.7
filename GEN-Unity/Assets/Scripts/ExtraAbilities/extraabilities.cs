using UnityEngine;
using System.Collections;

public class extraabilities : MonoBehaviour {

	//enemy counter from global var
	private int exabenemycounter;

	//ui label to show ability
	public UILabel exablabel;

	//side cannons
	public GameObject[] exabcannons;

	//black holes
	public GameObject[] exabblackholes;

	//constant count
	public int exabrequirementcounter;

	//variable time count
	public int exabtimecount;


	void Start()
	{
		StartCoroutine(Quick10());
	}

	IEnumerator Quick10()
	{
		yield return new WaitForSeconds(10f);

		if(DeadEnemyCounter.enemiesdead >= exabtimecount)
		{

		}

	}

}
