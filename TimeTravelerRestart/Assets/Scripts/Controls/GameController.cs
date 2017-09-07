using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static Hashtable playerMoveSpeed = new Hashtable();
    public static Hashtable playerShootSpeed = new Hashtable();

    void Start () {
        initGameConditions();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void initGameConditions() {
        playerMoveSpeed.Add("1", 1);
        playerMoveSpeed.Add("2", 1);
        playerShootSpeed.Add("1", 1);
        playerShootSpeed.Add("2", 1);
        //Debug.Log(playerShootSpeed.Keys.Count);
        //Debug.Log(playerShootSpeed.ContainsKey("1"));
        //Debug.Log(GameController.playerShootSpeed.ContainsKey("1") ? GameController.playerMoveSpeed["1"] : 1);
    }
}
