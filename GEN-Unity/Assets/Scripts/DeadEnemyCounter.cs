using UnityEngine;
using System.Collections;

public class DeadEnemyCounter : MonoBehaviour {

	//public GUIText deathcount;
	public static int enemiesdead = 0;
	private UILabel Edeadtext;

	void Start()

	{
		enemiesdead =0;
		Edeadtext = gameObject.GetComponent<UILabel>();
	}

	// Update is called once per frame
	void Update () {
	
		Edeadtext.text = enemiesdead.ToString();
		//guiText.text = enemiesdead.ToString();
	}
}
