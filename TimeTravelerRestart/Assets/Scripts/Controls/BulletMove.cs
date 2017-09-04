using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
	public float moveSpeed;
	public Vector3 direction;
	// Use this for initialization
	void Start () {
		//direction = new Vector3 (1, 0, 0);
		Destroy (gameObject, 15);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * moveSpeed * Time.deltaTime);
	}
}
