using UnityEngine;
using System.Collections;

public class pbullets : MonoBehaviour {

	public static bool pbulletactive = false;
	public GameObject playerbullets;
	private GameObject[] turretpos;
	private int chosenturret;
	public int weaponlimit;

	// Use this for initialization
	void Start () {
		turretpos = GameObject.FindGameObjectsWithTag("turret2s");
		print (chosenturret);
		print (turretpos.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(pbulletactive && weaponlimit>0)
		   {
			StartCoroutine (Slower());

		}
	}

	IEnumerator Slower(){
		Instantiate(playerbullets, turretpos[chosenturret].transform.position, turretpos[chosenturret].transform.rotation);
		weaponlimit = weaponlimit-1;
		chosenturret = Random.Range(0,turretpos.Length-1);
		yield return new WaitForSeconds(.5f);
	}
}

