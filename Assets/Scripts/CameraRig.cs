using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

	public float moveSpeed;
	public GameObject target;

	private Transform rigTransform;

	// Use this for initialization
	void Start () {
		this.rigTransform = this.transform.parent;

	}
	
	// Update is called once per frame
//	void Update () {
//		
//	}
	void FixedUpdate () {
		if(target == null){
			return;
		}

		this.rigTransform.position = Vector3.Lerp(this.rigTransform.position, this.target.transform.position, 
			Time.deltaTime * this.moveSpeed);
	}

}
