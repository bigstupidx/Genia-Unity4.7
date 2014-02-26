using UnityEngine;
using System.Collections;

public class DeadenemyAI : MonoBehaviour {
	
	private GameObject collector;
	private Transform etarget;
	private int edead;


	// Use this for initialization
	void Start () {
		collector = GameObject.Find ("inner");
		etarget= collector.transform;
		edead = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider sucker ){
		print ("trigger");
		//transform.position = Vector3.MoveTowards(transform.position,etarget.position,10f);
		GameMaster.deadcount += edead;
		Destroy (this.gameObject);
	}
}
