using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour {

	public static int phealth;
	public int mainhealth;
	public GUIText currenthealth;
	public int healthint =0;
	public static bool uphealth = false;
	public Material[] healthcircle;
	public GameObject hcircle;
	public GameObject sparks;
	private int healthcounter =0;
	public Material deathmat;

	//sucker reference
	public GameObject suckeroffer;

	//enemy stop at death
	private GameObject[] currentenemies;
	//wait time
	public float waittime = 0;
	//UIpanel to enable
	public UIPanel gameoverpanel;
	//timer UI label
	public UILabel timecounter;

	void Start()
	{

		phealth = mainhealth;
	}

	public void addhealth()

	{
		uphealth = false;
		phealth = phealth + healthint;
		
		if(phealth>10)
		{
			transform.FindChild("playershield").gameObject.SetActive(true);
		}
		
	
		if(phealth>mainhealth)
		{
			phealth = mainhealth;
		}
	}

	void Update()
	{
		//currenthealth.text = phealth.ToString();

		
		if(uphealth)	
		{
			addhealth();
		}


		if(phealth ==0)
		{
			currentenemies = GameObject.FindGameObjectsWithTag("Enemy");
			for(int i = 0;i<4;i++){
				currentenemies[i].transform.FindChild("Nose shooter").gameObject.SetActive(false);
				currentenemies[i].GetComponent<EnemyAI>().enabled =false;		
			}
			suckeroffer.gameObject.SetActive(false);
		}
	}


	void OnCollisionEnter(Collision pcollide)
	{
		
		int ehitcounter =0;
	 	ContactPoint ehit;
		ehit = pcollide.contacts[ehitcounter];
			
		if(pcollide.collider.tag == "eattack")
		{

			Instantiate (sparks,ehit.point,transform.rotation);
			phealth = phealth-1;


			healthcounter = Mathf.Abs(phealth/10);

			//print (healthcounter);
			switch (healthcounter)
			{
			case 4:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				break;
			case 3:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				break;
			case 2:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				break;
			case 1:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				break;		
			case 0:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				break;	
			}

			if(phealth ==10)
			{
				transform.FindChild("playershield").gameObject.SetActive(false);
			}
			
			if(phealth ==0)
			{
				hcircle.transform.renderer.material = deathmat;
				pbullets.pbulletactive =false;
				EnemyAI.freezer = false;
				currentenemies = GameObject.FindGameObjectsWithTag("Enemy");
				StartCoroutine(playerdeath());
			}
		}
		
	}

	IEnumerator playerdeath()
	{
		for(int i = 0;i<4;i++){
			currentenemies[i].transform.FindChild("Nose shooter").gameObject.SetActive(false);
			currentenemies[i].GetComponent<EnemyAI>().enabled =false;		
		}
		suckeroffer.gameObject.SetActive(false);

		gameoverpanel.gameObject.SetActive(true);
		timecounter.GetComponent<Timer>().enabled = false;

		renderer.enabled =false;
		yield return new WaitForSeconds(waittime);

	}
}
