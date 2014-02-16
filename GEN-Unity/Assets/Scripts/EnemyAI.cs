using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private Transform ptarget;
	private Vector3 targetvector;
	private float targetdistance =0;


	// Use this for initialization
	void Start () {
	
		ptarget = GameObject.FindWithTag("Player").transform;
		targetvector = GameObject.FindWithTag("Player").transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(ptarget);
		targetdistance = Vector3.Distance(transform.position,targetvector);
		print ("distance " + targetdistance);
		transform.Translate(0,0,20*Time.deltaTime);

	}
}
