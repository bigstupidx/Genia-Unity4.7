using UnityEngine;
using System.Collections;

public class Cannonscript : MonoBehaviour {

	Animator cannonanim;
	//emitter for bullets
	public GameObject emitter;
	//cannon bullet
	public GameObject cannonbullet;
	//set bool
	public bool animon = false;
	//wait time between bullet
	public float bulletwaittime = 0;
	//time of whole animation
	public float activeanimfloat = 0;


	// Use this for initialization
	void Start () {

	}

	void OnEnable()

	{
		animon = true;
		cannonanim = GetComponent<Animator>();

		cannonanim.SetTrigger("active");

		StartCoroutine(Activecannon());
	}

	IEnumerator Activecannon()

	{

		yield return new WaitForSeconds(.5f);

		cannonattack();

		yield return new WaitForSeconds(activeanimfloat);
		animon = false;
		cannonanim.SetTrigger("stop");
		yield return new WaitForSeconds(.5f);
		gameObject.SetActive(false);
	}

	void cannonattack()

	{
		GameObject canbull;
	
		if(animon){
	canbull = Instantiate(cannonbullet,emitter.transform.position,emitter.transform.rotation)as GameObject;
			canbull.gameObject.transform.Rotate(0,0,90);
		}
		StartCoroutine(Waiter());
	}

	IEnumerator Waiter()
	{
		yield return new WaitForSeconds(bulletwaittime);
		cannonattack();

	}

	void Update () {
			
	}
}
