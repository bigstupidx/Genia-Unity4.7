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
		print(rancount);
		StartCoroutine(Onesec());
		
		}

	}

	IEnumerator Onesec()
	{
		yield return new WaitForSeconds(3f);
		rancount = resetcount;
		gameObject.SetActive(false);
	}
}
