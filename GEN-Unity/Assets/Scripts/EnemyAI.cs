using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private Transform ptarget;
	private Vector3 targetvector;
	public float distance;
	private float rfloat;


	// Use this for initialization
	void Start () {
	
		ptarget = GameObject.FindWithTag("Player").transform;
		targetvector = GameObject.FindWithTag("Player").transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(ptarget);

		if(Vector3.Distance(ptarget.position,transform.position)>distance)
		{
			transform.Translate(0,0,20*Time.deltaTime);

		}

		//if(Vector3.Distance(ptarget.position,transform.position)==distance)
		else {
			rfloat = Random.Range(-20,20);
			transform.Translate(30f*Time.deltaTime,0,0);
		}


		//random gen
	//	transform.Translate(0,0,20*Time.deltaTime);
	}
	
}
