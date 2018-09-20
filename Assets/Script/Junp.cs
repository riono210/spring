using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junp : MonoBehaviour {
    // こっちが本物

	public Rigidbody springRb;
    public GameObject springObj;

	bool onGround = false;  // 地面判定
    bool oneJump = true;    // ジャンプ判定
    bool minimam = false;     // 小さくなったか
    public float force = 1f;  // 跳ねる強さ
    public float pos = 0.08f;    // 縮まる長さ
    float size;    // 縮まる大きさ
    public float movePow;

	// Use this for initialization
	void Start () {
        size = pos / 2;
	}
	
	// Update is called once per frame
	void Update () {
        springMove();


        if (onGround == true) {
            if (!minimam) {
                Shrink();
            }

                HoldSpace();


        }
        else{
            if(!oneJump){
                Hop2();

            }
            extend();
        }
	}

	void OnCollisionEnter(Collision ground){
		if (ground.gameObject.tag == "ground") {
			onGround = true;
            
		}
	}

    private void OnCollisionExit(Collision collision) {
        oneJump = true;
        onGround = false;
    }


    public void Hop2(){

        springRb.velocity = Vector3.up * force;
    }

    // 縮める
    private void Shrink(){
        springObj.transform.position = new Vector3(springObj.transform.position.x, springObj.transform.position.y - pos, springObj.transform.position.z);
        springObj.transform.localScale = new Vector3(springObj.transform.localScale.x, springObj.transform.localScale.y - size, springObj.transform.localScale.z);

        // 小さくなる下限
        if (springObj.transform.localScale.y <= 0.5f) {
            onGround = false;
            oneJump = false;
            minimam = true;
        }
    }


    // 力をためる・待機
    public void HoldSpace(){
        if(Input.GetKey(KeyCode.Space)){
            Debug.Log("スペース");
            onGround = true;
            oneJump = true;
        }
        else{
            minimam = false;
        }

    }

    // onGroundの管理
    public void checkSize(){
        if(springObj.transform.localScale.y <= 0.5f){
            onGround = false;
        }
    }

    // 伸長
    public void extend() {
        if (springObj.transform.localScale.y <= 1) {
            springObj.transform.position = new Vector3(springObj.transform.position.x, springObj.transform.position.y + pos,springObj.transform.position.z);
            springObj.transform.localScale = new Vector3(springObj.transform.localScale.x, springObj.transform.localScale.y + size, springObj.transform.localScale.z);
        }
        else{
            minimam = false;
        }
    }

    // 移動
    public void springMove(){
        //if(Input.GetKey(KeyCode.LeftArrow)){

        //}
        float xPos = Input.GetAxis("Horizontal") * movePow;
        float zPos = Input.GetAxis("Vertical") * movePow;

        Vector3 moveForce = new Vector3(xPos, 0, zPos);
        springRb.AddForce(moveForce);
    }
}
