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
	
	//	print (freezer);
		ptarget = GameObject.FindWithTag("Player").transform;
		targetvector = GameObject.FindWithTag("Player").transform.position;
		rfloat = Random.Range(-20,20);	
	}

	void FixedUpdate() {
		
		if(!freezer)
		{

			transform.LookAt(ptarget);

			if(Vector3.Distance(ptarget.position,transform.position)>playerdistance)
			{
				rigidbody.velocity = transform.forward * espeed;
			}else if(Vector3.Distance(ptarget.position,transform.position)<= playerdistance)
			{
				rigidbody.velocity = transform.forward * espeed *-1;
			}
	
				if(rfloat<0)
			{
				rfloat = -1f;
				rigidbody.velocity = transform.right*rotatespeed*rfloat;
			}
		}
		else 
		{
			print (freezer);
			StartCoroutine(Unfreeze());
		}
		
	}

	


	IEnumerator Unfreeze()
	{
		transform.FindChild("Nose shooter").gameObject.SetActive(false);
		yield return new WaitForSeconds(freezetime);
		freezer = false;
		print (freezer);
		transform.FindChild("Nose shooter").gameObject.SetActive(true);
	}
	
}
