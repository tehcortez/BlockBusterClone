using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float acceletarion;
	public float maxSpeed;

	private Rigidbody rigidBody;
	private KeyCode[] inputKeys;
	private Vector3[] directionsForKeys;

	// Use this for initialization
	void Start () {
		inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
		directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
//	void Update () {
//		
//	}

	// FixedUpdate() is frame rate independent and should be used when working with Rigidbodies. 
	// Instead of running as fast as possible, this method will be fired at a constant interval.
	void FixedUpdate () {
		for (int i = 0; i < inputKeys.Length; i++){
			var key = inputKeys[i];

			// This loop checks to see if any of the input keys were pressed.
			if(Input.GetKey(key)) {
				// Get the direction for the pressed key, multiply it by the acceleration and the number 
				// of seconds it took to complete the last frame. This produces a direction vector 
				// (speed on the X, Y and Z axes) that you'll use to move the Player object.
				Vector3 movement = directionsForKeys[i] * this.acceletarion * Time.deltaTime;
				movePlayer(movement);
			}
		}
	}

	void movePlayer(Vector3 movement) {
		if(rigidBody.velocity.magnitude * this.acceletarion > this.maxSpeed) {
			rigidBody.AddForce(movement * -1);
		} else {
			rigidBody.AddForce(movement);
		}
	}


}
