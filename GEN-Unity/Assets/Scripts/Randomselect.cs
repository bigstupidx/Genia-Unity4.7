using UnityEngine;
using System.Collections;

public class Randomselect : MonoBehaviour {

	public Material[] ranweapon;
	public int weaponamount =0;
	private int ranint;
	public static int rancount = 0;

	private int chosenint =0;
	private Material chosenweapon;
	private Playercontrol waves;

	//new variables for change in code
	public Texture[] weaponTextures;
	private Texture buttontexture;
	private bool chosenability;
	public Material blankmat;
	public Texture blanktext;
	public static bool buttonchanger =false;
	public static bool startran=false;
	public static Randomselect instant1;

	// Use this for initialization
	void Start () {
		waves = GameObject.Find ("Playerbody").GetComponent<Playercontrol>();
		instant1 = this;
	}

	void OnEnable(){
		ranint = Random.Range(0,ranweapon.Length);
		renderer.material =ranweapon[ranint];
	}
	
	// Update is called once per frame
	void Update () {
		if(startran){
		//	randomgo();

		if(rancount >0)
		{
			rancount = rancount -1;
			ranint = Random.Range(0,ranweapon.Length);
			renderer.material =ranweapon[ranint];
			buttontexture = blanktext;
		}
		if(rancount<=0){
		chosenweapon = ranweapon[ranint];
		renderer.material = chosenweapon;
		buttontexture = weaponTextures [ranint];
		chosenint = ranint;
		renderer.material = blankmat;
		buttonchanger = true;
		}
		}
	}

//	public void randomgo()
//
//	{
//		while( rancount >0)
//		{
//			StartCoroutine(decran());
//
//		}
//		chosenweapon = ranweapon[ranint];
//		renderer.material = chosenweapon;
//		buttontexture = weaponTextures [ranint];
//		chosenint = ranint;
//		renderer.material = blankmat;
//
//
//	}
//
//	IEnumerator decran()
//	{
//		yield return new WaitForSeconds(.2f);
//		rancount = rancount -1;
//		ranint = Random.Range(0,ranweapon.Length);
//		renderer.material =ranweapon[ranint];
//	}



	 void OnGUI()
	{
		if(buttonchanger){
		chosenability = GUI.Button(new Rect(100, Screen.height/2, 100, 100), buttontexture);
		}


		if(chosenability)
		{
			buttonchanger = false;
			switch (chosenint)
			{
			case 0:
				
				pbullets.pbulletactive = true;
				pbullets.instance.startbulletgen();
			//	renderer.material = blankmat;
			//	buttontexture = blanktext;
		 
				Debug.Log (buttonchanger);
		//		chosenint = 6;
				StartCoroutine(Needtime());
		//		print ("bullet");	
				break;
			case 1:
				
				makebigger.makelarger = true;
				chosenability = false;
			//	renderer.material = blankmat;
			//	buttontexture = blanktext;
	 
				Debug.Log (buttonchanger);
			//	chosenint = 6;
		//		print ("make larger");
				break;
			case 2:
				
				EnemyAI.freezer = true;
				chosenability = false;
			//	renderer.material = blankmat;
			//	buttontexture = blanktext;
		 
				Debug.Log (buttonchanger);
			//	chosenint = 6;
	//			print ("freezer");
				break;
			case 3: 
				
				Playerhealth.uphealth = true;
				StartCoroutine(Needtime());
			//	renderer.material = blankmat;
			//	buttontexture = blanktext;
	 
				Debug.Log (buttonchanger);
			//	chosenint = 6;
		//		print (" uphealth");
		
				break;
			case 4:
				
				Playercontrol.morespeed =true;
				chosenability = false;
			//	renderer.material = blankmat;
			//	buttontexture = blanktext;
 
				Debug.Log (buttonchanger);
			//	chosenint = 6;
		//		print ("more speed");
		
				break;
			case 5:
				
				Playercontrol.bigwave = true;
				waves.wavemaker();
				 
			//	renderer.material = blankmat;
			//	buttontexture = blanktext;
 
				Debug.Log (buttonchanger);
			//	chosenint = 6;
				chosenability = false;
		//		print (" make waves");
				break;
			}
	
		}
	}

	IEnumerator Needtime()
	{
		yield return new WaitForSeconds (5f);
		chosenability =false;
	}
}
