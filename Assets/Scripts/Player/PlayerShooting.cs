using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public Projectile projectilePrefab;
	public LayerMask mask;

	void shoot(RaycastHit hit){
		// Instantiates a projectile Prefab and gets its Projectile component so it can be initialized.
		var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();

		//	This point always looks like (x, 0.5, z). X and Z are coordinates on the floor 
		//	where the ray cast from the mouse click position hits. This calculation is 
		//	important, because the projectile has to be parallel to the floor – otherwise you'd 
		//	be shooting downward, and only amateurs shoot towards the ground. :]
		var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);

		// Calculates the direction from the Player GameObject to pointAboveFloor.
		var direction = pointAboveFloor - transform.position;

		// Creates a new ray that describes the projectile trajectory by its origin and direction.
		var shootRay = new Ray(this.transform.position, direction);
		Debug.DrawRay(shootRay.origin, shootRay.direction * 100.1f, Color.green, 2);

		// This line tells Unity's physics engine to ignore collisions between the Player collider 
		// and Projectile collider. Otherwise OnCollisionEnter() in the Projectile script 
		// would be called before it had the chance to fly off.
		Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());

		// Finally, it sets the trajectory for the projectile.
		projectile.FireProjectile(shootRay);
	}

	// This method casts a ray from the camera to the point where the mouse clicked. 
	// Then it checks to see if this ray intersects a game object with the given LayerMask.
	void raycastOnMouseClick () {
		RaycastHit hit;
		Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2);

		if(Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide)) {
			shoot(hit);
		}
	}

	// On every update, the script checks for a left mouse button press. If it finds one, it calls raycastOnMouseClick().
	void Update () {
		bool mouseButtonDown = Input.GetMouseButtonDown(0);
		if(mouseButtonDown) {
			raycastOnMouseClick();  
		}
	}


	// Use this for initialization
	void Start () {
		
	}
}
