using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour {

	public static int phealth;
	public int mainhealth = 0;
	public GUIText currenthealth;

	void Start()

	{
		phealth = mainhealth;
	}

	void Update()
	{
		currenthealth.text = phealth.ToString();
	}

	void OnGUI()

	{
		if(GUI.Button(new Rect(300,0,100,50),"Reset health"))
		{
			phealth = mainhealth;

			if(!transform.FindChild("playershield").gameObject.activeSelf)
			{
				transform.FindChild("playershield").gameObject.SetActive(true);
			}
		}
		             
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

				Application.LoadLevel(Application.loadedLevel);
			}
		}
		
	}
}
