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
			//this.rigidbody.AddForce(Vector3.forward * espeed,ForceMode.Impulse);
		//  transform.Translate(0,0,espeed*Time.deltaTime);
			rigidbody.velocity = transform.forward * espeed;
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

			rigidbody.velocity = transform.right*30f*rfloat;
			//transform.Translate(30f*Time.deltaTime*rfloat,0,0);
		}


		//random gen
	//	transform.Translate(0,0,20*Time.deltaTime);
	}
	
}
