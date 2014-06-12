using UnityEngine;
using System.Collections;

public class GUIability : MonoBehaviour {


	//ability textures
	public Texture[] ranability;
	public Texture chosenability;
	public UITexture abilitytexture;

	public int countdown;


	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		abilitytexture.mainTexture = ranability[1];
	}
}
