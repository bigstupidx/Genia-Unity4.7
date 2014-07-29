using UnityEngine;
using System.Collections;

public class Guiscrollers : MonoBehaviour {

	public float speed2;
	public float speed1;
	private float speed2rotation;
	private float speed1rotation;
	private GameObject playercontroller;
	public float speedinc;


	// Use this for initialization
	void Start () {
		playercontroller = GameObject.FindGameObjectWithTag("Player");
		speed1 = 5;

	}
	void Update () {

			speed1rotation= speed1*speedinc;
			playercontroller.transform.Rotate (0,speed1rotation*Time.deltaTime,0,Space.World);
	}

}
