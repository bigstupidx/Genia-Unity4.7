using UnityEngine;
using System.Collections;

public class VirtualJoystick_NGUI : MonoBehaviour 
{
	//detect pressing in area
	//when pressing is active track touch position
	public UISprite Joystick;
	public UISprite JoystickHotSpot;
	float hotSpotDistance;
	public float playerspeedf;

	public enum TouchState {NotTouching, Touching, Returning}
	TouchState currentState;

	bool useTouchValue;
	Vector2 touchPosition;
	Vector2 hotspotOrigin;
	public Camera NGUICamera;
	public Vector2 JoystickDirection;
	public float JoystickMagnitude;

	public GameObject Player;

	// Use this for initialization
	void Start () 
	{
		useTouchValue = false;
		currentState = TouchState.NotTouching;
		Vector3 con = NGUICamera.WorldToScreenPoint(JoystickHotSpot.transform.position);
		hotspotOrigin = new Vector2(con.x, con.y);
		hotSpotDistance = JoystickHotSpot.width/2f; //assumes a circle
	}
	
	// Update is called once per frame
	void Update () 
	{

		switch (currentState)
		{
		case TouchState.NotTouching:
			CheckForNewTouches();
			break;
		case TouchState.Touching:
			if (AreTouches())
			//if (Input.GetMouseButton(0))
			{
				bool foundTouch = false;
				foreach (Touch touch in Input.touches) 
				{
					if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
					{
						if (touch.position.x > Screen.width/2f)
						{
							//need to look at last position versus new positions and deltas to determine correct touch
							foundTouch = true;
							useTouchValue = true;
							touchPosition = touch.position;
							//touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
							touchPosition = NGUICamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 1f));
							Joystick.transform.position = new Vector3(touchPosition.x, touchPosition.y, Joystick.transform.position.z);
						}
					}
				}
				if (!foundTouch)
				{
					ResetJoystick();
				}
			}
			else
			{
				ResetJoystick();
			}
			break;
		}

		if (useTouchValue)
		{
			Vector2 temp = Joystick.transform.localPosition - JoystickHotSpot.transform.localPosition;
			JoystickDirection = temp.normalized; 
			JoystickMagnitude = temp.magnitude;
		}
		else
		{
			JoystickDirection = Vector2.zero; 
			JoystickMagnitude = 0f;
		}

		Vector3 tempVec = new Vector3(JoystickDirection.x, 0f, JoystickDirection.y);
		Player.rigidbody.AddForce(tempVec * JoystickMagnitude * playerspeedf * Time.deltaTime,ForceMode.Acceleration);
		Debug.Log(JoystickDirection);

		ClampJoystickPosition();
	}

	void ClampJoystickPosition()
	{
		Vector2 joyLocalPos = new Vector2(Joystick.transform.localPosition.x, Joystick.transform.localPosition.y);
		//Vector2 temp = joyLocalPos - hotspotOrigin;
		Vector3 temp = Joystick.transform.localPosition - JoystickHotSpot.transform.localPosition;
		if (temp.magnitude > hotSpotDistance)
		{
			//Vector2 newPos = hotspotOrigin + temp.normalized * hotSpotDistance;
			//Joystick.transform.localPosition = new Vector3(newPos.x, newPos.y, Joystick.transform.localPosition.z);
			Vector3 newPos = JoystickHotSpot.transform.localPosition + temp.normalized * hotSpotDistance;
			Joystick.transform.localPosition = newPos;
		}
	}

	void CheckForNewTouches()
	{
		if (Input.touchCount > 0) 
		{
			foreach (Touch touch in Input.touches) 
			{
				if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width/2f)
				{
					if (CheckIfInHotspot(touch.position))
					//if (Input.GetMouseButton(0) && CheckIfInHotspot(new Vector2(Input.mousePosition.x, Input.mousePosition.y)))
					{
						touchPosition = touch.position;
						//touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
						touchPosition = NGUICamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 1f));
						useTouchValue = true;
						currentState = TouchState.Touching;
						Joystick.transform.position = new Vector3(touchPosition.x, touchPosition.y, Joystick.transform.position.z);
						//in the future add interpolation
						return;
					}
				}
			}
		}
	}

	bool CheckIfInHotspot(Vector2 point)
	{
		//Debug.Log ("HotSpot: " + hotspotOrigin);
		//Debug.Log ("Position: " + NGUICamera.WorldToScreenPoint(JoystickHotSpot.transform.position));
		//Debug.Log ("Mouse: " + point);
		float distance = Vector2.Distance(point, hotspotOrigin);
		//Debug.Log("Distance: " + distance);
		if (distance <= hotSpotDistance)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool AreTouches()
	{
		if (Input.touchCount > 0)
		{
			return true;
		}
		return false;
	}

	void ResetJoystick()
	{
		Joystick.transform.localPosition = JoystickHotSpot.transform.localPosition;
		currentState = TouchState.NotTouching;
		useTouchValue = false;
	}

}
