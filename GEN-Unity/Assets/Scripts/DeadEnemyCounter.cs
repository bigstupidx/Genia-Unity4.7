using UnityEngine;
using System.Collections;

public class DeadEnemyCounter : MonoBehaviour {

	//public GUIText deathcount;
	public static int enemiesdead = 0;

	void Start()

	{
		enemiesdead =0;
	}

	// Update is called once per frame
	void Update () {
	
		guiText.text = enemiesdead.ToString();
	}
}
