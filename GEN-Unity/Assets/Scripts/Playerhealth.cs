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

	public int currentplayerhealth =0;

	//material health changer
	public Material healthmat;
	public Material tempmat;
	public Color orangemat;
	public Color yellowmat;
	public Color redmat;
	public Color greenmat;

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
		tempmat = healthmat;
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
		currentplayerhealth = phealth;

		if(phealth<=50 && phealth>=40)
		{
			hcircle.transform.renderer.material = healthcircle[4];
			//renderer.materials[3].color = greenmat;
		}

		if(phealth<=39 && phealth>=30)
		{
			hcircle.transform.renderer.material = healthcircle[3];
			//renderer.materials[3].color = greenmat;
		}

		if(phealth<=29 && phealth>=20)
		{
			hcircle.transform.renderer.material = healthcircle[2];
			//renderer.materials[3].color = yellowmat;
		}

		if(phealth<=19 && phealth>=10)
		{
			hcircle.transform.renderer.material = healthcircle[1];
			//renderer.materials[3].color = orangemat;
		}

		if(phealth<=9 && phealth>=1)
		{
			hcircle.transform.renderer.material = healthcircle[0];
			//renderer.materials[3].color = redmat;
		}
		
		renderer.materials[3].color = Color.Lerp(redmat, greenmat, phealth / 50f);

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

		if(pcollide.collider.name == "outerwalls")
		{
			phealth = 0;
			transform.FindChild("playershield").gameObject.SetActive(false);
			StartCoroutine(playerdeath());
		}
			
		if(pcollide.collider.tag == "eattack")
		{

			Instantiate (sparks,ehit.point,transform.rotation);

			if(pcollide.gameObject.name == "bbullet1(Clone)")
			{
			phealth = phealth-2;
			}
			if(pcollide.gameObject.name == "bbullet(Clone)")
			{
			phealth = phealth-1;
			}





			healthcounter = Mathf.Abs(phealth/10);

			/*switch (healthcounter)
			{
			case 4:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				renderer.materials[3].color = greenmat;
				break;
			case 3:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				renderer.materials[3].color = greenmat;
				break;
			case 2:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				renderer.materials[3].color = yellowmat;
				break;
			case 1:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				renderer.materials[3].color = orangemat;
				break;		
			case 0:
				hcircle.transform.renderer.material = healthcircle[healthcounter];
				renderer.materials[3].color = redmat;
				break;	
			}*/

			if(phealth <=10)
			{
				transform.FindChild("playershield").gameObject.SetActive(false);
			}
			
			if(phealth <=0)
			{
			//	gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
				hcircle.transform.renderer.material = deathmat;
				pbullets.pbulletactive =false;
			//	currentenemies = GameObject.FindGameObjectsWithTag("Enemy");
				StartCoroutine(playerdeath());
			}
		}
		
	}

	IEnumerator playerdeath()
	{
		//add to counter for ad stuff
		ademperor.deathcounter ++;
		print(ademperor.deathcounter);
		//big page ad

		if(ademperor.deathcounter ==3)
		{
			yield return new WaitForSeconds(2f);
		}

		gameoverpanel.gameObject.SetActive(true);
		timecounter.GetComponent<Timer>().enabled = false;

		renderer.enabled =false;
		yield return new WaitForSeconds(waittime);

	}
}
