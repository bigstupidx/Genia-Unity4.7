using UnityEngine;
using System.Collections;

public class InstructionPanel : MonoBehaviour {


	private int textcounter = 0;
	public UITexture helptextpanel;
	public Texture[] helptext;
	public UIPanel helppanel;
	public UIButton backup;
	public UIButton forwardgo;
	public UIButton backtotitle;

	public Texture Helptextpanel
		
	{
		get
		{
			//Some other code
			return helptextpanel.mainTexture;
		}
		set
		{
			//Some other code
			helptextpanel.mainTexture = value;
		}
	}


	public void forwardtexture()		
	{
		textcounter++; 
		if(textcounter == 5)
		{
		
			helptextpanel.mainTexture = helptext[textcounter];

			forwardgo.gameObject.SetActive(false);

		} else
		{

			backup.gameObject.SetActive(true);
			forwardgo.gameObject.SetActive(true);
			helptextpanel.mainTexture = helptext[textcounter];
		}

	}
	
	public void exitpanel()
		
	{

		helppanel.gameObject.SetActive(false);
	}

	public void backtexture()

	{
		textcounter--;

		if(textcounter == 0)
		{
			backup.gameObject.SetActive(false);
			
			helptextpanel.mainTexture = helptext[textcounter];
			
		} else
		{

			backup.gameObject.SetActive(true);
			forwardgo.gameObject.SetActive(true);
			helptextpanel.mainTexture = helptext[textcounter];
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
