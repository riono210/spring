using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnCollisionEnter(Collision ground){
		if (ground.gameObject.tag == "ground") {
			Shrink ();

		}
	}

	void Shrink(){
		if (transform.localScale.y >= 0.3f) {
			Vector3 size = transform.localScale;
			Vector3 pos = transform.position;

			size.y -= 0.0f;
//			pos.y -= 0.02f;

			transform.localScale = size;
			transform.position = pos;
		}
	}
}
