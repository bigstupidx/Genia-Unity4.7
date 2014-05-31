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
	
	}
	
	// Update is called once per frame
	void Update()
	{
		//startbulletgen();
	}
	
	void startbulletgen()
		
	{
		StartCoroutine (Slower());
	}
	
	IEnumerator Slower(){
		
		
		if(pbulletactive && weaponlimit>0 && Playerhealth.phealth!=0)
		{
			for(int i = 0; i<=weaponlimit;i++){
			yield return new WaitForSeconds(.1f);
			chosenturret = Random.Range(0,turretpos.Length);
			
			Instantiate(playerbullets, turretpos[chosenturret].transform.position, turretpos[chosenturret].transform.rotation);
			weaponlimit = weaponlimit-1;    
				print ("bullet");
			}
		}
		else{
			pbulletactive = false;
			weaponlimit = templimit;
		}
		
	}
}

