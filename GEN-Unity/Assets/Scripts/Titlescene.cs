using UnityEngine;
using System.Collections;

public class Titlescene : MonoBehaviour {


	private Rect arrowbutton;
	public Texture arrowtext;
	private bool goarrow;
	private GUIStyle inputstyle;


	// Use this for initialization
	void Start () {
	
		//StartCoroutine(Waitatstart());

		arrowbutton	= new Rect(Screen.width - 100,Screen.height - 100,100,100);
	
	}

	void Update()
	{
		for(int i =0; i<Input.touchCount;i++)
		{
			goarrow = arrowbutton.Contains(Input.touches[i].position);
		}

		if(Input.GetMouseButton(0))
			
		{
			Vector2 mousePosition = Input.mousePosition;
			mousePosition.y = Screen.height - mousePosition.y;

			goarrow = arrowbutton.Contains(mousePosition);
		}

	}

void OnGUI()

	{
		GUI.Label(arrowbutton, arrowtext,"label");

		if(goarrow)
		{
			Application.LoadLevel("Demo");
		}

	}
}
