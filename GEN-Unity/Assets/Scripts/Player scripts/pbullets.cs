using UnityEngine;
using System.Collections;

public class pbullets : MonoBehaviour {

	public static bool pbulletactive = false;
	public GameObject playerbullets;
	private GameObject[] turretpos;
	private int chosenturret;
	public int weaponlimit = 0;
	private int templimit;
	public static pbullets instance = null;

	// Use this for initialization
	void Start () {
		templimit = weaponlimit;
		turretpos = GameObject.FindGameObjectsWithTag("turret2s");
		instance = this;
	}
	
	// Update is called once per frame
	void Update()
	{


	}
	
	public void startbulletgen()
		
	{
		StartCoroutine (Slower());
	}
	
	IEnumerator Slower(){

			for(int i = 0; i<=templimit;i++){
				yield return new WaitForSeconds(.00f);
				chosenturret = Random.Range(0,turretpos.Length);
				
				Instantiate(playerbullets, turretpos[chosenturret].transform.position, turretpos[chosenturret].transform.rotation);
				weaponlimit = weaponlimit-1;    
			print(weaponlimit);
			}

			pbulletactive = false;
			weaponlimit = templimit;
	
		print(weaponlimit);
	}

}

