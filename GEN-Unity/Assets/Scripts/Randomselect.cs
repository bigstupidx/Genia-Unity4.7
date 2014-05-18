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

	//new variables for change in code
	public Texture[] weaponTextures;
	private Texture buttontexture;
	private bool chosenability;
	public Material blankmat;
	private Texture blanktext;
	public static bool buttonchanger =false;
	public static bool startran=false;


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
		if(startran){
	
		if(rancount >0)
		{
			rancount = rancount -1;
			ranint = Random.Range(0,ranweapon.Length);
			renderer.material =ranweapon[ranint];
	 
		}
		if(rancount <=0){
		chosenweapon = ranweapon[ranint];
		renderer.material = chosenweapon;
		buttontexture = weaponTextures [ranint];
		buttonchanger = true;
//
//		switch (ranint)
//			{
//			case 0:
//		 
//				pbullets.pbulletactive = true;
//				break;
//			case 1:
//			 
//				makebigger.makelarger = true;
//				break;
//			case 2:
//			 
//				EnemyAI.freezer = true;
//				break;
//			case 3: 
//		 
//				Playerhealth.uphealth = true;
//				break;
//			case 4:
//		 
//				Playercontrol.morespeed =true;
//				break;
//			case 5:
//
//				waves.wavemaker();
//				break;
//			}
//		StartCoroutine(Onesec());
//		
		}
		}
	}

	
	 void OnGUI()
	{
		if(buttonchanger){
		chosenability = GUI.Button(new Rect(100, Screen.height/2, 100, 100), buttontexture);
		}


		if(chosenability)
		{
						
			switch (ranint)
			{
			case 0:
				
				pbullets.pbulletactive = true;

				renderer.material = blankmat;
				buttontexture = blanktext;
				buttonchanger = false;
				if(GameMaster.deadcount>0){
				startran = true;
				}
				rancount = resetcount;
				break;
			case 1:
				
				makebigger.makelarger = true;

				renderer.material = blankmat;
				buttontexture = blanktext;
				buttonchanger = false;
				if(GameMaster.deadcount>0){
					startran = true;
				}
				rancount = resetcount;
				break;
			case 2:
				
				EnemyAI.freezer = true;

				renderer.material = blankmat;
				buttontexture = blanktext;
				buttonchanger = false;
				if(GameMaster.deadcount>0){
					startran = true;
				}
				rancount = resetcount;
				break;
			case 3: 
				
				Playerhealth.uphealth = true;

				renderer.material = blankmat;
				buttontexture = blanktext;
				buttonchanger = false;
				if(GameMaster.deadcount>0){
					startran = true;
				}
				rancount = resetcount;
				break;
			case 4:
				
				Playercontrol.morespeed =true;

				renderer.material = blankmat;
				buttontexture = blanktext;
				buttonchanger = false;
				if(GameMaster.deadcount>0){
					startran = true;
				}
				rancount = resetcount;
				break;
			case 5:
				
				waves.wavemaker();

				renderer.material = blankmat;
				buttontexture = blanktext;
				buttonchanger = false;
				if(GameMaster.deadcount>0){
					startran = true;
				}
				rancount = resetcount;
				break;
			}
	

		}
	}
	
}
