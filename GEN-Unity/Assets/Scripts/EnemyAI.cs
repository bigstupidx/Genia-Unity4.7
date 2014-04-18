using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private Transform ptarget;
	private Vector3 targetvector;
	public float playerdistance;
	private float rfloat;
	public float espeed;
	public float rotatespeed;
	private Transform friend;
	private Vector3 friendvector;
	public static bool freezer = false;
	public float freezetime =0;


	// Use this for initialization
	void Start () {
	
		ptarget = GameObject.FindWithTag("Player").transform;
		targetvector = GameObject.FindWithTag("Player").transform.position;
		rfloat = Random.Range(-20,20);	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(!freezer)
		{


		if(Vector3.Distance(ptarget.position,transform.position)>playerdistance)
		{
			transform.LookAt(ptarget);
			//this.rigidbody.AddForce(Vector3.forward * espeed,ForceMode.Impulse);
		//  transform.Translate(0,0,espeed*Time.deltaTime);
			rigidbody.velocity = transform.forward * espeed;
		}

		//if(Vector3.Distance(ptarget.position,transform.position)==distance)
		else {
			transform.LookAt(ptarget);
			if(rfloat<0)
			{
				rfloat = -1f;
				rigidbody.velocity = transform.right*rotatespeed*rfloat;
			}
			else
			{
				rfloat = 1f;
			}
			

			//transform.Translate(30f*Time.deltaTime*rfloat,0,0);
		}
		}
		else 
		{
			StartCoroutine(Unfreeze());
		}

	
	}

	IEnumerator Unfreeze()
	{
		transform.FindChild("Nose shooter").gameObject.SetActive(false);
		yield return new WaitForSeconds(freezetime);
		freezer = false;
		transform.FindChild("Nose shooter").gameObject.SetActive(true);
	}
	
}
