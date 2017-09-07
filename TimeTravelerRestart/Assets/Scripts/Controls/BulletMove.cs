using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMove : MonoBehaviour {
	public float moveSpeed;
	public float rotateSpeed;
	public Vector3 direction;

    private string parentName;

	void Start () {
        if (parentName == null) {
            parentName = "";
        }
        Destroy(gameObject, 15);
	}

	void Update () {
        bulletMove();
        bulletRotate();
	}

    public void setParentName(string parentName) {
        this.parentName = parentName;
    }

    private void bulletMove() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * (int)(GameController.playerShootSpeed.ContainsKey(parentName) ? GameController.playerMoveSpeed[parentName] : 1));
    }

    private void bulletRotate() {
        transform.RotateAround(transform.position, transform.forward, rotateSpeed * Time.deltaTime);
    }
}
