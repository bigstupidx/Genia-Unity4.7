using UnityEngine;
using System.Collections;

public class DeadenemyAI : MonoBehaviour {
	
	private GameObject collector;
	private Collider sucker;
	private Transform target;

	// Use this for initialization
	void Start () {
		collector = GameObject.Find ("inner");
		target= collector.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){

		if(sucker.gameObject.name == "sucker")
		{
			transform.position = Vector3.MoveTowards(transform.position,target.position,0f);
		}
	}
}
