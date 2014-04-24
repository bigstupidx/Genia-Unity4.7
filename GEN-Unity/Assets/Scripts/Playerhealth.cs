using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour {

	public static int phealth;
	public int mainhealth;
	public GUIText currenthealth;
	public int healthint =0;
	public static bool uphealth = false;

	void Start()

	{
		phealth = mainhealth;
	}

	void Update()
	{
		currenthealth.text = phealth.ToString();

		
		if(uphealth)	
		{
			phealth = phealth + healthint;

			if(phealth>10)
			{
				transform.FindChild("playershield").gameObject.SetActive(true);
			}
			
			uphealth = false;
			if(phealth>mainhealth)
			{
				phealth = mainhealth;
			}
		}

	}

	void OnGUI()

	{
//		if(GUI.Button(new Rect(410,10,100,50),"Reset health"))
//		{
//			phealth = mainhealth;
//
//			if(!transform.FindChild("playershield").gameObject.activeSelf)
//			{
//				transform.FindChild("playershield").gameObject.SetActive(true);
//			}
//		}
		             
	}

	void OnCollisionEnter(Collision pcollide)
	{
		
		if(pcollide.collider.tag == "eattack")
		{
			//	print ("collision of bullet");
			phealth = phealth-1;


			if(phealth ==10)
			{
				transform.FindChild("playershield").gameObject.SetActive(false);
			}
			
			if(phealth ==0)
			{
				pbullets.pbulletactive =false;
				EnemyAI.freezer = false;

				Application.LoadLevel(Application.loadedLevel);
			}
		}
		
	}
}
