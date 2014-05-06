using UnityEngine;
using System.Collections;

public class pbullets : MonoBehaviour {

	public static bool pbulletactive = false;
	public GameObject playerbullets;
	private GameObject[] turretpos;
	private int chosenturret;
	public int weaponlimit = 0;
	private int templimit;

	// Use this for initialization
	void Start () {
		templimit = weaponlimit;
		turretpos = GameObject.FindGameObjectsWithTag("turret2s");
		print (chosenturret);
		print (turretpos.Length);
	}
	
	// Update is called once per frame
	void Update()
	{
		startbulletgen();
	}
	
	void startbulletgen()
		
	{
		StartCoroutine (Slower());
	}
	
	IEnumerator Slower(){
		
		
		if(pbulletactive && weaponlimit>0 && Playerhealth.phealth!=0)
		{
			yield return new WaitForSeconds(.3f);
			chosenturret = Random.Range(0,turretpos.Length);
			
			Instantiate(playerbullets, turretpos[chosenturret].transform.position, turretpos[chosenturret].transform.rotation);
			weaponlimit = weaponlimit-1;                
		}
		else{
			pbulletactive = false;
			weaponlimit = templimit;
		}
		
	}
}

