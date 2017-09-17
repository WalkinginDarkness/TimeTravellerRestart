using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAddtionalMove : MonoBehaviour {

    public Vector3 addAddtionalMove;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other){
        Debug.Log("Object enter:" + other.name);
        if(other.tag==Tags.player1 || other.tag == Tags.player2){
            SimpleMove simpleMoveCom= other.GetComponent<SimpleMove>();
            other.GetComponent<SimpleMove>().addtionalMoveSpeed += this.addAddtionalMove;
        }
    }

    private void OnTriggerExit(Collider other){
        Debug.Log("Object exit:" + other.name);
        if (other.tag == Tags.player1 || other.tag == Tags.player2)
        {
            SimpleMove simpleMoveCom = other.GetComponent<SimpleMove>();
            other.GetComponent<SimpleMove>().addtionalMoveSpeed -= this.addAddtionalMove;
        }
    }
}
