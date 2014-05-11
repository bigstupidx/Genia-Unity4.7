using UnityEngine;
using System.Collections;

public class Randomselect : MonoBehaviour {

	public Material[] ranweapon;
	public int weaponamount =0;
	private int ranint;
	public int rancount = 0;
	public int resetcount;
	private Material chosenweapon;
	private Playercontrol waves;

	// Use this for initialization
	void Start () {
		waves = GameObject.Find ("Playerbody").GetComponent<Playercontrol>();
		resetcount =rancount;
	}

	void OnEnable(){
		ranint = Random.Range(0,ranweapon.Length);
		renderer.material =ranweapon[ranint];
	}
	
	// Update is called once per frame
	void Update () {

		if(rancount >0)
		{
			rancount = rancount -1;
			ranint = Random.Range(0,ranweapon.Length);
			renderer.material =ranweapon[ranint];
		}
		if(rancount <=0){
		chosenweapon = ranweapon[ranint];
		renderer.material = chosenweapon;
		switch (ranint)
			{
			case 0:
		 
				pbullets.pbulletactive = true;
				break;
			case 1:
			 
				makebigger.makelarger = true;
				break;
			case 2:
			 
				EnemyAI.freezer = true;
				break;
			case 3: 
		 
				Playerhealth.uphealth = true;
				break;
			case 4:
		 
				Playercontrol.morespeed =true;
				break;
			case 5:

			//	Playercontrol.bigwave = true;
				waves.wavemaker();
				break;
			}
		StartCoroutine(Onesec());
		
		}

	}

	IEnumerator Onesec()
	{
		yield return new WaitForSeconds(1.5f);
		rancount = resetcount;
		gameObject.SetActive(false);
	}
}
