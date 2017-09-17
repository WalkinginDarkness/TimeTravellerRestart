using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAddtionalMove : MonoBehaviour {

    public Vector3 addAddtionalMove;
    public float tileNum=1.0f;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().materials[0].mainTextureScale=new Vector2(1.0f,tileNum);
        this.addAddtionalMove = transform.rotation*addAddtionalMove;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other){
        if(other.tag==Tags.player1 || other.tag == Tags.player2){
            SimpleMove simpleMoveCom= other.GetComponent<SimpleMove>();
            other.GetComponent<SimpleMove>().addtionalMoveSpeed += this.addAddtionalMove;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.tag == Tags.player1 || other.tag == Tags.player2)
        {
            SimpleMove simpleMoveCom = other.GetComponent<SimpleMove>();
            other.GetComponent<SimpleMove>().addtionalMoveSpeed -= this.addAddtionalMove;
        }
    }
}
