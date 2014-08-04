using UnityEngine;
using System.Collections;

public class GUIability : MonoBehaviour {


	//ability textures
	public Texture[] ranability;
	public int chosentextint;
	private UITexture abilitytexture;
	public static GUIability textinstant;

	//turns off uibutton script
	public GUIability disbutton;

	public UIButton buttonobj;

	public Randomselect randomref;

	public Playercontrol waves;

	public Playerhealth phealth;

	private GameObject[] eobjs;

	//the button background
	public GameObject spritebg;

	//sound
	public AudioClip pressingbutton;

	public GameMaster freezestart;



	// Use this for initialization
	void Start () {

		abilitytexture = this.gameObject.GetComponent<UITexture>();
		textinstant = this;
		buttonobj = this.gameObject.GetComponent<UIButton>();
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
		chosentextint =0;
		//chosentextint = randomref.chosenint;
		abilitytexture.mainTexture = ranability[chosentextint];
		buttonobj.gameObject.SetActive(true);
		disbutton.gameObject.GetComponent<UIButton>().enabled = true;
		spritebg.gameObject.SetActive(true);
	}

	public void disablebutton()

	{
		audio.PlayOneShot(pressingbutton);
	
		disbutton.gameObject.GetComponent<UIButton>().enabled = false;
		buttonobj.gameObject.SetActive(false);
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

			eobjs = GameObject.FindGameObjectsWithTag("Enemy");
			for(int i = 0;i<4;i++){
				eobjs[i].transform.FindChild("Nose shooter").gameObject.SetActive(false);
				eobjs[i].GetComponent<EnemyAI>().enabled = false;
			}

			freezestart.coustarter();
		//	EnemyAI.freezer = true;

			break;
		case 3: 
			
			phealth.addhealth();
		 
			break;
		case 4:
			
			Playercontrol.morespeed =true;
	 
			break;
		case 5:
			
		//	Playercontrol.bigwave = true;
			waves.wavemaker();
			break;
		}

	}

//	IEnumerator Needtime()
//	{
//		yield return new WaitForSeconds (5f);
//
//		for(int i = 0;i<4;i++){
//			eobjs[i].transform.FindChild("Nose shooter").gameObject.SetActive(true);
//			eobjs[i].GetComponent<EnemyAI>().enabled = true;
//		}
//	}
}
