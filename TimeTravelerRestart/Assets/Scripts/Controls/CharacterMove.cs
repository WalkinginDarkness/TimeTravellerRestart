using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
	[Tooltip("移动的最小分度值")]
	public float tileLength = 1.0f;
	private float moveX = 0;
	private float moveZ = 0;

	/** while the player is moving, other actions are ignored.*/
	private bool isMoving = false;
	/** seconds need to move one tile.*/
	[Tooltip("移动最小分度值所需要的时间")]
	public float movingSpeed;
	private float movingSpeedInverse;
	private float movingProgress = 0f;
	private Vector3 movingStart;

	void Start () {
		movingStart = transform.position;
		movingSpeedInverse = 1.0f / movingSpeed;
	}
	
	void Update () {
		if (!isMoving) {
			// 如果不在移动状态下
			float mx = Input.GetAxisRaw ("Horizontal");	// 临时的x方向值
			float mz = Input.GetAxisRaw ("Vertical");	// 临时的z方向值
			if (mx != 0 || mz != 0) {	// 如果有输入
				moveX = mx;				// 设定 moveX 的值，此值在一次移动中仅会被修改一次
				moveZ = mz;				// 这是因为isMoving=true后，该分支就不会再进入了
				isMoving = true;		// 更新为true
				movingProgress = Time.deltaTime * movingSpeedInverse;
			}
		} else {
			// movingProgress 是 0~1 间的一个数字
			movingProgress += Time.deltaTime * movingSpeedInverse;
		}
	}

	void LateUpdate () {
		if (isMoving) {
			Vector3 movingEnd = movingStart + new Vector3 (moveX * tileLength, 0, moveZ * tileLength);
			Vector3 p = Vector3.Lerp (movingStart, movingEnd, movingProgress);
			transform.position = p;
			if (movingProgress >= 1) {	// 一格的移动完成，数据全部重置成初始状态
				moveX = 0;
				moveZ = 0;
				isMoving = false;
				movingProgress = 0;
				movingStart = movingEnd;
			}
		}
	}
}
