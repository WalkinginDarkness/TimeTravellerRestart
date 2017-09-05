using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject playerExplosion;
    //public int scoreValue;
    //private GameController gameController;

    void Start()
    {
        /*
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();

            //gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        
    }
}
