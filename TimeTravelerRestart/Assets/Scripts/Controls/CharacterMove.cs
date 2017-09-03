using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	private float tileLength = 1.0f;
	private float moveX = 0;
	private float moveZ = 0;

	/** while the player is moving, other actions are ignored.*/
	private bool isMoving = false;
	/** seconds need to move one tile.*/
	public float movingSpeed;
	private float movingSpeedInverse;
	private float movingProgress = 0f;
	private Vector3 movingStart;

	// Use this for initialization
	void Start () {
		movingStart = transform.position;
		movingSpeedInverse = 1.0f / movingSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			float mx = Input.GetAxisRaw ("Horizontal");
			float mz = Input.GetAxisRaw ("Vertical");
			if (mx != 0 || mz != 0) {
				moveX = mx;
				moveZ = mz;
				isMoving = true;
				movingProgress = Time.deltaTime * movingSpeedInverse;
			}
		} else {
			movingProgress += Time.deltaTime * movingSpeedInverse;
		}
	}

	void LateUpdate () {
		if (isMoving) {
			Vector3 movingEnd = movingStart + new Vector3 (moveX * tileLength, 0, moveZ * tileLength);
			Vector3 p = Vector3.Lerp (movingStart, movingEnd, movingProgress);
			transform.position = p;
			if (movingProgress >= 1) {
				moveX = 0;
				moveZ = 0;
				isMoving = false;
				movingProgress = 0;
				movingStart = movingEnd;
			}
		}
	}
}
