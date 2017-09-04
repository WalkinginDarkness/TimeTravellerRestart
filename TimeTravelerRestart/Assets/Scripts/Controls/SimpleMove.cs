using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

	[Tooltip("玩家ID")]
	public string playerID = "1";
	public float speed = 1.0f;

	public float rotateSpeed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		
	}

	void Move(){

		float mx = Input.GetAxisRaw ("Horizontal"+playerID);	// 临时的x方向值
		float mz = Input.GetAxisRaw ("Vertical"+playerID);		// 临时的z方向值



		Quaternion q1 = transform.rotation;
		// 如果输入的位置接近于0，那么不进行转向（否则LookRotation会抛警告）
		if  (Mathf.Sqrt(mx*mx+mz*mz) > 0.05f) {
			Quaternion q2 = Quaternion.LookRotation (new Vector3 (mx, 0, mz));
			transform.rotation = Quaternion.Lerp(q1, q2, Time.deltaTime * rotateSpeed);

			// 当当前方向和目标方向夹角过大时，只转向，不进行移动
			if (Quaternion.Angle (q1, q2) < 180) {
				// 为什么要用InverseTransformVector，因为转完之后Translate移动的方向也变了
				// 所以需要从局部的坐标映射回全局的坐标
				transform.Translate(transform.InverseTransformVector(new Vector3(mx,0,mz)));
				// 好了，我编不下去了。上面的代码是凑出来的，恰好没有bug而已
			}
		}



		
	}
}
