using UnityEngine;
using System.Collections;

public class GUIability : MonoBehaviour {


	//ability textures
	public Texture[] ranability;
	public int chosentextint;
	private UITexture abilitytexture;
	public static GUIability textinstant;

	private UIButton disbutton;

	public Randomselect randomref;

	public Playercontrol waves;

	public Playerhealth phealth;

	//the button background
	public GameObject spritebg;



	// Use this for initialization
	void Start () {
		abilitytexture = this.gameObject.GetComponent<UITexture>();
		textinstant = this;
		disbutton = this.gameObject.GetComponent<UIButton>();
	}
	
	// Update is called once per frame
	void Update () {
	}


	public Texture Abilitytexture

	{
		get
		{
			//Some other code
			return abilitytexture.mainTexture;
		}
		set
		{
			//Some other code
			abilitytexture.mainTexture = value;
		}
	}

	public void textchoice()

	{
		//chosentextint =0;
		chosentextint = randomref.chosenint;
		abilitytexture.mainTexture = ranability[chosentextint];
		disbutton.gameObject.SetActive(true);
		spritebg.gameObject.SetActive(true);
	}

	public void disablebutton()

	{

		disbutton.gameObject.SetActive(false);
		spritebg.gameObject.SetActive(false);
		abilitystart();
	}

	public void abilitystart()

	{
		switch (chosentextint)
		{
		case 0:
			
			pbullets.pbulletactive = true;
			pbullets.instance.startbulletgen();
				
			break;
		case 1:
			
			makebigger.makelarger = true;
 
			break;
		case 2:
			
			EnemyAI.freezer = true;
	 		
			break;
		case 3: 
			
			phealth.addhealth();
		 
			break;
		case 4:
			
			Playercontrol.morespeed =true;
	 
			break;
		case 5:
			
			Playercontrol.bigwave = true;
			waves.wavemaker();
			break;
		}

	}

	IEnumerator Needtime()
	{
		yield return new WaitForSeconds (5f);
	}
}
