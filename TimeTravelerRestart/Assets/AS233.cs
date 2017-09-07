using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS233 : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(GameObject.Find("Player").transform.position);
        transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 0, 30);
    }
}
