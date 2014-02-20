using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private Transform ptarget;
	private Vector3 targetvector;
	public float distance;
	private float rfloat;
	public float espeed;


	// Use this for initialization
	void Start () {
	
		ptarget = GameObject.FindWithTag("Player").transform;
		targetvector = GameObject.FindWithTag("Player").transform.position;
		rfloat = Random.Range(-20,20);	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(ptarget);

		if(Vector3.Distance(ptarget.position,transform.position)>distance)
		{
			transform.Translate(0,0,espeed*Time.deltaTime);

		}

		//if(Vector3.Distance(ptarget.position,transform.position)==distance)
		else {

			if(rfloat<0)
			{
				rfloat = -1f;
			}
			else
			{
				rfloat = 1f;
			}

			transform.Translate(30f*Time.deltaTime*rfloat,0,0);
		}


		//random gen
	//	transform.Translate(0,0,20*Time.deltaTime);
	}
	
}
