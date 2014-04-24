using UnityEngine;
using System.Collections;

public class JoystickInput : MonoBehaviour {
	// for controlling the game object
 		
		public Joystick joysticks;           // Reference to joystick prefab
		public float playerspeed;           // Movement speed
		public bool useAxisInput = true;   // Use Input Axis or Joystick
		private float h = 0, v = 0;         // Horizontal and Vertical values
		
		// Update is called once per frame
		void Update () {
			// Get horizontal and vertical input values from either axis or the joystick.
			if (!useAxisInput) {
				h = joysticks.position.x;
				v = joysticks.position.y;
			}
			else {
				h = Input.GetAxis("Horizontal");
				v = Input.GetAxis("Vertical");
			}
			
			// Apply horizontal velocity
			if (Mathf.Abs(h) > 0) {
			rigidbody.AddForce(new Vector3(h * playerspeed,0, rigidbody.velocity.y),ForceMode.Acceleration);
			//rigidbody.velocity = new Vector3(h * playerspeed,0, rigidbody.velocity.y);
			}

			
			// Apply vertical velocity
			if (Mathf.Abs(v) > 0) {
		//	rigidbody.velocity = new Vector3(rigidbody.velocity.x,0, v * playerspeed);

			rigidbody.AddForce(new Vector3(rigidbody.velocity.x,0, v * playerspeed),ForceMode.Acceleration);
			}
		}
	}

