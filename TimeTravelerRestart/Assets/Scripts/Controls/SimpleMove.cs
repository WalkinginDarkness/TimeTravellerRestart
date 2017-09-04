using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

	[Tooltip("玩家ID")]
	public string playerID = "1";
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		
	}

	void Move(){

		float mx = Input.GetAxis ("Horizontal"+playerID);	// 临时的x方向值
		float mz = Input.GetAxis ("Vertical"+playerID);	// 临时的z方向值
		transform.Translate(new Vector3(mx,0,mz));

//		Quaternion q1 = transform.rotation;
//		if  (Mathf.Sqrt(mx*mx+mz*mz) > 0.05f) {
//			Quaternion q2 = Quaternion.LookRotation (new Vector3 (mx, 0, mz));
//			transform.rotation = Quaternion.Lerp(q1,q2,1);
//		}

		
	}
}
