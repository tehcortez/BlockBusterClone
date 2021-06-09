using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health = 3;

	public event Action<Player> onPlayerDeath;

	void collidedWithEnemy(Enemy enemy) {
		// Enemy attack code
		enemy.Attack(this);
		if(health <= 0) {
			if(onPlayerDeath != null) {
				onPlayerDeath(this);
			}
			// Todo 
		}
	}

	void OnCollisionEnter (Collision col) {
		Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
		if(enemy) {
			collidedWithEnemy(enemy);
		}
//		collidedWithEnemy(enemy);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
