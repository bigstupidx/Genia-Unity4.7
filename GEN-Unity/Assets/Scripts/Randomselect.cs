using UnityEngine;
using System.Collections;

public class Randomselect : MonoBehaviour {

	public Material[] ranweapon;
	public int weaponamount =0;
	private int ranint;
	public int rancount = 0;
	public int resetcount;
	private Material chosenweapon;
 

	// Use this for initialization
	void Start () {
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
				print ("bullets");
				pbullets.pbulletactive = true;
				break;
			case 1:
				print ("expand");
				break;
			case 2:
				print ("freeze");
				break;
			case 3:
				print ("missles");
				break;
			case 4:
				print ("speed");
				break;
			case 5:
				print("waves");
				break;
			}
		StartCoroutine(Onesec());
		
		}

	}

	IEnumerator Onesec()
	{
		rancount = resetcount;
		gameObject.SetActive(false);
		yield return new WaitForSeconds(3f);
	
	}
}
