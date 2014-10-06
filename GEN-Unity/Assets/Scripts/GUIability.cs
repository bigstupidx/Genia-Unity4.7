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
	//will be frezzing enemies
	public static bool freezer = false;

	//the enemy counter
	public int enemycount=0;

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
		//chosentextint =1;
		chosentextint = randomref.chosenint;
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
			freezer = true;
			eobjs = GameObject.FindGameObjectsWithTag("Enemy");
			enemycount =GameObject.FindGameObjectsWithTag("Enemy").Length;
			for(int i = 0;i<enemycount;i++){
				eobjs[i].transform.FindChild("Nose shooter").gameObject.SetActive(false);
				eobjs[i].GetComponent<EnemyAI>().enabled = false;
				if(eobjs[i].gameObject.name == "bouy2(Clone)")
				{
					eobjs[i].transform.FindChild("Nose shooter2").gameObject.SetActive(false);
				}
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

}
