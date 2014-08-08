using UnityEngine;
using System.Collections;

public class Randomselect : MonoBehaviour {

	public Material[] ranweapon;
	public int weaponamount =0;
	private int ranint;
	public int rancount = 0;

	public int chosenint;
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
 
	public int resetcount;
	//randomaudioselect
	public AudioClip audioran;


	// Use this for initialization
	void Start () {
		waves = GameObject.Find ("Playerbody").GetComponent<Playercontrol>();
		//instant1 = this;
	}


	
	// Update is called once per frame
	void Update () {

	}

	public void randomgo()
	{
		StartCoroutine(decran());
	}

	IEnumerator decran()
	{
	//	print (rancount);
		while( rancount >0)
		{
			audio.PlayOneShot(audioran,1f);
			rancount--;
			ranint = Random.Range(0,ranweapon.Length);
			renderer.material =ranweapon[ranint];
			yield return new WaitForSeconds(.05f);
		}
		chosenweapon = ranweapon[ranint];
		renderer.material = chosenweapon;
		buttontexture = weaponTextures [ranint];
		renderer.material = blankmat;
		rancount = resetcount;
		chosenint = ranint;
		GUIability.textinstant.textchoice();
	}
}
