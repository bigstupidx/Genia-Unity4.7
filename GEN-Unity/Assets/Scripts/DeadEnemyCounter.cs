using UnityEngine;
using System.Collections;

public class DeadEnemyCounter : MonoBehaviour {

	//public GUIText deathcount;
	public static int enemiesdead = 0;
	private UILabel Edeadtext;
	public static int enemyend;
	void Start()

	{
		enemiesdead =0;
		Edeadtext = gameObject.GetComponent<UILabel>();
	}

	// Update is called once per frame
	void Update () {
	
		enemyend = enemiesdead;
		Edeadtext.text = enemiesdead.ToString();
		//guiText.text = enemiesdead.ToString();
	}
}
