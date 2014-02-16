using UnityEngine;
using System.Collections;

public class Guiscrollers : MonoBehaviour {

	public float speed2;
	public float speed1;
	private float speed2rotation;
	private float speed1rotation;
	public GameObject shield2;
	public GameObject playercontroller;
	public float speedinc;


	// Use this for initialization
	void Start () {
	
	}
	void OnGUI () {
		//scroll bars to do rotation
		speed2 = GUI.VerticalScrollbar(new Rect(100, 130, 50, 50), speed2, 1.0F, 2.0F, -1.0F);
		speed1 = GUI.VerticalScrollbar(new Rect(150, 130, 50, 50), speed1, 1.0F, 2.0F, -1.0F);

		//determin direction of ouside shield
		if(speed2>0)
		{
			speed2rotation= speed2*speedinc;
			shield2.transform.Rotate (0,speed2rotation*Time.deltaTime,0,Space.Self);
		}else if(speed2<0)
		{
			speed2rotation= speed2*speedinc;
			print (speed2rotation);
			shield2.transform.Rotate (0,speed2rotation*Time.deltaTime,0,Space.Self);
		}
		//Player rotation
		if(speed1>0)
		{
			speed1rotation= speed1*speedinc;
			playercontroller.transform.Rotate (0,speed1rotation*Time.deltaTime,0,Space.World);
		}else if(speed1<0)
		{
			speed1rotation= speed1*speedinc;
			print (speed1rotation);
			playercontroller.transform.Rotate (0,speed1rotation*Time.deltaTime,0,Space.World);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
