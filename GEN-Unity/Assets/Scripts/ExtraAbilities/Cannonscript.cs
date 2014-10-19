using UnityEngine;
using System.Collections;

public class Cannonscript : MonoBehaviour {

	Animator cannonanim;
	//emitter for bullets
	public GameObject emitter;
	//cannon bullet
	public GameObject cannonbullet;
	//set bool
	public bool animon;


	// Use this for initialization
	void Start () {
		animon  = false;

	}

	void OnEnable()

	{
		cannonanim = GetComponent<Animator>();

		cannonanim.SetTrigger("active");

		StartCoroutine(Activecannon());
	}

	IEnumerator Activecannon()

	{
		animon = true;
		yield return new WaitForSeconds(.5f);

		cannonattack();

		yield return new WaitForSeconds(5f);
		animon = false;
		cannonanim.SetTrigger("stop");
	}

	void cannonattack()

	{
	
		if(animon){
		Instantiate(cannonbullet,emitter.transform.position,Quaternion.identity);
		}
		StartCoroutine(Waiter());
	}

	IEnumerator Waiter()
	{
		yield return new WaitForSeconds(.3f);
		cannonattack();

	}

	void Update () {
	
	}
}
