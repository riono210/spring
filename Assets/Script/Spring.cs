using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

	public Rigidbody rd;

	bool Jump;
	bool onGround;

	// Springのサイズ変更値
	float SizeChange;

	Vector3 FirstSize;
	// Use this for initialization
	void Start () {
		//rd = Sp.GetComponent<Rigidbody> ();
		FirstSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && onGround) {
			Jump = true;
		}else {
			Jump = false;
		}
	}

	// ジャンプ
	void FixedUpdate(){
		if (Jump) {
			rd.AddForce (transform.up * 3, ForceMode.Impulse);
		}
		Transformation ();
	}


	// 接地判定
	void OnCollisionEnter(Collision ground){
		if (ground.gameObject.tag == "ground") {
			onGround = true;
			SizeChange = 0.3f;
		}
	}

	void OnCollisionExit(Collision ground){
		if (ground.gameObject.tag == "ground") {
			onGround = false;
		}
	}

	void Transformation(){
		if (onGround) {
			Vector3 size = transform.localScale;
			size.y -= SizeChange;
			transform.localScale = size;

			transform.position += new Vector3 (0, -0.15f, 0);
		} else if (!onGround) {
			Vector3 size = FirstSize;
			transform.localScale = size;
		}
	}
}
